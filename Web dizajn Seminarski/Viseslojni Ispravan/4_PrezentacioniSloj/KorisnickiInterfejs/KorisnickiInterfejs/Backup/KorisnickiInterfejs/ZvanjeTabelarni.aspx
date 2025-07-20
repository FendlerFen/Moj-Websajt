<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ZvanjeTabelarni.aspx.cs" Inherits="KorisnickiInterfejs.ZvanjeTabelarni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 237px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                TABELARNI PRIKAZ ZVANJA</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Filter (naziv):</td>
            <td>
                <asp:TextBox ID="FilterTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="FiltrirajButton" runat="server" onclick="FiltrirajButton_Click" 
                    Text="FILTRIRAJ" />
                <asp:Button ID="SviButton" runat="server" onclick="SviButton_Click" Text="SVI" 
                    Width="68px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                <asp:GridView ID="SpisakZvanjaGridView" runat="server" Height="211px" Width="353px">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
