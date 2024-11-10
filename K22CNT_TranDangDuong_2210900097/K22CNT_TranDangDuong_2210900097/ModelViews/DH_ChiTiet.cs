using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace K22CNT_TranDangDuong_2210900097.ModelViews
{
    public class DH_ChiTiet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double? Total { get; set; }
    }
}