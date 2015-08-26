<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HtmlWidget.ascx.cs"
    Inherits="SampleWidgets.HtmlWidget" %>
<asp:Panel ID="Settings" runat="server" Visible="false">
    <div>
        <textarea id="Editor" rows="5" cols="50" runat="server"></textarea>
    </div>
    <div>
        <asp:Button ID="btnSaveSettings" runat="server" OnClick="btnSaveSettings_Click"
            Text="Save" />
    </div>
</asp:Panel>
<asp:Literal ID="ltrOutput" runat="server"></asp:Literal>
