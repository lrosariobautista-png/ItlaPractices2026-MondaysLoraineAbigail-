using CookingRecipeLog.Data;
using CookingRecipeLog.Models;
using CookingRecipeLog.Services;

DataContext db = new DataContext();

db.Database.EnsureCreated();

RecipeService service = new RecipeService();

bool running = true;

Console.WriteLine("================================");
Console.WriteLine("      COOKING RECIPE LOG");
Console.WriteLine("================================");

while (running)
{
    Console.WriteLine("\nChoose an option:");

    Console.WriteLine("1. List Recipes");
    Console.WriteLine("2. Search Recipes");
    Console.WriteLine("3. Add Recipe");
    Console.WriteLine("4. Modify Recipe");
    Console.WriteLine("5. Delete Recipe");
    Console.WriteLine("6. Exit");

    Console.Write("Option: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int option))
    {
        Console.WriteLine(
            "Please enter a valid number.");

        continue;
    }

    switch (option)
    {
        case 1:

            service.ListRecipes();

            break;

        case 2:

            Console.WriteLine(
                "\n1. Search by ID");

            Console.WriteLine(
                "2. Search by Name");

            Console.WriteLine(
                "3. Search by Type");

            Console.Write("Option: ");

            if (!int.TryParse(
                Console.ReadLine(),
                out int search))
            {
                Console.WriteLine(
                    "Invalid option.");

                break;
            }

            if (search == 1)
            {
                Console.Write("ID: ");

                if (int.TryParse(
                    Console.ReadLine(),
                    out int id))
                {
                    service.SearchById(id);
                }
                else
                {
                    Console.WriteLine(
                        "Invalid ID.");
                }
            }
            else if (search == 2)
            {
                Console.Write("Name: ");

                string name =
                    Console.ReadLine();

                service.SearchByName(name);
            }
            else if (search == 3)
            {
                Console.Write("Type: ");

                string type =
                    Console.ReadLine();

                service.SearchByType(type);
            }
            else
            {
                Console.WriteLine(
                    "Invalid option.");
            }

            break;

        case 3:

            Console.Write(
                "\nRecipe name: ");

            string newName =
                Console.ReadLine();

            Console.Write(
                "Category: ");

            string category =
                Console.ReadLine();

            Console.Write(
                "Ingredients: ");

            string ingredients =
                Console.ReadLine();

            Console.Write(
                "Food type: ");

            string typeNew =
                Console.ReadLine();

            Recipe recipe = new Recipe
            {
                Name = newName,
                Category = category,
                Ingredients = ingredients,
                FoodType = typeNew
            };

            service.AddRecipe(recipe);

            break;

        case 4:

            Console.Write(
                "\nRecipe ID: ");

            if (!int.TryParse(
                Console.ReadLine(),
                out int idModify))
            {
                Console.WriteLine(
                    "Invalid ID.");

                break;
            }

            Console.Write(
                "New name: ");

            string modifyName =
                Console.ReadLine();

            Console.Write(
                "New category: ");

            string modifyCategory =
                Console.ReadLine();

            Console.Write(
                "New ingredients: ");

            string modifyIngredients =
                Console.ReadLine();

            Console.Write(
                "New food type: ");

            string modifyType =
                Console.ReadLine();

            service.ModifyRecipe(
                idModify,
                modifyName,
                modifyCategory,
                modifyIngredients,
                modifyType);

            break;

        case 5:

            Console.Write(
                "\nRecipe ID: ");

            if (!int.TryParse(
                Console.ReadLine(),
                out int idDelete))
            {
                Console.WriteLine(
                    "Invalid ID.");

                break;
            }

            service.DeleteRecipe(idDelete);

            break;

        case 6:

            running = false;

            Console.WriteLine(
                "Thanks for using the system!");

            break;

        default:

            Console.WriteLine(
                "Invalid option.");

            break;
    }
}