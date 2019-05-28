using LogManager.Models;
using System;

namespace LogManager
{
    class LogManager
    {
        static void Main(string[] args)
        {
            ILogRepository repository = new LogRepository();

            //var m = repository.Add(new LogViewModel
            //{
            //    Note = "로그 기록",
            //    Application = "콘솔",
            //    Logger = "나",
            //    Message = "데이터를 입력했습니다.",
            //    IpAddress = "127.0.0.1",
            //    TimeStamp = DateTimeOffset.Now
            //});
            
            Logger.Log(
                logger: "관리자", 
                message: "대시보드에 로그인했습니다.", 
                ipAddress: "127.0.0.1", 
                level: LogLevel.Information, 
                application: "관리자모드");

            var logs = repository.GetAllWithPaging(0, 100);
            foreach (var log in logs)
            {
                Console.WriteLine($"{log.Id}, {log.Logger}, {log.Message}");
            }
        }
    }
}
