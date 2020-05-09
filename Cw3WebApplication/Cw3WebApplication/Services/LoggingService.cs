using System.IO;


namespace Cw3WebApplication.Services
{
    public class LoggingService
    {
        internal void logToFile(string method, string path, string bodyStr, string queryStr)
        {
            var filepath = "Logs/requestLog.txt";
            using (StreamWriter sw = File.AppendText(filepath))
            {
                sw.WriteLine("Method: " + method
                    + ", Path: " + path
                    + ", Request Body: " + bodyStr
                    + ", QueryStr: " + queryStr
                    );
            }
        }
    }
}
