using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Reflection.Metadata.BlobBuilder;

namespace RecipeApp_WPF
{
    /// <summary>
    /// Interaction logic for ViewRecipesWindow.xaml
    /// </summary>
    public partial class ViewRecipesWindow : Window
    {
        //Allows this class to access the variables from the RecipeFields class
        List<RecipeFields> recipes = new List<RecipeFields>();
        List<RecipeIngredients> ingredients = new List<RecipeIngredients>();
        List<StepDescriptions> stepDescriptions = new List<StepDescriptions>();

        string recipeDetails = "";

        public ViewRecipesWindow()
        {
            InitializeComponent();
        }

        //public ViewRecipes(List<Recipe> bookDetails) : this()
        //{
        //    // Initialize the book collection
        //    books = bookDetails;
        //   return BookDetailsTextBlock.Text = string.Join("\n\n", books.Select(b => b.ToString()));
        //}

        private void ShowAllRecipesBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        //The DisplayRecipe method does simply just what it's name states:
        //It displays the recipe with all its ingredients (each with their respective name, quantity and unit of measurement)
        //and all its steps along with their descriptions
        //but it does all of this in a beautiful and user-friendly way.
        private void SearchByRecipeNameBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchRecipeName = RecipeNameSearchTxtBox.Text;
            string recipeDescriptions = "";
            string recipeIngredients = "";
            foreach (RecipeFields Item in recipes)
            {
                if (Item.RecipeName.Equals(searchRecipeName))
                {
                    for (int i = 0; i < ingredients.Count; i++)
                    {
                        if (ingredients[i].RecipeName.Equals(searchRecipeName))
                        {
                            recipeIngredients += $"   ~ {ingredients[i].FoodGroup}: {ingredients[i].Quantity} {ingredients[i].UnitOfMeasurement} of {ingredients[i].Name} with a calorie count of {ingredients[i].CalorieCount}\n";
                        }
                    }

                    for (int i = 0; i < stepDescriptions.Count; i++)
                    {
                        if (stepDescriptions[i].RecipeName.Equals(searchRecipeName))
                        {
                            recipeDescriptions += $"Step {i+1}:\nstepDescriptions[i].Description";
                        }
                    }
                    
                    recipeDetails += $"   ~ Recipe Name: {Item.RecipeName}\n" + $"{recipeIngredients}\n" + $"{recipeDescriptions}\n";
                    RecipeDetailsTxtBlock.Text += recipeDetails;

                }
                else
                {
                    //Console.WriteLine("Could not found a recipe with the name you entered! Try again!");
                    MessageBox.Show("Could not foind a recipe with the name you entered! Try again!");
                    
                }
            }
        }
    }
}
