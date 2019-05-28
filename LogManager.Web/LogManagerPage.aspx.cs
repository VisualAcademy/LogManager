using LogManager.Models;
using System;
using System.Web.UI;

namespace LogManager.Web
{
    public partial class LogManagerPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Logger.Log(
                    LogApplication.CommunityManager,
                    "관리자",
                    "새로운 로그 메서드로 접속",
                    Request.UserHostAddress);

                Logger.Log(
                    application: "로그 관리자",
                    message: "관리자가 로그 관리자 페이지 접속했습니다.",
                    logger: "Admin",
                    ipAddress: Request.UserHostAddress);
            }
        }
    }
}
