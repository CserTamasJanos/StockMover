using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class QueryStrings
    {
        public const string ServerConnection = @" Data Source=DESKTOP-HHV34GN\SQLEXPRESS; Initial Catalog=FictiveCompany; Integrated Security=true";

        public const string AllOrderDataDownload = @" SELECT a.ProductName
	                                                   ,b.ProductCategoryName
	                                                   ,c.OrderDateTime
	                                                   ,SUBSTRING(d.CustomerName, 1,CHARINDEX(' ',d.CustomerName)) AS 'FirstName'
	                                                   ,SUBSTRING(d.CustomerName, CHARINDEX(' ',d.CustomerName), LEN(d.CustomerName) - CHARINDEX(' ',d.CustomerName) +1) AS 'LastName'
	                                                   ,e.OrderedAmount
	                                                   ,(e.OrderedAmount * a.ProductListPrice) AS 'Rendelés összértéke'
	                                                   ,CASE
	                                                   WHEN e.OrderedAmount*a.ProductListPrice <= 1000 THEN 'Alacsony'
	                                                   WHEN e.OrderedAmount*a.ProductListPrice > 1000 AND (e.OrderedAmount*a.ProductListPrice) < 2000 THEN 'Közepes'
	                                                   ELSE 'Magas'
	                                                   END AS 'Érték kategória'
	                                                   ,CASE
		                                               WHEN (SELECT AVG(OrderedAmount*UnitPrice) FROM OrderedProduct) < (e.OrderedAmount*e.UnitPrice) THEN 1
		                                               ELSE 0
		                                               END
										               FROM OrderedProduct e
                                                       JOIN Product a ON a.ProductID = e.ProductID
                                                       JOIN ProductCategory b ON b.ProductCategoryID = a.ProductCategoryID
                                                       JOIN CustomerOrder c ON c.CustomerOrderID = e.CustomerOrderID
                                                       JOIN Customer d ON d.CustomerID = c.CustomerID
											           WHERE {0} > (CASE
											           WHEN (SELECT AVG(OrderedAmount*UnitPrice) FROM OrderedProduct) < (e.OrderedAmount*e.UnitPrice) THEN 0
											           ELSE 1
											           END) ";

        public const string CountOfProductAccordingToProductCategoryDownload = @" SELECT c.ProductCategoryName, SUM(a.OrderedAmount) FROM OrderedProduct a
                                                                                  JOIN Product b ON b.ProductID = a.ProductID
                                                                                  JOIN ProductCategory c ON c.ProductCategoryID = b.ProductCategoryID
                                                                                  GROUP BY c.ProductCategoryID, c.ProductCategoryName ";

        public const string YearlyPersonAllOrderAmountDowload = @" SELECT b.CustomerName AS CustomerName, YEAR(a.OrderDateTime) AS OrderYear, SUM(c.UnitPrice*c.OrderedAmount) AS OrderedAmount	
	                                                               FROM CustomerOrder a
                                                                   JOIN Customer b ON b.CustomerID = a.CustomerID
	                                                               JOIN OrderedProduct c ON a.CustomerOrderID = c.CustomerOrderID
			                                                       GROUP BY b.CustomerID, YEAR(a.OrderDateTime), b.CustomerName ";

        public const string AllOrderAmountAccordingToModeAndStatusDownload = @" SELECT CASE
                                                                                WHEN a.OrderMode = 1 THEN 'Online'
                                                                                ELSE 'Személyes'
                                                                                END
                                                                                ,CASE 
                                                                                WHEN a.OrderStatus = 0 THEN 'Feldolgozás alatt'
                                                                                WHEN a.OrderStatus = 1 THEN 'Csomagolás alatt'
                                                                                WHEN a.OrderStatus = 2 THEN 'Központi elosztónál'
                                                                                WHEN a.OrderStatus = 3 THEN 'Regionális elosztónál'
                                                                                WHEN a.OrderStatus = 4 THEN 'Kiszállítás alatt'
                                                                                ELSE 'Kiszállítva'
                                                                                END
                                                                                ,SUM(b.OrderedAmount*b.UnitPrice)
                                                                                FROM CustomerOrder a
                                                                                JOIN OrderedProduct b ON b.CustomerOrderID = a.CustomerOrderID
                                                                                GROUP BY a.OrderMode, a.OrderStatus ";

        public const string AllOrerAmountAccordingToDayDownload = @" SELECT CONVERT(DATE, a.OrderDateTime), SUM(b.OrderedAmount*b.UnitPrice) FROM CustomerOrder a
                                                                    JOIN OrderedProduct b ON b.CustomerOrderID = a.CustomerOrderID
                                                                    GROUP BY CONVERT(DATE, a.OrderDateTime) ";

        public const string CountOfTheProductsAccordingToGenderDownload = @" SELECT CASE
                                                                          WHEN a.CustomerGender = 1 THEN 'Férfi'
                                                                          ELSE 'Nő'
                                                                          END
                                                                          ,SUM(c.OrderedAmount) FROM Customer a
                                                                          JOIN CustomerOrder b ON b.CustomerID = a.CustomerID
                                                                          JOIN OrderedProduct c ON c.CustomerOrderID = b.CustomerOrderID
                                                                          GROUP BY a.CustomerGender ";

        public const string ProductsWarrantyExpriredDownload = @" SELECT d.CustomerName, a.ProductName, b.OrderedAmount, b.UnitPrice, b.CustomerOrderID FROM Product a
                                                               JOIN OrderedProduct b ON b.ProductID = a.ProductID
                                                               JOIN CustomerOrder c ON c.CustomerOrderID = b.CustomerOrderID
                                                               JOIN Customer d ON d.CustomerID = c.CustomerID
                                                               WHERE DATEADD(MONTH, a.WarrantyPeriod,c.OrderDateTime)  < GETDATE() ";

        public const string ProductsOrderedMoreThanGivenNumberDowmnload = @" SELECT a.ProductName, SUM(b.OrderedAmount) FROM Product a
                                                                          JOIN OrderedProduct b ON b.ProductID = a.ProductID
                                                                          GROUP BY a. ProductID, a.ProductName
                                                                          HAVING SUM(b.OrderedAmount) > {0} ";

        public const string ProductsAreNotOrderedDownload = @" SELECT ProductName FROM Product
                                                               WHERE ProductID NOT IN (SELECT ProductID FROM OrderedProduct) ";

        public const string AllProductsWithAllDataDownload = @" SELECT a.ProductName, a.ProductListPrice, a.WarrantyPeriod, b.ProductCategoryName, a.ProductDescription,
                                                                CASE
                                                                WHEN a.ProductStatus = 1 THEN 'Aktív'
                                                                ELSE 'Inaktív'
                                                                END,
                                                                a.ProductID FROM Product a
                                                                JOIN ProductCategory b ON b.ProductCategoryID = a.ProductCategoryID
                                                                WHERE {0} > CASE
                                                                WHEN a.ProductStatus = 0 THEN 1
                                                                ELSE 0
                                                                END ";

        public const string AllProductCategoryDataDownload = @" SELECT ProductCategoryID, ProductCategoryName FROM ProductCategory ";

        public const string AllProductDataDownload = @" SELECT ProductID, ProductName, ProductDescription, ProductListPrice, WarrantyPeriod, ProductCategoryID,ProductStatus FROM Product ";

        public const string AllCustomerDataDownload = @" SELECT CustomerID, CustomerName, CustomerLocation, CustomerEmailAddress, CustomerGender, CustomerBirthDate FROM Customer ";

        public const string AllCustomerOrderDataDownload = @" SELECT CustomerOrderID, OrderDateTime, CustomerID, OrderMode, OrderStatus FROM CustomerOrder ";

        public const string AllOrderedProductDownload = @" SELECT OrderedProductID, CustomerOrderID, ProductID, OrderedAmount, UnitPrice FROM OrderedProduct ";
    }
}
