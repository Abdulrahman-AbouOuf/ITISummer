<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="aspday2.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
    <tr>
        <td>Name:</td>
        <td>
            <asp:TextBox ID="txt_lgname" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_lgname" ErrorMessage="Enter The name">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="height: 26px">Password:</td>
        <td style="height: 26px">
            <asp:TextBox ID="txt_lgpass" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td style="height: 26px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_lgpass" ErrorMessage="Enter the Password">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:CheckBox ID="cb_remember" runat="server" Text="Remember Me" />
        </td>
        <td>
            <asp:Label ID="lbl_status" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_Click" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <p>
        Login</p>
</asp:Content>

