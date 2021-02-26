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
    public partial class F013 : Form
    {
        public F013()
        {
            InitializeComponent();
        }

        private int[] ClickedProductData { get; set; } //After double click on a row the storehouseID (ClickedProductData[0]) and productID (ClickedProductData[1]) are set.
        private int formerClickedColumn;
        private bool theLatestClickedOrderBy = false;
        private bool stockTransferWasclosed = false;
        private int clickedColumn;

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void ErrorMessagePopUp(string errorText)
        { 
            MessageBox.Show(errorText.Contains(Operations.ErrorTexts.AllProductDataDownloadErrorText) ? F013Operations.ErrorText.ProgramCanNotStart + errorText : errorText);
        }

        private void StockTransferFormOpen()
        {
            StockTransfer stockTransfer = new StockTransfer(ClickedProductData);

            if (stockTransfer.ShowDialog() == DialogResult.Cancel)
            {
                stockTransferWasclosed = true;
                StoreHousesStockDataDownload(clickedColumn);
            }
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            StockTransferFormOpen();
        }

        private void ListViewColumnclicked(object sender, ColumnClickEventArgs e)
        {            
            clickedColumn = e.Column;
            StoreHousesStockDataDownload(clickedColumn);
        }
        /// <summary>
        /// Downloads data fro ListView.
        /// </summary>
        /// <param name="clickedColumn"></param>
        private void StoreHousesStockDataDownload(int clickedColumn)
        {
            if(!stockTransferWasclosed)//Set the fromer sight of the Listview.
            {
                theLatestClickedOrderBy = formerClickedColumn == clickedColumn ? !theLatestClickedOrderBy : true;//Clicked coulumn is set orderby or descending, the first click on a "new" column is always orderby;
            }

            listViewStockOfStoreHouses.Items.Clear();

            List<ListViewItem> storeHouseData;

            SQLOperations.StoreHouseDataListViewDownload(clickedColumn,  theLatestClickedOrderBy, out storeHouseData);

            foreach (ListViewItem aListViewItem in storeHouseData)
            {
                listViewStockOfStoreHouses.Items.Add(aListViewItem);
            }

            formerClickedColumn = clickedColumn;
            listViewStockOfStoreHouses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            stockTransferWasclosed = false;
        }

        /// <summary>
        /// Check if Data or more than one storehouse is exists. 
        /// </summary>
        /// <returns></returns>
        private bool DataIsAvailableTransferIsPossible()
        {
            List<int> listForCheckData = new List<int>();
            bool transferIsPossible = true;

            if(SQLOperations.AllStoreHouse.Count >= 2)
            {
                foreach (StoreHouse aStoreHouse in SQLOperations.AllStoreHouse)
                {
                    SQLOperations.SelectedStoreHouseProductIDsDownload(aStoreHouse.StoreHouseID, F013Data.MinimumTransferAmount, out listForCheckData);

                    if (listForCheckData.Count > 0)
                    {
                        break;
                    }
                }

                if(listForCheckData.Count == 0)
                {
                    transferIsPossible = false;
                    MessageBox.Show(F013FormsTexts.AllOfTheStoreHousesAreAvailableAreEmpty);
                }
            }
            else
            {
                transferIsPossible = false;
                MessageBox.Show(SQLOperations.AllStoreHouse.Count <= 0 ? F013FormsTexts.NoStoreHouseDataAvailable : F013FormsTexts.OnlyOneStoreHouseIsAvailable);
            }
            return transferIsPossible;
        }

        private void F013_Load(object sender, EventArgs e)
        {
            SQLOperations.ErrorMessageEvent += ErrorMessagePopUp;
            Operations.SQLWay.ErrorHappenedevent += ErrorMessagePopUp;

            buttonTransfer.Enabled = false;
            listViewStockOfStoreHouses.FullRowSelect = true;

            if(Operations.SQLWay.AllProductDataDownload() && SQLOperations.StoreHouseDownload())
            {
                listViewStockOfStoreHouses.Columns.Add(F013FormsTexts.ListViewStockOfStoreHousesColumn1);
                listViewStockOfStoreHouses.Columns.Add(F013FormsTexts.ListViewStockOfStoreHousesColumn2);
                listViewStockOfStoreHouses.Columns.Add(F013FormsTexts.ListViewStockOfStoreHousesColumn3);

                if (DataIsAvailableTransferIsPossible())
                {
                    StoreHousesStockDataDownload(F013Data.BasicColumnOrderNumber);
                    buttonTransfer.Enabled = true;
                }
            }
            else
            {
                this.Close();
            }
        }
        /// <summary>
        /// Double Clicking on a record StockTransfer Form is open with parameters of the clicked record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewStockOfStoreHouses_DoubleClick(object sender, EventArgs e)
        {
            if(listViewStockOfStoreHouses.SelectedItems[0].Tag is int[])
            {
                ClickedProductData = (int[])listViewStockOfStoreHouses.SelectedItems[0].Tag;
            }
            StockTransferFormOpen();
        }
    }
}
