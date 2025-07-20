<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ZvanjeParametarStampe.aspx.cs" Inherits="KorisnickiInterfejs.ZvanjeParametarStampe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: right;
            width: 385px;
        }
    .auto-style1 {
        text-align: right;
        width: 215px;
    }
    .auto-style2 {
        color: #0000CC;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style2">
                <strong>IZBOR PARAMETRA ŠTAMPE SPISKA ZVANJA</strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label1" runat="server" style="text-align: right" 
                    Text="Naziv zvanja"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="FilterTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="FilterStampaButton" runat="server" onclick="FilterStampaButton_Click" 
                    Text="PRIKAZI FILTRIRANI SPISAK ZA STAMPU" Width="344px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
