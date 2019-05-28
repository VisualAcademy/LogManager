using System.Collections.Generic;

namespace LogManager.Models
{
    public interface ILogRepository
    {
        LogViewModel Add(LogViewModel model);           // 로그 기록
        List<LogViewModel> GetAllWithPaging(
            int pageIndex, int pageSize);               // 로그 리스트
        LogViewModel GetById(int id);                   // 로그 상세 보기

        int GetCount();                                 // 전체 레코드수

        void DeleteByIds(params int[] ids);             // 선택 삭제
    }
}
