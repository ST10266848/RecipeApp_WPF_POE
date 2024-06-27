using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecipeApp_WPF
{
    class RecipeFields
    {
        //This class contains all of the program's properties

        //Stores name of Recipe that the user enters
        public string RecipeName { get; set; } = null!;

        //stores number of ingredients that the user enters
        public int NumberOfIngredients { get; set; }

        //Stores the list of ingredients and their respective fields for each Recipe
        public List<RecipeIngredients> Ingredient = new List<RecipeIngredients>();

        //Store the total number of calories of a recipe
        public double TotalCalories { get; set; }

        //stores the number of steps for the recipe that the user enters
        public int NumberOfSteps { get; set; }

        //Stores the description of each step in a recipe
        public List<StepDescriptions> StepDescription = new List<StepDescriptions>();

        public override string ToString()
        {
            return $"Recipe Name: {RecipeName}\nIngredient: {Ingredient}\nStep Description: \n{StepDescription}\n";
        }

        public RecipeFields(string recipeName, int numberOfIngredients, List<RecipeIngredients> ingredient, double totalCalories, int numberOfSteps, List<StepDescriptions> stepDescription)
        {
            this.RecipeName = recipeName;
            this.NumberOfIngredients = numberOfIngredients;
            this.Ingredient = ingredient;
            this.TotalCalories = totalCalories;
            this.NumberOfSteps = numberOfSteps;
            this.StepDescription = stepDescription;
        }
    }
}
