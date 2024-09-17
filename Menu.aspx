<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="My_Weather_App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>Weather App</h1>
        <p class="lead">In this app you will be able to view the weather of the different cities that you have chosen as the regular cities you would like to see.</p>
       <br><br>
        <div class="text-justify" style="width: 846px">
            <asp:Button ID="btnLog" runat="server" Text="Log In" BorderStyle="Double" Font-Bold="True" Font-Size="180px" ForeColor="White" style="font-size: larger; background-color: #000000" OnClick="btnLog_Click" />
        </div>

        <br>
        <div>
            <table class="nav-justified">
                <tr>
                    <td style="height: 50px; width: 388px" class="text-right">
                        <strong>
                        <asp:Label ID="lblUser" runat="server" Text="UserName:" style="font-size: large"></asp:Label>
                    &nbsp;&nbsp;&nbsp; </strong>
                    </td>
                    <td style="height: 50px">
                        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 45px; width: 388px" class="text-right">
                        <strong>
                        <asp:Label ID="lblPass" runat="server" Text="Password:" style="font-size: large"></asp:Label>
                    &nbsp;&nbsp;&nbsp; </strong>
                    </td>
                    <td style="height: 45px">
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 41px;" class="text-center" colspan="2">
                        <asp:Label ID="lblError" runat="server" style="color: #FF0000" Text="The Username or Password you entered is wrong!"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td style="width: 388px" class="text-right"><strong>
                        <asp:Button ID="btnLogIn" runat="server" OnClick="btnLogIn_Click" style="font-weight: bold; font-size: medium; margin-left: 0" Text="Log In" Width="79px" href="~/About" />
                        </strong>&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp; <strong>
                        <asp:Button ID="btnCancel" runat="server" style="font-weight: bold; font-size: medium; margin-left: 0" Text="Cancel" />
                        </strong></td>
                    
                </tr>
            </table>
        </div>
    </div>
       
    </asp:Content>
 