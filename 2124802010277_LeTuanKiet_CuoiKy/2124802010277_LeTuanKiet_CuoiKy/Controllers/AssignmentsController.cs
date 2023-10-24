﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2124802010277_LeTuanKiet_CuoiKy.Models;
namespace _2124802010277_LeTuanKiet_CuoiKy.Controllers
{
    public class AssignmentsController : Controller
    {
        DataTiengAnhEntities db = new DataTiengAnhEntities();
        // GET: Assignments
        public ActionResult Index(int id)
        {
            List<ChiTietBaiTap> tmp = db.ChiTietBaiTaps.Where(item => item.IdBaiTap == id).ToList();
            
            var x= db.BaiTaps.FirstOrDefault(item => item.IdBaiTap == id);
            x.LuotXem += 1;
            db.SaveChanges();
            ViewBag.BaiTap = x;
            return View(tmp);
        }
        public ActionResult ListAssi(int pg=1)
        {
            List<BaiTap> ds = db.BaiTaps.ToList();
            const int pageSize = 20;
            if (pg < 1)
                pg = 1;

            int totalitem = ds.Count();

            var pager = new Pager(totalitem, pg, pageSize);

            int skipPage = (pg - 1) * pageSize;
            List<BaiTap> ds1= ds.OrderBy(item => item.IdBaiTap).Skip(skipPage).Take(pageSize).ToList();
            ViewBag.Pager = pager;
            return View(ds1);
        }
        public ActionResult CreateAssignment()
        {
            if(Session["TaiKhoan"]==null)
            {
                return RedirectToAction("DangNhap","User");
            }
            List<ChiTietBaiTap> tmp = new List<ChiTietBaiTap>(); 
            return View(tmp);
        }
        [HttpPost]
        public ActionResult CreateAssignment(string TenBaiTap, List<ChiTietBaiTap> ListCauHoi)
        {
            string bg = "Các câu hỏi bị lỗi cần sửa lại: ";
            int check = 0;
            for (int i = 0; i < ListCauHoi.Count; i++)
            {
                if (ListCauHoi[i].Ques == null && ListCauHoi[i].A == null
                    && ListCauHoi[i].B == null && ListCauHoi[i].C == null
                    && ListCauHoi[i].D == null && ListCauHoi[i].Ans == null)
                {
                    continue;
                }    
                if (ListCauHoi[i].Ques == null || ListCauHoi[i].A == null 
                    || ListCauHoi[i].B == null || ListCauHoi[i].C == null 
                    || ListCauHoi[i].D == null || ListCauHoi[i].Ans == null 
                    || (ListCauHoi[i].Ans!=ListCauHoi[i].A) && (ListCauHoi[i].Ans != ListCauHoi[i].B) && (ListCauHoi[i].Ans != ListCauHoi[i].C) && (ListCauHoi[i].Ans != ListCauHoi[i].D))
                {
                    bg += ", " + i;
                    check++;
                }
            }
            if(check>0)
            {
                ViewBag.bug = bg;
                ViewBag.TenBaiTap = TenBaiTap;
                return View(ListCauHoi);
            }    
            BaiTap tmp = new BaiTap();
            tmp.TenBaiTap=TenBaiTap;
            NguoiDung Nd = (NguoiDung)Session["TaiKhoan"];
            tmp.TacGia = Nd.MaKH;
            tmp.SoLuotNop = 0;
            tmp.NgayDang = DateTime.Now;
            tmp.DiemTrungBinh = 0;
            tmp.LuotThich = 0;
            tmp.LuotXem = 0;
            db.BaiTaps.Add(tmp);
            db.SaveChanges();
            for (int i = 0; i < ListCauHoi.Count; i++)
            {
                if(ListCauHoi[i].Ques!=null)
                {
                    ChiTietBaiTap bt = ListCauHoi[i];
                    bt.IdBaiTap = tmp.IdBaiTap;
                    db.ChiTietBaiTaps.Add(bt);
                }    
            }
            db.SaveChanges();
            return RedirectToAction("CreateAssignment");
        }

    }
}