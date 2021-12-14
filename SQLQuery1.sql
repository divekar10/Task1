CREATE PROCEDURE spDisplayDetails
AS
BEGIN
	SELECT Products.ProductName, Categories.CatName, Products.Username FROM Products, Categories WHERE Products.CategoryId = Categories.Id 
END