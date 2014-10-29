using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusyIndicator
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      Load += Form1_Load;
    }

    void Form1_Load(object sender, EventArgs e)
    {
      usBusyIndicator1.Hide();
    }

    private void btnShow_Click(object sender, EventArgs e)
    {
      usBusyIndicator1.Show();
      usBusyIndicator1.BackColor = Color.FromArgb(10, 0, 0, 0);
    }

    private void btnHide_Click(object sender, EventArgs e)
    {
      usBusyIndicator1.Hide();
      usBusyIndicator1.BackColor = Color.FromArgb(10, 0, 0, 0);
    }
  }
}
