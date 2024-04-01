using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;

namespace ConsoleApp
{
    internal class Program
    {


        static void Main(string[] args)
        {
            int maSV; string hoTen; string ngaySinh; string gioiTinh; string diaChi; string soDienThoai;
            DateTime dateTime;
            try
            {
                //string connectionString = "Data Source=admin\\thao;Initial Catalog=TT88_ver2;Integrated Security=True";
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                while (true)
                {
                    Console.WriteLine("1. Hien danh sach sinh vien");
                    Console.WriteLine("2. Them moi sinh vien");
                    Console.WriteLine("3. Hien sinh vien ngat ket noi");
                    Console.WriteLine("4. Hien danh sach sinh vien theo dieu kien");
                    Console.WriteLine("5. Them sinh vien ngat ket noi");
                    Console.WriteLine("6. Sua thong tin sinh vien ngat ket noi");
                    Console.WriteLine("7. Xoa sinh vien ngat ket noi");
                    Console.Write("Moi nhap lua chon: ");
                    int x = int.Parse(Console.ReadLine());

                    switch (x)
                    {
                        case 1:
                            HienSinhVien(connectionString);
                            break;

                        case 2:
                            Console.Write("Nhap ma sinh vien: ");
                            maSV = Convert.ToInt32(Console.ReadLine());
                            while (!KiemTraMaSinhVien(connectionString, maSV))
                            {
                                Console.Write("Nhap lai ma sinh vien: ");
                                maSV = Convert.ToInt32(Console.ReadLine());
                            }

                            Console.Write("Nhap ho ten sinh vien: ");
                            hoTen = Console.ReadLine();

                            Console.Write("Nhap ngay sinh: ");
                            dateTime = Convert.ToDateTime(Console.ReadLine());
                            ngaySinh = dateTime.ToString("yyyy/MM/d");

                            Console.Write("Nhap gioi tinh: ");
                            gioiTinh = Console.ReadLine();

                            Console.Write("Nhap dia chi: ");
                            diaChi = Console.ReadLine();

                            Console.Write("Nhap so dien thoai: ");
                            soDienThoai = Console.ReadLine();


                            bool i = ThemSinhVien(connectionString, maSV, hoTen, ngaySinh, diaChi, soDienThoai, IsGender(gioiTinh));
                            if (i)
                            {
                                Console.WriteLine("Them moi thanh cong");
                            }
                            else
                            {
                                Console.WriteLine("Them moi khong thanh cong");
                            }
                            break;
                        case 3:
                            HienSinhVienNgatKetNoi(connectionString);
                            break;
                        case 4:
                            HienSinhVienTheoDieuKien(connectionString);
                            break;
                        case 5:
                            Console.Write("Nhap ma sinh vien: ");
                            maSV = Convert.ToInt32(Console.ReadLine());
                            while (!KiemTraMaSinhVien(connectionString, maSV))
                            {
                                Console.Write("Nhap lai ma sinh vien: ");
                                maSV = Convert.ToInt32(Console.ReadLine());
                            }

                            Console.Write("Nhap ho ten sinh vien: ");
                            hoTen = Console.ReadLine();

                            Console.Write("Nhap ngay sinh: ");
                            dateTime = Convert.ToDateTime(Console.ReadLine());
                            ngaySinh = dateTime.ToString("yyyy/MM/d");

                            Console.Write("Nhap gioi tinh: ");
                            gioiTinh = Console.ReadLine();

                            Console.Write("Nhap dia chi: ");
                            diaChi = Console.ReadLine();

                            Console.Write("Nhap so dien thoai: ");
                            soDienThoai = Console.ReadLine();

                            bool i1 = ThemSinhVienNgatKetNoi(connectionString, maSV, hoTen, ngaySinh, diaChi, soDienThoai, IsGender(gioiTinh));
                            if (i1)
                            {
                                Console.WriteLine("Them moi thanh cong");
                            }
                            else
                            {
                                Console.WriteLine("Them moi khong thanh cong");
                            }
                            break;
                        case 6:
                            Console.Write("Nhap ma sinh vien: ");
                            maSV = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Nhap ho ten sinh vien: ");
                            hoTen = Console.ReadLine();

                            Console.Write("Nhap ngay sinh: ");
                            dateTime = Convert.ToDateTime(Console.ReadLine());
                            ngaySinh = dateTime.ToString("yyyy/MM/d");

                            Console.Write("Nhap gioi tinh: ");
                            gioiTinh = Console.ReadLine();

                            Console.Write("Nhap dia chi: ");
                            diaChi = Console.ReadLine();

                            Console.Write("Nhap so dien thoai: ");
                            soDienThoai = Console.ReadLine();

                            bool i3 = SuaSinhVienNgatKetNoi(connectionString, maSV, hoTen, ngaySinh, diaChi, soDienThoai, IsGender(gioiTinh));
                            if (i3)
                            {
                                Console.WriteLine("Sua thong tin sinh vien thanh cong");
                            }
                            else
                            {
                                Console.WriteLine("Sua thong tin sinh vien khong thanh cong");
                            }
                            break;
                        case 7:
                            Console.Write("Nhap ma sinh vien can xoa: ");
                            maSV = Convert.ToInt32(Console.ReadLine());
                            while (KiemTraMaSinhVien(connectionString, maSV))
                            {
                                Console.Write("Ma {0} khong ton tai! Nhap lai ma sinh vien: ", maSV);
                                maSV = Convert.ToInt32(Console.ReadLine());
                            }
                            bool i4 = XoaSinhVienNgatKetNoi(connectionString, maSV);
                            if (i4)
                            {
                                Console.WriteLine("Xoa thong tin sinh vien thanh cong");
                            }
                            else
                            {
                                Console.WriteLine("Xoa thong tin sinh vien khong thanh cong");
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static bool IsGender(string gender)
        {
            bool index;
            if (gender.ToLower() == "nam")
            {
                index = true;
            }
            else
            {
                index = false;
            }
            return index;
        }

        public static bool ThemSinhVien(string connectionString, int maSV, string hoTen, string ngaySinh, string diaChi, string soDT, bool gioiTinh)
        {
            string queryInsert = "INSERT INTO tblSINHVIEN(iMaSV, sHoTen, dNgaySinh, sDiaChi, sSoDienThoai, bGioiTinh)" +
                                 "VALUES('" + maSV + "', N'" + hoTen + "', '" + ngaySinh + "', '" + diaChi + "', '" + soDT + "','" + gioiTinh + "')";
            using (SqlConnection sqlConnetion = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnetion.CreateCommand())
                {
                    sqlCommand.CommandText = queryInsert;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlConnetion.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    sqlConnetion.Close();
                    return i > 0;
                }
            }
        }

        //public static bool ThemSinhVien(string connectionString, int maSV, string hoTen, 
        //                                string ngaySinh, string diaChi, string soDT, bool gioiTinh)
        //{
        //    string queryInsert = "Insert_tblSINHVIEN";
        //    using (SqlConnection sqlConnetion = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand sqlCommand = sqlConnetion.CreateCommand())
        //        {
        //            sqlCommand.CommandText = queryInsert;
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            sqlCommand.Parameters.AddWithValue("@maSV", maSV);
        //            sqlCommand.Parameters.AddWithValue("@tenSV", hoTen);
        //            sqlCommand.Parameters.AddWithValue("@ngaySinh", ngaySinh);
        //            sqlCommand.Parameters.AddWithValue("@gioiTinh", gioiTinh);
        //            sqlCommand.Parameters.AddWithValue("@diaChi", diaChi);
        //            sqlCommand.Parameters.AddWithValue("@soDienThoai", soDT);
        //            sqlConnetion.Open();
        //            int i = sqlCommand.ExecuteNonQuery();
        //            sqlConnetion.Close();
        //            return i > 0;
        //        }
        //    }
        //}

        public static bool XoaSinhVienNgatKetNoi(string connectionString, int maSV)
        {
            string queryDelete = "Delete_tblSINHVIEN";
            using (SqlConnection sqlConnetion = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    //Lấy danh sách sinh viên vào dataTable
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM tblSINHVIEN", sqlConnetion);
                    DataTable dtSINHVIEN = new DataTable("tblSINHVIEN");
                    adapter.Fill(dtSINHVIEN);

                    //add từng dataTable và dataSet
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dtSINHVIEN);

                    //tìm ma sv cần xóa
                    dtSINHVIEN.PrimaryKey = new DataColumn[] { dtSINHVIEN.Columns["iMaSV"] };
                    DataRow dataRow = dtSINHVIEN.Rows.Find(maSV);
                    dataRow.Delete();

                    //xóa mã đã chọn trong CSDL thực hiện DeleteCommand
                    using (SqlCommand sqlCommand = sqlConnetion.CreateCommand())
                    {
                        sqlCommand.CommandText = queryDelete;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@maSV", maSV);

                        adapter.DeleteCommand = sqlCommand;
                        int i = adapter.Update(ds, "tblSINHVIEN");

                        return i > 0;
                    }
                }
            }
        }

        public static bool ThemSinhVienNgatKetNoi(string connectionString, int maSV, string hoTen, string ngaySinh, string diaChi, string soDT, bool gioiTinh)
        {
            string queryInsert = "Insert_tblSINHVIEN";
            using (SqlConnection sqlConnetion = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    //Lấy danh sách sinh viên vào dataTable
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM tblSINHVIEN", sqlConnetion);
                    DataTable dtSINHVIEN = new DataTable("tblSINHVIEN");
                    adapter.Fill(dtSINHVIEN);

                    //add từng dataTable và dataSet
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dtSINHVIEN);

                    //thêm bản ghi vào trong dataTable
                    DataRow newRow = dtSINHVIEN.NewRow();
                    newRow["iMaSV"] = maSV;
                    newRow["sHoTen"] = hoTen;
                    newRow["dNgaySinh"] = ngaySinh;
                    newRow["bGioiTinh"] = gioiTinh;
                    newRow["sDiaChi"] = diaChi;
                    newRow["sSoDienThoai"] = soDT;
                    dtSINHVIEN.Rows.Add(newRow);

                    //thêm bản ghi vào CSDL thực hiện InsertCommand
                    using (SqlCommand sqlCommand = sqlConnetion.CreateCommand())
                    {
                        sqlCommand.CommandText = queryInsert;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@maSV", maSV);
                        sqlCommand.Parameters.AddWithValue("@tenSV", hoTen);
                        sqlCommand.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                        sqlCommand.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                        sqlCommand.Parameters.AddWithValue("@diaChi", diaChi);
                        sqlCommand.Parameters.AddWithValue("@soDienThoai", soDT);

                        adapter.InsertCommand = sqlCommand;
                        int i = adapter.Update(ds, "tblSINHVIEN");

                        return i > 0;
                    }
                }
            }
        }

