using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyDoanVienBE.ModelFromDB;

namespace QuanLyDoanVienBE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoanVienController : ControllerBase
    {
        dbQuanLyDoanVien dbc;
        public DoanVienController(dbQuanLyDoanVien db)
        {
            dbc = db;
        }

        //lấy danh sách
        [HttpGet]
        [Route("/DoanVien/List")]
        public IActionResult GetList()
        {
            return Ok(dbc.DoanViens.ToList());
        }

        //insert
        [HttpPost]
        [Route("/DoanVien/Insert")]
        public IActionResult InsertDoanVien(String idDoanVien, String tenDoanVien, DateOnly ngaySinh, int idPhuongXa,
            String soDienThoai,String email, String gioiTinh, DateOnly ngayVaoDoan,bool trangThaiSoDoan, DateOnly ngayNopSoDoan,
            String idTaiKhoan, String idChiDoan)
        {
            DoanVien dv = new DoanVien();
            dv.IddoanVien = idDoanVien;
            dv.TenDoanVien = tenDoanVien;
            dv.NgaySinh = ngaySinh;
            dv.IdphuongXa = idPhuongXa;
            dv.Sdt = soDienThoai;
            dv.Email = email;
            dv.GioiTinh = gioiTinh;
            dv.NgayVaoDoan = ngayVaoDoan;
            dv.TrangThaiSoDoan = trangThaiSoDoan;
            dv.NgayNopSoDoan = ngayNopSoDoan;
            dv.IdtaiKhoan = idTaiKhoan;
            dv.IdchiDoan = idChiDoan;

            dbc.DoanViens.Add(dv);
            dbc.SaveChanges();
            return Ok(new { dv });
        }
    }
}
