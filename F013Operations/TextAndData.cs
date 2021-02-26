using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F013Operations
{
    public class ErrorText
    {
        public const string ProgramCanNotStart = "A program működése a következő hiba miatt leállt: ";
        public const string StoreHouseDownloadErrorText = "A raktáradatok letöltése közben hiba történt.";
        public const string StoreHouseProductsIDsErrorText = "A kiválasztott raktárhoz tartozó termékazonosítók letöltése közben hiba történt.";
        public const string ProductAmountStoredInSelectedStoreHouseErrorText = "A kiválasztott termékhez tartozó mennyiség letöltése közben hiba történt.";
        public const string StoreHouseDataListViewDownloadErrorText = "A megjelenítéshez szükséges raktáradatok letöltése közben hiba történt.";
        public const string ChangeSelectedStoreHousesStockErrorText = "A raktáradatok frissítése közben hiba történt.";
        public const string NewStockCreationErrorText = "Az új raktáradat létrehozása közben hiba történt.";
    }

    public class F013OperationData
    {
        public const string OrderByStoreHouseName = " c.StoreHouseName ";
        public const string OrderByProductName = " b.ProductName ";
        public const string OrderByProductAmount = " a.StoredProductAmount ";

        public const string ListViewColumnDescending = "DESC";

        public const string StockChangeIndicatorPlus = "+";
        public const string StockChangeIndicatorMinus = "-";

        public const int ProductAmountBasicNumber = -2;
        public const int ProductAmountReadingErrorNumber = -1;
        public const int StoredProductMinimumAmount = 0;
    }
}
