DROP DATABASE IF EXISTS mealPlannerDb;
CREATE DATABASE mealPlannerDb;

DROP TABLE IF EXISTS mealPlannerDb.Meals;
CREATE TABLE mealPlannerDb.Meals(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(225),
tag VARCHAR(225),
PRIMARY KEY(id)

);

DROP TABLE IF EXISTS mealPlannerDb.Ingredients;
CREATE TABLE mealPlannerDb.Ingredients(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(225),
tag VARCHAR(225),
PRIMARY KEY(id)

);

DROP TABLE IF EXISTS mealPlannerDb.MealIngredients;
CREATE TABLE mealPlannerDb.MealIngredients(
MealId INT NOT NULL,
IngredientId INT NOT NULL,
Ammount FLOAT,
Format VARCHAR(225)
);


DELIMITER $
-- add ingredient
DROP PROCEDURE IF EXISTS mealPlannerDb.sp_CreateIngredient $
CREATE PROCEDURE mealPlannerDb.sp_CreateIngredient(name VARCHAR(225),tag VARCHAR(225))
BEGIN
	INSERT INTO mealPlannerDb.Ingredients(name, tag)
    VALUES(name, tag);
END $
-- get ingredients
DROP PROCEDURE IF EXISTS mealPlannerDb.sp_GetIngredients $
CREATE PROCEDURE mealPlannerDb.sp_GetIngredients()
BEGIN
	SELECT * FROM mealPlannerDb.Ingredients;
END $
-- add meal
DROP PROCEDURE IF EXISTS mealPlannerDb.sp_CreateMeal $
CREATE PROCEDURE mealPlannerDb.sp_CreateMeal(name VARCHAR(225),tag VARCHAR(225))
BEGIN
	INSERT INTO mealPlannerDb.Meals(name, tag)
    VALUES(name, tag);
    SELECT LAST_INSERT_ID(); 
END $
-- get meal
DROP PROCEDURE IF EXISTS mealPlannerDb.sp_GetMeals $
CREATE PROCEDURE mealPlannerDb.sp_GetMeals()
BEGIN
	SELECT * FROM mealPlannerDb.Meals;
END $
-- add ingredient to meal
DROP PROCEDURE IF EXISTS mealPlannerDb.sp_AddIngredientToMeal $
CREATE PROCEDURE mealPlannerDb.sp_AddIngredientToMeal(MealId INT,IngredientId INT,Ammount FLOAT,Format VARCHAR(225))
BEGIN
	INSERT INTO mealPlannerDb.MealIngredients(MealId,IngredientId,Ammount,Format)
    VALUES(MealId, IngredientId,Ammount,Format);
    
END $

-- get meal ingredients
DROP PROCEDURE IF EXISTS mealPlannerDb.sp_GetMealIngredients $
CREATE PROCEDURE mealPlannerDb.sp_GetMealIngredients()
BEGIN
	select Meals.Id,Meals.Name,Ingredients.Id, Ingredients.Name,MealIngredients.Ammount,MealIngredients.Format 
    from mealPlannerDb.Meals
    inner join mealPlannerDb.MealIngredients
    on mealPlannerDb.Meals.Id = mealPlannerDb.MealIngredients.MealId
    inner Join mealPlannerDb.Ingredients
    on mealPlannerDb.MealIngredients.IngredientId = mealPlannerDb.Ingredients.Id
    where mealPlannerDb.MealIngredients.MealId = MealId;
    
END $

DELIMITER ;
-- add test Ingredients
Call mealPlannerDb.sp_CreateIngredient('Meatballs','meat');
Call mealPlannerDb.sp_CreateIngredient('Spaghetti','pasta');
Call mealPlannerDb.sp_CreateIngredient('Onion','veg');
Call mealPlannerDb.sp_CreateIngredient('Carrot','veg');
Call mealPlannerDb.sp_CreateIngredient('Celery','veg');
Call mealPlannerDb.sp_CreateIngredient('Mushrooms','veg');
Call mealPlannerDb.sp_CreateIngredient('MeatballSauce','sauce');
Call mealPlannerDb.sp_CreateIngredient('Hallumi','cheese');
Call mealPlannerDb.sp_CreateIngredient('Korma Sauce','sauce');
Call mealPlannerDb.sp_CreateIngredient('Jasmin Rice','rice');
-- add test meals
CALL mealPlannerDb.sp_CreateMeal('spaghetti and meatballs','pasta');
SET @MEALID = last_insert_id();
SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'MeatBalls';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,12,'Item');

SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'Onion';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,1,'Item');

SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'Carrot';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,1,'Item');

SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'Celery';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,1,'Item');

SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'MeatballSauce';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,1,'Item');

SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'Spaghetti';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,200,'Gram');

CALL mealPlannerDb.sp_CreateMeal('Hallumi Curry','Indian');
SET @MEALID = last_insert_id();

SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'Hallumi';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,200,'Gram');

SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'Onion';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,1,'Item');

SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'Carrot';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,1,'Item');

SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'Celery';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,1,'Item');

SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'Korma Sauce';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,1,'Item');

SELECT Id INTO @INGREDIENTID from mealPlannerDb.Ingredients where name = 'Jasmin Rice';
CALL mealPlannerDb.sp_AddIngredientToMeal(@MEALID,@INGREDIENTID,1, 'Cup');

select * from mealPlannerDb.Ingredients;
select * from mealPlannerDb.Meals;
select * from mealPlannerDb.MealIngredients;






