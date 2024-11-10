using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K22CNT_TranDangDuong_2210900097.ModelViews
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image {  get; set; }
        public int Qty { get; set; }
        public float Price { get; set; }
        public float Total {  get; set; }
    }
}