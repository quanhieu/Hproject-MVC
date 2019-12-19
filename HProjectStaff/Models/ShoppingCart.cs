using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HProjectStaff.Models
{
    public class ShoppingCart
    {
        private HCosmeticEntities db = new HCosmeticEntities();
        public List<Product> Items = new List<Product>();
        public int Count
        {
            get
            {
                var qty = (int)Items.Sum(p => p.UnitsInOrder);
                return qty;
            }
        }
        public double Amount
        {
            get
            {
                var amt = (double)Items.Sum(p => p.UnitsInOrder * p.Price);
                return amt;
            }
        }
        public void Add(int ProductId, int UnitsInOrder)
        {
            if (UnitsInOrder <= 0) UnitsInOrder = 1;
            try
            {
                var Item = Items.Single(p => p.ProductId == ProductId);
                Item.UnitsInOrder += UnitsInOrder;
            }
            catch
            {
                var Item = db.Products.Single(p => p.ProductId == ProductId);
                Item.UnitsInOrder = UnitsInOrder;
                Items.Add(Item);
            }
        }
        public void Remove(int ProductId)
        {
            var Item = Items.Single(p => p.ProductId == ProductId);
            Items.Remove(Item);
        }
        public void Update(int ProductId, int newQty)
        {
            if (newQty <= 0) newQty = 1;
            var Item = Items.Single(p => p.ProductId == ProductId);
            Item.UnitsInOrder = newQty;
        }
        public void Clear()
        {
            Items.Clear();
        }
        public static ShoppingCart Cart
        {
            get
            {
                var cart = HttpContext.Current.Session["Cart"] as ShoppingCart;
                if (cart == null)
                {
                    cart = new ShoppingCart();
                    HttpContext.Current.Session["Cart"] = cart;
                }
                return cart;
            }
        }
    }
}