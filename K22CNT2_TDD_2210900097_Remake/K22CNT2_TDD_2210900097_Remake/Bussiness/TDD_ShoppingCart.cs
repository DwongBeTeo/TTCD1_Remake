using K22CNT2_TDD_2210900097_Remake.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K22CNT2_TDD_2210900097_Remake.Bussiness
{
    public class TDD_ShoppingCart
    {
        
        public List<TDDCartItem> Items { get; set; }
        public TDD_ShoppingCart() {
            Items = new List<TDDCartItem>();
        }
        //Chức năng thêm sản phẩm vàoi giỏ hàng
        public void AddToCart(TDDCartItem item) { 
            var existingItem = Items.FirstOrDefault(x => x.ID == item.ID);
            if (existingItem !=null)
            {
                existingItem.SoLuongMua += item.SoLuongMua;
            }
            else
            {
                Items.Add(item);
            }
        }
        //xóa bảng sản phẩm trong giỏ hàng
        public void RemoveToCart(int id) 
        {
            var itemToRemove = Items.FirstOrDefault(x => x.ID == id);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }
        //tinh tong tien
        public float GetTongThanhTien()
        {
            return Items.Sum(x => x.SoLuongMua * x.DonGiaMua);
        }
        //cập nhật shopping cart
         public void UpdateFromCart(int id, int qty)
        {
            var existingItem = Items.FirstOrDefault(x=>x.ID == id);
            if (existingItem != null) 
            {
                existingItem.SoLuongMua = qty;
            }
        }
    }
}