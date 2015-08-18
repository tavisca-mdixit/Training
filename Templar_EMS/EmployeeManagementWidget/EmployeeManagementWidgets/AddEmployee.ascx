<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.ascx.cs" Inherits="EmployeeManagementWidget.EmployeeManagementWidgets.AddEmployee" %>
<asp:Panel ID="AddEmp" runat="server" Visible="true"><div>
         <asp:Button ID="Button1" runat="server" Text="Logout" OnClick="Button1_Click" BackColor="Black" ForeColor="White" Width="104px" />
            <asp:Button ID="Button3" runat="server" Text="AddRemark" OnClick="RedirectToAddRemark" BackColor="Black" ForeColor="White" Width="104px" />
        <asp:Button ID="Button2" runat="server" OnClick="RedirectToChangePassword" Text="ChangePassword" BackColor="Black" ForeColor="White" Width="97px" />
    </div>

    <table class="auto-style1">
        <tr>
            <td class="auto-style2">First Name</td>
            <td>
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Employee" runat="server" ControlToValidate="FirstName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Last Name</td>
            <td>
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Employee" runat="server" ControlToValidate="LastName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
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
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="Employee" runat="server" ControlToValidate="Email" ErrorMessage="Invalid email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Phone</td>
            <td>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="Employee" ControlToValidate="Phone" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Date of Joining</td>
            <td>
                <asp:TextBox ID="DOJ" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="Employee" ControlToValidate="DOJ" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>



    </table>
    <asp:Button ID="Submit" runat="server" ValidationGroup="Employee" Text="Submit" OnClick="SubmitEmployee" BackColor="Black" BorderColor="Black" ForeColor="White" Width="96px" />
    <asp:Label ID="ErrorMessageEmployee" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#003300"></asp:Label>
  
</div>
</asp:Panel>