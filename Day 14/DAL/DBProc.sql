CREATE OR ALTER PROCEDURE InsertProduct
    @ProductName     NVARCHAR(40),
    @SupplierID      INT = NULL,
    @CategoryID      INT = NULL,
    @QuantityPerUnit NVARCHAR(20) = NULL,
    @UnitPrice       MONEY = 0,
    @UnitsInStock    SMALLINT = 0,
    @UnitsOnOrder    SMALLINT = 0,
    @ReorderLevel    SMALLINT = 0,
    @Discontinued    BIT
AS
BEGIN
    
    INSERT INTO dbo.Products
    (
        ProductName,
        SupplierID,
        CategoryID,
        QuantityPerUnit,
        UnitPrice,
        UnitsInStock,
        UnitsOnOrder,
        ReorderLevel,
        Discontinued
    )
    VALUES 
    (
        @ProductName,
        @SupplierID,
        @CategoryID,
        @QuantityPerUnit,
        @UnitPrice,
        @UnitsInStock,
        @UnitsOnOrder,
        @ReorderLevel,
        @Discontinued
    );
    
END
GO

CREATE OR ALTER PROCEDURE UpdateProduct
    @ProductID       INT,
    @ProductName     NVARCHAR(40) = NULL,
    @SupplierID      INT = NULL,
    @CategoryID      INT = NULL,
    @QuantityPerUnit NVARCHAR(20) = NULL,
    @UnitPrice       MONEY = NULL,
    @UnitsInStock    SMALLINT = NULL,
    @UnitsOnOrder    SMALLINT = NULL,
    @ReorderLevel    SMALLINT = NULL,
    @Discontinued    BIT = NULL
AS
BEGIN
    
    UPDATE dbo.Products
    SET 
        ProductName     = COALESCE(@ProductName, ProductName),
        SupplierID      = COALESCE(@SupplierID, SupplierID),
        CategoryID      = COALESCE(@CategoryID, CategoryID),
        QuantityPerUnit = COALESCE(@QuantityPerUnit, QuantityPerUnit),
        UnitPrice       = COALESCE(@UnitPrice, UnitPrice),
        UnitsInStock    = COALESCE(@UnitsInStock, UnitsInStock),
        UnitsOnOrder    = COALESCE(@UnitsOnOrder, UnitsOnOrder),
        ReorderLevel    = COALESCE(@ReorderLevel, ReorderLevel),
        Discontinued    = COALESCE(@Discontinued, Discontinued)
    WHERE ProductID = @ProductID;
    
END
GO

CREATE OR ALTER PROCEDURE DeleteProduct
    @ProductID INT
AS
BEGIN
    
    DELETE FROM dbo.Products
    WHERE ProductID = @ProductID;
    
END
GO

CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT * FROM dbo.Products;
END
GO

CREATE OR ALTER PROCEDURE GetAllCategories
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT CategoryID,CategoryName FROM dbo.Categories;
END
GO

CREATE OR ALTER PROCEDURE GetAllSuppliers
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT SupplierID,CompanyName FROM dbo.Suppliers;
END
GO



