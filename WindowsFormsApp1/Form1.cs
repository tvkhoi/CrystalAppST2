using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private ErrorProvider errorProvider = new ErrorProvider();
        private DataView dv_cbMaLop = new DataView();
        private DataView dv_dgv = new DataView();
        private string ngaySinh;
        private string gioiTinh;
        private string reportFilter;

        public Form1()
        {
            InitializeComponent();
        }

        private void ShowDSLop()
        {
            string querySelect = "Select_tblLOP";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = querySelect;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            using (DataTable dataTable = new DataTable())
                            {
                                dataTable.Clear();
                                adapter.Fill(dataTable);

                                if (dataTable.Rows.Count > 0)
                                {
                                    dv_cbMaLop = dataTable.DefaultView;
                                    dgv_dssv.DataSource = dv_cbMaLop;
                                    foreach (DataRowView dataRow in dv_cbMaLop)
                                    {
                                        cb_malop.Items.Add(dataRow["sMaLop"]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowData(string filter = "")
        {
            string querySelect = "Select_TongHop";
            using (SqlConnection sqlConnetion = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnetion.CreateCommand())
                {
                    sqlCommand.CommandText = querySelect;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = sqlCommand;
                        using (DataTable dataTable = new DataTable())
                        {
                            adapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                dv_dgv = dataTable.DefaultView;
                                dgv_dssv.AutoGenerateColumns = false;
                                if (!string.IsNullOrEmpty(filter))
                                {
                                    dv_dgv.RowFilter = filter;
                                }
                                dgv_dssv.DataSource = dv_dgv;
                            }
                            else
                            {
                                MessageBox.Show("Khong co ban ghi nao");
                            }
                        }
                    }
                }
            }
        }
        private void ResetData()
        {
            tb_masv.Text =
            tb_tensv.Text =
            tb_sdt.Text =
            tb_diachi.Text =
            tb_tencvht.Text = 
            cb_malop.Text = string.Empty;
            mask_ngaysinh.ResetText();
            tb_masv.Focus();
        }

        public bool IsNumber(string strValue)
        {
            foreach (Char ch in strValue)
            {
                if (!Char.IsDigit(ch))
                    return false;
            }
            return true;
        }

        public bool IsGender(string gender)
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

        private void tb_masv_TextChanged(object sender, EventArgs e)
        {
            if ((this.tb_masv.Text.Length > 0) == true)
            {
                btn_them.Enabled = true;
            }
            else
            {
                btn_them.Enabled = false;

            }
        }
        private void tb_masv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_masv.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(tb_masv, "Mã sinh viên không được để trống");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tb_masv, null);
            }
        }

        private void tb_tensv_TextChanged(object sender, EventArgs e)
        {
            if ((this.tb_tensv.Text.Length > 0) == true)
            {
                btn_them.Enabled = true;
            }
            else
            {
                btn_them.Enabled = false;

            }
        }

        private void tb_tensv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_tensv.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(tb_tensv, "Tên sinh viên không được để trống");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tb_tensv, null);
            }
        }

        private void tb_sdt_TextChanged(object sender, EventArgs e)
        {
            if (!IsNumber(tb_sdt.Text))
            {
                btn_them.Enabled = false;
            }
            else
            {
                btn_them.Enabled = true;
            }
        }

        private void tb_sdt_Validating(object sender, CancelEventArgs e)
        {
            if (!IsNumber(tb_sdt.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(tb_sdt, "Số điện thoại không hợp lệ");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tb_sdt, null);
            }
        }

        private void mask_ngaysinh_Validating(object sender, CancelEventArgs e)
        {
            if (mask_ngaysinh.MaskFull)
            {
                try
                {
                    DateTime dateTime = Convert.ToDateTime(mask_ngaysinh.Text);
                    ngaySinh = dateTime.ToString("yyyy/MM/d");
                }
                catch
                {
                    MessageBox.Show("Ngày không hợp lệ");
                    mask_ngaysinh.ResetText();
                }
            }
        }

        private void dt_ngaysinh_ValueChanged(object sender, EventArgs e)
        {
            mask_ngaysinh.Text = dt_ngaysinh.Value.ToString();
            DateTime dateTime1 = Convert.ToDateTime(mask_ngaysinh.Text);
            ngaySinh = dateTime1.ToString("yyyy/MM/d");
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (rb_nam.Checked == true)
            {
                gioiTinh = "nam";
            }
            else if (rb_nu.Checked == true)
            {
                gioiTinh = "nữ";
            }

            string idSV = tb_masv.Text;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = "Select_iMaSV_tblSINHVIEN";
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@maSV", idSV);
                        sqlConnection.Open();
                        var idSV_sql = sqlCommand.ExecuteScalar();
                        sqlConnection.Close();

                        if (idSV_sql == null)
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter())
                            {
                                //Lấy danh sách sinh viên vào dataTable
                                adapter.SelectCommand = new SqlCommand("SELECT * FROM tblSINHVIEN", sqlConnection);
                                DataTable dtSINHVIEN = new DataTable("tblSINHVIEN");
                                adapter.Fill(dtSINHVIEN);

                                //add từng dataTable và dataSet
                                DataSet ds = new DataSet();
                                ds.Tables.Add(dtSINHVIEN);

                                //thêm bản ghi vào trong dataTable
                                DataRow newRow = dtSINHVIEN.NewRow();
                                newRow["sMaSV"] = this.tb_masv.Text;
                                newRow["sHoTen"] = this.tb_tensv.Text;
                                newRow["dNgaySinh"] = ngaySinh;
                                newRow["bGioiTinh"] = IsGender(gioiTinh);
                                newRow["sDiaChi"] = this.tb_diachi.Text;
                                newRow["sSoDienThoai"] = this.tb_sdt.Text;
                                newRow["sMaLop"] = this.cb_malop.Text;
                                dtSINHVIEN.Rows.Add(newRow);

                                //thêm bản ghi vào CSDL thực hiện InsertCommand
                                sqlCommand.CommandText = "Insert_tblSINHVIEN";
                                sqlCommand.Parameters.Clear();
                                sqlCommand.Parameters.AddWithValue("@maSV", this.tb_masv.Text);
                                sqlCommand.Parameters.AddWithValue("@tenSV", this.tb_tensv.Text);
                                sqlCommand.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                                sqlCommand.Parameters.AddWithValue("@diaChi", this.tb_diachi.Text);
                                sqlCommand.Parameters.AddWithValue("@soDienThoai", this.tb_sdt.Text);
                                sqlCommand.Parameters.AddWithValue("@gioiTinh", IsGender(gioiTinh));
                                sqlCommand.Parameters.AddWithValue("@maLop", this.cb_malop.Text);

                                adapter.InsertCommand = sqlCommand;
                                adapter.Update(ds, "tblSINHVIEN");

                                MessageBox.Show("Thêm mới thành công");

                                ShowData();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã Khách hàng " + idSV + " đã tồn tại", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            
            ResetData();
        }

        private void btn_huybo_Click(object sender, EventArgs e)
        {
            tb_masv.ReadOnly = false;
            ResetData();
        }

        private void btn_chinhsua_Click(object sender, EventArgs e)
        {
            if (rb_nam.Checked == true)
            {
                gioiTinh = "nam";
            }
            else if (rb_nu.Checked == true)
            {
                gioiTinh = "nữ";
            }

            string queryUpdate = "Update_tblSINHVIEN";
            try
            {
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
                        dtSINHVIEN.PrimaryKey = new DataColumn[] { dtSINHVIEN.Columns["sMaSV"] };
                        DataRow dataRow = dtSINHVIEN.Rows.Find(tb_masv.Text);
                        dataRow["sHoTen"] = this.tb_tensv.Text;
                        dataRow["dNgaySinh"] = ngaySinh;
                        dataRow["bGioiTinh"] = IsGender(gioiTinh);
                        dataRow["sDiaChi"] = this.tb_diachi.Text;
                        dataRow["sSoDienThoai"] = this.tb_sdt.Text;
                        dataRow["sMaLop"] = this.cb_malop.Text;

                        //thực hiện UpdateCommand
                        using (SqlCommand sqlCommand = sqlConnetion.CreateCommand())
                        {
                            sqlCommand.CommandText = queryUpdate;
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@maSV", this.tb_masv.Text);
                            sqlCommand.Parameters.AddWithValue("@tenSV", this.tb_tensv.Text);
                            sqlCommand.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                            sqlCommand.Parameters.AddWithValue("@diaChi", this.tb_diachi.Text);
                            sqlCommand.Parameters.AddWithValue("@soDienThoai", this.tb_sdt.Text);
                            sqlCommand.Parameters.AddWithValue("@gioiTinh", IsGender(gioiTinh));
                            sqlCommand.Parameters.AddWithValue("@maLop", this.cb_malop.Text);

                            adapter.UpdateCommand = sqlCommand;
                            adapter.Update(ds, "tblSINHVIEN");
                            MessageBox.Show("Chỉnh sửa thành công");

                            ShowData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra" + ex);
            }

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            ShowDSLop();
            ShowData();
            
        }

        private void dgv_dssv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgv_dssv.CurrentRow.Index;
            //tb_masv.Text = dv_dgv[index]["sMaSV"].ToString();
            tb_masv.Text = dgv_dssv.Rows[index].Cells["MaSV"].Value.ToString();
            tb_masv.ReadOnly = true;
            tb_tensv.Text = dv_dgv[index]["sHoTen"].ToString();
            tb_diachi.Text = dv_dgv[index]["sDiaChi"].ToString();
            mask_ngaysinh.Text = dv_dgv[index]["dNgaySinh"].ToString();
            DateTime dateTime = Convert.ToDateTime(mask_ngaysinh.Text);
            ngaySinh = dateTime.ToString("yyyy/MM/d");
            tb_sdt.Text = dv_dgv[index]["sSoDienThoai"].ToString();
            cb_malop.Text = dv_dgv[index]["sMaLop"].ToString();
            tb_tencvht.Text = dv_dgv[index]["sHoTenGV"].ToString();
            if (dv_dgv[index]["bGioiTinh"].ToString().ToLower() == "nam")
            {
                rb_nam.Checked = true;
            }
            else
            {
                rb_nu.Checked = true;
            }
        }

        private void btn_xoabo_Click(object sender, EventArgs e)
        {
            int index = dgv_dssv.CurrentRow.Index;
            string maSV = dv_dgv[index]["sMaSV"].ToString();

            try
            {
                //Xóa
                DialogResult h = MessageBox.Show("Có muốn xóa mã khách hàng " + maSV + " thật không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (h == DialogResult.Yes)
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
                            dtSINHVIEN.PrimaryKey = new DataColumn[] { dtSINHVIEN.Columns["sMaSV"] };
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

                            }
                        }
                    }
                    ResetData();
                    ShowData();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string filter = "sMaSV IS NOT NULL";
            if (!string.IsNullOrEmpty(tb_masv.Text.Trim()))
            {
                filter += string.Format(" AND sMaSV LIKE '%{0}%'", tb_masv.Text);
            }
            if (!string.IsNullOrEmpty(tb_tensv.Text.Trim()))
            {
                filter += string.Format(" AND sHoTen LIKE '%{0}%'", tb_tensv.Text);
            }
            ShowData(filter);
        }

        private void cb_malop_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cb_malop.SelectedIndex;
            string malop = dv_cbMaLop[index]["sMaLop"].ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                    {
                        sqlCommand.CommandText = "SELECT_TenGV";
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@maLop", malop);
                        sqlConnection.Open();

                        var a = sqlCommand.ExecuteScalar();
                        tb_tencvht.Text = a.ToString();
                        sqlConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cb_malop_Validating(object sender, CancelEventArgs e)
        {
            string malop = cb_malop.Text.ToUpper();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "Select_sMaLop";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@maLop", malop);
                    sqlConnection.Open();
                    var a = sqlCommand.ExecuteScalar();
                    sqlConnection.Close();

                    if (a != null)
                    {
                        e.Cancel = false;
                        errorProvider.SetError(cb_malop, null);
                    }
                    else
                    {
                        e.Cancel = true;
                        errorProvider.SetError(cb_malop, "Không đúng định dạng");
                    }
                }
            }
        }

        private void cb_malop_TextChanged(object sender, EventArgs e)
        {
            btn_them.Enabled = true;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_inDSSV_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.ShowReport("DDSV.rpt", "Select_TongHop");
        }

        private void btn_group_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.ShowReport("DDSVPhanNhom.rpt", "Select_TongHop");
        }

        private void btn_inbangdiem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
