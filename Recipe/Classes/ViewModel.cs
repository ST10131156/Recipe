using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Classes
{
    public class RecipeViewModel : INotifyPropertyChanged
    {
        private RecipeRepository repository;
        private List<Recipe> filteredRecipes;

        public RecipeViewModel()
        {
            repository = new RecipeRepository();
            Recipes = repository.GetAllRecipes();
            FilteredRecipes = Recipes;
        }

        private List<Recipe> recipes;
        public List<Recipe> Recipes
        {
            get { return recipes; }
            set
            {
                recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public List<Recipe> FilteredRecipes
        {
            get { return filteredRecipes; }
            set
            {
                filteredRecipes = value;
                OnPropertyChanged(nameof(FilteredRecipes));
            }
        }

        private string ingredientFilter;
        public string IngredientFilter
        {
            get { return ingredientFilter; }
            set
            {
                ingredientFilter = value;
                ApplyFilters();
            }
        }

        private string foodGroupFilter;
        public string FoodGroupFilter
        {
            get { return foodGroupFilter; }
            set
            {
                foodGroupFilter = value;
                ApplyFilters();
            }
        }

        private int maxCaloriesFilter;
        public int MaxCaloriesFilter
        {
            get { return maxCaloriesFilter; }
            set
            {
                maxCaloriesFilter = value;
                ApplyFilters();
            }
        }

        private void ApplyFilters()
        {
            FilteredRecipes = repository.FilterRecipes(IngredientFilter, FoodGroupFilter, MaxCaloriesFilter);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
