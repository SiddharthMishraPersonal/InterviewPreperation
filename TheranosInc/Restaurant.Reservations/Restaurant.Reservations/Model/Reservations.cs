using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Restaurant.Reservations.Model
{
  [Serializable, XmlRoot("Reservations"), XmlType("Reservations")]
  public class Reservations
  {
    private List<CustomerReservation> _todayReservations = null;

    public Reservations()
    {
      _todayReservations = new List<CustomerReservation>();
    }

    [XmlElement("Reservation")]
    public List<CustomerReservation> TodayReservations
    {
      get { return _todayReservations; }
      set { _todayReservations = value; }
    }
  }
}