using System;

namespace LogManager.Models
{
    public class Logger
    {
        public static void Log(
            LogApplication la = LogApplication.Dashboard,
            string logger = "",
            string message = "",
            string ipAddress = ""
        )
        {
            try
            {
                var _repository = new LogRepository();

                var model = new LogViewModel
                {
                    Application = la.ToFriendlyString(),
                    Logger = logger,
                    Level = LogLevel.None.ToString(),
                    Message = message,
                    IpAddress = ipAddress,
                    TimeStamp = DateTimeOffset.Now
                };

                _repository.Add(model);
            }
            catch (Exception)
            {
                // Logger 때문에 발생하는 예외는 무시
            }
        }

        public static void Log(
            string note = "",
            string application = "", 
            string logger = "", 
            string message = "", 
            string ipAddress = "",
            LogLevel level = LogLevel.None 
        )
        {
            try
            {
                var _repository = new LogRepository();
                
                var model = new LogViewModel
                {
                    Note = note,
                    Application = application,
                    Logger = logger,
                    Level = level.ToString(),
                    Message = message,
                    IpAddress = ipAddress,
                    TimeStamp = DateTimeOffset.Now
                };

                _repository.Add(model);
            }
            catch (Exception)
            {
                // Logger 때문에 발생하는 예외는 무시
            }
        }
    }
}
