using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using F013Operations;
using Operations;

namespace F013
{
    public partial class StockTransfer : Form
    {
        private List<int> productIDs = new List<int>(); 

        private ToolTip selectedProduct = new ToolTip();
        private AllProducts allProducts;

        private int selectedProductAmountInSelectedWhereFromStoreHouseStock;
        private int selectedProductAmountInSelectedDestinationStoreHouseStock;

        private const int NumericUpDownDeliveryAmountBasicValue = 0;
        private const int NumericUpDownDeliveryAmountMinimumValue = 0;
        private const int NumericUpDownDeliveryAmountDecimalPlaces = 0;
        private const int NumericUpDownDeliveryAmountIncrement = 1;
        private const int NoDataIndicator = -1;

        private int[] gotClickedProductData;

        private StoreHouse SelectedStoreHouseWhereFrom
        {
            get { return (StoreHouse)comboBoxStoreHouseWhereFrom.SelectedItem; }
        }

        private StoreHouse SelectedStoreHouseDestination
        {
            get { return (StoreHouse)comboBoxStoreHouseDestination.SelectedItem; }
        }

        private Product SelectedProduct
        {
            get { return (Product)comboBoxSelectedStoreHouseProducts.SelectedItem; }
        }

        private int ActualStockChangeAmount
        {
            get { return Convert.ToInt32(numericUpDownDeliveryAmount.Value); }
        }

        public StockTransfer(int[] clickedProductData)
        {
            InitializeComponent();

            gotClickedProductData = clickedProductData;
        }

        /// <summary>
        /// Form the text a bit before tooltip going to be shown, and set the tooltip.
        /// </summary>
        private void ToolTipSelectedProductFormAndShow()
        {
            string textToAppear = SelectedProduct.ProductDescription;
            string actualTextLine = String.Empty;

            string[] separatedWords = textToAppear.Split(F013Data.SeparationCharachter);

            textToAppear = String.Empty;

            for(int i = 0; i < separatedWords.Length; i++)
            {
                actualTextLine = actualTextLine.Length == 0 ? separatedWords[i] : actualTextLine + F013Data.SeparationCharachter + separatedWords[i]; 

                if(actualTextLine.Length > F013Data.ToolTipWidth || i == separatedWords.Length -1)
                {
                    textToAppear = textToAppear + actualTextLine + Environment.NewLine;
                    actualTextLine = String.Empty;
                }
            }

            selectedProduct.ShowAlways = true;
            selectedProduct.SetToolTip(comboBoxSelectedStoreHouseProducts, textToAppear);
        }
        #region Conditioning transfer

        /// <summary>
        /// Three ComboboxLists are changed here:
        /// If the combobox where from the product are delivered is changed, or when the selected product amount is changed to zero.
        /// - The combobox where from is filled up with storehouses have minimum one product.
        /// - Remove the selected where from storehouse from combobox destination items.
        /// - Product comboBox is filled up with products have at least an amount of stock.
        /// 
        /// If comboBox where from is changed.
        /// - The combobox destinations is filled up, but the selected one in combobox where from (zero stock storehouses are allowed).
        /// - The combobox product is filled up (zero stock products are not allowed).
        /// - Product amount labels are set, if the destination storehouse have no ID of the product label change to unknown product.
        /// 
        /// If combobox destination is changed.
        /// - Destination label amount is set.
        /// 
        /// If combobox product is changed.
        /// - Both product amount labels are changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboboxSelectionChanged(object sender, EventArgs e)
        {
            if(sender == comboBoxStoreHouseWhereFrom)
            {
                Product lastSelectedProduct = (Product)comboBoxSelectedStoreHouseProducts.SelectedItem;
                StoreHouse lastSelectedDestinationStoreHouse = (StoreHouse)comboBoxStoreHouseDestination.SelectedItem;

                comboBoxStoreHouseDestination.Items.Clear();
                comboBoxSelectedStoreHouseProducts.Items.Clear();
                
                //The storehouse "where from" is removed from comboBox destination.               
                SelectableStoreHouseRefresh(comboBoxStoreHouseDestination);

                comboBoxStoreHouseDestination.Items.Remove(comboBoxStoreHouseWhereFrom.SelectedItem);

                comboBoxStoreHouseDestination.SelectedIndexChanged -= ComboboxSelectionChanged;

                if(comboBoxStoreHouseDestination.Items.Count > 0)
                {
                    comboBoxStoreHouseDestination.SelectedItem = lastSelectedDestinationStoreHouse != null && comboBoxStoreHouseWhereFrom.SelectedItem != lastSelectedDestinationStoreHouse ? lastSelectedDestinationStoreHouse : comboBoxStoreHouseDestination.Items[0];
                }

                comboBoxStoreHouseDestination.SelectedIndexChanged += ComboboxSelectionChanged;

                //Refill products can be delivered from "where from" storehouse, the selection is the former selection if it is in the new product list.
                //SQLOperations.SelectedStoreHouseProductsDownload(SelectedStoreHouseWhereFrom.StoreHouseID, out productsList);
                MoveableProductUpload();

                comboBoxSelectedStoreHouseProducts.SelectedIndexChanged -= ComboboxSelectionChanged;

                if(comboBoxSelectedStoreHouseProducts.Items.Count > 0)
                {
                    if (gotClickedProductData != null && gotClickedProductData.Length == F013Data.StoreHouseAndProductIDArrayLength)//Main form double click product is set here.
                    {
                        lastSelectedProduct = comboBoxSelectedStoreHouseProducts.Items.Cast<Product>().FirstOrDefault(x => x.ProductID == gotClickedProductData[1]);

                        if (lastSelectedProduct != null)
                        {
                            comboBoxSelectedStoreHouseProducts.SelectedItem = lastSelectedProduct;
                        }

                        gotClickedProductData = null;
                    }
                    else
                    {
                        comboBoxSelectedStoreHouseProducts.SelectedItem = comboBoxSelectedStoreHouseProducts.Items[0];
                    }
                }

                comboBoxSelectedStoreHouseProducts.SelectedIndexChanged += ComboboxSelectionChanged;

                ProductAmountRefresh(true);

            }
            if(sender == comboBoxStoreHouseDestination)
            {
                ProductAmountRefresh(false);
            }
            if(sender == comboBoxSelectedStoreHouseProducts)
            {
                ProductAmountRefresh(true);
            }

            ToolTipSelectedProductFormAndShow();
        }

