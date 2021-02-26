using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operations
{
    #region ClassesForListViewTables

    public class AllOrderData : ListViewItemInterface
    {
        public string ProductName { get; set; }
        public string ProductCategoryName { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int OrderedAmount { get; set; }
        public int OrderedValue { get; set; }
        public string OrderedValueCategory { get; set; }

        ListViewItem allOrderData;

        public AllOrderData(string productName, string productCategoryName, DateTime orderDateTime, string customerFirstName,
                            string customerLastName, int orderedAmount, int orderedValue, string orderedValueCategory)
        {
            ProductName = productName;
            ProductCategoryName = productCategoryName;
            OrderDateTime = orderDateTime;
            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            OrderedAmount = orderedAmount;
            OrderedValue = orderedValue;
            OrderedValueCategory = orderedValueCategory;

            allOrderData = new ListViewItem(ProductName);
            allOrderData.SubItems.Add(ProductCategoryName);
            allOrderData.SubItems.Add(OrderDateTime.ToString());
            allOrderData.SubItems.Add(CustomerFirstName);
            allOrderData.SubItems.Add(CustomerLastName);
            allOrderData.SubItems.Add(OrderedAmount.ToString());
            allOrderData.SubItems.Add(OrderedValue.ToString());
            allOrderData.SubItems.Add(OrderedValueCategory);
        }

        public ListViewItem ListViewItemForTable
        {
            get
            {
                return allOrderData;
            }
        }
    }

    public class ProductCategoryCount : ListViewItemInterface
    {
        public string ProductCategoryName { get; set; }
        public int OrderedProductCount { get; set; }

        ListViewItem aProductCategoryCount;

        public ProductCategoryCount(string productCategoryName, int orderedProductCount)
        {
            ProductCategoryName = productCategoryName;
            OrderedProductCount = orderedProductCount;

            aProductCategoryCount = new ListViewItem(ProductCategoryName);
            aProductCategoryCount.SubItems.Add(OrderedProductCount.ToString());
        }

        public ListViewItem ListViewItemForTable
        {
            get
            {
                return aProductCategoryCount;
            }
        }
    }

    public class YearlyPersonAllOrderAmount : ListViewItemInterface
    {
        public string CustomerName { get; set; }
        public int Year { get; set; }
        public int AllOrderAmount { get; set; }

        ListViewItem aYearlyPersonAllOrderAmount;

        public YearlyPersonAllOrderAmount(string customerName, int year, int allOrderAmount)
        {
            CustomerName = customerName;
            Year = year;
            AllOrderAmount = allOrderAmount;

            aYearlyPersonAllOrderAmount = new ListViewItem(CustomerName);
            aYearlyPersonAllOrderAmount.SubItems.Add(Year.ToString());
            aYearlyPersonAllOrderAmount.SubItems.Add(AllOrderAmount.ToString());
        }

        public ListViewItem ListViewItemForTable
        {
            get
            {
                return aYearlyPersonAllOrderAmount;
            }
        }
    }

    public class ModeAndStatusAllOrderAmount : ListViewItemInterface
    {
        public string OrderMode { get; set; }
        public string OrderStatus { get; set; }
        public int ModeNumberAllOrderedAmount { get; set; }

        ListViewItem aModeAndStatusAllOrderAmount;

        public ModeAndStatusAllOrderAmount(string orderedMode, string orderedStatus, int modeNumberAllOrderedAmount)
        {
            OrderMode = orderedMode;
            OrderStatus = orderedStatus;
            ModeNumberAllOrderedAmount = modeNumberAllOrderedAmount;

            aModeAndStatusAllOrderAmount = new ListViewItem(OrderMode);
            aModeAndStatusAllOrderAmount.SubItems.Add(OrderStatus);
            aModeAndStatusAllOrderAmount.SubItems.Add(ModeNumberAllOrderedAmount.ToString());
        }

        public ListViewItem ListViewItemForTable
        {
            get
            {
                return aModeAndStatusAllOrderAmount;
            }
        }
    }

    public class OrderAmountDay : ListViewItemInterface
    {
        private const string DateForm = "yyyy.MM.dd";

        public DateTime OrderDay { get; set; }
        public int DaylyOrderAmount { get; set; }

        ListViewItem anOrderAmountDay;

        public OrderAmountDay(DateTime orderDay, int daylyOrderAmount)
        {
            OrderDay = orderDay;
            DaylyOrderAmount = daylyOrderAmount;

            anOrderAmountDay = new ListViewItem(OrderDay.ToString(DateForm));
            anOrderAmountDay.SubItems.Add(DaylyOrderAmount.ToString());
        }

        public ListViewItem ListViewItemForTable
        {
            get
            {
                return anOrderAmountDay;
            }
        }
    }

    public class GenderProductCount : ListViewItemInterface
    {
        public string GenderName { get; set; }
        public int ProductCount { get; set; }

        ListViewItem aGenderProductCount;

        public GenderProductCount(string genderNamer, int productCount)
        {
            GenderName = genderNamer;
            ProductCount = productCount;

            aGenderProductCount = new ListViewItem(GenderName);
            aGenderProductCount.SubItems.Add(ProductCount.ToString());
        }

        public ListViewItem ListViewItemForTable
        {
            get
            {
                return aGenderProductCount;
            }
        }
    }

    public class OrderedProductForWarranty : ListViewItemInterface
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int OrderedAmount { get; set; }
        public int UnitPrice { get; set; }
        public int OrderedProductID { get; set; }

        ListViewItem anOrderProductForWarranty;

        public OrderedProductForWarranty(string customerName, string productName, int orderedAmount,
                                         int unitPrice, int orderedProductID)
        {
            OrderedProductID = orderedProductID;
            CustomerName = customerName;
            ProductName = productName;
            OrderedAmount = orderedAmount;
            UnitPrice = unitPrice;

            anOrderProductForWarranty = new ListViewItem(CustomerName);
            anOrderProductForWarranty.SubItems.Add(ProductName);
            anOrderProductForWarranty.SubItems.Add(OrderedAmount.ToString());
            anOrderProductForWarranty.SubItems.Add(UnitPrice.ToString());
            anOrderProductForWarranty.SubItems.Add(OrderedProductID.ToString());
        }

        public ListViewItem ListViewItemForTable
        {
            get
            {
                return anOrderProductForWarranty;
            }
        }
    }

    public class ProductsAreNotOrdered : ListViewItemInterface
    {
        public string ProductName { get; set; }

        ListViewItem aNotOrderedProductName;

        public ProductsAreNotOrdered(string productName)
        {
            ProductName = productName;

            aNotOrderedProductName = new ListViewItem(ProductName);
        }

        public ListViewItem ListViewItemForTable
        {
            get
            {
                return aNotOrderedProductName;
            }
        }
    }

    public class ProductForAllProductWithAllData : ListViewItemInterface
    {
        public string ProductName { get; set; }
        public int ProductListPrice { get; set; }
        public int WarrantyPeriod { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductStatus { get; set; }
        public int ProductID { get; set; }

        ListViewItem aProductForAllProductWithAllData;

        public ProductForAllProductWithAllData(string productName, int productListPrice, int warrantyPeriod,
                   string productCategoryName, string productDescription, string productSatatus, int productID)
        {
            ProductName = productName;
            ProductListPrice = productListPrice;
            WarrantyPeriod = warrantyPeriod;
            ProductCategoryName = productCategoryName;
            ProductDescription = productDescription;
            ProductStatus = productSatatus;
            ProductID = productID;

            aProductForAllProductWithAllData = new ListViewItem(ProductName);
            aProductForAllProductWithAllData.SubItems.Add(ProductListPrice.ToString());
            aProductForAllProductWithAllData.SubItems.Add(WarrantyPeriod.ToString());
            aProductForAllProductWithAllData.SubItems.Add(ProductCategoryName);
            aProductForAllProductWithAllData.SubItems.Add(ProductDescription);
            aProductForAllProductWithAllData.SubItems.Add(ProductStatus);
            aProductForAllProductWithAllData.SubItems.Add(ProductID.ToString());
        }

        public ListViewItem ListViewItemForTable
        {
            get
            {
                return aProductForAllProductWithAllData;
            }
        }
    }
    #endregion

    #region BasicClasses

    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string ProductCategoryName { get; set; }

        public ProductCategory(int productCategoryID, string productCategoryName)
        {
            ProductCategoryID = productCategoryID;
            ProductCategoryName = productCategoryName;
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductListprice { get; set; }
        public int WarrantyPeriod { get; set; }
        public int ProductCategoryID { get; set; }
        public int ProductStatus { get; set; }

        public Product(int productID, string productName, string productDescription, int productListPrice,
                       int warrantyPeriod, int productCategoryID, int productStatus)
        {
            ProductID = productID;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductListprice = productListPrice;
            WarrantyPeriod = warrantyPeriod;
            ProductCategoryID = productCategoryID;
            ProductStatus = productStatus;
        }

        public override string ToString()
        {
            return ProductName;
        }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLocation { get; set; }
        public string CustomerEmailAddress { get; set; }
        public int CustomerGender { get; set; }
        public DateTime CustomerBirthDate { get; set; }

        public Customer(int customerID, string customerName, string customerLocation, string customerEmailAddress,
                        int customerGender, DateTime customerBirthDate)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerLocation = customerLocation;
            CustomerEmailAddress = customerEmailAddress;
            CustomerGender = customerGender;
            CustomerBirthDate = customerBirthDate;
        }
    }

    public class CustomerOrder
    {
        public int CustomerOrderID { get; set; }
        public DateTime OrderDateTime { get; set; }
        public int CustomerID { get; set; }
        public int OrderMode { get; set; }
        public int OrderStatus { get; set; }

        public CustomerOrder(int customerOrderID, DateTime orderDateTime, int customerID, int orderMode, int orderStatus)
        {
            CustomerOrderID = customerOrderID;
            OrderDateTime = orderDateTime;
            CustomerID = customerID;
            OrderMode = orderMode;
            OrderStatus = orderStatus;
        }
    }

    public class OrderedProduct
    {
        public int OrderedProductID { get; set; }
        public int CustomerOrderID { get; set; }
        public int ProductID { get; set; }
        public int OrderedAmount { get; set; }
        public int UnitPrice { get; set; }

        public OrderedProduct(int orderedProductID, int customerOrderID, int productID, int orderedAmount, int unitPrice)
        {
            OrderedProductID = orderedProductID;
            CustomerOrderID = customerOrderID;
            ProductID = productID;
            OrderedAmount = orderedAmount;
            UnitPrice = unitPrice;
        }
    }

    public class ListviewColumnName
    {
        public int ColumnIdentifier { get; set; }
        public string ColumnName { get; set; }

        public ListviewColumnName(int columnIdentifier, string columnName)
        {
            ColumnIdentifier = columnIdentifier;
            ColumnName = columnName;
        }
    }
    #endregion
}
