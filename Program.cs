List<string> productCategories = new()
    {
        "apparel",
        "potions",
        "enchanted objects",
        "wands"
    };

List<Product> products = new List<Product>()
{
    new Product()
    {
        ProductTypeId = 2,
        Name = "Liquid Love",
        Price = 35.0M,
        IsAvailable = true,
        StockDate = new DateTime(2026, 1, 30)
    },
    new Product()
    {
        ProductTypeId = 1,
        Name = "Invisibility Cloak",
        Price = 105.0M,
        IsAvailable = true,
        StockDate = new DateTime(2026, 2, 28)
    },
    new Product()
    {
        ProductTypeId = 4,
        Name = "Master Wand",
        Price = 3500.0M,
        IsAvailable = false,
        StockDate = new DateTime(2026, 1, 30)
    }
};

string greeting = @"Welcome to Reductio & Absurdum.
Providing high-quality magical supplies to the wizarding community for nearly 1000 years\n";
Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"What would you like to do?
    0. Exit
    1. View All Products
    2. View Products For a Particular Category
    3. Add Products to Inventory
    4. Delete a Product from Inventory
    5. Update a Product's Details
Your Choice: ");
    choice = Console.ReadLine().Trim();

    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        Console.WriteLine("Our Products: ");
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        //ViewParticularCategory();
        //Console.WriteLine("What Category of Products Do You Want To Look At?")
    }
}

void ViewAllProducts()
{
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewProductDetails()
{
    ViewAllProducts();
    string choice = null;
    Product chosenProduct = null;
    while (choice == null)
    {
        try
        {
            choice = Console.ReadLine().Trim();
            chosenProduct = products[int.Parse(choice) - 1];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Enter a valid option!");
        }
    }

    Console.WriteLine(@$"The product {chosenProduct.Name} costs ${chosenProduct.Price}.
It is {(chosenProduct.IsAvailable ? "" : "not")} available.
It {(chosenProduct.IsAvailable ? "has been" : "was")} in stock for {chosenProduct.DaysOnShelf} days.");
}

//void ViewParticularCategory()
//{
//    string categoryChoice = null;
//    while (categoryChoice)
//}