<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Capitu.Web.Perfil" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <table>
        <tr style="height: 5px;">
            <td></td>
        </tr>
        <tr>
            <td style="width: 10px;"></td>
            <td align="center">
                <asp:Image ID="imgPerfil" runat="server" ImageUrl="~/Images/modelo8.jpg" Width="300px" /></td>
            <td style="width: 10px;"></td>
        </tr>
        <tr style="height: 5px;">
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td align="center">
                    <table>
                        <tr>
                            <td colspan="4" style="text-align: center; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-size: xx-large;">Julia</td>
                        </tr>
                        <tr>
                            <td style="font-family: Arial, Helvetica, sans-serif; font-weight: bold; text-align: right; width: 80px;">Idade:</td>
                            <td style="font-family: Arial, Helvetica, sans-serif; text-align: left; width: 100px;">
                                <asp:Label ID="lblIdade" runat="server" Text="19" /></td>
                            <td style="font-family: Arial, Helvetica, sans-serif; font-weight: bold; text-align: right;  width: 80px;">Etnia:</td>
                            <td style="font-family: Arial, Helvetica, sans-serif; text-align: left; width: 100px;">
                                <asp:Label ID="lblEtnia" runat="server" Text="Loira" /></td>
                        </tr>
                        <tr>

                            <td style="font-family: Arial, Helvetica, sans-serif; font-weight: bold; text-align: right">Olhos:</td>
                            <td style="font-family: Arial, Helvetica, sans-serif; text-align: left">
                                <asp:Label ID="lblOlhos" runat="server" Text="Verdes" /></td>
                            <td style="font-family: Arial, Helvetica, sans-serif; font-weight: bold; text-align: right">Preço:</td>
                            <td style="font-family: Arial, Helvetica, sans-serif; text-align: left">
                                <asp:Label ID="lblPreço" runat="server" Text="R$275,00" /></td>
                        </tr>
                        <tr>
                            <td colspan="4">loasj doasijd badshfiu bshfiudsbfiuo dbsafhu bgdsuafhbg sdu ibgf odsiuhgf osihbf oi dshbf odshbf h </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>


</asp:Content>
