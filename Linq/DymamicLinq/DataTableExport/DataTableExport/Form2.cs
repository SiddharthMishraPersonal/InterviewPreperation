using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;

namespace DataTableExport
{


    public partial class Form2 : Form
    {
        List<Customer> liCust = null;
        List<Order> liOrder = null;

        //Code from devesh omar
        public class Customer
        {
            public int CustomerID { get; set; }
            public int OrderId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAddress { get; set; }
            public string CustomerPinCode { get; set; }
            public string CustomerPhoneNumber { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerOffice { get; set; }
            public string LocationCode { get; set; }

            public Customer(int custid, int orderid, string custname, string cusAddress,
                string custtPin, string custPhone, string CustEmail
                , string CustOffice, string LocCode)
            {

                this.CustomerID = custid;this.OrderId = orderid;  this.CustomerName = custname;
                this.CustomerAddress = cusAddress; this.CustomerPinCode = custtPin;
                this.CustomerPhoneNumber = custPhone; this.CustomerEmail = CustEmail;
                this.CustomerOffice = CustOffice;this.LocationCode = LocCode;

            }

        }
        //Code from devesh omar
        public class Order
        {
            public int OrderId { get; set; }
            public string ProductName { get; set; }
            public string ProductCost { get; set; }
            public string ProductQunatity { get; set; }
            public Order( int orderid, string pName, string pCost, string Pquant)
            {
                this.OrderId = orderid; this.ProductCost = pCost;
                this.ProductQunatity = Pquant; this.ProductName = pName;
            }

        }

