USE Northwind2	

select * from Categories
select * from [Suppliers]
select * from Customers

	INSERT INTO northwind2.dbo.Categories(CategoryName,
				Description,
				Picture)
		SELECT  CategoryName,
				Description,
				Picture
		FROM northwind.dbo.Categories

  go 

  INSERT INTO northwind2.dbo.Customers(CustomerId,Address,
				City,
				CompanyName,
				ContactName,
				ContactTitle,
				Country,
				Fax,
				Phone,
				PostalCode,
				Region)
		SELECT CustomerId,
				Address,
				City,
				CompanyName,
				ContactName,
				ContactTitle,
				Country,
				Fax,
				Phone,
				PostalCode,
				Region
		FROM northwind.dbo.Customers

go 

	insert into northwind2.[dbo].[CustomerDemographics](CustomerTypeID,
				CustomerDesc)
		
		select	CustomerTypeID,
				CustomerDesc
		from northwind.[dbo].[CustomerDemographics]

go

	 INSERT INTO northwind2.[dbo].[Suppliers](Address,
				City,
				CompanyName,
				ContactName,
				ContactTitle,
				Country,
				Fax,
				HomePage)
		SELECT Address,
				City,
				CompanyName,
				ContactName,
				ContactTitle,
				Country,
				Fax,
				HomePage
		FROM northwind.[dbo].[Suppliers]

go

	 INSERT INTO northwind2.[dbo].[Products](CategoryID,
				Discontinued,
				ProductName,
				QuantityPerUnit,
				ReorderLevel,
				SupplierID,
				UnitPrice,
				UnitsInStock,
				UnitsOnOrder)
		SELECT CategoryID,
				Discontinued,
				ProductName,
				QuantityPerUnit,
				ReorderLevel,
				SupplierID,
				UnitPrice,
				UnitsInStock,
				UnitsOnOrder
		FROM northwind.[dbo].[Products]

go
INSERT INTO Features
VALUES('No tengo idea','Feature 1')

INSERT INTO Features
VALUES('Porque no lo hizo compa�ero','Feature 2')

INSERT INTO Features
VALUES('hagale mamao','Feature 3')

INSERT INTO Features
VALUES('hagale tanque','Feature 4')

INSERT INTO Features
VALUES('hagale Raula','Feature 5')