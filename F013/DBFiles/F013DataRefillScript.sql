USE FictiveCompany


--SELECT * FROM ProductCategory
--SELECT * FROM Product
--SELECT * FROM StoreHouse
--SELECT * FROM Stock
--SELECT * FROM Customer
--SELECT * FROM CustomerOrder
--SELECT * FROM OrderedProduct


DELETE FROM OrderedProduct
DELETE FROM CustomerOrder
DELETE FROM Customer
DELETE FROM Stock
DELETE FROM StoreHouse
DELETE FROM Product 
DELETE FROM ProductCategory


SET IDENTITY_INSERT ProductCategory ON

INSERT INTO ProductCategory(ProductCategoryID,ProductCategoryName)
VALUES(1,'Elektromos kiegészítõk')

INSERT INTO ProductCategory(ProductCategoryID,ProductCategoryName)
VALUES(2,'Kisgép alkatrészek')

INSERT INTO ProductCategory(ProductCategoryID,ProductCategoryName)
VALUES(3,'Irodaszerek')

INSERT INTO ProductCategory(ProductCategoryID,ProductCategoryName)
VALUES(4,'Játékok')

SET IDENTITY_INSERT ProductCategory OFF


SET IDENTITY_INSERT Product ON

INSERT INTO Product (ProductID,ProductName,ProductDescription,ProductListPrice,WarrantyPeriod,ProductCategoryID,ProductStatus)
VALUES (1, 'Egypólusú kapcsoló', 'Egy fogyasztó (pl.lámpatest) egy helyrõl történõ kapcsolására alkalmas. Elhelyezése: beltér, kivéve vizes, nedves helyiségek.', 550, 12, 1, 1)

INSERT INTO Product (ProductID,ProductName,ProductDescription,ProductListPrice,WarrantyPeriod,ProductCategoryID,ProductStatus)
VALUES (2,'Csiszoló korong', 'A lamellás csiszolótányér vászonból készült csiszolólamellái legyezõszerû, sugaras elrendezõdésének köszönhetõen a szokványos szerszámok csiszolási teljesítményének többszörösét éri el. A lamellás csiszolótányér egyenes kivitelû. Egyenletes csiszolat a szerszám teljes elhasználódásáig. Nagy leválasztási teljesítmény. Aluminium-oxid (korund) szemcséjû.', 200, 1, 2, 1)

INSERT INTO Product (ProductID,ProductName,ProductDescription,ProductListPrice,WarrantyPeriod,ProductCategoryID,ProductStatus)
VALUES (3,'Hosszabbító', 'Színe fehér, védõföldelés, vezeték típusa: H05VV-F 3G 1,0 mm2, vezeték hossza: 20 m, névleges feszültség: 250 V~, névleges áramerõsség: 10 A, névleges teljesítmény: 2300 W, aljzatok száma: 1 db, IP védelem: IP20.', 1900, 6, 1, 1)

INSERT INTO Product (ProductID,ProductName,ProductDescription,ProductListPrice,WarrantyPeriod,ProductCategoryID,ProductStatus)
VALUES (4,'Tûzõgép', 'Mûanyag testû, fémszerkezetû fûzõgép, tûzõ és fûzõ funkcióval - használható kapocsméret: No. 10. - fûzési mélység: 42 mm - egyszerre összefûzhetõ lapok száma: 10 lap.', 440, 12, 3, 1)

INSERT INTO Product (ProductID,ProductName,ProductDescription,ProductListPrice,WarrantyPeriod,ProductCategoryID,ProductStatus)
VALUES (5,'Fûnyírókés', 'Alkalmazott gép típus(ok): AL-KO COMFORT 420 E/B BIO-COMBI (112362), (112363), utángyártott (származási hely: Magyarország), Fûnyírókés hossza (mm): 400, Középsõ furat átmérõje (mm): 19,7, Szélsõ furatok átmérõje (mm): 8,2x12, Szélsõ furatok távolsága (mm): 65, Fûnyírókés szélessége (mm): 55.', 1490, 1,2, 1)

