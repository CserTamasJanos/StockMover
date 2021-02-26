using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Operations;

namespace F013Operations
{
    public class StoreHouse
    {
        public int StoreHouseID { get; set; }
        public string StoreHouseName { get; set; }
        public string StoreHouseAddress { get; set; }

        public StoreHouse(int storeHouseID, string storeHouseName, string storeHouseAddress)
        {
            StoreHouseID = storeHouseID;
            StoreHouseName = storeHouseName;
            StoreHouseAddress = storeHouseAddress;
        }

        public override string ToString()
        {
            return StoreHouseName;
        }
    }

    public sealed class AllProducts
    {
        private static AllProducts instance = null;
        public List<Product> allProducts;

        private AllProducts()
        {
            Operations.SQLWay.AllProductDataDownload();

            allProducts = Operations.SQLWay.allProducts;
        }

        public static AllProducts getInstance()
        {
            if(instance == null)
            {
                instance = new AllProducts();
            }         
            return instance;
        }
    }
}
