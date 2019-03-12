<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registiration.aspx.cs" Inherits="aspday2.Registiration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%">
    <tr>
        <td>Name:</td>
        <td>
            <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name" Display="Dynamic" ErrorMessage="Enter Your Full name">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Age:</td>
        <td>
            <asp:TextBox ID="txt_age" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_age" Display="Dynamic" ErrorMessage="Enter your age">*</asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_age" Display="Dynamic" ErrorMessage="Age from 20 to 30" MaximumValue="30" MinimumValue="20">20-30</asp:RangeValidator>
        </td>
    </tr>
    <tr>
        <td>Password:</td>
        <td>
            <asp:TextBox ID="txt_pass" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_pass" Display="Dynamic" ErrorMessage="Enter the password">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Confirm Password:</td>
        <td>
            <asp:TextBox ID="txt_conpass" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_conpass" Display="Dynamic" ErrorMessage="Enter the password again">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_pass" ControlToValidate="txt_conpass" Display="Dynamic" ErrorMessage="Wrong Password Confirmation">Wrong Confirmation</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>E-mail:</td>
        <td>
            <asp:TextBox ID="txt_mail" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_mail" Display="Dynamic" ErrorMessage="Enter Your mail">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_mail" Display="Dynamic" ErrorMessage="This E-mail isn't valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Not Valid</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="height: 54px">Gender:</td>
        <td style="height: 54px">
            <asp:RadioButtonList ID="rbl_gender" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td style="height: 54px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ErrorMessage="Choose Your Gender" ControlToValidate="rbl_gender">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>Department</td>
        <td>
            <asp:DropDownList ID="ddl_dept" runat="server">
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>Image:</td>
        <td>
            <asp:FileUpload ID="fu_img" runat="server" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" />
        </td>
        <td>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <p>
        Registiration</p>
</asp:Content>