        public static bool SuaSinhVienNgatKetNoi(string connectionString, int maSV, string hoTen, string ngaySinh, string diaChi, string soDT, bool gioiTinh)
        {
            string queryUpdate = "Update_tblSINHVIEN";
            using (SqlConnection sqlConnetion = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    //Lấy danh sách sinh viên vào dataTable
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM tblSINHVIEN", sqlConnetion);
                    DataTable dtSINHVIEN = new DataTable("tblSINHVIEN");
                    adapter.Fill(dtSINHVIEN);

                    //add từng dataTable và dataSet
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dtSINHVIEN);

                    //chỉnh sửa dữ liệu trong datatable của dataset
                    dtSINHVIEN.PrimaryKey = new DataColumn[] { dtSINHVIEN.Columns["iMaSV"] };
                    DataRow dataRow = dtSINHVIEN.Rows.Find(maSV);
                    dataRow["sHoTen"] = hoTen;
                    dataRow["dNgaySinh"] = ngaySinh;
                    dataRow["bGioiTinh"] = gioiTinh;
                    dataRow["sDiaChi"] = diaChi;
                    dataRow["sSoDienThoai"] = soDT;

                    //thực hiện UpdateCommand
                    using (SqlCommand sqlCommand = sqlConnetion.CreateCommand())
                    {
                        sqlCommand.CommandText = queryUpdate;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@maSV", maSV);
                        sqlCommand.Parameters.AddWithValue("@tenSV", hoTen);
                        sqlCommand.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                        sqlCommand.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                        sqlCommand.Parameters.AddWithValue("@diaChi", diaChi);
                        sqlCommand.Parameters.AddWithValue("@soDienThoai", soDT);

                        adapter.UpdateCommand = sqlCommand;
                        int i = adapter.Update(ds, "tblSINHVIEN");

                        return i > 0;
                    }
                }
            }
        }

        public static void HienSinhVien(string connectionString)
        {
            string querySelect = "Select_tblSINHVIEN";
            using (SqlConnection sqlConnetion = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnetion.CreateCommand())
                {
                    sqlCommand.CommandText = querySelect;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnetion.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                                                    dataReader["iMaSV"]
                                                  , dataReader["sHoTen"]
                                                  , dataReader["dNgaySinh"]
                                                  , dataReader["bGioiTinh"]
                                                  , dataReader["sDiaChi"]
                                                  , dataReader["sSoDienThoai"]);
                            }
                        }
                    }
                    sqlConnetion.Close();
                }
            }
        }

        public static void HienSinhVienNgatKetNoi(string connectionString)
        {
            string queryInsert = "Select_tblSINHVIEN";
            using (SqlConnection sqlConnetion = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnetion.CreateCommand())
                {
                    sqlCommand.CommandText = queryInsert;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = sqlCommand;
                        using (DataTable dataTable = new DataTable())
                        {
                            adapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                                                    row["iMaSV"]
                                                  , row["sHoTen"]
                                                  , row["dNgaySinh"]
                                                  , row["bGioiTinh"]
                                                  , row["sDiaChi"]
                                                  , row["sSoDienThoai"]);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Khong co ban ghi nao");
                            }
                        }
                    }
                }
            }
        }

        public static void HienSinhVienTheoDieuKien(string connectionString)
        {
            string queryInsert = "Select_tblSINHVIEN";
            using (SqlConnection sqlConnetion = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnetion.CreateCommand())
                {
                    sqlCommand.CommandText = queryInsert;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = sqlCommand;
                        using (DataTable dataTable = new DataTable())
                        {
                            adapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                using (DataView dataView = new DataView(dataTable))
                                {
                                    dataView.RowFilter = "bGioiTinh = 'Nu'";// OR bGioiTinh = 'Nam'";
                                    dataView.Sort = "dNgaySinh ASC";
                                    foreach (DataRowView row in dataView)
                                    {
                                        Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                                                        row["iMaSV"]
                                                      , row["sHoTen"]
                                                      , row["dNgaySinh"]
                                                      , row["bGioiTinh"]
                                                      , row["sDiaChi"]
                                                      , row["sSoDienThoai"]);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Khong co ban ghi nao");
                            }
                        }
                    }
                }
            }
        }


        public static bool KiemTraMaSinhVien(string connectionString, int maSV)
        {
            string queryInsert = "Select_iMaSV_tblSINHVIEN";
            using (SqlConnection sqlConnetion = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnetion.CreateCommand())
                {
                    sqlCommand.CommandText = queryInsert;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@maSV", maSV);
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = sqlCommand;
                        using (DataTable dataTable = new DataTable())
                        {
                            adapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                Console.WriteLine("Ma sinh vien {0} da ton tai!", maSV);
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
    }
}
