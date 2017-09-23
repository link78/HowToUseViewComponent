using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppViewComponent.Models
{
    public interface IProduct
    {
        IEnumerable<Product> Products { get; }
        void AddNew(Product Newproduct);
        
    }

    public class ProductRepo:IProduct
    {
        private List<Product> products = new List<Product>
        {
            new Product{ ID=1,Name="Smart Apple TV", Category="Electronics",Price=999.99m},
            new Product{ID=2, Name="Microwave Iserrie",Category="Appliances", Price=249.99m},
            new Product{ID=3, Name="Kayak", Category="Sports", Price=275m}
        };


        public IEnumerable<Product> Products => products;

        public void AddNew(Product p)
        {
            products.Add(p);
        }


        public Decimal TotalCost(decimal cost)
        {
            return cost= products.Sum(p => p.Price);
        }
        

    }

}
