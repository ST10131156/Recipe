using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Recipe.Classes
{
    public class Recipe : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private ObservableCollection<Ingredient> ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
                CalculateTotalCalories();
            }
        }

        private int totalCalories;
        public int TotalCalories
        {
            get { return totalCalories; }
            set
            {
                totalCalories = value;
                OnPropertyChanged(nameof(TotalCalories));
                CheckCaloriesExceedLimit();
            }
        }

        public Recipe()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            Ingredients.CollectionChanged += Ingredients_CollectionChanged;
        }

        private void Ingredients_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CalculateTotalCalories();
        }

        private void CalculateTotalCalories()
        {
            TotalCalories = Ingredients.Sum(ing => ing.Calories);
        }

        private void CheckCaloriesExceedLimit()
        {
            if (TotalCalories > 300)
            {
                // Notify the user
                MessageBox.Show("Total calories exceed 300!", "Calorie Limit Exceeded", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
