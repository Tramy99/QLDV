using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDV.Models
{
    public class HoatDong
    {
        [Key]
        [Required, DisplayName("Mã hoạt động")]
        public int mahd { get; set; }
        [Required, DisplayName("Mã đoàn viên")]
        public string madv { get; set; }
        [Required, DisplayName("Tên hoạt động")]
        public string tenhd { get; set; }
        [Required, DisplayName("Thời gian tổ chức")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime thoigiantc { get; set; }
        [DisplayName("Ghi chú")]
        public string ghichu { get; set; }
        [ForeignKey("madv")]
        public ICollection<DoanVien> DoanViens { get; set; }
        public ICollection<KhenThuong> KhenThuongs { get; set; }
    }
}