        private void MoveableProductUpload()
        {
            Product storeHouseProduct = null;

            SQLOperations.SelectedStoreHouseProductIDsDownload(SelectedStoreHouseWhereFrom.StoreHouseID, F013Data.MinimumTransferAmount, out productIDs);

            foreach(int selectedProductID in productIDs)
            {
                storeHouseProduct = allProducts.allProducts.FirstOrDefault(x => x.ProductID == selectedProductID);

                if (storeHouseProduct != null)
                {
                    comboBoxSelectedStoreHouseProducts.Items.Add(storeHouseProduct);
                }
            }
        }

        /// <summary>
        /// Set the stock amount labels, according to the combobox changes.
        /// </summary>
        /// <param name="both"></param>
        private void ProductAmountRefresh(bool both)
        {
            SQLOperations.SelectedProductAmountStoredInSelectedStoreHouseDownload(SelectedStoreHouseDestination.StoreHouseID,
							SelectedProduct.ProductID, false, F013Data.MinimumTransferAmount, out selectedProductAmountInSelectedDestinationStoreHouseStock);
            labelAmountOfDestinationStock.Text = selectedProductAmountInSelectedDestinationStoreHouseStock.ToString();

            if (both)
            {
                SQLOperations.SelectedProductAmountStoredInSelectedStoreHouseDownload(SelectedStoreHouseWhereFrom.StoreHouseID,
							SelectedProduct.ProductID, true, F013Data.MinimumTransferAmount, out selectedProductAmountInSelectedWhereFromStoreHouseStock);
                labelAmountOfWhereFromStock.Text = selectedProductAmountInSelectedWhereFromStoreHouseStock.ToString();
            }

            numericUpDownDeliveryAmount.Maximum = selectedProductAmountInSelectedWhereFromStoreHouseStock;

            if(selectedProductAmountInSelectedDestinationStoreHouseStock == NoDataIndicator)
            {
                labelAmountOfDestinationStock.Text = F013FormsTexts.UnknownProduct;
            }
        }

