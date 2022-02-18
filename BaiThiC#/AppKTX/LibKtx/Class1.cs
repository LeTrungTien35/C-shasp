using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LibKtx
{
    public class ConnectSql
    {
        public SqlConnection connect;// ham ket noi 
        public SqlCommand cmd;//hanh thuc hien cau lenh
        public string quer = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=KTX;Integrated Security=True";
        public SqlDataAdapter adapter = new SqlDataAdapter();//do database vao winfrom

        public DataTable Load1()//ham load data
        {
            DataTable table = new DataTable();
            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = "Select * from Phong";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            return table;

        }
        public DataTable Load2()//ham load data
        {
            DataTable table = new DataTable();
            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = "Select * from SinhVienKtx";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            return table;

        }
        public DataTable Find(string s)//ham tim 
        {
            DataTable table = new DataTable();
            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = "SELECT * FROM SinhVienKtx WHERE HoTen+GioiTinh+QueQuan+Phong LIKE  '%"+s+"%'";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            return table;
        }
        public DataTable FindP(string s)
        {
            DataTable table = new DataTable();
            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = "SELECT * FROM Phong WHERE Phong = '"+s+"'";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            return table;
        }
        public DataTable FindSv(string s)
        {
            DataTable table = new DataTable();
            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = "select *  from SinhVienktx where HoTen= '"+s+"'";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            return table;
        }
        public DataTable Delete(string d)
        {
            DataTable table = new DataTable();
            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = "DELETE FROM SinhVienKtx WHERE HoTen='"+d+"'";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            return table;
        }
        public void Add(String t, String g, String q, String p)
        {
            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = "INSERT INTO SinhVienKtx (HoTen,GioiTinh,QueQuan,Phong) VALUES('" + t + "','" + g + "','" + q + "','" + p + "') ";
            cmd.ExecuteNonQuery();
            
        }
        public void Fix(String t, String g, String q, String p)
        {
            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = "UPDATE SinhVienKtx SET HoTen =N'"+t+"',GioiTinh =N'"+g+"',QueQuan=N'"+q+"',Phong=N'"+p+"'WHERE HoTen ='"+t+"'";
            cmd.ExecuteNonQuery();

        }
        public void fixp(int n,string p)
        {

            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = "update Phong set [So nguoi dang o] = '"+n+"' where Phong = '"+p+"'";
            cmd.ExecuteNonQuery();
        }
        
        public DataTable  SearchSmart()
        {
            DataTable table = new DataTable();
            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText ="select Phong ,LoaiPhong, MIN([So nguoi dang o] ) AS 'Số người đang ở' from Phong  where LoaiPhong='Nu' AND [So nguoi dang o]<4   GROUP BY  Phong ,LoaiPhong" ;
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            return table;

        }
        public DataTable SearchSmart2()
        {
            DataTable table = new DataTable();
            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = "select Phong ,LoaiPhong, MIN([So nguoi dang o] ) AS 'Số người đang ở' from Phong  where LoaiPhong='Nam' AND [So nguoi dang o]<4   GROUP BY  Phong ,LoaiPhong";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            return table;

        }
        public DataTable ListDanhSach(string L)
        {
             DataTable table = new DataTable();
            connect = new SqlConnection(quer);
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = "Select * from SinhVienKtx where Phong='"+L+"'";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            return table;
        }
    }
}


