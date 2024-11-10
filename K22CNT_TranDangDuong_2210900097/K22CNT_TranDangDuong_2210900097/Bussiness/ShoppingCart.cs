using DocumentFormat.OpenXml.Spreadsheet;
using K22CNT_TranDangDuong_2210900097.ModelViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K22CNT_TranDangDuong_2210900097.Bussiness
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public List<CartItem> Items { get; set; }
        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }
        public void AddToCart(CartItem item)
        {
            var existingitem = Items.FirstOrDefault(i => i.Id == item.Id);
            if (existingitem != null)
            {
                existingitem.Qty += item.Qty;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void UpdateToCart(int id, int qty)
        {
            var existingitem = Items.FirstOrDefault(i => i.Id == id);
            if (existingitem != null)
            {
                existingitem.Qty = qty;
            }
        }
        public void RemoveItemCart(int productId)
        {
            var itemToRemove = Items.FirstOrDefault(i => i.Id == productId);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }
        public float GetTotal()
        {
            return Items.Sum(i => i.Price * i.Qty);
        }
    }
}
