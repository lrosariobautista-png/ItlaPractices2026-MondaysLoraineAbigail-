using CookingRecipeLog;


RecipeManager manager = new RecipeManager();


bool running = true;


Console.WriteLine("COOKING RECIPE LOG!!");


while (running)
{
    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("1. List Recipes");
    Console.WriteLine("2. Search Recipes");
    Console.WriteLine("3. Add Recipe");
    Console.WriteLine("4. Modify Recipe");
    Console.WriteLine("5. Delete Recipe");
    Console.WriteLine("6. Exit");


    try
    {
        int option = Convert.ToInt32(Console.ReadLine());


        switch (option)
        {

            case 1:

                manager.ListRecipes();

                break;



            case 2:

                Console.WriteLine("1. Search by ID");
                Console.WriteLine("2. Search by Name");
                Console.WriteLine("3. Search by Type");


                int search = Convert.ToInt32(Console.ReadLine());


                if (search == 1)
                {
                    Console.Write("ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    manager.SearchById(id);
                }

                else if (search == 2)
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    manager.SearchByName(name);
                }

                else if (search == 3)
                {
                    Console.Write("Type: ");
                    string type = Console.ReadLine();

                    manager.SearchByType(type);
                }

                break;



            case 3:

                Console.Write("Recipe name: ");
                string nameNew = Console.ReadLine();


                Console.Write("Category: ");
                string category = Console.ReadLine();


                Console.Write("Ingredients: ");
                string ingredients = Console.ReadLine();


                Console.Write("Food type: ");
                string typeNew = Console.ReadLine();


                int idNew = manager.CreateNewId();


                Recipe recipe = new Recipe(
                    idNew,
                    nameNew,
                    category,
                    ingredients,
                    typeNew
                );


                manager.AddRecipe(recipe);

                break;




            case 4:

                Console.Write("Recipe ID: ");
                int idModify = Convert.ToInt32(Console.ReadLine());


                Console.Write("New name: ");
                string newName = Console.ReadLine();


                Console.Write("New category: ");
                string newCategory = Console.ReadLine();


                Console.Write("New ingredients: ");
                string newIngredients = Console.ReadLine();


                Console.Write("New type: ");
                string newType = Console.ReadLine();



                manager.ModifyRecipe(
                    idModify,
                    newName,
                    newCategory,
                    newIngredients,
                    newType
                );


                break;



            case 5:

                Console.Write("Recipe ID: ");

                int idDelete = Convert.ToInt32(Console.ReadLine());

                manager.DeleteRecipe(idDelete);

                break;



            case 6:

                running = false;

                Console.WriteLine("Thanks for using the system!");

                break;



            default:

                Console.WriteLine("Invalid option");

                break;

        }

    }
    catch
    {
        Console.WriteLine("Error: Enter valid data.");
    }

}


Console.ReadKey();