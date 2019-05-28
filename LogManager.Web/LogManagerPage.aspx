<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="LogManagerPage.aspx.cs"
    Inherits="LogManager.Web.LogManagerPage" %>

<%@ Register Src="~/LogManagerUserControl.ascx"
    TagPrefix="uc1" TagName="LogManagerUserControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>로그 관리자</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <uc1:LogManagerUserControl runat="server" 
                ID="LogManagerUserControl" />
        </div>
    </form>
</body>
</html>
