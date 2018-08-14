using System;
using System.Collections.Generic;

namespace MissionPlanner.Controls
{
    public class ModuleStatus
    {
        private static string[] ModuleName = {
            "Error or APM\nnot connected",
            "No module",
            "Spotlight module",
            "Sprinkler module",
            "Delivery module",
            "Meteorological module"
        };
        private static string[][] ParameterName = {
            new string[]{ },
            new string[]{ },
            //new string[]{ "Spotlight status", "PWM value" }, //first prototype
            new string[]{ "Spotlight status", "PWM value", "Blinking frequency (in ms)"},
            new string[]{ "Pump status", "Water level (percent)", "Water level value"},
            new string[]{ "Package presence", "Pin status", "Echo distance (in cm)", "PWM value"},
            new string[]{ "Temperature (in °C)", "Humidity (in %)", "Luminosity (H=0, L=1023)"}
        };

        //Parameter in the same order as in the transmitted message, some are of type string to avoid data loss
        public readonly int MessageNumberAPM = -1;
        public readonly string[] PositionFieldsValue;
        public static string[] PositionFieldsName = {"Latitude", "Longitude", "Altitude"};
        public readonly ulong MillisecondsSinceAPMStart;

        public int ModuleNumber; //not marked as readonly to allow Error or disconnecting detection and signalisation
        public readonly int MessageNumberController = -1;
        public string[] Parameters; //not marked as readonly to allow Error or disconnecting detection and signalisation


        public ModuleStatus(ThesisMessageEventArgs args)
        {
            string message = args.Message;
            if (message.StartsWith("\nAPM:") && !message.Substring(1).Contains("\n"))
            {
                String[] tmpData = message.Split('/');
                if (tmpData[tmpData.Length - 1].EndsWith(";"))
                {
                    int messageNumberAPM = Int32.Parse(tmpData[0].Split(':')[1]);
                    string longitude = tmpData[1].Split(':')[1];
                    string latitude = tmpData[2].Split(':')[1];
                    string altitude = tmpData[3].Split(':')[1];
                    ulong millisecondsSinceAPMStart = ulong.Parse(tmpData[4].Split(':')[1]);
                    int moduleNumber = Int32.Parse(tmpData[5].Split(':')[1]);

                    int messageNumberController;
                    try
                    {
                        messageNumberController = Int32.Parse(tmpData[6].Split(':')[1]);
                    }
                    catch (Exception)
                    {
                        messageNumberController = -1;
                    }
                    List<string> parameters = new List<string>();
                    for (int i = 7; i < (7 + GetNumberParameter(moduleNumber)); i++)
                    {
                        parameters.Add(tmpData[i].Split(':')[1]);
                    }
                    ModuleNumber = moduleNumber;
                    PositionFieldsValue = new string[] { longitude, latitude, altitude };
                    MessageNumberAPM = messageNumberAPM;
                    Parameters = parameters.ToArray();
                    MessageNumberController = messageNumberController;
                    MillisecondsSinceAPMStart = millisecondsSinceAPMStart;
                }
            }
            else
                throw new Exception();
        }

        public ModuleStatus(int moduleNumber, string longitude, string latitude, string altitude, string[] parameters, int messageNumberAPM = -1, int messageNumberController = -1, ulong millisecondsSinceAPMStart = 0)
        {
            ModuleNumber = moduleNumber;
            PositionFieldsValue = new string[]{longitude, latitude, altitude};
            MessageNumberAPM = messageNumberAPM;
            Parameters = parameters;
            MessageNumberController = messageNumberController;
            MillisecondsSinceAPMStart = millisecondsSinceAPMStart;
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