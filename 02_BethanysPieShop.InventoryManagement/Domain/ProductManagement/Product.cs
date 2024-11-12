using _02_BethanysPieShop.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public partial class Product
    {
        private int id;
        private string name = string.Empty;
        private string? description;

        private int maxItemsInStock = 0;

        private UnitType unitType;
        private int amountInStock = 0;
        private bool isBelowStockTreshold = false;
        public Price Price { get; set; }    
        private int maxAmountInStock = 0;

        // Property for id
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        // Property for name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Property for description
        public string? Description
        {
            get { return description; }
            set { description = value; }
        }

        // Property for maxItemsInStock
        public int MaxItemsInStock
        {
            get { return maxItemsInStock; }
            set { maxItemsInStock = value; }
        }

        // Property for unitType
        public UnitType UnitType
        {
            get { return unitType; }
            set { unitType = value; }
        }

        // Property for amountInStock
        public int AmountInStock
        {
            get { return amountInStock; }
            set { amountInStock = value; }
        }

        // Property for isBelowStockTreshold
        public bool IsBelowStockTreshold
        {
            get { return isBelowStockTreshold; }
            set { isBelowStockTreshold = value; }
        }

        public Product(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Product(int id) : this(id, string.Empty)
        {

        }
        public Product(int id, string name, string? description, Price price, UnitType unitType,
            int maxAmountInStock)
        {
            this.id = id;
            Name = name;
            Description = description;
            Price = price;
            UnitType = unitType;
            MaxItemsInStock = maxAmountInStock;

            UpdateLowStock();   
        }

        public void UseProduct(int items)
        {
            if (items < amountInStock)
            {
                amountInStock -= items;
                UpdateLowStock();
                Log($"Amount un stock updated. Now {amountInStock} items in stock.");
            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}. " +
                    $"{amountInStock} available but {items} requested.");
            }
        }

        public void IncreaseStock()
        {
            amountInStock++;
        }

        public void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount;

            if (newStock < maxItemsInStock)
            {
                AmountInStock += amount;
            }
            else
            {
                AmountInStock = maxItemsInStock;
                Log($"{CreateSimpleProductRepresentation} stock overlow. {newStock - AmountInStock} item(s)" +
                    $"ordered that couldn't be stored.");
            }

            if (AmountInStock > 10)
            {
                IsBelowStockTreshold = false;
            }
        }


        public string DisplayDetailsShort()
        {
            return $"{id}. {name} \n{amountInStock} items in stock";
        }

        public string DisplayDetailsFull()
        {
            return DisplayDetailsFull("");
        }

        public string DisplayDetailsFull(string extraDetails)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{id} {name} \n{description}\n{amountInStock} item(s) in stock");

            stringBuilder.Append(extraDetails);
            stringBuilder.Append($"\n{Price.ItemPrice} {Price.Currency}");


            if (isBelowStockTreshold)
            {
                stringBuilder.Append("\n!!STOCK LOW!!");
            }
            return stringBuilder.ToString();
        }



    }
}
