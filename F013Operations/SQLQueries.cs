using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F013Operations
{
    class SQLQueries
    {
        public const string StoreHouseDownload = @" SELECT StoreHouseID, StoreHouseName, StoreHouseAddress FROM StoreHouse ";

        public const string StoreHouseProductsIDs = @" SELECT a.ProductID FROM Stock a
                                                       JOIN StoreHouse b ON a.StoreHouseID = b.StoreHouseID
                                                       WHERE a.StoreHouseID = @SelectedStoreHouseID AND a.StoredProductAmount >= @MinimumTransferAmount ";

        public const string ProductAmountStoredInSelectedStoreHouse =@" SELECT StoredProductAmount FROM Stock 
                                                                        WHERE StoreHouseID = @SelectedStoreHouseID AND StoredProductAmount >= {0} AND ProductID = @SelectedProductID ";

        public const string ChangeSelectedStoreHouseStock = @" UPDATE Stock
                                                               SET StoredProductAmount = StoredProductAmount {0} @AmountOfChange
                                                               WHERE StoreHouseID = @SelectedStoreHouseID AND ProductID = @SelectedProductID ";

        public const string StoreHouseDataListView = @" SELECT c.StoreHouseName, b.ProductName, a.StoredProductAmount, c.StoreHouseID, b.ProductID FROM Stock a
                                                        JOIN Product b ON b.ProductID = a.ProductID
                                                        JOIN StoreHouse c ON c.StoreHouseID = a.StoreHouseID
                                                        WHERE StoredProductAmount > 0
                                                        ORDER BY ";

        public const string NewStockCreation = @" INSERT INTO Stock (StoreHouseID, ProductID, StoredProductAmount)
                                                  VALUES (@StoreHouseID, @ProductID, @ProductAmount) ";
    }
}
