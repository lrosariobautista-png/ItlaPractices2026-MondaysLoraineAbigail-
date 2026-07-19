using System;
using System.Collections.Generic;
using System.Linq;


namespace CookingRecipeLog
{
    public class RecipeManager
    {
        private List<Recipe> recipes = new List<Recipe>();


        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            Console.WriteLine("Recipe added successfully.");
        }


        public void ListRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("There are no registered recipes.");
                return;
            }


            Console.WriteLine("\n=================================================");
            Console.WriteLine("ID\tName\tCategory\tType");
            Console.WriteLine("=================================================");


            foreach (var recipe in recipes)
            {
                Console.WriteLine(
                    $"{recipe.Id}\t{recipe.Name}\t{recipe.Category}\t{recipe.Type}");
            }
        }



        public void SearchById(int id)
        {
            Recipe recipe = recipes.FirstOrDefault(r => r.Id == id);


            if (recipe != null)
            {
                Console.WriteLine(recipe.GetInformation());
            }
            else
            {
                Console.WriteLine("Recipe doesn't exist.");
            }
        }



        public void SearchByName(string name)
        {
            var result = recipes
                .Where(r => r.Name.ToLower().Contains(name.ToLower()));


            foreach (var recipe in result)
            {
                Console.WriteLine(recipe.GetInformation());
            }
        }



        public void SearchByType(string type)
        {
            var result = recipes
                .Where(r => r.Type.ToLower().Contains(type.ToLower()));


            foreach (var recipe in result)
            {
                Console.WriteLine(recipe.GetInformation());
            }
        }



        public void ModifyRecipe(int id, string name, string category,
            string ingredients, string type)
        {
            Recipe recipe = recipes.FirstOrDefault(r => r.Id == id);


            if (recipe != null)
            {
                recipe.ModifyRecipe(name, category, ingredients, type);

                Console.WriteLine("Recipe modified successfully.");
            }
            else
            {
                Console.WriteLine("Recipe doesn't exist.");
            }
        }



        public void DeleteRecipe(int id)
        {
            Recipe recipe = recipes.FirstOrDefault(r => r.Id == id);


            if (recipe != null)
            {
                recipes.Remove(recipe);

                Console.WriteLine("Recipe deleted successfully.");
            }
            else
            {
                Console.WriteLine("Recipe doesn't exist.");
            }
        }



        public int CreateNewId()
        {
            if (recipes.Count > 0)
            {
                return recipes.Max(r => r.Id) + 1;
            }

            return 1;
        }
    }
}