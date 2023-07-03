using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Classes
{
    public class RecipeRepository
    {
        private ObservableCollection<Recipe> recipes;

        public RecipeRepository()
        {
            recipes = new ObservableCollection<Recipe>();
        }

        public ObservableCollection<Recipe> GetAllRecipes()
        {
            return recipes;
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void RemoveRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
        }

        internal List<Recipe> FilterRecipes(string ingredientFilter, string foodGroupFilter, int maxCaloriesFilter)
        {
            throw new NotImplementedException();
        }
    }
}
