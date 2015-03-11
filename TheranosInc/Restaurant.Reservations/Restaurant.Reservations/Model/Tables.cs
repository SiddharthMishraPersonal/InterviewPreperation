using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Serialization;

namespace Restaurant.Reservations.Model
{
  [Serializable, XmlRoot("Tables"), XmlType("Tables")]
  internal class Tables
  {
    private List<Table> _list;

    [XmlElement("Table")]
    public List<Table> ListTableModel
    {
      get { return _list; }
      set { _list = value; }
    }

    public Tables()
    {
      ListTableModel = new List<Table>();
    }
  }
}