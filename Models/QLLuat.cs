using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web4dotnet.Models
{
    public class QLLuat
    {
        public int ID { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào chương")]
        [Display(Name = "Chương")]
        public string Chuong { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào nội dung chương")]
        [Display(Name = "Nội dung chương")]
        public string NDChuong { set; get; }
        [Display(Name = "Mục")]
        public string Muc { set; get; }
        [Display(Name = "Nội dung mục")]
        public string NDMuc { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào điều")]
        [Display(Name = "Điều")]
        public string Dieu { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào nội dung điều")]
        [Display(Name = "Nội dung điều")]
        public string NDDieu { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập vào khoản")]
        [Display(Name = "Khoản")]
        public string Khoan { set; get; }
        [Display(Name = "Nội dung khoản")]
        public string NDKhoan { set; get; }
        [Display(Name = "Mức phạt dưới")]
        public string MucPhatduoi { set; get; }
        [Display(Name = "Mức phạt trên")]
        public string MucPhattren { set; get; }
        //[Display(Name = "Status")]
        public string Status { set; get; }
        //[Display(Name = "QAQC")]
        public string QAQC { set; get; }
    }

    class LuatList
    {
        DBConnection db;
        public LuatList()
        {
            db = new DBConnection();
        }

        public List<QLLuat> GetLuat(string ID)
        {
            string sql;
            if (string.IsNullOrEmpty(ID))
            {
                sql = "Select * From Luat";
            }
            else
            {
                sql = "Select * From Luat Where Id = " + ID;
            }

            List<QLLuat> strList = new List<QLLuat>();
            SqlConnection con = db.GetConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            // Mở kết nối
            con.Open();
            cmd.Fill(dt);
            // Đóng kết nối
            cmd.Dispose();
            con.Close();

            QLLuat strLuat;
            for(int i =0; i <dt.Rows.Count; i++)
            {
                strLuat = new QLLuat();
                strLuat.ID = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                strLuat.Chuong = dt.Rows[i]["Chuong"].ToString();
                strLuat.NDChuong = dt.Rows[i]["NDChuong"].ToString();
                strLuat.Muc = dt.Rows[i]["Muc"].ToString();
                strLuat.NDMuc = dt.Rows[i]["NDMuc"].ToString();
                strLuat.Dieu = dt.Rows[i]["Dieu"].ToString();
                strLuat.NDDieu = dt.Rows[i]["NDDieu"].ToString();
                strLuat.Khoan = dt.Rows[i]["Khoan"].ToString();
                strLuat.NDKhoan = dt.Rows[i]["NDKhoan"].ToString();
                strLuat.MucPhatduoi = dt.Rows[i]["MucPhatduoi"].ToString();
                strLuat.MucPhattren = dt.Rows[i]["MucPhattren"].ToString();
                strLuat.Status = dt.Rows[i]["Status"].ToString();
                strLuat.QAQC = dt.Rows[i]["QAQC"].ToString();

                strList.Add(strLuat);
            }
            return strList;

        }
        // Thêm dữ liệu
        public void AddLuat(QLLuat strLuat)
        {
            string sql = "INSERT INTO Luat(Chuong, NDChuong, Muc, NDMuc, Dieu, NDDieu, Khoan, NDKhoan, MucPhatduoi, MucPhattren, Status, QAQC)VALUES(N'"+strLuat.Chuong+ "',N'" + strLuat.NDChuong + "',N'" + strLuat.Muc + "',N'" + strLuat.NDMuc + "',N'" + strLuat.Dieu + "',N'" + strLuat.NDDieu + "',N'" + strLuat.Khoan + "',N'" + strLuat.NDKhoan + "',N'" + strLuat.MucPhatduoi + "',N'" + strLuat.MucPhattren + "',N'" + strLuat.Status + "',N'" + strLuat.QAQC + "')";
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();
            // Đóng kết nối
            cmd.Dispose();
            con.Close();
        }

        // Sửa dữ liệu
        public void EditLuat(QLLuat strLuat)
        {
            string sql = "UPDATE Luat SET Chuong = N'" + strLuat.Chuong + "',NDChuong =  N'" + strLuat.NDChuong + "',Muc =  N'" + strLuat.Muc + "',NDMuc =  N'" + strLuat.NDMuc + "',Dieu =  N'" + strLuat.Dieu + "',NDDieu =  N'" + strLuat.NDDieu + "',Khoan =  N'" + strLuat.Khoan + "',NDKhoan =  N'" + strLuat.NDKhoan + "',MucPhatduoi =  N'" + strLuat.MucPhatduoi + "',MucPhattren =  N'" + strLuat.MucPhattren + "',Status =  N'" + strLuat.Status + "',QAQC =  N'" + strLuat.QAQC + "' WHERE Id =" + strLuat.ID;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();
            // Đóng kết nối
            cmd.Dispose();
            con.Close();
        }

        // Xóa dữ liệu
        public void DeleteLuat(QLLuat strLuat)
        {
            string sql = "DELETE FROM Luat WHERE Id = " +strLuat.ID;
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            // Mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();
            // Đóng kết nối
            cmd.Dispose();
            con.Close();
        }

       


    }

}