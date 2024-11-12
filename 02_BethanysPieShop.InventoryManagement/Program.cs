// See https://aka.ms/new-console-template for more information
using _02_BethanysPieShop.InventoryManagement.Domain.General;
using _02_BethanysPieShop.InventoryManagement.Domain.ProductManagement;

Console.WriteLine("Hello, World!");



Price samplePrice = new Price(10, Currency.EUR);
Price samplePrice2 = new Price() {ItemPrice = 23, Currency = Currency.EUR };
Console.WriteLine(samplePrice.ToString());
Product p1 = new Product(1, "Sugar", "Loren ipsum", samplePrice, UnitType.PerKg, 100);
p1.IncreaseStock(10);
p1.Description = "Sample Description";

var p2 = new Product(2, "Cake decoration", "Loren ipsum", samplePrice, UnitType.PerKg, 20);
Product p3 = new Product(3, "strawberry", "Loren ipsum", samplePrice2, UnitType.PerBox, 10);

Console.WriteLine("\n" + p1.DisplayDetailsFull());
Console.WriteLine("\n" + p2.DisplayDetailsFull());
Console.WriteLine("\n" + p3.DisplayDetailsFull());