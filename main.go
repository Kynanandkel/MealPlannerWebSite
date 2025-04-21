package main

import (
	"encoding/json"
	"fmt"
	"net/http"

	"github.com/Kynanandkel/MealPlannerWebSite/MealPlannerDatabase"
)

func main() {

	http.HandleFunc("/CreateIngredient", CreateIngredientHandler)
	http.HandleFunc("/CreateIngredient/", CreateIngredientHandler)
	http.HandleFunc("/GetAllIngredients", GetAllIngredientsHandler)
	http.HandleFunc("/GetAllIngredients/", GetAllIngredientsHandler)
	http.HandleFunc("/CreateMeal", CreateMealHandler)
	http.HandleFunc("/CreateMeal/", CreateMealHandler)
	http.HandleFunc("/GetAllMeals", GetAllMealsHandler)
	http.HandleFunc("/GetAllMeals/", GetAllMealsHandler)

	fmt.Println("starting the api on localhost:8080")

	http.ListenAndServe(":8080", nil)
}

func enableCors(w *http.ResponseWriter) {
	(*w).Header().Set("Access-Control-Allow-Origin", "*")
}

// {"id":-,"name":"--","mealIngredients":[{"mealId":-,"ingredientId":-,"ingredientName":"--","ammount":-,"type":"--"}
// {"id":69,"name":"test meal","mealIngredients":[{"mealId":69,"ingredientId":69,"ingredientName":"test","ammount":1,"type":"test type"}
// {\"id\":69,\"Name\":\"test\",\"type\":\"testticle\"}
func CreateIngredientHandler(w http.ResponseWriter, r *http.Request) {
	enableCors(&w)
	var Ingredient MealPlannerDatabase.Ingredient
	err := json.NewDecoder(r.Body).Decode(&Ingredient)
	if err != nil {
		fmt.Println(err.Error())
		return
	}

	MealPlannerDatabase.CreateNewIngredient(Ingredient.Name, Ingredient.Type)
}

func GetAllIngredientsHandler(w http.ResponseWriter, r *http.Request) {
	enableCors(&w)
	ingredients, err := MealPlannerDatabase.GetAllIngredients()
	if err != nil {
		w.Write([]byte(err.Error()))
		return
	}
	jsonIngredients, err := json.Marshal(ingredients)
	if err != nil {
		w.Write([]byte(err.Error()))
		return
	}
	w.Write(jsonIngredients)

}

// {"id":-,"name":"--","mealIngredients":[{"mealId":-,"ingredientId":-,"ingredientName":"--","ammount":-,"type":"--"}
// {\"id\":69,\"name\":\"test meal\",\"type\":\"test type\",\"mealIngredients\":[{\"mealId\":69,\"ingredientId\":69,\"ingredientName\":\"test\",\"ammount\":1,\"type\":\"test type\"}]}
func CreateMealHandler(w http.ResponseWriter, r *http.Request) {
	enableCors(&w)
	var Meal MealPlannerDatabase.Meal
	err := json.NewDecoder(r.Body).Decode(&Meal)
	if err != nil {
		fmt.Println(err.Error())
		return
	}

	MealPlannerDatabase.CreateNewMeal(Meal.Name, Meal.Type, Meal.MealIngredients)
}

func GetAllMealsHandler(w http.ResponseWriter, r *http.Request) {
	enableCors(&w)
	meals, err := MealPlannerDatabase.GetAllMeals()
	if err != nil {
		w.Write([]byte(err.Error()))
	}
	jsonMeals, err := json.Marshal(meals)
	if err != nil {
		w.Write([]byte(err.Error()))
	}
	w.Write(jsonMeals)
}
