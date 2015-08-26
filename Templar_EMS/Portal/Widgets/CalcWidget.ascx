<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalcWidget.ascx.cs" Inherits="Calc.CalcWidget.CalcWidget" %>

<%@ Register Assembly="Tavisca.Templar.WebControls" Namespace="Tavisca.Templar.WebControls" TagPrefix="gtc" %>

<asp:Panel ID="pnlSettings" runat="server" Visible="false">
<gtc:TemplarLabel ID="Calculator" runat="server" Text="Calculator"></gtc:TemplarLabel>

<asp:Table ID="Table1" runat="server" Visible="true">
    <asp:TableRow>
        <asp:TableHeaderCell>
            <asp:TextBox ID="OutputBox" runat="server" Text="0"></asp:TextBox></asp:TableHeaderCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><gtc:TemplarButton ID="num1" runat="server" Text="1" /></asp:TableCell>
        <asp:TableCell><gtc:TemplarButton ID="num2" runat="server" Text="2" /></asp:TableCell>
        <asp:TableCell><gtc:TemplarButton ID="num3" runat="server" Text="3" /></asp:TableCell>
        <asp:TableCell><gtc:TemplarButton ID="plus" runat="server" Text="+" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><gtc:TemplarButton ID="num4" runat="server" Text="4" /></asp:TableCell>
        <asp:TableCell><gtc:TemplarButton ID="num5" runat="server" Text="5" /></asp:TableCell>
        <asp:TableCell><gtc:TemplarButton ID="num6" runat="server" Text="6" /></asp:TableCell>
        <asp:TableCell><gtc:TemplarButton ID="minus" runat="server" Text="-" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell><gtc:TemplarButton ID="num7" runat="server" Text="7" /></asp:TableCell>
        <asp:TableCell><gtc:TemplarButton ID="num8" runat="server" Text="8" /></asp:TableCell>
        <asp:TableCell><gtc:TemplarButton ID="num9" runat="server" Text="9" /></asp:TableCell>
        <asp:TableCell><gtc:TemplarButton ID="multiply" runat="server" Text="*" /></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2"><gtc:TemplarButton ID="num0" runat="server" Text="0"/></asp:TableCell>
        <asp:TableCell><gtc:TemplarButton ID="decimal" runat="server" Text="." /></asp:TableCell>
        <asp:TableCell><gtc:TemplarButton ID="divide" runat="server" Text="/" /></asp:TableCell>
    </asp:TableRow>
</asp:Table>
</asp:Panel>
<gtc:TemplarLabel ID="Tlabel" runat="server" Text="Name" ></gtc:TemplarLabel>