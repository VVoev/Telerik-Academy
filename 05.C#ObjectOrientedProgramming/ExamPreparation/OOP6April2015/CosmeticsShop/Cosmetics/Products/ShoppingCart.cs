namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> listOfProducts;

        public ShoppingCart()
        {
           this.ProductList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return new List<IProduct>(listOfProducts); }
            set { listOfProducts = value; }
        }

        public void AddProduct(IProduct product)
        {
            this.listOfProducts.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            if (this.listOfProducts.Contains(product))
            {
                return true;
            }
            return false;
        }

        public void RemoveProduct(IProduct product)
        {
            this.listOfProducts.Remove(product);
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = this.ProductList.Sum(x => x.Price);
            return totalPrice;
        }
    }
}
