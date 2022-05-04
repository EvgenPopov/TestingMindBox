CREATE TABLE [dbo].[Categories]
(Id int not null PRIMARY KEY,
CategoryName varchar(32) NULL)

GO

CREATE TABLE [dbo].[Products]
(Id int not null PRIMARY KEY,
CategoryName varchar(32) NULL)

GO

CREATE TABLE [dbo].[CategoriesProducts]
(CategoriesId int not null,
ProductsId int not null,
CONSTRAINT PK_CategoriesProducts PRIMARY KEY(CategoriesID, ProductsId),
CONSTRAINT FK_CategoriesProducts_CategoriesId FOREIGN KEY (CategoriesId)
REFERENCES [dbo].[Categories] (Id),
Constraint FK_CategoriestProducts_ProductsId FOREIGN KEY (ProductsId)
REFERENCES [dbo].[Products] (Id));

GO


INSERT INTO [dbo].[Categories] VALUES (1, 'CatName1'),(2, 'CatName2'),(3, 'CatName3'),(4, 'CatName4'),(5, 'CatName5'),
(6, 'CatName6'),(7, 'CatName7');
INSERT INTO [dbo].Products VALUES(1,'ProdName1'), (2,'ProdName2'), (3,'ProdName3'),(4,'ProdName4'),(5,'ProdName5'),(6,'ProdName6'),
(7,'ProdName7')

INSERt INTO [dbo].CategoriesProducts VALUES (1,1),(1,2),(1,3),(2,1),(3,1),(5,1),(5,7),(8,8)

GO

Select Products.ProductName 'Имя продукта', Categories.CategoryName 'Имя категории' 
FROM Products
LEFT OUTER JOIN dbo.CategoriesProducts as attachTable
ON AttachTable.ProductsId = Products.Id
Left OUTER JOIN Categories
ON Categories.id = AttachTable.CategoriesId 

