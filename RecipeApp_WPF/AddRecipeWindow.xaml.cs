using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecipeApp_WPF
{
    /// <summary>
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
        public delegate int TotalCalorieNumbers(int Calorie);

        //Allows this class to access the variables from the RecipeFields class
        List<RecipeFields> recipes = new List<RecipeFields>();
        List<RecipeIngredients> ingredients = new List<RecipeIngredients>();
        List<StepDescriptions> stepDescriptions = new List<StepDescriptions>();

        //Stores the name of the recipe that user wants to add
        public string recipeName;

        //stores the factor the user wants to scale the recipe by
        public double scaleFactor;

        //Stores the Calorie range of a recipe along with a relevant explanation
        //that is specific and based on the the total number of calories of the
        //recipe
        public string calorieRangeInfo = "";

        public double calorieCount;

        //Stores the total number of calories for a particular recipe
        public double totalCalories;

        //Stores the name of the food group for a particular ingredient
        public string foodGroup = "";

        //Used to check whether the value a user entered for ingredient quantity is indeed a number or not
        public bool isQuantityNum = false;

        //Used to check whether the value a user entered for number of calories is indeed a number or not
        public bool isCalorieCountNum = false;

        public int numberOfIngredients;

        public int numberOfSteps;

        public string ingredientName;

        public double quantity;

        public string unitOfMeasurement;

        public string description;

        public string recipeDescriptions = "";

        public AddRecipeWindow()
        {
            InitializeComponent();
        }

        //Code Attribution:
        //Author: Open AI
        //Source: Open AI's ChatgGPT 3.5 at
        //https://chatgpt.com/

        // Checks if the entered text is a valid numeric value (double).
        //If the try-parse fails to convert the user input into a double
        //because of the user entering a character instead of a number
        //e.Handled will be set to true and this will prevent the user
        //from entering said character.
        private void QuantityTxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            if (!double.TryParse(e.Text, out _))
            {
                e.Handled = true; // Prevents the character from being entered
                MessageBox.Show("A format error has occured! \nPlease correct this:\nEnter a number for Ingredient Quantity!\n", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void CalorieCountTxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check if the entered text is a valid numeric value (double)
            //If the try-parse fails to convert the user input into a double
            //because of the user entering a character instead of a number
            //e.Handled will be set to true and this will prevent the user
            //from entering said character.
            if (!double.TryParse(e.Text, out _))
            {
                e.Handled = true; // Prevents the character from being entered
                MessageBox.Show("A format error has occured! \nPlease correct this:\n Enter a number for Number of Calories!\n", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //If the the try-parse is successfully, and the user has entered a number
        }

        //The RadioButton representing the "Starchy Foods" food group,
        //is checked by default ensuring that when the user clicks "Save Ingredient" Button,
        //the foodGrup variable will never be null.
        //The user can still select another Radio Button if they wish
        public void StarchyFoodRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            foodGroup = "Starchy Foods";
        }

        private void VegAndFruitRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            foodGroup = "Vegetables and Fruits";
        }

        private void DairyRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            foodGroup = "Milk and dairy products";
        }

        private void WaterRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            foodGroup = "Water";
        }

        private void DryRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            foodGroup = "Dry beans, peas, lentils and soya";
        }

        private void ProteinRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            foodGroup = "Chicken, fish, meat and eggs";
        }

        private void FatsAndOilsRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            foodGroup = "Fats and Oil";
        }

        //When the user clicks on "Save Ingredient", this event will run:
        public void SaveIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (QuantityTxtBox.Text == "" || CalorieCountTxtBox.Text == "")
            {
                MessageBox.Show("Cannot have a null value for Ingredient Quantity or Number of Calories!\nPlease corrects this:\n Enter a number!\n", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else //The code within runs if both quantity and calorieCount are numbers
            {
                recipeName = RecipeNameTxtBox.Text;
                
                //If the the try-parse in the event QuantityTxtBox_PreviewTextInput is successfully,
                //and the user has entered a number
                //the number will then be taken from the txtbox and stored in a double variable
                quantity = double.Parse(QuantityTxtBox.Text);

                //The same thing could be said about the try-parse in PreviewTextInput event
                //of CalorieCountTxtBox
                calorieCount = double.Parse(CalorieCountTxtBox.Text);

                //Taking the text the user entered in the txtbox for ingredient name
                //and storing it in a variable
                ingredientName = IngredientNameTxtBox.Text;

                //Taking the text the user entered in the txtbox for measurement unit
                //and storing it in a variable
                unitOfMeasurement = MeasurementUnitTxtBox.Text;

                RecipeIngredients ingredient = new RecipeIngredients(recipeName, ingredientName, quantity, unitOfMeasurement, calorieCount, foodGroup, quantity);
                ingredients.Add(ingredient);
                MessageBox.Show("The indredient was added! (Feel free to add another)", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

                //DelegateName objectName = new DelegateName(class.method)
                TotalCalorieNumbers CalorieCounter = new TotalCalorieNumbers(TotalCalories.CalorieWatcher);
                //The total number of calories stored for a recipe
                totalCalories = CalorieCounter((int)totalCalories);
            }
        }

        //When the user clicks on "Save Ingredient", this event will run:
        private void SaveStepBtn_Click(object sender, RoutedEventArgs e)
        {
            description = StepDescriptionTxtBox.Text;
            StepDescriptions desc = new StepDescriptions(recipeName, description);
            stepDescriptions.Add(desc);
            MessageBox.Show("The step was added! (Feel free to add another)", "Added!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            RecipeFields recipe = new RecipeFields(recipeName, numberOfIngredients, ingredients, totalCalories, numberOfSteps, stepDescriptions);
            recipes.Add(recipe);
            MessageBox.Show($"{recipe.ToString()}"); //For testing putposes, to see if the recipe or ingredients or step descriptions actually get stored in the lists, it seems they may not sadly
            MessageBox.Show("The recipe was added fully successfully!\n Returning you to the menu...","Success!", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

    }
}
