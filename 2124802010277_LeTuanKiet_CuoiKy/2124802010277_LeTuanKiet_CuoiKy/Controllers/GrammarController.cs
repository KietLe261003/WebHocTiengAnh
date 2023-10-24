using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2124802010277_LeTuanKiet_CuoiKy.Models;
namespace _2124802010277_LeTuanKiet_CuoiKy.Controllers
{
    public class GrammarController : Controller
    {
        DataTiengAnhEntities db = new DataTiengAnhEntities();
        // GET: Grammar
        public ActionResult Index()
        {
            List<NguPhap> tmp = db.NguPhaps.ToList();
            ViewBag.TaiKhoan = db.NguoiDungs.ToList();
            return View(tmp);
        }

        /*xử lý khi thêm 1 ngữ pháp mới start*/ 
        public ActionResult AddGrammar()
        {
            if (Session["TaiKhoan"] == null)
                return RedirectToAction("DangNhap", "User");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddGrammar(FormCollection data)
        {
            NguPhap np = new NguPhap();

            var sIdTacGia = (NguoiDung)Session["TaiKhoan"];
            var sTen = data["TenNguPhap"];
            var sNoiDung = data["NoiDung"];
            var sMoTa = data["MoTa"];

            np.IdTacGia = sIdTacGia.MaKH;
            np.TenNguPhap = sTen;
            np.NoiDung = sNoiDung;
            np.MoTaNgan = sMoTa;
            np.LuotXem = 0;
            np.LuotThich = 0;
            np.NgayDang = DateTime.Now;
            np.TrangThai = false;
            db.NguPhaps.Add(np);
            db.SaveChanges();
            return View();
        }
        /*Xử lý khi thêm 1 ngữ pháp mới kết thúc*/

        /*Chi tiết 1 ngữ pháp start*/
        public ActionResult DetailGrammar(int id)
        {
            NguPhap tmp = db.NguPhaps.FirstOrDefault(item => item.IdNguPhap == id);
            ViewBag.MucLuc = db.NguPhaps.ToList();
            
            return View(tmp);
        }
        /*Chi tiết 1 ngữ pháp end*/
    }
}