        /// <summary>
        /// If the selected storehouse is the one from the delivery is going to be the selectable product list is refreshed.
        /// </summary>
        /// <param name="aCombobox"></param>
        private void SelectableStoreHouseRefresh(ComboBox aCombobox)
        {
            aCombobox.Items.Clear();

            if(aCombobox == comboBoxStoreHouseWhereFrom)
            {
                foreach (StoreHouse aStoreHouse in SQLOperations.AllStoreHouse)
                {
                    SQLOperations.SelectedStoreHouseProductIDsDownload(aStoreHouse.StoreHouseID, F013Data.MinimumTransferAmount, out productIDs);

                    if (productIDs.Count > 0)
                    {
                        aCombobox.Items.Add(aStoreHouse);
                    }
                }

                if(aCombobox.Items.Count > 0)
                {
                    if (gotClickedProductData != null && gotClickedProductData.Length == F013Data.StoreHouseAndProductIDArrayLength)//Main form double click StoreHouse is set here.
                    {
                        StoreHouse gotStoreHouse = SQLOperations.AllStoreHouse.FirstOrDefault(x => x.StoreHouseID == gotClickedProductData[0]);

                        if (gotStoreHouse != null)
                        {
                            aCombobox.SelectedItem = gotStoreHouse;
                        }
                    }
                    else
                    {
                        aCombobox.SelectedItem = aCombobox.Items[0];
                    }
                }
            }
            else
            {
                foreach(StoreHouse aStoreHouse in SQLOperations.AllStoreHouse)
                {
                    aCombobox.Items.Add(aStoreHouse);
                }
            }
        }
        #endregion

        #region Make transfer
        /// <summary>
        /// Make the transfer. Before update data, it compares the stock amounts. If it is the same than make the update.
        /// If the destination storehouse has no information create a new record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            if(numericUpDownDeliveryAmount.Value >= F013Data.MinimumTransferAmount)
            {
                DialogResult areYouSure = MessageBox.Show(F013FormsTexts.AreYouSureYouWantToSave, String.Empty, MessageBoxButtons.YesNo);

                int whereFromAmount = selectedProductAmountInSelectedWhereFromStoreHouseStock;

                if (areYouSure == DialogResult.Yes)
                {
                    int destinationAmount = selectedProductAmountInSelectedDestinationStoreHouseStock;

                    ProductAmountRefresh(true);

                    if (whereFromAmount == selectedProductAmountInSelectedWhereFromStoreHouseStock &&
                        destinationAmount == selectedProductAmountInSelectedDestinationStoreHouseStock)
                    {
                        if (SQLOperations.ChangeSelectedStoreHouseStock(SelectedStoreHouseWhereFrom.StoreHouseID,
                                            SelectedProduct.ProductID, ActualStockChangeAmount, false))
                        {
                            bool SaveTypeNewStockCreation = destinationAmount == NoDataIndicator;

                            if (SaveTypeNewStockCreation ? SQLOperations.NewStockCreation(SelectedStoreHouseDestination.StoreHouseID,
                            SelectedProduct.ProductID, ActualStockChangeAmount) :
                            SQLOperations.ChangeSelectedStoreHouseStock(SelectedStoreHouseDestination.StoreHouseID,
                            SelectedProduct.ProductID, ActualStockChangeAmount, true))
                            {
                                MessageBox.Show(SaveTypeNewStockCreation ? F013FormsTexts.StockChangeAndStockCreationRegisteredSuccesfully :
                                                                                       F013FormsTexts.StockChangeRegisteredSuccessfully);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(F013FormsTexts.StockDataHasBeenChangedCheckItAgain);
                    }

                    //If stock goes zero or the product amount is less than the minimumtrasnsferamount the where from Storehouse list is refreshed.
                    if (ActualStockChangeAmount == selectedProductAmountInSelectedWhereFromStoreHouseStock || whereFromAmount - ActualStockChangeAmount  < F013Data.MinimumTransferAmount)
                    {
                        SelectableStoreHouseRefresh(comboBoxStoreHouseWhereFrom);
                    }
                    ProductAmountRefresh(true);
                }
            }
            else
            {
                MessageBox.Show(F013FormsTexts.SetMinimumTransferAmount);
            }
        }
        #endregion

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StockTransfer_Load(object sender, EventArgs e)
        {
            allProducts = AllProducts.getInstance();

            //Fills up the comboBoxStoreHouseWhereFrom with storehouses can be chosen.
            //When comboBoxStoreHouseWhereFrom selected item is changed all of the comboBoxes items and the amount labels are refreshed
            SelectableStoreHouseRefresh(comboBoxStoreHouseWhereFrom);

            labelMinimumTransferAmountValue.Text = F013Data.MinimumTransferAmount.ToString();

            numericUpDownDeliveryAmount.Maximum = selectedProductAmountInSelectedWhereFromStoreHouseStock;
            numericUpDownDeliveryAmount.Minimum = NumericUpDownDeliveryAmountMinimumValue;
            numericUpDownDeliveryAmount.DecimalPlaces = NumericUpDownDeliveryAmountDecimalPlaces;
            numericUpDownDeliveryAmount.Value = NumericUpDownDeliveryAmountBasicValue;
            numericUpDownDeliveryAmount.Increment = NumericUpDownDeliveryAmountIncrement;
        }

        private void StockTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
