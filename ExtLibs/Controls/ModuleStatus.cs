namespace MissionPlanner.Controls
{
    public class ModuleStatus
    {
        private static string[] ModuleName = {
            "Error or APM\nnot connected",
            "No module",
            "Delivery module",
            "Sprinkler module",
            "Weather module",
            "Light spot module"
        };
        private static string[][] ParameterName = {
            new string[]{ },
            new string[]{ },
            new string[]{ "param 1", "param 2", "param 3"},
            new string[]{ "Pump status"},
            new string[]{ "Temperature", "Humidity", "Luminosity"},
            new string[]{ "Spot status" }
        };

        public int ModuleNumber;
        public string[] Param;
        public readonly int MessageNumber;

        // These 3 parameter are of type string to avoid convertion lost
        public readonly string[] PositionFieldsValue;
        public static string[] PositionFieldsName = { "Latitude", "Longitude", "Altitude" };



        public ModuleStatus(int moduleNumber, string longitude, string latitude, string altitude, string[] param, int messageNumber = -1)
        {
            ModuleNumber = moduleNumber;
            PositionFieldsValue = new string[]{longitude, latitude, altitude};
            MessageNumber = messageNumber;
            Param = param;
        }

        public static string GetModuleName(int moduleNumber)
        {
            return ModuleName[moduleNumber + 1];
        }

        public static string GetParameterName(int moduleNumber, int parameterNumber)
        {
            return ParameterName[moduleNumber + 1][parameterNumber];
        }

        public static int GetNumberParameter(int moduleNumber)
        {
            return ParameterName[moduleNumber + 1].Length;
        }

    }
}