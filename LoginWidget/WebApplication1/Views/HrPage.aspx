<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HrPage.aspx.cs" Inherits="WebApplication1.WebForm1" %>







<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/HrPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pull-right">
    <asp:Button  ID="Button1" runat="server" Text="Logout" OnClick="Button1_Click" BackColor="Black" ForeColor="White" Width="104px" />
    </div>
        <div style="height: 263px">
        
        <!-- Nav tabs -->
        <ul class="nav nav-tabs" role="tablist">
            <li><a data-toggle="tab" href="#home">Add Remark</a></li>
            <li><a data-toggle="tab" href="#profile" class="active">Add Employee</a></li>
            <li><a data-toggle="tab" href="#password" class="active">Change Password</a></li>

        </ul>

        <!-- Tab panes -->
        <div class="tab-content">
            <div class="tab tab-pane " id="home" visible="true">
                <br />
                <br />
                <div id="DropDownList">
                    <asp:Label ID="Label2" runat="server" Text="Employee List" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownListEmp" runat="server" Height="33px" Width="255px" AutoPostBack="false">
                    </asp:DropDownList>
                    <br />
                    <br />

                    <br />
                </div>

                <div id="EnterRemark">
                    <asp:Label ID="Label1" runat="server" Text="Enter Remark" Font-Bold="True" Font-Size="Medium"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;               
                <asp:TextBox ID="EmpRemarkBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Remark" runat="server" ControlToValidate="EmpRemarkBox" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <br />

                </div>
                <div id="RemarkButton">
                    <asp:Button ID="EmpRemarkButton" ValidationGroup="Remark" runat="server" Text="AddRemark" OnClick="SubmitRemark" Height="29px" BackColor="Black" ForeColor="White" />
                    <asp:Label ID="ErrorMessage" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#003300"></asp:Label>

                </div>
            </div>

            <div class="tab tab-pane active" id="profile">


                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">First Name</td>
                        <td>
                            <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Employee"  runat="server" ControlToValidate="FirstName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Last Name</td>
                        <td>
                            <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Employee"  runat="server" ControlToValidate="LastName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Title</td>
                        <td>

                            <asp:TextBox ID="EmpTitle" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Employee" runat="server" ControlToValidate="EmpTitle" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Email</td>
                        <td>
                            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"   ValidationGroup="Employee" runat="server" ControlToValidate="Email" ErrorMessage="Invalid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Phone</td>
                        <td>
                            <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="Employee"  ControlToValidate="Phone" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td class="auto-style2">Date of Joining</td>
                        <td>
                            <asp:TextBox ID="DOJ" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="Employee"  ControlToValidate="DOJ" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </td>
                    </tr>



                </table>
                <asp:Button ID="Submit" runat="server" ValidationGroup="Employee" Text="Submit" OnClick="SubmitEmployee" BackColor="Black" BorderColor="Black" ForeColor="White" Width="96px" />
                <asp:Label ID="ErrorMessageEmployee" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#003300"></asp:Label>
                <%--    //         <input id="Button2" type="button" value="Submit" onclick="submitClick()" />--%>
            </div>


        
    
     
        <div class="tab tab-pane " id="password">
            <br />
            <br />
      
                <asp:Label ID="Label3" runat="server" Text="Old Password  " Font-Bold="True" Font-Size="Medium"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="OldPass" TextMode="Password" runat="server" Width="300px"></asp:TextBox><asp:RequiredFieldValidator ValidationGroup="Password" ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="OldPass"></asp:RequiredFieldValidator><br />
                <asp:Label ID="Label4" runat="server" Text="New Password" Font-Bold="True" Font-Size="Medium"></asp:Label>
                &nbsp;
                <asp:TextBox ID="NewPass" TextMode="Password" runat="server" Width="299px"></asp:TextBox><asp:RequiredFieldValidator ValidationGroup="Password"  ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="NewPass"></asp:RequiredFieldValidator><br />
                <asp:Button ID="ChangePassBtn" runat="server" Text="Change Password" ValidationGroup="Password" OnClick="EmpChangePassword" BackColor="Black" Font-Italic="True" Font-Names="Myanmar Text" ForeColor="White" Height="35px" Width="156px" />
                <asp:Label ID="Message" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#003300"></asp:Label>
          
        </div>
    </div>
        
            </div>
   
</asp:Content>
