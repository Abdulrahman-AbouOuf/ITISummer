<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="aspday2.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View2" runat="server">
            <table style="width: 100%">
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:Label ID="lbl_name" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Age:</td>
                    <td>
                        <asp:Label ID="lbl_age" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>E-mail:</td>
                    <td>
                        <asp:Label ID="lbl_email" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Gender:</td>
                    <td>
                        <asp:Label ID="lbl_gender" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Profile Picture:</td>
                    <td>
                        <asp:Image ID="img_profile" runat="server" Height="100px" Width="100px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 17px">
                        <asp:LinkButton ID="lb_logout" runat="server" OnClick="lb_logout_Click">LogOut</asp:LinkButton>
                    </td>
                    <td style="height: 17px">
                        <asp:LinkButton ID="lb_cp" runat="server" OnClick="lb_cp_Click">Change Password</asp:LinkButton>
                    </td>
                    <td style="height: 17px">
                        <asp:LinkButton ID="lb_edit" runat="server" OnClick="lb_edit_Click">Edit</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View1" runat="server">
            <table style="width: 100%">
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        Edit:</td>
                </tr>
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:TextBox ID="txt_edname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Age:</td>
                    <td>
                        <asp:TextBox ID="txt_edage" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>E-mail:</td>
                    <td>
                        <asp:TextBox ID="txt_edmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Gender:</td>
                    <td>
                        <asp:RadioButtonList ID="rbl_edgender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>Profile Picture:</td>
                    <td>
                        <asp:FileUpload ID="fu_imgedit" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btn_saveedits" runat="server" OnClick="btn_saveedits_Click" Text="Save Edits" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 17px">&nbsp;</td>
                    <td style="height: 17px">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <p>
        Your Profile</p>
</asp:Content>

