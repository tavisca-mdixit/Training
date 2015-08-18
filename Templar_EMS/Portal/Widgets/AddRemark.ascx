<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddRemark.ascx.cs" Inherits="EmployeeManagementWidget.EmployeeManagementWidgets.AddRemark" %>
 <asp:Panel ID="AddRem" runat="server" Visible="true"><div>
         <asp:Button ID="Button1" runat="server" Text="Logout" OnClick="Button1_Click" BackColor="Black" ForeColor="White" Width="104px" />
            <asp:Button ID="Button3" runat="server" Text="AddEmployee" OnClick="RedirectToAddEmployee" BackColor="Black" ForeColor="White" Width="104px" />
        <asp:Button ID="Button2" runat="server" OnClick="RedirectToChangePassword" Text="ChangePassword" BackColor="Black" ForeColor="White" Width="97px" />
    </div>
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
     </asp:Panel>
