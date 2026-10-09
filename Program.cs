using System.Net.Http.Headers;
using System.Transactions;

List<ProductType> productCategories = new()
{
    new ProductType()
    {
        Id = 1,
        Name = "Apparel"
    },
    new ProductType()
    {
        Id = 2,
        Name = "Potions"
    },
    new ProductType()
    {
        Id = 3,
        Name = "enchanted objects"
    },
    new ProductType()
    {
        Id = 4,
        Name = "wands"
    }
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
    else if (choice == "2")
    {
        ViewParticularCategory();
        //Console.WriteLine("What Category of Products Do You Want To Look At?")
    }
    else if (choice == "3")
    {
        AddNewProduct();
    }
    else if (choice == "4")
    {
        DeleteProduct();
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
            Console.WriteLine("Your Choice: ");
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
It is{(chosenProduct.IsAvailable ? "" : " not")} available.
It {(chosenProduct.IsAvailable ? "has been" : "was")} in stock for {chosenProduct.DaysOnShelf} days.");
}

void ViewParticularCategory()
{
    Console.WriteLine("What category of products would you like to see? ");

    foreach (ProductType productCategory in productCategories)
    {
        Console.WriteLine($"{productCategory.Id}. {productCategory.Name}");
    }

    string categoryChoice = null;
    List<Product> selectedCategory = null;
    while (categoryChoice == null)
    {
        try
        {
            categoryChoice = Console.ReadLine().Trim();
            int result = int.Parse(categoryChoice);
            selectedCategory = products.Where(p => p.ProductTypeId == result).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Enter a valid option!");
        }
    }

    for (int i = 0; i < selectedCategory.Count; i++)
    {
        Console.WriteLine(@$"{i + 1}. {selectedCategory[i].Name}
        Price: ${selectedCategory[i].Price}
        Days In Stock: {selectedCategory[i].DaysOnShelf}
        Sold: {(selectedCategory[i].IsAvailable ? "No" : "Yes")}
         ");
    }
}

void AddNewProduct()
{
    Console.WriteLine("What is the name of the new product? ");
    string productName = Console.ReadLine().Trim();
    decimal productPrice = 0.0M;
    int productId = 0;
    if (!products.Any(p => p.Name.ToLower() == productName.ToLower()))
    {
        try
        {
            Console.WriteLine("How much does the item cost: ");
            productPrice = decimal.Parse(Console.ReadLine().Trim());
            Console.WriteLine("Choose the category of product the item falls under: ");

            foreach (ProductType productCategory in productCategories)
            {
                Console.WriteLine($"{productCategory.Id}. {productCategory.Name}");
            }
            productId = int.Parse(Console.ReadLine().Trim());

            products.Add(new Product()
            {
                ProductTypeId = productId,
                Name = productName,
                Price = productPrice,
                IsAvailable = true,
                StockDate = DateTime.Now
            }
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }
    else
    {
        Console.WriteLine("Product already exists!");
    }
}

void DeleteProduct()
{
    // Method 1 - Entering the name of the item
    //ViewAllProducts();
    //Console.WriteLine("Delete an item: ");

    //string productName = Console.ReadLine().Trim();
    //Product result = null;
    //try
    //{
    //    result = products.First(p => p.Name.ToLower() == productName.ToLower());
    //    products.Remove(result);
    //}
    //catch (Exception ex)
    //{
    //    Console.WriteLine(ex);
    //    Console.WriteLine("Do better!");
    //}

    //if (result == null)
    //{
    //    Console.WriteLine("Product doesn't exists!");
    //}

    // Method 2 - Entering the s/n of the item
    ViewAllProducts();
    string choice = null;
    string item = null;
    Product chosenProduct = null;
    while (choice == null)
    {
        try
        {
            Console.WriteLine("Item to delete? ");
            choice = Console.ReadLine().Trim();
            int index = int.Parse(choice);
            if (index < 0 || index > products.Count)
            {
                Console.WriteLine("Enter a valid option!");
            }
            else
            {
                chosenProduct = products[int.Parse(choice) - 1];
                item = chosenProduct.Name;
                products.Remove(chosenProduct);
                Console.WriteLine($"{item} has been deleted!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            
        }
    }
}