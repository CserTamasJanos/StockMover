using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operations
{
    public static class CSharpWay
    {
        /// <summary>
        /// Properties to real use of all downloaded datatables.
        /// </summary>
        public static List<Product> ProductList
        {
            get { return SQLWay.allProducts; }
        }

        public static List<Customer> CustomerList
        {
            get { return SQLWay.allCustomers; }
        }

        public static List<ProductCategory> ProductCategoryList
        {
            get { return SQLWay.allProductCategories; }
        }

        public static List<CustomerOrder> CustomerOrderList
        {
            get { return SQLWay.allCustomerOrders; }
        }

        public static List<OrderedProduct> OrderedProductList
        {
            get { return SQLWay.allOrderedProducts; }
        }

        /// <summary>
        /// Categories and pricelevels forAllOrderDataList.
        /// </summary>
        private const int LowPriceCategoryUpperLevel = 1000;
        private const int MiddlePriceCategoryUpperLevel = 2000;
        private const string LowPriceCategoryText = "Alacsony";
        private const string MiddlePriceCategoryText = "Közepes";
        private const string HighPriceCategoryText = "Magas";

        /// <summary>
        /// Orderstatus' for AllOrderAmountAccordingToModeAndStatusList.
        /// </summary>
        private const string OrderStatus0 = "Feldolgozás alatt";
        private const string OrderStatus1 = "Csomagolás alatt";
        private const string OrderStatus2 = "Központi elosztónál";
        private const string OrderStatus3 = "Regionális elosztónál";
        private const string OrderStatus4 = "Kiszállítás alatt";
        private const string OrderStatus5 = "Kiszállítva";

        /// <summary>
        /// Gendertypes for CountOfTheProductsAccordingToGenderList.
        /// </summary>
        private const string GenderNameMale = "Férfi";
        private const string GenderNameFemale = "Nő";

        /// <summary>
        /// ProductStatus AllProductsWithAllDataList.
        /// </summary>
        private const string ProductStatusActive = "Aktív";
        private const string ProductStatusInactive = "Inaktív";

        /// <summary>
        /// OrderModes for AllOrderAmountAccordingToModeAndStatusList.
        /// </summary>
        private const string OrderedModeOnline = "Online";
        private const string OrderdModePersonally = "Személyesen";

        /// <summary>
        /// Put order into a pricecategory.
        /// </summary>
        /// <param name="orderValue"></param>
        /// <returns></returns>
        private static string PriceCategory(int orderValue)
        {
            string returnString = String.Empty;

            if (orderValue < LowPriceCategoryUpperLevel)
            {
                returnString = LowPriceCategoryText;
            }
            else if (orderValue > LowPriceCategoryUpperLevel && orderValue < MiddlePriceCategoryUpperLevel)
            {
                returnString = MiddlePriceCategoryText;
            }
            else
            {
                returnString = HighPriceCategoryText;
            }
            return returnString;
        }

        public static List<ListViewItem> AllOrderDataList(bool checkedActive)
        {
            return (from a in OrderedProductList
                    join b in ProductList on a.ProductID equals b.ProductID
                    join c in ProductCategoryList on b.ProductCategoryID equals c.ProductCategoryID
                    join d in CustomerOrderList on a.CustomerOrderID equals d.CustomerOrderID
                    join e in CustomerList on d.CustomerID equals e.CustomerID
                    where !checkedActive || (a.OrderedAmount * a.UnitPrice) > OrderedProductList.Average(x => x.OrderedAmount * x.UnitPrice)
                    select (new AllOrderData(b.ProductName,
                                             c.ProductCategoryName,
                                             d.OrderDateTime,
                                             e.CustomerName.Substring(0, e.CustomerName.IndexOf(' ')),
                                             e.CustomerName.Substring(e.CustomerName.IndexOf(' '), e.CustomerName.Length - e.CustomerName.IndexOf(' ')),
                                             a.OrderedAmount,
                                             a.OrderedAmount * b.ProductListprice,
                                             PriceCategory(a.OrderedAmount * b.ProductListprice))).ListViewItemForTable).ToList();
        }

        public static List<ListViewItem> CountOfProductAccordingToProductCategoryList
        {
            get
            {
                return (from a in OrderedProductList
                        join b in ProductList on a.ProductID equals b.ProductID
                        join c in ProductCategoryList on b.ProductCategoryID equals c.ProductCategoryID
                        group new { a, c } by new { c.ProductCategoryID, c.ProductCategoryName } into grouppedAC
                        select (new ProductCategoryCount(grouppedAC.Key.ProductCategoryName,
                                                         grouppedAC.Sum(x => x.a.OrderedAmount))).ListViewItemForTable).ToList();
            }
        }

        public static List<ListViewItem> YearlyPersonAllOrderAmountList
        {
            get
            {
                return (from a in CustomerOrderList
                        join b in CustomerList on a.CustomerID equals b.CustomerID
                        join c in OrderedProductList on a.CustomerOrderID equals c.CustomerOrderID
                        group new { a, b, c } by new { a.OrderDateTime.Year, b.CustomerID, b.CustomerName } into grouppedABC
                        select (new YearlyPersonAllOrderAmount(grouppedABC.Key.CustomerName,
                                                               grouppedABC.Key.Year,
                                                               grouppedABC.Sum(x => x.c.UnitPrice * x.c.OrderedAmount))).ListViewItemForTable).ToList();
            }
        }

        public static List<ListViewItem> AllOrderAmountAccordingToModeAndStatusList
        {
            get
            {
                var AnOrdderStatusDictionary = new Dictionary<int, string>()
                {
                { 0, OrderStatus0 },
                { 1, OrderStatus1 },
                { 2, OrderStatus2 },
                { 3, OrderStatus3 },
                { 4, OrderStatus4 },
                { 5, OrderStatus5 },
                };

                return (from a in CustomerOrderList
                        join b in OrderedProductList on a.CustomerOrderID equals b.CustomerOrderID
                        group new { a, b } by new { a.OrderMode, a.OrderStatus } into grouppedAB
                        select (new ModeAndStatusAllOrderAmount(grouppedAB.Key.OrderMode == 1 ? OrderedModeOnline : OrderdModePersonally,
                                                                AnOrdderStatusDictionary[grouppedAB.Key.OrderStatus],
                                                                grouppedAB.Sum(x => x.b.OrderedAmount * x.b.UnitPrice))).ListViewItemForTable).ToList();
            }
        }

        public static List<ListViewItem> AllOrderAmountAccordingToDayList
        {
            get
            {
                return (from a in CustomerOrderList
                        join b in OrderedProductList on a.CustomerOrderID equals b.CustomerOrderID
                        group new { a, b } by new { a.OrderDateTime.Date } into grouppedAB
                        select (new OrderAmountDay(grouppedAB.Key.Date,
                                                   grouppedAB.Sum(x => x.b.OrderedAmount * x.b.UnitPrice))).ListViewItemForTable).ToList();
            }
        }

        public static List<ListViewItem> CountOfTheProductsAccordingToGenderList
        {
            get
            {
                return (from a in CustomerList
                        join b in CustomerOrderList on a.CustomerID equals b.CustomerID
                        join c in OrderedProductList on b.CustomerOrderID equals c.CustomerOrderID
                        group new { a, b, c } by new { a.CustomerGender } into grouppedABC
                        select (new GenderProductCount(grouppedABC.Key.CustomerGender == 1 ? GenderNameMale : GenderNameFemale,
                                                       grouppedABC.Sum(x => x.c.OrderedAmount))).ListViewItemForTable).ToList();
            }
        }

        public static List<ListViewItem> ProductsWarrantyExpriredList
        {
            get
            {
                return (from a in ProductList
                        join b in OrderedProductList on a.ProductID equals b.ProductID
                        join c in CustomerOrderList on b.CustomerOrderID equals c.CustomerOrderID
                        join d in CustomerList on c.CustomerID equals d.CustomerID
                        where c.OrderDateTime.AddMonths(a.WarrantyPeriod) < DateTime.Now
                        select (new OrderedProductForWarranty(d.CustomerName,
                                                              a.ProductName,
                                                              b.OrderedAmount,
                                                              b.UnitPrice,
                                                              b.CustomerOrderID)).ListViewItemForTable).ToList();
            }
        }

        public static List<ListViewItem> ProductsOrderedMoreThanGivenNumberList(int InputNumberToCompare)
        {
            return (from a in ProductList
                    join b in OrderedProductList on a.ProductID equals b.ProductID
                    group new { a, b } by new { a.ProductID, a.ProductName } into grouppedAB
                    where grouppedAB.Sum(x => x.b.OrderedAmount) > InputNumberToCompare
                    select (new ProductCategoryCount(grouppedAB.Key.ProductName,
                                                     grouppedAB.Sum(x => x.b.OrderedAmount))).ListViewItemForTable).ToList();
        }

        public static List<ListViewItem> ProductsAreNotOrderedList
        {
            get
            {
                return (from a in ProductList
                        where !(from b in OrderedProductList
                                select b.ProductID).Contains(a.ProductID)
                        select (new ProductsAreNotOrdered(a.ProductName).ListViewItemForTable)).ToList();
            }
        }

        public static List<ListViewItem> AllProductsWithAllDataList(bool checkBoxActive)
        {
            return (from a in ProductList
                    join b in ProductCategoryList on a.ProductCategoryID equals b.ProductCategoryID
                    where !checkBoxActive || a.ProductStatus == 1
                    select (new ProductForAllProductWithAllData(a.ProductName,
                            a.ProductListprice,
                            a.WarrantyPeriod,
                            b.ProductCategoryName,
                            a.ProductDescription,
                            a.ProductStatus == 1 ? ProductStatusActive : ProductStatusInactive,
                            a.ProductID)).ListViewItemForTable).ToList();
        }
    }
}
