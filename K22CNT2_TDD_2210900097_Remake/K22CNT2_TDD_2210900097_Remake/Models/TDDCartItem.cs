using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K22CNT2_TDD_2210900097_Remake.Models
{
    public class TDDCartItem
    {
        
        public int ID { get; set; }
        public string TenSanPham{ get; set; }
        public string HinhAnh {  get; set; }
        public int SoLuongMua {  get; set; }
        public float DonGiaMua { get; set; }
        public float ThanhTien {  get; set; }
    }
}