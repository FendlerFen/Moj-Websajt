<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ZvanjeDetaljiEdit.aspx.cs" Inherits="KorisnickiInterfejs.ZvanjeDetaljiEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 275px;
        text-align: right;
    }
    .style2
    {
        width: 400px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            ZVANJE - DETALJNI PRIKAZ ZA EDITOVANJE</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Sifra</td>
        <td class="style2">
            <asp:TextBox ID="SifraTextBox" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Naziv</td>
        <td class="style2">
            <asp:TextBox ID="NazivTextBox" runat="server" Enabled="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:Label ID="StatusLabel" runat="server" Text="STATUS"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:Button ID="ObrisiButton" runat="server" Text="Obrisi" 
                onclick="ObrisiButton_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            <asp:Button ID="IzmeniButton" runat="server" Text="Omoguci izmenu" 
                onclick="IzmeniButton_Click" Width="167px" />
            <asp:Button ID="SnimiIzmenuButton" runat="server" onclick="SnimiIzmenuButton_Click" 
                Text="SNIMI IZMENU" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