INSERT INTO Product (ProductID,ProductName,ProductDescription,ProductListPrice,WarrantyPeriod,ProductCategoryID,ProductStatus)
VALUES (6, 'Körzõ 1','Maped Körzõ készlet, rögzíthetõ lábakkal, 7 darabos.', 1500, 12, 3, 0)

INSERT INTO Product (ProductID,ProductName,ProductDescription,ProductListPrice,WarrantyPeriod,ProductCategoryID,ProductStatus)
VALUES (7, 'Slime labda','A Slime labda egy puha, nyálkás anyaggal töltött és hálóba csomagolt golyó, amit ha összenyomsz, ki fog türemkedni a háló résein.', 200, 1, 4, 0)

INSERT INTO Product (ProductID,ProductName,ProductDescription,ProductListPrice,WarrantyPeriod,ProductCategoryID,ProductStatus)
VALUES (8, 'Fürdõszobai csempekréta','A Fürdõszobai csempekréta 8 darabos készlet színes krétákat tartalmaz, amikkel a csempére, és a kád felületére tudsz rajzolni. A kréták élénk színûek, és vízzel nyom nélkül le lehet mosni a felületrõl.', 1800, 6, 4, 1)

INSERT INTO Product (ProductID,ProductName,ProductDescription,ProductListPrice,WarrantyPeriod,ProductCategoryID,ProductStatus)
VALUES (9, 'Körzõ 2','Rotring, kiváló minõségû iskolai körzõ. A szett körzõ hegyet is tartalmaz, Mûanyag tárolódobozban.', 2000, 12, 3, 0)

SET IDENTITY_INSERT Product OFF


SET IDENTITY_INSERT StoreHouse ON

INSERT INTO StoreHouse (StoreHouseID, StoreHouseName, StoreHouseAddress)
VALUES(1,'1 Raktár Európacenter', 'Budapest, 1044, Ezred utca 21')

INSERT INTO StoreHouse (StoreHouseID, StoreHouseName, StoreHouseAddress)
VALUES (2,'2 Raktár Csigakert','Debrecen, 4027, Böszörményi út 2')

INSERT INTO StoreHouse (StoreHouseID, StoreHouseName, StoreHouseAddress)
VALUES (3,'3 Raktár Vas','Szombathely, 9700, Semmelweis Ignác utca 53')

INSERT INTO StoreHouse (StoreHouseID, StoreHouseName, StoreHouseAddress)
VALUES (4,'4 Raktár Tolna','Szekszárd, 7100, Bogyiszlói út 5')

SET IDENTITY_INSERT StoreHouse OFF


SET IDENTITY_INSERT Stock ON

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (1,1,1,320)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (2,1,2,721)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (3,1,3,143)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (4,1,4,189)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (5,1,5,60)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (6,1,6,440)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (7,1,7,1200)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (8,1,8,355)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (9,1,9,400)


INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (10,2,1,43)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (11,2,2,25)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (12,2,3,11)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (13,2,4,5)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (14,2,6,14)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (15,2,7,30)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (16,2,8,1)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (17,2,9,0)


INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (18,3,1,9)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (19,3,2,21)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (20,3,3,10)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (21,3,4,0)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (22,3,5,8)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (23,3,6,29)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (24,3,7,0)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (25,3,8,15)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (26,3,9,10)


INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (27,4,1,12)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (28,4,2,5)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (29,4,3,89)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (30,4,5,0)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (31,4,6,40)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (32,4,7,0)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (33,4,8,0)

INSERT INTO Stock (StockCreationID, StoreHouseID, ProductID, StoredProductAmount)
VALUES (34,4,9,25)

SET IDENTITY_INSERT Stock OFF


SET IDENTITY_INSERT Customer ON

INSERT INTO Customer (CustomerID,CustomerName,CustomerLocation,CustomerEmailAddress,CustomerGender,CustomerBirthDate)
VALUES (1,'Szendrei Kálmán', 'Budapest, Nap utca 2,', 'kalman.szendrei@gmail.com',1,'1995-06-12')

INSERT INTO Customer (CustomerID,CustomerName,CustomerLocation,CustomerEmailAddress,CustomerGender,CustomerBirthDate)
VALUES (2,'Endrõdi Albert', 'Budapest, Felhévízi utca 9,', 'endrodi.albert@freemail.hu',1,'1977-11-01')

