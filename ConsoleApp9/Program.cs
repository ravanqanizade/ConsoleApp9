using ConsoleApp9.Context;
using Microsoft.Identity.Client;

public class Program
{
    static void Menu()
    {
        Console.WriteLine(" [1] Add");
        Console.WriteLine(" [2] Delete");
        Console.WriteLine(" [3] Update");
        Console.WriteLine(" [4] View");
        Console.WriteLine(" [5] ❤️REDBULl❤️");
    }

    static async Task Add(string name, float price)
    {
        BaseEntityDbContext dbContext = new();
        Products product1 = new Products()
        {
            Name = name,
            Price = price,
            InsertionDate = DateTime.Now,
        };
        await dbContext.Products.AddAsync(product1);
        await dbContext.SaveChangesAsync();
    }

    static async Task Delete(int Id, int check)
    {
        BaseEntityDbContext dbContext = new();
        var product = dbContext.Products.FirstOrDefault(x => x.Id == Id);
        if (product != null)
        {
            product.DeletedDate = DateTime.Now;
            product.IsDeleted = true;
            await dbContext.SaveChangesAsync();
            check = 1;
        }
    }

    static async Task Update(int Id, string new_name, float new_price)
    {
        BaseEntityDbContext dbContext = new();
        var product = dbContext.Products.FirstOrDefault(x => x.Id == Id);
        if (product != null)
        {
            product.Name = new_name;
            product.Price = new_price;
            await dbContext.SaveChangesAsync();
        }
    }
    static async Task Show(int Id)
    {
        BaseEntityDbContext dbContext = new();
        var product = dbContext.Products.FirstOrDefault(x => x.Id == Id);
        if (product != null)
        {
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);
            await dbContext.SaveChangesAsync();
        }
    }

    static void Main(string[] args)
    {
        int choice = 0;
        while (choice != 3)
        {
            Menu();
            Console.WriteLine("Choose your option: ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Enter Product name: ");
                        string prName = Console.ReadLine()!;
                        Console.WriteLine("Enter Product price: ");
                        float prPrice = Convert.ToSingle(Console.ReadLine());
                        Add(prName, prPrice);
                        Console.WriteLine("Added");
                        break;
                    }
                case 2:
                    {
                        int check = 0;
                        Console.WriteLine("Enter Id: ");
                        int del_Id = Convert.ToInt32(Console.ReadLine());
                        Delete(del_Id, check);
                        if (check == 1)
                        {
                            Console.WriteLine("Deleted");
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter Id: ");
                        int up_Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Product name: ");
                        string new_Name = Console.ReadLine()!;
                        Console.WriteLine("Enter Product price: ");
                        float new_Price = Convert.ToSingle(Console.ReadLine());
                        Update(up_Id, new_Name, new_Price);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Enter Id: ");
                        int show_Id = Convert.ToInt32(Console.ReadLine());
                        Show(show_Id);
                        break;
                    }
            }
        }
    }
}