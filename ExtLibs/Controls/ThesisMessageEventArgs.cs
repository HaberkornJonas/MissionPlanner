namespace MissionPlanner.Controls
{
    /// <summary>
    /// Class that olds the main infos about a ThesisMessage.
    /// </summary>
    public class ThesisMessageEventArgs
    {
        public readonly string Message;

        /// <summary>
        /// ThesisMessageEventArgs Constructor.
        /// </summary>
        /// <param name="message">Message received</param>
        public ThesisMessageEventArgs(string message)
        {
            Message = message;
        }

    }
}
