using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDV.Models
{
    public class ChiDoan
    {
        [Key]
        [Required, DisplayName("Mã chi đoàn")]
        public string macd { get; set; }
        [Required,MaxLength(50), DisplayName("Tên chi đoàn")]
        public string tencd { get; set; }
        public ICollection<DoanVien> DoanViens { get; set; }


    }
}