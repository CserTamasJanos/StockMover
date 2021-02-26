using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Operations
{
    public static class SQLWay
    {
        /// <summary>
        /// Lists for all data downloads.
        /// </summary>
        public static List<Product> allProducts = new List<Product>();
        public static List<Customer> allCustomers = new List<Customer>();
        public static List<ProductCategory> allProductCategories = new List<ProductCategory>();
        public static List<CustomerOrder> allCustomerOrders = new List<CustomerOrder>();
        public static List<OrderedProduct> allOrderedProducts = new List<OrderedProduct>();

        /// <summary>
        /// Delegate to send erreormessage to User, invoked at F010 Load.
        /// </summary>
        /// <param name="errorText"></param>
        public delegate void Errorhappened(string errorText);
        public static event Errorhappened ErrorHappenedevent;

        /// <summary>
        /// This function presents the error message text for the MessageBox Invoked By the SQLErrors.
        /// </summary>
        /// <param name="anErrorText"></param>
        /// <param name="exceptionMessage"></param>
        /// <returns></returns>
        public static string ErrorMessageText(DataQueries anErrorText, string exceptionMessage)
        {
            string errorText = String.Empty;

            switch(anErrorText)
            {
                case DataQueries.AllOrderData:
                    errorText = Operations.ErrorTexts.AllOrderDataDownloadErrorText;
                    break;
                case DataQueries.CountOfProductAccordingToProductCategory:
                    errorText = Operations.ErrorTexts.CountOfProductAccordingToProductCategoryErrorText;
                    break;
                case DataQueries.YearlyPersonAllOrderAmount:
                    errorText = Operations.ErrorTexts.YearlyPersonAllOrderAmountDowloadErrorText;
                    break;
                case DataQueries.AllOrderAmountAccordingToModeAndStatus:
                    errorText = Operations.ErrorTexts.AllOrderAmountAccordingToModeAndStatusDownloadErrorText;
                    break;
                case DataQueries.AllOrdderAmountAccordingToDay:
                    errorText = Operations.ErrorTexts.AllOrerAmountAccordingToDayDownloadErrorText;
                    break;
                case DataQueries.CountOfTheProductsAccordingToGender:
                    errorText = Operations.ErrorTexts.CountOfTheProductsAccordingToGenderDownloadErrorText;
                    break;
                case DataQueries.ProductsWarrantyExpired:
                    errorText = Operations.ErrorTexts.ProductsWarrantyExpriredDownloadErrorText;
                    break;
                case DataQueries.ProductsOrderMoreThanGivenNumber:
                    errorText = Operations.ErrorTexts.ProductsOrderedMoreThanGivenNumberDowmnloadErrorText;
                    break;
                case DataQueries.ProductsAreNotOrdered:
                    errorText = Operations.ErrorTexts.ProductsAreNotOrderedDownloadErrorText;
                    break;
                case DataQueries.AllProductsWithAllData:
                    errorText = Operations.ErrorTexts.AllProductsWithAllDataDownloadErrorText;
                    break;
                case DataQueries.AllProductCategoryData:
                    errorText = Operations.ErrorTexts.AllProductCategoryDataDownloadErrorText;
                    break;
                case DataQueries.AllProductData:
                    errorText = Operations.ErrorTexts.AllProductDataDownloadErrorText;
                    break;
                case DataQueries.AllCustomerData:
                    errorText = Operations.ErrorTexts.AllCustomerDataDownloadErrorText;
                    break;
                case DataQueries.AllCustomerOrderData:
                    errorText = Operations.ErrorTexts.AllCustomerOrderDataDownloadErrorText;
                    break;
                case DataQueries.AllOrderedProduct:
                    errorText = Operations.ErrorTexts.AllOrderedProductDownloadErrorText;
                    break;
            }
            return errorText + Environment.NewLine + exceptionMessage;
        }

        /// <summary>
        /// Download data for Queries (F010).
        /// </summary>
        /// <returns></returns>
        #region QueryDownloads

        public static bool AllOrderDataDownload(bool checkBoxChecked, out List<ListViewItem> AllOrderDataListViewList)
        {
            AllOrderDataListViewList = new List<ListViewItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(string.Format(QueryStrings.AllOrderDataDownload, checkBoxChecked == true ? 1 : 2), connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        AllOrderData aNewAllOrderData = new AllOrderData(reader[0].ToString(), reader[1].ToString(), Convert.ToDateTime(reader[2]),
                                   reader[3].ToString(), reader[4].ToString(), Convert.ToInt32(reader[5]), Convert.ToInt32(reader[6]), reader[7].ToString());

                        AllOrderDataListViewList.Add(aNewAllOrderData.ListViewItemForTable);
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.AllOrderData, a.Message));
                return false;
            }
            return true;
        }

        public static bool CountOfProductAccordingToProductCategoryDownload(out List<ListViewItem> countOfProductAccordingToProductCategoryListViewItemList)
        {
            countOfProductAccordingToProductCategoryListViewItemList = new List<ListViewItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(Operations.QueryStrings.CountOfProductAccordingToProductCategoryDownload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductCategoryCount aNewProductCategoryCount = new ProductCategoryCount(reader[0].ToString(), Convert.ToInt32(reader[1]));

                        countOfProductAccordingToProductCategoryListViewItemList.Add(aNewProductCategoryCount.ListViewItemForTable);
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.CountOfProductAccordingToProductCategory, a.Message));
                return false;
            }
            return true;
        }

        public static bool YearlyPersonAllOrderAmountDowload(out List<ListViewItem> yearlyPersonAllOrderAmountListViewItemList)
        {
            yearlyPersonAllOrderAmountListViewItemList = new List<ListViewItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(Operations.QueryStrings.YearlyPersonAllOrderAmountDowload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        YearlyPersonAllOrderAmount aNewYearlyPersonAllOrderAmount = new YearlyPersonAllOrderAmount(reader[0].ToString(),
                            Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2]));

                        yearlyPersonAllOrderAmountListViewItemList.Add(aNewYearlyPersonAllOrderAmount.ListViewItemForTable);
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.YearlyPersonAllOrderAmount, a.Message));
                return false;
            }
            return true;
        }


        public static bool AllOrderAmountAccordingToModeAndStatusDownload(out List<ListViewItem> allOrderAmountAccordingToModeAndStatusListViewItemList)
        {
            allOrderAmountAccordingToModeAndStatusListViewItemList = new List<ListViewItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Operations.QueryStrings.AllOrderAmountAccordingToModeAndStatusDownload, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ModeAndStatusAllOrderAmount aNewModeAndstatusAllOrderAmount = new ModeAndStatusAllOrderAmount(reader[0].ToString(),
                            reader[1].ToString(), Convert.ToInt32(reader[2]));

                        allOrderAmountAccordingToModeAndStatusListViewItemList.Add(aNewModeAndstatusAllOrderAmount.ListViewItemForTable);
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.AllOrderAmountAccordingToModeAndStatus, a.Message));
                return false;
            }
            return true;
        }


        public static bool AllOrerAmountAccordingToDayDownload(out List<ListViewItem> allOrderAmountAccordingToDayListViewItemList)
        {
            allOrderAmountAccordingToDayListViewItemList = new List<ListViewItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(Operations.QueryStrings.AllOrerAmountAccordingToDayDownload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        OrderAmountDay aNewOrderAmountDay = new OrderAmountDay(Convert.ToDateTime(reader[0]), Convert.ToInt32(reader[1]));

                        allOrderAmountAccordingToDayListViewItemList.Add(aNewOrderAmountDay.ListViewItemForTable);
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.AllOrdderAmountAccordingToDay, a.Message));
                return false;
            }
            return true;
        }

        public static bool CountOfTheProductsAccordingToGenderDownload(out List<ListViewItem> countOfTheProductsAccordingToGenderListViewItemList)
        {
            countOfTheProductsAccordingToGenderListViewItemList = new List<ListViewItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(Operations.QueryStrings.CountOfTheProductsAccordingToGenderDownload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        GenderProductCount aNewGenderProductCount = new GenderProductCount(reader[0].ToString(), Convert.ToInt32(reader[1]));

                        countOfTheProductsAccordingToGenderListViewItemList.Add(aNewGenderProductCount.ListViewItemForTable);
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.CountOfTheProductsAccordingToGender, a.Message));
                return false;
            }
            return true;
        }

        public static bool ProductsWarrantyExpriredDownload(out List<ListViewItem> productWarrantyExpiredListViewItemList)
        {
            productWarrantyExpiredListViewItemList = new List<ListViewItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(Operations.QueryStrings.ProductsWarrantyExpriredDownload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        OrderedProductForWarranty aNewOrderdedProductForWarranty = new OrderedProductForWarranty(reader[0].ToString(), reader[1].ToString(),
                            Convert.ToInt32(reader[2]), Convert.ToInt32(reader[3]), Convert.ToInt32(reader[4]));

                        productWarrantyExpiredListViewItemList.Add(aNewOrderdedProductForWarranty.ListViewItemForTable);
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.ProductsWarrantyExpired, a.Message));
                return false;
            }
            return true;
        }

        public static bool ProductsOrderedMoreThanGivenNumberDowmnload(int referenceNumber, out List<ListViewItem> productsOrderedMoreThanGivenNumberListViewItemList)
        {
            productsOrderedMoreThanGivenNumberListViewItemList = new List<ListViewItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(string.Format(Operations.QueryStrings.ProductsOrderedMoreThanGivenNumberDowmnload, referenceNumber), connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductCategoryCount aNewProductCategoryCount = new ProductCategoryCount(reader[0].ToString(), Convert.ToInt32(reader[1]));

                        productsOrderedMoreThanGivenNumberListViewItemList.Add(aNewProductCategoryCount.ListViewItemForTable);
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.ProductsOrderMoreThanGivenNumber, a.Message));
                return false;
            }
            return true;
        }

        public static bool ProductsAreNotOrderedDownload(out List<ListViewItem> productsAreNotOrderedNameListViewItemList)
        {
            productsAreNotOrderedNameListViewItemList = new List<ListViewItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(Operations.QueryStrings.ProductsAreNotOrderedDownload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductsAreNotOrdered aNewNotOrderedProduct = new ProductsAreNotOrdered(reader[0].ToString());

                        productsAreNotOrderedNameListViewItemList.Add(aNewNotOrderedProduct.ListViewItemForTable);
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.ProductsAreNotOrdered, a.Message));
                return false;
            }
            return true;
        }

        public static bool AllProductsWithAllDataDownload(bool checkedActive, out List<ListViewItem> allProductsWithAllDataListViewItemList)
        {
            allProductsWithAllDataListViewItemList = new List<ListViewItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(String.Format(QueryStrings.AllProductsWithAllDataDownload, checkedActive == true ? 1 : 2), connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ProductForAllProductWithAllData aNewProductForAllProductWithAllData = new ProductForAllProductWithAllData(reader[0].ToString(), Convert.ToInt32(reader[1]),
                            Convert.ToInt32(reader[2]), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[6]));

                        allProductsWithAllDataListViewItemList.Add(aNewProductForAllProductWithAllData.ListViewItemForTable);
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.AllProductsWithAllData, a.Message));
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// Download data for C# way lists.
        /// </summary>
        /// <returns></returns>
        #region DownloadForCSharpWay

        public static bool AllProductCategoryDataDownload()
        {
            allProductCategories.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(Operations.QueryStrings.AllProductCategoryDataDownload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        allProductCategories.Add(new ProductCategory(Convert.ToInt32(reader[0]), reader[1].ToString()));
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.AllProductCategoryData, a.Message));
                return false;
            }
            return true;
        }

        public static bool AllProductDataDownload()
        {
            allProducts.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(Operations.QueryStrings.AllProductDataDownload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        allProducts.Add(new Product(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),
                            Convert.ToInt32(reader[3]), Convert.ToInt32(reader[4]), Convert.ToInt32(reader[5]), Convert.ToInt32(reader[6])));
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.AllProductData, a.Message));
                return false;
            }
            return true;
        }

        public static bool AllCustomerDataDownload()
        {
            allCustomers.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(Operations.QueryStrings.AllCustomerDataDownload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        allCustomers.Add(new Customer(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                            Convert.ToInt32(reader[4]), Convert.ToDateTime(reader[5])));
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.AllCustomerData, a.Message));
                return false;
            }
            return true;
        }

        public static bool AllCustomerOrderDataDownload()
        {
            allCustomerOrders.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(Operations.QueryStrings.AllCustomerOrderDataDownload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        allCustomerOrders.Add(new CustomerOrder(Convert.ToInt32(reader[0]), Convert.ToDateTime(reader[1]),
                            Convert.ToInt32(reader[2]), Convert.ToInt32(reader[3]), Convert.ToInt32(reader[4])));
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.AllCustomerOrderData, a.Message));
                return false;
            }
            return true;
        }

        public static bool AllOrderedProductDownload()
        {
            allOrderedProducts.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(Operations.QueryStrings.AllOrderedProductDownload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        allOrderedProducts.Add(new OrderedProduct(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]),
                            Convert.ToInt32(reader[2]), Convert.ToInt32(reader[3]), Convert.ToInt32(reader[4])));
                    }
                }
            }
            catch (Exception a)
            {
                if (ErrorHappenedevent != null)
                    ErrorHappenedevent.Invoke(ErrorMessageText(DataQueries.AllOrderedProduct, a.Message));
                return false;
            }
            return true;
        }
        #endregion
    }
}
