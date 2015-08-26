<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowRemarksControl.ascx.cs" Inherits="EmployeeManagementWidget.ShowRemarksControl" %>
<asp:Panel ID="Remarks" runat="server" Visible="true">
    <div class="pull-right">
        <asp:Button ID="Button1" runat="server" Text="Logout" OnClick="RedirectToLogout" BackColor="Black" ForeColor="White" Width="104px" />
        <asp:Button ID="Button2" runat="server" OnClick="RedirectToChangePassword" Text="ChangePassword" BackColor="Black" ForeColor="White" Width="116px" />
    </div>

    <asp:GridView ID="EmpGridView" runat="server" Height="203px" AllowPaging="true" Width="385px" AllowCustomPaging="True" OnPageIndexChanging="EmpGridView_SelectedIndexChanging" PageSize="3" Font-Bold="True" Font-Size="Medium">
        <EditRowStyle HorizontalAlign="Left" />
    </asp:GridView>


    <br />
    <br />
    <asp:Label ID="NoRemarkLabel" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="EmptyRemark" runat="server" Text=""></asp:Label>
</asp:Panel>
