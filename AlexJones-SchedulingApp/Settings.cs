using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AlexJones_SchedulingApp
{
    public static class Settings
    {
        private static string settingsFilename = "settings.xml";
        private static string databasePassword;

        public static List<string> AppointmentTypes { get; } = new List<string>() { "Scrum", "Presentation", "Evalutation", "Meeting" };
        public static string DBServer { get; private set; }
        public static int DBPort { get; private set; }
        public static string DBSchema { get; private set; }
        public static string DBUser { get; private set; }
        public static string DBConnectionString { get; private set; }
        public static void Initialize()
        {
            if (File.Exists(settingsFilename))
            {
                LoadFromFile();
            }
            else
            {
                LoadFromNull();
            }
            DBConnectionString = $"SERVER={DBServer}; PORT={DBPort}; DATABASE={DBSchema}; UId={DBUser}; PASSWORD={databasePassword};";
        }

        private static void LoadFromFile()
        {
            XDocument settings = XDocument.Load(settingsFilename);
            XElement connectionElement = settings.Element("Settings").Element("Connection");

            DBServer = connectionElement.Element("Server").Value;
            DBPort = int.Parse(connectionElement.Element("Port").Value);
            DBSchema = connectionElement.Element("Schema").Value;
            DBUser = connectionElement.Element("User").Value;
            databasePassword = connectionElement.Element("Password").Value;
        }

        private static void LoadFromNull()
        {
            DBServer = "wgudb.ucertify.com";
            DBPort = 3306;
            DBSchema = "U07v8q";
            DBUser = "U07v8q";
            databasePassword = "53689143851";

            XElement settingsElement = new XElement("Settings");
            XElement connectionElement = new XElement("Connection");

            XElement dbServerElement = new XElement("Server", DBServer);
            XElement dbPortElement = new XElement("Port", DBPort);
            XElement dbSchemaElement = new XElement("Schema", DBSchema);
            XElement dbUserElement = new XElement("User", DBUser);
            XElement dbPasswordElement = new XElement("Password", databasePassword);

            connectionElement.Add(dbServerElement);
            connectionElement.Add(dbPortElement);
            connectionElement.Add(dbSchemaElement);
            connectionElement.Add(dbUserElement);
            connectionElement.Add(dbPasswordElement);

            settingsElement.Add(connectionElement);

            XDocument settingsFile = new XDocument();

            settingsFile.Add(settingsElement);
            settingsFile.Save(settingsFilename);
        }
    }
}
