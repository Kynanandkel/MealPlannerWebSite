package MealPlannerDatabase

import (
	"database/sql"
	"fmt"

	"github.com/go-sql-driver/mysql"
)

type Ingredient struct {
	Id   int    `json:"id"`
	Name string `json:name"`
	Type string `json:"type"`
}

type MealIngredient struct {
	MealId         int     `json:"mealId"`
	IngredientId   int     `json:"ingredientId"`
	IngredientName string  `json:"ingredientName"`
	Ammount        float64 `json:"ammount"`
	Type           string  `json:"type"`
}

type Meal struct {
	Id              int              `json:"id"`
	Name            string           `json:"name"`
	Type            string           `json:"type"`
	MealIngredients []MealIngredient `json:"mealIngredients"`
}

var db *sql.DB

func OpenDatabaseConnection() error {
	//capture connection properties
	cfg := mysql.Config{
		User:   "root",
		Passwd: "password",
		Net:    "tcp",
		Addr:   "127.0.0.1:3306",
		DBName: "mealPlannerDb",
	}

	var err error
	db, err = sql.Open("mysql", cfg.FormatDSN())
	if err != nil {
		return err
	}

	pingErr := db.Ping()
	if pingErr != nil {
		return pingErr
	}
	fmt.Println("Connected")
	return nil
}

func CreateNewIngredient(Name string, Tag string) error {

	if err := OpenDatabaseConnection(); err != nil {
		return err
	}

	var result string

	rows, err := db.Query("CALL sp_CreateIngredient(?,?)", Name, Tag)
	if err != nil {
		return nil
	}

	defer rows.Close()

	for rows.Next() {
		if err := rows.Scan(&result); err != nil {
			return err
		}
	}

	return nil
}

func GetAllIngredients() ([]Ingredient, error) {

	if err := OpenDatabaseConnection(); err != nil {
		return nil, err
	}

	var ingredients []Ingredient

	rows, err := db.Query("call sp_GetIngredients")
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	for rows.Next() {
		var ing Ingredient
		if err := rows.Scan(&ing.Id, &ing.Name, &ing.Type); err != nil {
			return nil, err
		}
		ingredients = append(ingredients, ing)
	}

	return ingredients, nil
}

func CreateNewMeal(Name string, tag string, Ingredients []MealIngredient) error {

	if err := OpenDatabaseConnection(); err != nil {
		return err
	}

	rows, err := db.Query("CALL sp_CreateMeal(?,?) ", Name, tag)
	if err != nil {
		return err
	}

	var MealId int
	for rows.Next() {
		if err := rows.Scan(&MealId); err != nil {
			return err
		}
	}

	rows.Close()

	for _, Ing := range Ingredients {

		rows, err = db.Query("CALL sp_AddIngredientToMeal(?, ?, ?, ?)", MealId, Ing.IngredientId, Ing.Ammount, Ing.Type)
		if err != nil {
			return err
		}
		var result string
		for rows.Next() {
			if err := rows.Scan(&result); err != nil {
				return err
			}
		}

	}
	rows.Close()

	return nil
}

func GetAllMeals() ([]Meal, error) {

	if err := OpenDatabaseConnection(); err != nil {
		return nil, err
	}

	rows, err := db.Query("CALL sp_GetMealIngredients")
	if err != nil {
		return nil, err
	}
	defer rows.Close()

	var oldMealId = 0
	var mealId int
	var mealName string
	var ingId int
	var ingName string
	var ammount float64
	var format string

	var meal Meal
	var meals []Meal
	for rows.Next() {

		if err := rows.Scan(&mealId, &mealName, &ingId, &ingName, &ammount, &format); err != nil {
			return nil, err
		}

		if oldMealId == 0 {

			meal = Meal{
				Id:   mealId,
				Name: mealName,
			}
			oldMealId = mealId

		} else if oldMealId != mealId {

			meals = append(meals, meal)
			meal = Meal{
				Id:   mealId,
				Name: mealName,
			}
			oldMealId = mealId
		}

		meal.MealIngredients = append(meal.MealIngredients, MealIngredient{
			MealId:         mealId,
			IngredientId:   ingId,
			IngredientName: ingName,
			Ammount:        ammount,
			Type:           format,
		})

	}

	meals = append(meals, meal)

	return meals, nil
}
