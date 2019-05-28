using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LogManager.Models
{
    public class LogRepository : ILogRepository
    {
        private readonly SqlConnection db;

        public LogRepository()
        {
            db = new SqlConnection(
                ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString);
        }

        /// <summary>
        /// 로그 저장하기
        /// </summary>
        public LogViewModel Add(LogViewModel model)
        {
            var sql = @"
                Insert Into Logs (
                    Note, 
                    Application, 
                    Logger, 
                    LogEvent, 
                    Message, 
                    MessageTemplate, 
                    Level, 
                    TimeStamp, 
                    Exception, 
                    Properties, 
                    Callsite, 
                    IpAddress) 
                Values (
                    @Note, 
                    @Application, 
                    @Logger, 
                    @LogEvent, 
                    @Message, 
                    @MessageTemplate, 
                    @Level, 
                    @TimeStamp, 
                    @Exception, 
                    @Properties, 
                    @Callsite, 
                    @IpAddress); 
        
                Select Cast(SCOPE_IDENTITY() As Int);
            ";

            var id = db.Query<int>(sql, model).Single();

            model.Id = id;
            return model;
        }

        /// <summary>
        /// 페이징 처리된 로그 리스트
        /// </summary>
        public List<LogViewModel> GetAllWithPaging(int pageIndex, int pageSize)
        {
            // 인라인 SQL(Ad Hoc 쿼리) 또는 저장 프로시저 지정
            string sql = "GetLogsWithPaging"; // 페이징 저장 프로시저

            // 파라미터 추가
            var parameters = new DynamicParameters();
            parameters.Add("@PageIndex",
                value: pageIndex,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            parameters.Add("@PageSize",
                value: pageSize,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            // 실행
            return db.Query<LogViewModel>(sql, parameters,
                commandType: CommandType.StoredProcedure).ToList();
        }

        /// <summary>
        /// 특정 번호(Id)에 해당하는 로그
        /// </summary>
        public LogViewModel GetById(int id)
        {
            string sql = "Select * From Logs Where Id = @Id";
            return db.Query<LogViewModel>(sql, new { id }).SingleOrDefault();
        }

        /// <summary>
        /// 로그 테이블의 전체 레코드 수
        /// </summary>
        public int GetCount()
        {
            var sql = "Select Count(*) From Logs";

            return db.Query<int>(sql).Single();
        }

        /// <summary>
        /// 선택 삭제
        /// </summary>
        public void DeleteByIds(params int[] ids)
        {
            string sql = "Delete Logs Where Id In @Ids";
            db.Execute(sql, new { Ids = ids });
        }
    }
}
