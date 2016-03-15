using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLibrary
{
    using System.Windows.Forms;

    public class MessageBoxOutputService : IOutputService
    {
        public void WriteMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
