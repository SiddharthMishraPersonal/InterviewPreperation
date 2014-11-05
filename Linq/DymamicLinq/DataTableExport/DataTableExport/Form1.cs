using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DataTableExport
{
    public partial class Form1 : Form
    {
        /// sample code from devesh omar
        /// 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Displaynotify();
        }
        protected void Displaynotify()
        {
            try
            {
                notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@"image\graph.ico"));
                notifyIcon1.Text = "Export Datatable Utlity";
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "Welcome Devesh omar to Datatable Export Utlity";
                notifyIcon1.BalloonTipText = "Click Here to see details";
                notifyIcon1.ShowBalloonTip(100);
            }
            catch (Exception ex)
            {

            }
        }
        private void btnCSV_Click(object sender, EventArgs e)
        {
            DataTable dt = OperationsUtlity.createDataTable();
            string filename = OpenSavefileDialog();
            dt.ToCSV(filename);
           
            
        }
        protected void load()
        { 
         DataTable dt = OperationsUtlity.createDataTable();
         dataGridView1.DataSource = dt;


         //notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@"image\graph.ico"));
         //notifyIcon1.Text = "Export Datatable Utlity";
         //notifyIcon1.Visible = true;
         //notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
         //notifyIcon1.BalloonTipText = "Click Here to see details";
         //string s = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
        }

       
        /// <summary>
        /// FUNCTION FOR OPENDAVEFILEDIALOG
        /// ADDED BY DEVESH 
        /// </summary>
        /// <returns></returns>
        private string OpenSavefileDialog()
        {
            string Filename = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Excel|*.xls";
            saveFileDialog.Filter = "csv File|*.csv";
            saveFileDialog.Title = "Save Report";
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                Filename = saveFileDialog.FileName;

            }

            return Filename;


        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
                    }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DEVESH !!! you clicked on notifyicon");
        }
    }
}
