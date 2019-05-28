<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="LogManagerUserControl.ascx.cs"
    Inherits="LogManager.Web.LogManagerUserControl" %>
<style>
    .GridPagerStyle {
        padding: 10px;
        margin: 5px;
    }
</style>
<script>
    //[1] 체크박스 전체 선택 및 전체 해제
    var chkFlag = false; // 체크 해제된 상태
    function CheckAll(arrSelect) {
        if (chkFlag == false) {
            for (var i = 0; i < arrSelect.length; i++) {
                arrSelect[i].checked = true; // 체크박스 선택
            }
            chkFlag = true;
            return "전체해제";
        }
        else {
            for (var i = 0; i < arrSelect.length; i++) {
                arrSelect[i].checked = false; // 체크박스 해제
            }
            chkFlag = false;
            return "전체선택";
        }
    }
    //[2] 체크 박스 선택 시 해당 행의 배경색 변경
    $(function () {
        $('input[name="chkSelect"]').on('change', function () {
            $(this)
                .closest('tr')
                    .toggleClass('info',
                        $(this).is(':checked'));
        });
        $("#btnCheckAll").on('click', function () {
            $('input[name="chkSelect"]')
                .closest('tr')
                    .toggleClass('info',
                        $('input[name = "chkSelect"]'
                            ).is(':checked'));
        });
    });
</script>

<div class="row">
    <h1>로그 관리자</h1>

    <asp:GridView ID="ctlLogLists" runat="server"
        CssClass="table table-bordered table-striped table-hover"
        AutoGenerateColumns="false"
        AllowPaging="true"
        OnPageIndexChanging="ctlLogLists_PageIndexChanging"
        AllowCustomPaging="true"
        PageSize="10"
        ItemType="LogManager.Models.LogViewModel">
        <PagerStyle Font-Size="Large" CssClass="GridPagerStyle" />
        <Columns>
            <asp:TemplateField
                HeaderStyle-CssClass="text-center"
                ItemStyle-CssClass="text-center">
                <HeaderTemplate>
                    <input type="button"
                        id="btnCheckAll"
                        value="전체선택"
                        class="btn btn-sm btn-default"
                        onclick="this.value=CheckAll(this.form.chkSelect);" />
                </HeaderTemplate>
                <ItemTemplate>
                    <input type="checkbox" name="chkSelect"
                        value="<%# Item.Id %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="번호" />
            <asp:BoundField DataField="Application" HeaderText="앱 위치" />
            <asp:BoundField DataField="TimeStamp" HeaderText="시간" />
            <asp:BoundField DataField="Message" HeaderText="로그 메시지" />
            <asp:BoundField DataField="Logger" HeaderText="사용자" />
            <asp:BoundField DataField="IpAddress" HeaderText="IP 주소" />
        </Columns>
    </asp:GridView>
</div>
<div class="row text-right">
    <asp:Button ID="btnDelete" runat="server"
        Text="선택 삭제" CssClass="btn btn-danger btn-sm"
        OnClick="btnDelete_Click" />
</div>