        DataTable tableCustomer = null;
        DataTable tableOrder = null;
        
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {

            liCust = new List<Customer>();

            Customer oCust = new Customer(001, 123000, "Devesh", "Ghaziabad", "250301", 
                "9891586890", "devesh.akgec@gmail.com", "Genpact", "3123000");
            liCust.Add(oCust);
            oCust = new Customer(002, 123001, "NIKHIL", "NOIDA", "250201", 
                "xxx9892224", "devesh.akgec@gmail.com", "X-vainat", "4123001");
            liCust.Add(oCust);
            oCust = new Customer(003, 123002, "Shruti", "NOIDA", "25001",
                "xxx0002345", "devesh.akgec@gmail.com", "Genpact", "5123002");
            liCust.Add(oCust);
            oCust = new Customer(004, 123003, "RAJ", "DELHI", "2500133", 
                "xxx9898907", "devesh.akgec@gmail.com", "HCL", "6123003");
            liCust.Add(oCust);
            oCust = new Customer(005, 123004, "Shubham", "Patna", "250013",
                "x222333xx3", "devesh.akgec@gmail.com", "Genpact", "6123004");
            liCust.Add(oCust);
          

            //order data
            liOrder = new List<Order>();
            Order oOrder = new Order(123000, "Noika Lumia", "7000", "2");
            liOrder.Add(oOrder);
            oOrder = new Order(123001, "Moto G", "17000", "1");
            liOrder.Add(oOrder);
            oOrder = new Order(123002, "Intext Mobile", "7000", "1");
            liOrder.Add(oOrder);
            oOrder = new Order(123001, "Celkom GX898", "2500", "1");
            liOrder.Add(oOrder);
            oOrder = new Order(123001, "Micromax", "1000", "10");
            liOrder.Add(oOrder);
            oOrder = new Order(222, "NOIKA Asha", "2500", "1");
            liOrder.Add(oOrder);
            oOrder = new Order(22212, "Iphone", "1000", "10");
            liOrder.Add(oOrder);

            DrgCustomer.DataSource = liCust;
            drgOrder.DataSource = liOrder;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //var result = from T1 in tableCustomer.AsEnumerable()
            //             join T2 in tableOrder.AsEnumerable()
            //             on T1.Field<int>("OrderId") equals T2.Field<int>("OrderId")
            //             select T2.Field<int>("OrderId");

        }
        protected void table()
        {


            tableCustomer = new DataTable();
            //columns
            tableCustomer.Columns.Add("CustomerID", typeof(int));
            tableCustomer.Columns.Add("OrderId", typeof(int));
            tableCustomer.Columns.Add("CustomerName", typeof(string));
            tableCustomer.Columns.Add("CustomerAddress", typeof(string));
            tableCustomer.Columns.Add("CustomerPinCode", typeof(string));
            tableCustomer.Columns.Add("CustomerPhoneNumber", typeof(string));
            tableCustomer.Columns.Add("CustomerEmail", typeof(string));
            tableCustomer.Columns.Add("CustomerOffice", typeof(string));
            tableCustomer.Columns.Add("LocationCode", typeof(int));

            tableCustomer.Rows.Add(001, 123000, "Devesh", "Ghaziabad", "250301", "9891586890", "devesh.akgec@gmail.com", "Genpact", 3123000);
            tableCustomer.Rows.Add(002, 123001, "NIKHIL", "NOIDA", "250201", "xxx9892224", "devesh.akgec@gmail.com", "X-vainat", 4123001);
            tableCustomer.Rows.Add(003, 123002, "Shruti", "NOIDA", "25001", "xxx0002345", "devesh.akgec@gmail.com", "Genpact", 5123002);
            tableCustomer.Rows.Add(004, 123003, "RAJ", "DELHI", "2500133", "xxx9898907", "devesh.akgec@gmail.com", "HCL", 6123003);
            tableCustomer.Rows.Add(005, 123004, "Shubham", "Patna", "250013", "x222333xx3", "devesh.akgec@gmail.com", "Genpact", 6123004);


            tableOrder = new DataTable();
            tableOrder.Columns.Add("OrderID", typeof(int));
            tableOrder.Columns.Add("ProductName", typeof(string));
            tableOrder.Columns.Add("ProductCost", typeof(string));
            tableOrder.Columns.Add("ProductQunatity", typeof(int));

            //data
            tableOrder.Rows.Add(123000, "Noika Lumia", 7000, 2);
            tableOrder.Rows.Add(123001, "Moto G", 17000, 1);
            tableOrder.Rows.Add(123002, "Intext Mobile", 7000, 1);
            tableOrder.Rows.Add(123001, "Celkom GX898", 2500, 1);
            tableOrder.Rows.Add(123001, "Micromax", 1000, 10);
            tableOrder.Rows.Add(222, "NOIKA Asha", 2500, 1);
            tableOrder.Rows.Add(22212, "Iphone", 1000, 10);
            //"new (T1.OrderId,T1.CustomerName,T1.CustomerID,T2.ProductCost,T2.ProductName)"

            DrgCustomer.DataSource = tableCustomer;
            drgOrder.DataSource = tableOrder;
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            // code from devesh omar
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var result = (from T1 in liCust
                          join T2 in liOrder
                            on T1.OrderId equals T2.OrderId
                            select new { T1,T2}).AsQueryable();


            string selectStatement= "new ( " + textSelectStatement.Text +")";
            IQueryable iq = result.Select(selectStatement);

            int i = 0;
            foreach ( var data in iq)
            {
               List<object> li = new List<object>();
               if (i == 0)
               {
                   string[] str = data.ToString().Replace("{", "").Replace("}", "").Split(',');

                   foreach (string col in str)
                   {

                       string colname = col.Substring(0, col.IndexOf("="));
                       string dataValue = col.Substring(col.IndexOf("=") + 1);
                       li.Add(dataValue);
                       dataGridView1.Columns.Add(colname, colname);

                   }
               }
               else
               {
                   string[] str = data.ToString().Replace("{", "").Replace("}", "").Split(',');

                   foreach (string col in str)
                   {

                       string colname = col.Substring(0, col.IndexOf("="));
                       string dataValue = col.Substring(col.IndexOf("=") + 1);
                       li.Add(dataValue);

                   }
                  
               }

               dataGridView1.Rows.Add(li.ToArray());
               i++;


           }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
