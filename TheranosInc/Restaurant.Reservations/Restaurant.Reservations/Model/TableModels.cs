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
  internal class TableModels
  {
    private List<TableModel> _list;

    [XmlElement("Table")]
    public List<TableModel> ListTableModel
    {
      get { return _list; }
      set { _list = value; }
    }

    public TableModels()
    {
      ListTableModel = new List<TableModel>();
    }
  }
}