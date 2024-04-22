using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
        }

        public void ShowReport(string tenBaoCao, string tenProc, string reportFilter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using(SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = tenProc;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using(SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            using(DataTable dt = new DataTable())
                            {
                                adapter.Fill(dt);

                                //Load du lieu len bao cao
                                ReportDocument report = new ReportDocument();
                                string path = string.Format("{0}\\Report\\{1}",
                                    Application.StartupPath, tenBaoCao);
                                report.Load(path);

                                report.Database.Tables[tenProc].SetDataSource(dt);

                                report.SetParameterValue("sNguoiLapBieu", "NDPT");

                                //đặt điều kiện để lọc các bản ghi hiển thị lên báo cáo
                                if(reportFilter != null)
                                {
                                    report.RecordSelectionFormula = reportFilter;
                                }
                                
                                
                                crystalReportViewer.ReportSource = report;
                                crystalReportViewer.Refresh();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
