<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="aspday2.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
    <tr>
        <td>Old Password:</td>
        <td>
            <asp:TextBox ID="txt_oldpass" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_oldpass" Display="Dynamic" ErrorMessage="Enter the old password">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>New Password:</td>
        <td>
            <asp:TextBox ID="txt_newpass" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_newpass" Display="Dynamic" ErrorMessage="Enter the new password">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Confirm Password:</td>
        <td>
            <asp:TextBox ID="txt_newconpass" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_newconpass" Display="Dynamic" ErrorMessage="Enter the confirm password">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Wrong password Confrimation" ControlToCompare="txt_newconpass" ControlToValidate="txt_newpass">Wrong Confirmation</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btn_change" runat="server" Text="Change" OnClick="btn_change_Click" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <p>
        ChangePassword</p>
</asp:Content>

