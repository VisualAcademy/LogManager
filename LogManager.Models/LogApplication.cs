namespace LogManager.Models
{
    /// <summary>
    /// Logs.Application 리스트
    /// </summary>
    public enum LogApplication
    {
        /// <summary>
        /// 대시보드
        /// </summary>
        Dashboard,
        /// <summary>
        /// 로그 관리자
        /// </summary>
        LogManager,
        /// <summary>
        /// 커뮤니티 관리자
        /// </summary>
        CommunityManager,
        /// <summary>
        /// 게시판 관리자
        /// </summary>
        BoardManager,
        /// <summary>
        /// 댓글 관리자
        /// </summary>
        CommentManager,
        /// <summary>
        /// 사용자 관리자
        /// </summary>
        UserManager,
        /// <summary>
        /// 그룹 관리자
        /// </summary>
        GroupManager,
        /// <summary>
        /// 메뉴 관리자
        /// </summary>
        MenuManager,
        /// <summary>
        /// 통계 관리자
        /// </summary>
        StatisticsManager,
        /// <summary>
        /// 채팅 관리자
        /// </summary>
        ChatManager,
        /// <summary>
        /// 이벤트 관리자
        /// </summary>
        EventManager
    }

    public static class LogApplicationExtensions
    {
        public static string ToFriendlyString(this LogApplication la)
        {
            string r = "";

            switch (la)
            {
                case LogApplication.Dashboard:
                    r = "대시보드";
                    break;
                case LogApplication.LogManager:
                    r = "로그 관리자";
                    break;
                case LogApplication.CommunityManager:
                    r = "커뮤니티 관리자";
                    break;
                case LogApplication.BoardManager:
                    r = "게시판 관리자";
                    break;
                case LogApplication.CommentManager:
                    r = "댓글 관리자";
                    break;
                case LogApplication.UserManager:
                    r = "사용자 관리자";
                    break;
                case LogApplication.GroupManager:
                    r = "그룹 관리자";
                    break;
                case LogApplication.MenuManager:
                    r = "메뉴 관리자";
                    break;
                case LogApplication.StatisticsManager:
                    r = "통계 관리자";
                    break;
                case LogApplication.ChatManager:
                    r = "채팅 관리자";
                    break;
                case LogApplication.EventManager:
                    r = "이벤트 관리자";
                    break;
                default:
                    r = "대시보드";
                    break;
            }

            return r; 
        }
    }
}
