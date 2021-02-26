using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Operations;

namespace F013Operations
{
    public class SQLOperations
    {
        public delegate void ErrorMessage(string ErrorText);
        public static event ErrorMessage ErrorMessageEvent;

        private static List<StoreHouse> allStoreHouses = new List<StoreHouse>();

        public static List<StoreHouse> AllStoreHouse
        {
            get { return allStoreHouses; }
        }

        /// <summary>
        /// /Choose the right error text and attach the program generated one.
        /// </summary>
        /// <param name="selectedEnum"></param>
        /// <param name="exceptionString"></param>
        /// <returns></returns>
        public static string ErrorMessageText(ErrorEnum selectedEnum, string exceptionString)
        {
            string errorText = String.Empty;

            switch(selectedEnum)
            {
                case ErrorEnum.StoreHouseDownloadError:
                    errorText = ErrorText.ProgramCanNotStart + ErrorText.StoreHouseDownloadErrorText;
                    break;
                case ErrorEnum.StoreHouseProductsIDsError:
                    errorText = ErrorText.StoreHouseProductsIDsErrorText;
                    break;
                case ErrorEnum.ProductAmountStoredInSelectedStoreHouseError:
                    errorText = ErrorText.ProductAmountStoredInSelectedStoreHouseErrorText;
                    break;
                case ErrorEnum.StoreHouseDataListViewDownloadError:
                    errorText = ErrorText.StoreHouseDataListViewDownloadErrorText;
                    break;
                case ErrorEnum.ChangeSelectedStoreHousesStockError:
                    errorText = ErrorText.ChangeSelectedStoreHousesStockErrorText;
                    break;
                case ErrorEnum.NewStockCreationError:
                    errorText = ErrorText.NewStockCreationErrorText;
                    break;
            }
            return errorText + Environment.NewLine + exceptionString;
        }

