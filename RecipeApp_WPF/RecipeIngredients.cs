using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp_WPF
{
    class RecipeIngredients
    {
        public string RecipeName { get; set; } = null!;

        //stores name of an ingredient that the user enters
        public string Name { get; set; } = null!;

        //stores quantity of an ingredient that the user enters
        public double Quantity { get; set; }

        //stores the unit of measure of each ingredient quantity that the user enters
        public string UnitOfMeasurement { get; set; } = null!;

        //Stores the number of calories for an ingredient
        public double CalorieCount { get; set; }

        //Stores the food group that an ingredient belongs to
        public string FoodGroup { get; set; } = null!;

        //Stores the original quantity of an ingredient
        public double OgQuantity { get; set; }

        public RecipeIngredients(string recipeName, string name, double quantity, string unitOfMeasurement, double calorieCount, string foodGroup, double ogQuantity)
        {
            this.RecipeName = recipeName;
            this.Name = name;
            this.Quantity = quantity;
            this.UnitOfMeasurement = unitOfMeasurement;
            this.CalorieCount = calorieCount;
            this.FoodGroup = foodGroup;
            this.OgQuantity = ogQuantity;
        }
    }
}
