using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeApp_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipe = new AddRecipeWindow();
            this.Hide();
            addRecipe.ShowDialog();
            this.Show();
        }

        private void ViewRecipesBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipesWindow viewRecipes = new ViewRecipesWindow();
            this.Hide();
            viewRecipes.ShowDialog();
            this.Show();
        }

        private void ScaleRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipeWindow scaleRecipe = new ScaleRecipeWindow();
            this.Hide();
            scaleRecipe.ShowDialog();
            this.Show();
        }

        private void RevertRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            RevertRecipeWindow revertRecipe = new RevertRecipeWindow();
            this.Hide();
            revertRecipe.ShowDialog();
            this.Show();
        }

        private void ClearRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearRecipeWindow clearRecipe = new ClearRecipeWindow();
            this.Hide();
            clearRecipe.ShowDialog();
            this.Show();
        }

        private void ExitAppBtn_Click(object sender, RoutedEventArgs e)
        {
            ExitAppWindow exitApp = new ExitAppWindow();
            this.Hide();
            exitApp.ShowDialog();
            this.Show();
        }
    }
}