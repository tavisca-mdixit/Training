<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeePasswordChange.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
     <div class="pull-right">
    <asp:Button  ID="Button2" runat="server" Text="Logout" OnClick="Button1_Click" BackColor="Black" ForeColor="White" Width="104px" />
    </div>
    <asp:Label ID="Label1" runat="server" Text="Old Password  " Font-Bold="True" Font-Size="Medium"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="OldPass" TextMode="Password" runat="server" Width="300px"></asp:TextBox><br/>
    <asp:Label ID="Label2" runat="server" Text="New Password" Font-Bold="True" Font-Size="Medium"></asp:Label>
    &nbsp;
    <asp:TextBox ID="NewPass" TextMode="Password" runat="server" Width="299px"></asp:TextBox><br/>
    <asp:Button ID="Button1" runat="server" Text="Change Password" OnClick="EmpChangePassword" BackColor="Black" Font-Italic="False" Font-Names="Arial" ForeColor="White" Height="30px" Width="113px"/>
    <asp:Label ID="Message" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#003300"></asp:Label>
<br />
<br />
<br />
<br />
</asp:Content>
