namespace QuanLySieuThi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(10)]
        public string MaNhanVien { get; set; }

        [StringLength(100)]
        public string HoTenNhanVien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(30)]
        public string SoCMND { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [Column(TypeName = "image")]
        public byte[] AnhDaiDien { get; set; }

        [StringLength(10)]
        public string MaChucVu { get; set; }

        [StringLength(100)]
        public string QueQuan { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }
    }
}