INSERT INTO Customer (CustomerID,CustomerName,CustomerLocation,CustomerEmailAddress,CustomerGender,CustomerBirthDate)
VALUES (3,'Horváth Ibolya', 'Balatonmáriafürdõ, Rákóczi utca 138,', 'ibolykaH@citromail.hu',2,'1999-03-03')

INSERT INTO Customer (CustomerID,CustomerName,CustomerLocation,CustomerEmailAddress,CustomerGender,CustomerBirthDate)
VALUES (4,'Szeles Károly', 'Székesfehérvár, Budai út 192 ,', 'szkaroly@gmail.com',1,'1962-05-22')

INSERT INTO Customer (CustomerID,CustomerName,CustomerLocation,CustomerEmailAddress,CustomerGender,CustomerBirthDate)
VALUES (5,'Kertes Endre', 'Hajdudorog, Tokaji út 31', 'EndreKertes2001@gmail.com',1,'2001-01-09')

INSERT INTO Customer (CustomerID,CustomerName,CustomerLocation,CustomerEmailAddress,CustomerGender,CustomerBirthDate)
VALUES (6,'Kertes Endre', 'Székesfehérvár, Pesti út 198', 'EndreKertes1979@gmail.com',1,'1979-06-17')

INSERT INTO Customer (CustomerID,CustomerName,CustomerLocation,CustomerEmailAddress,CustomerGender,CustomerBirthDate)
VALUES (7,'Kenderesi Sára', 'Marcali, Rózs utca 56,', 'sarikavilagra@gmail.com',2,'1988-08-11')

SET IDENTITY_INSERT Customer OFF


SET IDENTITY_INSERT CustomerOrder ON

INSERT INTO CustomerOrder (CustomerOrderID,OrderDateTime,CustomerID,OrderMode,OrderStatus)
VALUES (1,'2017-04-20 13:25:45', 1, 1, 5)

INSERT INTO CustomerOrder (CustomerOrderID,OrderDateTime,CustomerID,OrderMode,OrderStatus)
VALUES (2,'2018-04-22 09:30:01', 1, 2, 5)

INSERT INTO CustomerOrder (CustomerOrderID,OrderDateTime,CustomerID,OrderMode,OrderStatus)
VALUES (3,'2018-05-22 09:25:01', 2, 2, 5)

INSERT INTO CustomerOrder (CustomerOrderID,OrderDateTime,CustomerID,OrderMode,OrderStatus)
VALUES (4,'2019-06-30 11:10:10', 3, 1, 3)

INSERT INTO CustomerOrder (CustomerOrderID,OrderDateTime,CustomerID,OrderMode,OrderStatus)
VALUES (5,'2019-07-02 23:01:55', 4, 2, 2)

INSERT INTO CustomerOrder (CustomerOrderID,OrderDateTime,CustomerID,OrderMode,OrderStatus)
VALUES (6,'2019-07-03 10:44:12', 5, 1, 1)

INSERT INTO CustomerOrder (CustomerOrderID,OrderDateTime,CustomerID,OrderMode,OrderStatus)
VALUES (7,'2019-07-03 15:44:12', 2, 2, 1)

INSERT INTO CustomerOrder (CustomerOrderID,OrderDateTime,CustomerID,OrderMode,OrderStatus)
VALUES (8,'2019-07-26 10:10:10', 6, 2, 0)

SET IDENTITY_INSERT CustomerOrder OFF


SET IDENTITY_INSERT OrderedProduct ON

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (1,1,1,1,900)

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (2,2,3,1,2600)

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (3,3,2,3,300)

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (4,3,3,1,2600)

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (5,4,3,1,2600)

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (6,4,4,2,760)

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (7,4,5,1,3100)

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (8,5,1,4,900)

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (9,5,3,1,2600)

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (10,6,2,2,300)

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (11,7,3,1,2600)

INSERT INTO OrderedProduct (OrderedProductID,CustomerOrderID,ProductID,OrderedAmount,UnitPrice)
VALUES (12,8,8,1,2690)

SET IDENTITY_INSERT OrderedProduct OFF