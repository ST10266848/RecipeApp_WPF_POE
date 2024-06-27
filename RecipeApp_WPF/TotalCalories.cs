using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecipeApp_WPF
{
    public class TotalCalories
    {
        //This method will be called after the total number of calories is calculated
        public static int CalorieWatcher(int Calorie)
        {
            //If the total amount of calories for a recipe exceeds 300 then a warning message will
            //be displayed to the user.
            if (Calorie > 300)
            {
                MessageBox.Show("WARNING! \nThis recipe exceeds 300 Calories! Calories keep your body fueled and functioning properly but consuming over 300 may result in you gaining extra weight....\n", "Over 300!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return Calorie;
        }
    }
}
