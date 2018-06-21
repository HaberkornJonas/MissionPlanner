namespace MissionPlanner.Controls
{
    public class ModuleStatus
    {
        public readonly int ModuleNumber;
        public readonly double[] Param;
        public ModuleStatus(int moduleNumber, double[] param)
        {
            ModuleNumber = moduleNumber;
            Param = param;
        }

    }
}