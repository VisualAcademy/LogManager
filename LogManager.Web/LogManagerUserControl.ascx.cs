using LogManager.Models;
using System;
using System.Web.UI;

namespace LogManager.Web
{
    public partial class LogManagerUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayData(0, ctlLogLists.PageSize);
            }
        }

        private void DisplayData(int pageIndex, int pageSize)
        {
            var repository = new LogRepository();

            var logs = repository.GetAllWithPaging(pageIndex, pageSize);

            ctlLogLists.VirtualItemCount = repository.GetCount();
            ctlLogLists.PageIndex = pageIndex;
            ctlLogLists.PageSize = pageSize;
            ctlLogLists.DataSource = logs;
            ctlLogLists.DataBind();
        }

        protected void ctlLogLists_PageIndexChanging(
            object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            DisplayData(e.NewPageIndex, ctlLogLists.PageSize);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // 선택한 체크 박스 정보를 배열로 받기
            string[] strArr = Request.Form.GetValues("chkSelect");

            if (strArr != null)
            {
                //for (int i = 0; i < strArr.Length; i++)
                //{
                //    // 테스트로 화면에 출력
                //    Response.Write(strArr[i] + "<br />");
                //}

                // 문자열 배열을 정수형 배열로 변경
                int[] intArr = Array.ConvertAll(strArr, int.Parse);

                var repository = new LogRepository();
                repository.DeleteByIds(intArr);
                Response.Redirect(Request.RawUrl); // 현재 페이지 다시 로드
            }
        }
    }
}
