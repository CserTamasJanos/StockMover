namespace F013
{
    public class F013FormsTexts
    {
        public const string ListViewStockOfStoreHousesColumn1 = "Raktár neve";
        public const string ListViewStockOfStoreHousesColumn2 = "Termék neve";
        public const string ListViewStockOfStoreHousesColumn3 = "Raktározott mennyiség";

        public const string UnknownProduct = "Ismeretlen termék";

        public const string AreYouSureYouWantToSave = "Minden adat megfelelő?";
        public const string StockChangeAndStockCreationRegisteredSuccesfully = "A raktárkészlet változtatása és az új bejegyzése sikeresen megtörtént.";
        public const string StockChangeRegisteredSuccessfully = "A raktárkészletek változtatása sikeresen megtörtént.";
        public const string StockDataHasBeenChangedCheckItAgain = "A készletadatok időközben megváltoztak. Vizsgálja felül a korábbi beállításait.";
        public const string NoStoreHouseDataAvailable = "Nincs rendelkezésre álló adat.";
        public const string AllOfTheStoreHousesAreAvailableAreEmpty = "Az elérhető raktárak üresek, nincs mozgatható áru.";
        public const string OnlyOneStoreHouseIsAvailable = "Összesen egy raktár érhető el, így az átmozgatás más raktárba nem lehetséges.";

        public const string SetMinimumTransferAmount = "Állítsa be a minimálisan mozgatható mennyiséget.";
    }

    public class F013Data
    {
        public const int BasicColumnOrderNumber = 0;

        public const int StoreHouseAndProductIDArrayLength = 2;

        public const char SeparationCharachter = ' ';
        public const int ToolTipWidth = 40;

        public const int MinimumTransferAmount = 1;
    }
}