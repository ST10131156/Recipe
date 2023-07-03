using Recipe.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Recipe
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
        Ingredient I = new Ingredient();


        private void button_Click(object sender, RoutedEventArgs e)
        {
            // get value from input field
           I.Name = txtName.Text;
            I.FoodGroup = txtFG.Text;
            I.ingridents = txtIngridients.Text;
            I.Calories = txtCalories.Text;
            
        }
    }
}
