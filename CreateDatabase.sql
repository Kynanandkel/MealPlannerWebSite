/*CREATE DATABASE MealPlanner */
USE MealPlanner
/*CREATE TABLE Meals (
    ID int IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255)
);

CREATE TABLE Ingredients(
    ID int IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255),

)

CREATE TABLE MealIngredients(
    ID int IDENTITY(1,1) PRIMARY KEY,
    MealId int not NULL,
    IngredientId int not null,
    Amount int NOT NULL,
    FormatId INT Not NULL
) 
drop TABLE dbo.Format
CREATE TABLE Format(
    ID int IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255) not NULL
) 

INSERT into dbo.[Format](Name)
Values ('Item')
INSERT into dbo.[Format](Name)
Values ('TBspn')
INSERT into dbo.[Format](Name)
Values ('Tspn')
INSERT into dbo.[Format](Name)
Values ('grams')
INSERT into dbo.[Format](Name)
Values ('ml')


GO
Create PROCEDURE dbo.sp_CreateNewMeal(@Name VARCHAR(255))
AS
BEGIN
    
    Insert into dbo.Meals(Name)
    Values (@Name)

    RETURN SCOPE_IDENTITY()
END
GO

GO 
Create PROCEDURE dbo.sp_addIngredientToMeal(@mealId int, @ingredientId int, @amount int, @formatId int)
AS
BEGIN
    INSERT into dbo.MealIngredients(MealId,IngredientId,Amount,FormatId)
    VALUES (@mealId,@ingredientId,@amount,@formatId)
END

GO
Create PROCEDURE dbo.sp_GetMealIngredients(@mealId int)
AS
BEGIN
    select MealIngredients.IngredientId,Ingredients.Name as "Ingredient Name", MealIngredients.Amount,Format.Name as "format name"
    from MealIngredients 
    inner JOIN Ingredients on MealIngredients.IngredientId = Ingredients.ID 
    INNER JOIN Format on MealIngredients.FormatId = Format.ID 
    where MealIngredients.MealId = @mealId
END
GO



GO
Create PROCEDURE dbo.sp_CreateNewIngredient(@IngredientName VARCHAR(255) )
AS
BEGIN
    insert into dbo.Ingredients(Name)
    VALUES(@IngredientName)
END
GO

EXEC sp_CreateNewIngredient "Celery"
EXEC sp_CreateNewIngredient "Carrot"
EXEC sp_CreateNewIngredient "MeatBall"
EXEC sp_CreateNewIngredient "MinceBeef"
EXEC sp_CreateNewIngredient "Mushrooms"
EXEC sp_CreateNewIngredient "potatos"
EXEC sp_CreateNewIngredient "meatball sauce"
EXEC sp_CreateNewIngredient "Spaghetti"
*/
