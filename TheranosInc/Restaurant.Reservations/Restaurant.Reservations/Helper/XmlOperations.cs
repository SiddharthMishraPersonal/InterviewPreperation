using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Restaurant.Reservations.Model;

namespace Restaurant.Reservations.Helper
{
  internal static class XmlOperations
  {
    private static string _xmlFilePath;

    public static void Serialize()
    {
    }

    public static List<Table> DeSerialize(string xmlFilePath)
    {
      //xmlFilePath =
      //  @"C:\Users\smishra\Documents\GitHub\InterviewPreperation\TheranosInc\Restaurant.Reservations\Restaurant.Reservations\Data\Tables.xml";
      List<Table> _tableList = null;

      _xmlFilePath = xmlFilePath;

      var xmlSerializer = new XmlSerializer(typeof(Tables));
      using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
      {
        var tableModelsObj = (Tables)xmlSerializer.Deserialize(fileStream);

        if (tableModelsObj != null)
          _tableList = tableModelsObj.ListTableModel;
      }

      return _tableList;
    }
  }
}