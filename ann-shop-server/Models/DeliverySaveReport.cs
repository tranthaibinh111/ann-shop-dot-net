//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ann_shop_server.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeliverySaveReport
    {
        public int ID { get; set; }
        public string MaDonHang { get; set; }
        public Nullable<int> MaDonHangShop { get; set; }
        public int TrangThaiDonHang { get; set; }
        public System.DateTime NgayTao { get; set; }
        public System.DateTime NgayHoanThanh { get; set; }
        public decimal KhoiLuong { get; set; }
        public string KhachHang { get; set; }
        public string Phone { get; set; }
        public string DiaChi { get; set; }
        public decimal TienCod { get; set; }
        public decimal PhiBaoHiem { get; set; }
        public decimal PhiGiaoHang { get; set; }
        public decimal PhiDichVuTraTruoc { get; set; }
        public decimal PhiDichVuCanTru { get; set; }
        public decimal PhiDichVuHoanLai { get; set; }
        public decimal PhiChuyenHoan { get; set; }
        public decimal PhiThayDoiDiaChiGiaoHang { get; set; }
        public decimal PhiLuuKho { get; set; }
        public decimal TienTip { get; set; }
        public decimal PhiDonHoanDaThanhToan { get; set; }
        public decimal ShopTraShipKhiTraHang { get; set; }
        public decimal KhuyenMai { get; set; }
        public decimal ThanhToan { get; set; }
        public string GhiChu { get; set; }
        public string FileName { get; set; }
        public int OrderSearchStatus { get; set; }
        public Nullable<decimal> ShopCod { get; set; }
        public Nullable<decimal> ShopFee { get; set; }
        public string Staff { get; set; }
        public int Review { get; set; }
    }
}
