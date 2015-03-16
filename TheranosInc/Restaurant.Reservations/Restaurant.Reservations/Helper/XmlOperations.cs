using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Restaurant.Reservations.Shared.Models;

namespace Restaurant.Reservations.Helper
{
  internal static class XmlOperations
  {
    private static string _xmlFilePath;

    public static void Serialize()
    {
    }

    public static List<Table> DeSerializeTableList(string xmlFilePath)
    {
      //xmlFilePath =
      //  @"C:\Users\smishra\Documents\GitHub\InterviewPreperation\TheranosInc\Restaurant.Reservations\Restaurant.Reservations\Data\Tables.xml";
      List<Table> _tableList = null;

      _xmlFilePath = xmlFilePath;

      var xmlSerializer = new XmlSerializer(typeof (TableList));
      using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
      {
        var tableModelsObj = (TableList) xmlSerializer.Deserialize(fileStream);

        if (tableModelsObj != null)
          _tableList = tableModelsObj.ListTableModel;
      }

      return _tableList;
    }

    public static List<Reservation> DeSerializeReservationLists(string xmlFilePath)
    {
      List<Reservation> _reservationList = null;

      _xmlFilePath = xmlFilePath;

      var xmlSerializer = new XmlSerializer(typeof (ReservationList));
      using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
      {
        var tableModelsObj = (ReservationList) xmlSerializer.Deserialize(fileStream);

        if (tableModelsObj != null)
          _reservationList = tableModelsObj.TodayReservations;
      }

      return _reservationList;
    }

    public static SettingsModel DeSerializeSettings(string xmlFilePath)
    {
      SettingsModel settingsObject = null;

      _xmlFilePath = xmlFilePath;

      var xmlSerializer = new XmlSerializer(typeof (SettingsModel));
      using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
      {
        settingsObject = (SettingsModel) xmlSerializer.Deserialize(fileStream);
      }

      return settingsObject;
    }
  }
}