using System;
using System.Collections.Generic;
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

namespace RecipeApp_WPF
{
    /// <summary>
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
        //Allows this class to access the variables from the RecipeFields class
        List<RecipeFields> recipes = new List<RecipeFields>();
        List<RecipeIngredients> ingredients = new List<RecipeIngredients>();
        List<StepDescriptions> stepDescriptions = new List<StepDescriptions>();


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
        public bool isQuantityNumber = false;

        public bool isCalorieCountNumber = false;

        public int numberOfIngredients;

        public int numberOfSteps;

        public string ingredientName;

        public double quantity;

        public string unitOfMeasurement;

        public string recipeDescriptions = "";

        public AddRecipeWindow()
        {
            InitializeComponent();
        }


        public bool EnsureQuantityIsNumber()
        {
            //An error handling block of code which:
            // ensures that the user enters a number to represent
            //the quantity ingredient instead of a string or an invalid character
            try
            {
                quantity = double.Parse(QuantityTxtBox.Text);
                isQuantityNumber = true;
            }
            //The catch block will run when a format exception is caught as a result of
            //the user inputting an invalid string or character instead of a number
            catch (FormatException ex)
            {
                
                //QuantityTxtBox.Text = string.Empty;
                isQuantityNumber = false;
            }
            return isQuantityNumber;
        }

        public bool EnsureCalorieCountIsNumber()
        {
            try
            {
                calorieCount = double.Parse(CalorieCountTxtBox.Text);
                isCalorieCountNumber = true;
            }
            //The catch block will run when a format exception is caught as a result of
            //the user inputting an invalid string or character instead of a number
            catch (FormatException ex)
            {
                //MessageBox.Show("A format error has occured! \nPlease enter a number for ingredient calories!\n", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                //CalorieCountTxtBox.Text = string.Empty;
                isCalorieCountNumber = false;
            }

            return isCalorieCountNumber;
        }

        public void StarchyFoodRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            foodGroup = "Starchy Foods";
        }



        public void SaveIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            EnsureQuantityIsNumber();
            EnsureCalorieCountIsNumber();
            //MessageBox.Show("Hello" + foodGroup);

          
            //Runs if both quantity and calorieCount are not numbers
            if (isQuantityNumber == false)
            {
                MessageBox.Show("A format error has occured! \nPlease enter a number for ingredient quantity!\n", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (isCalorieCountNumber == false)
            {
                MessageBox.Show("A format error has occured! \nPlease enter a number for number of calories!\n", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (isQuantityNumber == false || isCalorieCountNumber == false)
            {
                if (isQuantityNumber && isCalorieCountNumber == false)
                {

                }
                MessageBox.Show("A format error has occured! \nPlease enter a number for ingredient quantity!\n", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else //runs if both quantity and calorieCount are numbers
            {
                //Taking the text the user entered in the txtbox for ingredient name
                //and storing it in a variable
                ingredientName = IngredientNameTxtBox.Text;

                //Taking the text the user entered in the txtbox for measurement unit
                //and storing it in a variable
                unitOfMeasurement = MeasurementUnitTxtBox.Text;
            }
 
        }

     
    }
}
