using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDV.Models
{
    public class DoanVien
    {
        [Key]
        [Required, DisplayName("Mã đoàn viên")]
        public string madv { get; set; }
        [Required, MaxLength(50), DisplayName("Tên đoàn viên")]
        public string tendv { get; set; }
        [Required, DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ns { get; set; }
        [Required, DisplayName("Giới tính")]
        public string gioitinh { get; set; }
        [Required, DisplayName("Quê quán")]
        public string quequan { get; set; }
        [Required, DisplayName("Ngày vào đoàn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ngayvd { get; set; }
        [Required, DisplayName("Dân tộc")]
        public string dantoc { get; set; }
        public string macd { get; set; }
        [ForeignKey("macd")]
        public ChiDoan ChiDoan { get; set; }
        public ICollection<XepLoai> XepLoais { get; set; }
        public ICollection<KhenThuong> KhenThuongs { get; set; }
        public ICollection<HoatDong> HoatDongs { get; set; }



    }
}