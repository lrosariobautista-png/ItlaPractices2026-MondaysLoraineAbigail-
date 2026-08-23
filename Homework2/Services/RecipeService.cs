using CookingRecipeLog.Data;
using CookingRecipeLog.Models;

namespace CookingRecipeLog.Services
{
    public class RecipeService
    {
        private readonly DataContext db;

        public RecipeService()
        {
            db = new DataContext();
        }

        public void ListRecipes()
        {
            var recipes = db.Recipes.ToList();

            if (recipes.Count == 0)
            {
                Console.WriteLine(
                    "There are no registered recipes.");

                return;
            }

            Console.WriteLine(
                "\n==========================================");

            Console.WriteLine(
                "ID\tName\t\tCategory\tType");

            Console.WriteLine(
                "==========================================");

            foreach (var recipe in recipes)
            {
                Console.WriteLine(
                    $"{recipe.Id}\t" +
                    $"{recipe.Name}\t\t" +
                    $"{recipe.Category}\t\t" +
                    $"{recipe.FoodType}");
            }
        }

        public void SearchById(int id)
        {
            var recipe = db.Recipes
                .FirstOrDefault(r => r.Id == id);

            if (recipe == null)
            {
                Console.WriteLine(
                    "Recipe doesn't exist.");

                return;
            }

            ShowRecipe(recipe);
        }

        public void SearchByName(string name)
        {
            var recipes = db.Recipes
                .Where(r => r.Name.Contains(name))
                .ToList();

            ShowResults(recipes);
        }

        public void SearchByType(string type)
        {
            var recipes = db.Recipes
                .Where(r => r.FoodType.Contains(type))
                .ToList();

            ShowResults(recipes);
        }

        public void AddRecipe(Recipe recipe)
        {
            if (string.IsNullOrWhiteSpace(recipe.Name))
            {
                Console.WriteLine(
                    "Recipe name is required.");

                return;
            }

            db.Recipes.Add(recipe);

            db.SaveChanges();

            Console.WriteLine(
                "Recipe added successfully.");
        }

        public void ModifyRecipe(
            int id,
            string name,
            string category,
            string ingredients,
            string type)
        {
            var recipe = db.Recipes
                .FirstOrDefault(r => r.Id == id);

            if (recipe == null)
            {
                Console.WriteLine(
                    "Recipe doesn't exist.");

                return;
            }

            recipe.Name = name;
            recipe.Category = category;
            recipe.Ingredients = ingredients;
            recipe.FoodType = type;

            db.SaveChanges();

            Console.WriteLine(
                "Recipe modified successfully.");
        }

        public void DeleteRecipe(int id)
        {
            var recipe = db.Recipes
                .FirstOrDefault(r => r.Id == id);

            if (recipe == null)
            {
                Console.WriteLine(
                    "Recipe doesn't exist.");

                return;
            }

            db.Recipes.Remove(recipe);

            db.SaveChanges();

            Console.WriteLine(
                "Recipe deleted successfully.");
        }

        private void ShowResults(
            List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine(
                    "No recipes found.");

                return;
            }

            foreach (var recipe in recipes)
            {
                ShowRecipe(recipe);
            }
        }

        private void ShowRecipe(Recipe recipe)
        {
            Console.WriteLine(
                "\n-------------------------");

            Console.WriteLine(
                $"ID: {recipe.Id}");

            Console.WriteLine(
                $"Name: {recipe.Name}");

            Console.WriteLine(
                $"Category: {recipe.Category}");

            Console.WriteLine(
                $"Ingredients: {recipe.Ingredients}");

            Console.WriteLine(
                $"Food Type: {recipe.FoodType}");

            Console.WriteLine(
                "-------------------------");
        }
    }
}