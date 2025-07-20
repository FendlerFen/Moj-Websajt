<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="NastavnikUnos.aspx.cs" Inherits="KorisnickiInterfejs.NastavnikUnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 423px;
    }
    .style2
    {
        width: 342px;
        text-align: right;
    }
    .style3
    {
        width: 423px;
        font-size: large;
    }
    .style4
    {
        font-size: large;
    }
    .style5
    {
        width: 342px;
        font-size: large;
        text-align: right;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td class="style3">
            <strong>UNOS NASTAVNIKA</strong></td>
        <td class="style4">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label1" runat="server" Text="JMBG"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="JMBGTextBox" runat="server" MaxLength="13"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label2" runat="server" Text="Prezime"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="PrezimeTextBox" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label3" runat="server" Text="Ime"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="ImeTextBox" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label4" runat="server" Text="Zvanje"></asp:Label>
        </td>
        <td class="style1">
            <asp:DropDownList ID="ZvanjeDropDownList" runat="server" Height="16px" Width="233px">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            <asp:Label ID="StatusLabel" runat="server" Text="STATUS"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            <asp:Button ID="SnimiButton" runat="server" Text="SNIMI" Width="69px" 
                onclick="SnimiButton_Click" />
            <asp:Button ID="btnPonisti" runat="server" Text="PONISTI" 
                onclick="PonistiButton_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
