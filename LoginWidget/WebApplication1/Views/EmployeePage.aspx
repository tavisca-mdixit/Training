<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeePage.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pull-right">
    <asp:Button  ID="Button1" runat="server" Text="Logout" OnClick="Button1_Click" BackColor="Black" ForeColor="White" Width="104px" />
       <asp:Button ID="Button2" runat="server" OnClick="ChangePasswordClicked" Text="ChangePassword" BackColor="Black" ForeColor="White" Width="97px" />
    </div>

    <asp:GridView ID="EmpGridView"  runat="server" Height="203px"  AllowPaging="true" Width="385px" AllowCustomPaging="True" OnPageIndexChanging="EmpGridView_SelectedIndexChanging" PageSize="3">
    </asp:GridView>
    

    <br/><br/>
    <asp:Label ID="NoRemarkLabel" runat="server" Text=""></asp:Label>
    <br/>
   <%--<asp:DataPager ID="DataPager1" runat="server" PagedControlID="EmpGridView" PageSize="2" >
        <Fields>
            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="true" />
            
            
            </Fields>
    </asp:DataPager>
   --%> <br/>
    <br />
    <asp:Label ID="EmptyRemark" runat="server" Text=""></asp:Label>
</asp:Content>

