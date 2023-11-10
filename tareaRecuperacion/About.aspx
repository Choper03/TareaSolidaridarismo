<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="tareaRecuperacion.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding:15px">

        <table class="w-70" style="height: 287px; width: 1208px">
            <tr>
                <td colspan="2" style="font-size: xx-large; background-color: #333333; color: #FFFFFF; height: 46px;">Abonos&nbsp;</td>
            </tr>
            <tr>
                <td class="text-end" style="height: 29px; width: 604px">&nbsp;</td>
                <td class="text-start" style="height: 29px; text-align: justify; width: 604px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-end" style="height: 30px; width: 604px">
                    <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Codigo:" BorderColor="#3333FF" BorderStyle="Double"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; text-align: justify; width: 604px">
                    <asp:TextBox ID="TxtCodigo" runat="server" Font-Size="Medium" TextMode="Number" Width="200px" BackColor="#66FFFF"></asp:TextBox>
                &nbsp;
                   </td>
            </tr>
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Seleccione el Credito:" BorderColor="Blue" BorderStyle="Double"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:DropDownList ID="dropDownListCreditos" runat="server" AutoPostBack="True" BackColor="#66FFFF">
                    </asp:DropDownList>
                     <asp:Button ID="BtnBuscar" runat="server" BackColor="Yellow" Font-Bold="True" Font-Size="Large" ForeColor="Black" Text="Buscar" OnClick="BtnBuscar_Click" />
                       </td>
            </tr>
            
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Monto:" BorderColor="Blue" BorderStyle="Double"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:TextBox ID="TxtMonto" runat="server" Font-Size="Medium" TextMode="Number" Width="500px" BackColor="#66FFFF" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label7" runat="server" Font-Size="Medium" Text="Fecha:" BorderColor="Blue" BorderStyle="Double"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:TextBox ID="TxtFecha" runat="server" Font-Size="Medium" TextMode="Date" Width="680px" BackColor="#FF5050" Height="25px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 604px; height: 30px">&nbsp;</td>
                <td style="height: 30px; width: 604px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 604px; height: 30px">&nbsp;</td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:Button ID="BtnGuardar" runat="server" BackColor="#66FF33" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="Guardar" OnClick="BtnGuardar_Click" BorderColor="#009933" BorderStyle="Double" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="VistaVenta" runat="server" BackColor="#CCCCFF" Font-Bold="True" ForeColor="Black" Width="1208px" BorderColor="#660066" BorderWidth="5px" GridLines="Vertical">
            
        </asp:GridView>
    </div>

</asp:Content>

