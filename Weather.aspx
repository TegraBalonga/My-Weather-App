<%@ Page Title="Weather" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Weather.aspx.cs" Inherits="My_Weather_App.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br><br>
    <div class="text-left">
        <table style="width: 100%; height: 285px;">
            <tr>
                <td class="modal-sm" colspan="3" style="text-align: center; height: 59px"><strong>
                    <asp:Label ID="Label7" runat="server" style="font-size: x-large; color: #000000; text-decoration: underline;" Text="Choose a City:"></asp:Label>
                    </strong>&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 333px; height: 208px; color: #000000; text-align: right;"><strong>
                    <asp:Label ID="lblDate" runat="server" style="font-size: medium" Text="Label"></asp:Label>
                    <span style="font-size: large">&nbsp;
                    <br />
                    <asp:Label ID="lblCity" runat="server" Text="Label" style="font-size: x-large"></asp:Label>
                    </span></strong><span style="font-size: large">&nbsp;</span><strong><span style="font-size: large"><br />
                    <asp:Label ID="lblTemp" runat="server" Text="Label" Font-Size="60pt" style="font-size: larger"></asp:Label>
                    </span></strong></td>
                <td style="width: 358px; height: 208px"></td>
                <td style="height: 208px">
                    <asp:Image ID="imgWeather" runat="server" Height="160px" Width="160px" />
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 333px">&nbsp;</td>
                <td style="width: 358px">&nbsp;</td>
                <td style="font-size: large; color: #000000"><strong>
                    <asp:Label ID="lblHum" runat="server" Text="Humidity:"></asp:Label>
                    </strong>&nbsp;<strong><asp:Label ID="lblHumDis" runat="server" Text="Label"></asp:Label>
                    </strong>&nbsp;<strong><br />
                    <asp:Label ID="lblMin" runat="server" Text="Min Temp:"></asp:Label>
                    </strong>&nbsp;<strong><asp:Label ID="lblMinDis" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="lblMax" runat="server" Text="Max Temp:"></asp:Label>
                    </strong>&nbsp;<strong><asp:Label ID="lblMaxDis" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="lblPrec" runat="server" Text="Precipitation:"></asp:Label>
                    </strong>&nbsp;<strong><asp:Label ID="lblPrecDis" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="lblWind" runat="server" Text="Wind Speed:"></asp:Label>
                    </strong>&nbsp;<strong><asp:Label ID="lblWindDis" runat="server" Text="Label"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 333px">&nbsp;</td>
                <td style="width: 358px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
</asp:Content>
