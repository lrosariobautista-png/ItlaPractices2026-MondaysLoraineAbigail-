namespace CookingRecipeLog
{
    public class Recipe
    {
        public Recipe()
        {

        }

        public Recipe(int id, string name, string category, string ingredients, string type)
        {
            Id = id;
            Name = name;
            Category = category;
            Ingredients = ingredients;
            Type = type;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }
        public string Type { get; set; }


        public string GetInformation()
        {
            return $"ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Category: {Category}\n" +
                   $"Ingredients: {Ingredients}\n" +
                   $"Type: {Type}";
        }


        public void ModifyRecipe(string name, string category, string ingredients, string type)
        {
            Name = name;
            Category = category;
            Ingredients = ingredients;
            Type = type;
        }
    }
}