<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="EmployeeManagementWidget.LoginControl" %>

<asp:Panel ID="LoginWidget" runat="server" Visible="true">


<div style="width: 1146px; height: 302px" aria-dropeffect="popup">
    &nbsp;

    
    <asp:Label ID="Label1" runat="server" Text="UserName" Font-Bold="True"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Invalid User"></asp:RequiredFieldValidator>
    <br />
    &nbsp;<asp:Label ID="Label2" runat="server" Text="Password " Font-Bold="True"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox2" runat="server" ErrorMessage="Invalid Password"></asp:RequiredFieldValidator>
    <br />
    <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Login" Style="height: 28px; width: 67px" BackColor="Black" ForeColor="White" /><asp:CheckBox ID="Rememberpassword" runat="server" OnCheckedChanged="Rememberpassword_CheckedChanged" />


    <br />
    <asp:Label ID="Message" runat="server" Text=""></asp:Label>



</div>

</asp:Panel>