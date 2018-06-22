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
            new string[]{ "Temperature", "Humidity", "Pressure"},
            new string[]{ "Spot status" }
        };
        public readonly int ModuleNumber;
        public readonly double[] Param;
        public ModuleStatus(int moduleNumber, double[] param)
        {
            ModuleNumber = moduleNumber;
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