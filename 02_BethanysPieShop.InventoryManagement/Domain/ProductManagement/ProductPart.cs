using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _02_BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public partial class Product
    {
        public static int StockThreshold = 5;

        //public bool IsBelowStockThreshold;
        public static void ChangeStockThreshhold(int newStockThreshhold)
        {
            if(newStockThreshhold > 0)
                StockThreshold = newStockThreshhold;
        }
        public void UpdateLowStock()
        {
            if (amountInStock < 10)
            {
                isBelowStockTreshold |= true;
            }
        }


        private void Log(string message)
        {
            Console.WriteLine(message);
        }
        private string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }
    }
}