        #region Downloads
        /// <summary>
        /// Downloads the Storehouses.
        /// </summary>
        /// <returns></returns>
        public static bool StoreHouseDownload()
        {
            allStoreHouses.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(SQLQueries.StoreHouseDownload, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        allStoreHouses.Add(new StoreHouse(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString()));
                    }
                }               
            }
            catch(Exception e)
            {    
                if(ErrorMessageEvent != null)
                {
                    ErrorMessageEvent.Invoke(ErrorMessageText(ErrorEnum.StoreHouseDownloadError, e.Message));
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gives ID list can be moved to an other StoreHouse.
        /// </summary>
        /// <param name="selectedStoreHouseID"></param>
        /// <param name="aSelectedStoreHouseProductIDs"></param>
        /// <returns></returns>
        public static bool SelectedStoreHouseProductIDsDownload(int selectedStoreHouseID, int minimumTransferAmount, out List<int> aSelectedStoreHouseProductIDs)
        {
            aSelectedStoreHouseProductIDs = new List<int>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(SQLQueries.StoreHouseProductsIDs, connection);

                    command.Parameters.Add("@SelectedStoreHouseID", SqlDbType.Int);
                    command.Parameters[0].Value = selectedStoreHouseID;

                    command.Parameters.Add("@MinimumTransferAmount", SqlDbType.Int);
                    command.Parameters[1].Value = minimumTransferAmount;

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        aSelectedStoreHouseProductIDs.Add(Convert.ToInt32(reader[0]));
                    }
                }
            }
            catch(Exception e)
            {
                if(ErrorMessageEvent != null)
                {
                    ErrorMessageEvent.Invoke(ErrorMessageText(ErrorEnum.StoreHouseProductsIDsError,e.Message));
                }
                return false;
            }
            return true;
        }

		/// <summary>
		/// Download the amount of the selected product.
		/// </summary>
		/// <param name="selectedStoreHouseID"></param>
		/// <param name="selectedProductID"></param>
		/// <param name="itHasAmount"></param>The destination storehouse stock can be 0, the storehouse where from the delivery happens can not be 0.
		/// <param name="productAmount"></param> When reader can not read this amount is set to -1.
		/// <returns></returns>
        public static bool SelectedProductAmountStoredInSelectedStoreHouseDownload(int selectedStoreHouseID, int selectedProductID, bool itHasAmount, int minimumTransferAmount, out int productAmount)
        {
            productAmount = F013OperationData.ProductAmountBasicNumber;

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(String.Format(SQLQueries.ProductAmountStoredInSelectedStoreHouse, itHasAmount ? minimumTransferAmount : F013OperationData.StoredProductMinimumAmount), connection);

                    command.Parameters.Add("@SelectedStoreHouseID", SqlDbType.Int);
                    command.Parameters[0].Value = selectedStoreHouseID;

                    command.Parameters.Add("@SelectedProductID",SqlDbType.Int);
                    command.Parameters[1].Value = selectedProductID;

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    productAmount = reader.Read() ? Convert.ToInt32(reader[0]) : F013OperationData.ProductAmountReadingErrorNumber;
                }
            }
            catch(Exception e)
            {           
                if (ErrorMessageEvent != null)
                {
                    ErrorMessageEvent.Invoke(ErrorMessageText(ErrorEnum.ProductAmountStoredInSelectedStoreHouseError, e.Message));
                }
                return false;
            }
            return true;
        }

		/// <summary>
		/// Shows the stock of the storehouses depends on the order user would like to see.
		/// </summary>
		/// <param name="clickedColumn"></param>
		/// <param name="listViewData"></param>
		/// <returns></returns>
        public static bool StoreHouseDataListViewDownload(int clickedColumn, bool orderBy, out List<ListViewItem> listViewData)
        {
            listViewData = new List<ListViewItem>();

            var forOrderBy = new Dictionary<int, string>
            {
                {0, F013OperationData.OrderByStoreHouseName},
                {1, F013OperationData.OrderByProductName},
                {2, F013OperationData.OrderByProductAmount},
            };

            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(orderBy ? SQLQueries.StoreHouseDataListView + forOrderBy[clickedColumn] : SQLQueries.StoreHouseDataListView + forOrderBy[clickedColumn] + F013OperationData.ListViewColumnDescending,  connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    ListViewItem storeHouseData;

                    int[] productData = new int[2];

                    while (reader.Read())
                    {
                        productData = new int[2];
                         
                        storeHouseData = new ListViewItem(reader[0].ToString());
                        storeHouseData.SubItems.Add(reader[1].ToString());
                        storeHouseData.SubItems.Add(reader[2].ToString());

                        productData[0] = Convert.ToInt32(reader[3]);//StoreHouseID
                        productData[1] = Convert.ToInt32(reader[4]);//ProductID

                        storeHouseData.Tag = productData;

                        listViewData.Add(storeHouseData);
                    }
                }
            }
            catch(Exception e)
            {
                if(ErrorMessageEvent != null)
                {
                    ErrorMessageEvent.Invoke(ErrorMessageText(ErrorEnum.StoreHouseDataListViewDownloadError, e.Message));
                }
                return false;
            }
            return true;
        }
        #endregion

        #region Inserts and updates
        /// <summary>
        /// When product in both stors exists, transfer happens.
        /// </summary>
        /// <param name="selectedStoreHouseID"></param>
        /// <param name="selectedProductID"></param>
        /// <param name="amountOfChange"></param>
        /// <param name="stockIncrease"></param>
        /// <returns></returns>
        public static bool ChangeSelectedStoreHouseStock (int selectedStoreHouseID, int selectedProductID, int amountOfChange, bool stockIncrease)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(String.Format(SQLQueries.ChangeSelectedStoreHouseStock, stockIncrease ?
									F013OperationData.StockChangeIndicatorPlus : F013OperationData.StockChangeIndicatorMinus), connection);

                    command.Parameters.Add("@SelectedStoreHouseID", SqlDbType.Int);
                    command.Parameters[0].Value = selectedStoreHouseID;

                    command.Parameters.Add("@SelectedProductID", SqlDbType.Int);
                    command.Parameters[1].Value = selectedProductID;

                    command.Parameters.Add("@AmountOfChange", SqlDbType.Int);
                    command.Parameters[2].Value = amountOfChange;

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception a)
            {
                if (ErrorMessageEvent != null)
                {
                    ErrorMessageEvent.Invoke(ErrorMessageText(ErrorEnum.ChangeSelectedStoreHousesStockError, a.Message));
                }
                return false;
            }
            return true;
        }

		/// <summary>
		/// If product has not been delivered to the selected storehouse a new product insert is necessary.
		/// </summary>
		/// <param name="selectedStoreHouseID"></param>
		/// <param name="productID"></param>
		/// <param name="productAmount"></param>
		/// <returns></returns>
        public static bool NewStockCreation (int selectedStoreHouseID, int productID, int productAmount)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(QueryStrings.ServerConnection))
                {
                    SqlCommand command = new SqlCommand(SQLQueries.NewStockCreation,connection);

                    command.Parameters.Add("@StoreHouseID", SqlDbType.Int);
                    command.Parameters[0].Value = selectedStoreHouseID;

                    command.Parameters.Add("@ProductID", SqlDbType.Int);
                    command.Parameters[1].Value = productID;

                    command.Parameters.Add("@ProductAmount", SqlDbType.Int);
                    command.Parameters[2].Value = productAmount;

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                if(ErrorMessageEvent != null)
                {
                    ErrorMessageEvent.Invoke(ErrorMessageText(ErrorEnum.NewStockCreationError, e.Message));
                }
                return false;
            }
            return true;
        }
        #endregion
    }
}
