﻿<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="mobile_home.aspx.cs" Inherits="HomeManagementSite.mobile_home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="WebApp">
        <div id="iHeader">
            <a href="#" id="waBackButton">Back</a>
            <span id="waHeadTitle">Mishan Home</span>
        </div>
        <div id="iGroup">
            <div class="iLayer" id="waHome" title="Home">
                <div class="iMenu">
                    <h3>Choose Action</h3>
                    <ul>
                        <li><a href="#_InsertExpense">Insert Expense</a></li>
                        <li><a href="#_QuickInsert">Quick Insert</a></li>
                        <li><a href="#_ViewSummary">View Summary</a></li>
                    </ul>
                </div>
            </div>
            <div class="iLayer" id="waQuickInsert" title="Quick Insert">
                <div class="iBlock">
                    <h1><asp:TextBox ID="txtAmountQuickInsert" runat="server" Font-Size="Large" Width="50px" ValidationGroup="quickInsert"></asp:TextBox></h1>
                    <table style="width: 100%;">
                        <tr>
                            <td><asp:ImageButton ID="btnGroceryMobile" runat="server" ImageUrl="https://d30y9cdsu7xlg0.cloudfront.net/png/28468-200.png" Height="70px" Width="70px"/></td>
                            <td><asp:ImageButton ID="btnElectricityBill" runat="server" ImageUrl="http://js.syncfusion.com/UG/Web/Content/electricity.png" Height="70px" Width="70px" /></td>
                            <td><asp:ImageButton ID="btnZipCar" runat="server" ImageUrl="https://upload.wikimedia.org/wikipedia/en/thumb/5/59/Zipcar_Logo.svg/399px-Zipcar_Logo.svg.png" Height="70px" Width="70px" /></td>
                        </tr>
                        <tr>
                            <td><asp:ImageButton ID="btnInternetBill" runat="server" ImageUrl="http://findicons.com/files/icons/1741/170_dock/256/wifi.png" Height="70px" Width="70px" /></td>
                            <td><asp:ImageButton ID="btnPartyRest" runat="server" ImageUrl="http://www.icone-png.com/png/29/28791.png" Height="70px" Width="70px"/></td>
                            <td><asp:ImageButton ID="btnVaction" runat="server" ImageUrl="http://icons.iconarchive.com/icons/visualpharm/vacation/256/beach-chair-icon.png" Height="70px" Width="70px"/></td>
                        </tr>
                        <tr>
                            <td><asp:ImageButton ID="btnMortgage" runat="server" ImageUrl="http://media.point2.com/p2a/htmltext/092c/05f5/eca0/fa98fd4f9c04e7f26ac3/original.png" Height="70px" Width="70px"/></td>
                            <td><asp:ImageButton ID="btnTTC" runat="server" ImageUrl="https://hookmeup.files.wordpress.com/2011/01/ttc-logo.png?w=600" Height="70px" Width="70px" /></td>
                            <td><asp:ImageButton ID="btnCellular" runat="server" ImageUrl="http://images.clipartpanda.com/phone-clipart-mobile-phone-md.png" Height="70px" Width="70px" /></td>
                        </tr>
                    </table>
                </div>
            </div>

            <div class="iLayer" id="waInsertExpense" title="Insert Expense Layer">
                <div class="iBlock">
                    <h3>
                    Category:
                        <asp:DropDownList ID="drpCategory" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HomeMngmentDBConnectionString %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
                    </h3>
                    <h3>
                        Person:&nbsp;
                        <asp:DropDownList ID="drpPerson" runat="server">
                            <asp:ListItem>איתי</asp:ListItem>
                            <asp:ListItem>רעות</asp:ListItem>
                        </asp:DropDownList>
                    </h3>
                    <h3>
                        Type:
                        <asp:DropDownList ID="drpExpensetype" runat="server">
                            <asp:ListItem>אישי</asp:ListItem>
                            <asp:ListItem Selected="True">משותף</asp:ListItem>
                        </asp:DropDownList>
                    </h3>
                    <h3>Year:
                        <asp:DropDownList ID="drpYear" runat="server">
                            <asp:ListItem Selected="True">2016</asp:ListItem>
                            <asp:ListItem>2015</asp:ListItem>
                            <asp:ListItem>2014</asp:ListItem>
                            <asp:ListItem>2013</asp:ListItem>
                        </asp:DropDownList>
                    </h3>
                     <h3>Month:
                        <asp:DropDownList ID="drpMonth" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                        </asp:DropDownList>
                    </h3>
                    <h3>
                        Currency:&nbsp;
                        <asp:DropDownList ID="drpCurrency" runat="server">
                            <asp:ListItem>CAD</asp:ListItem>
                            <asp:ListItem>ILS</asp:ListItem>
                            <asp:ListItem>USD</asp:ListItem>
                        </asp:DropDownList>
                         &nbsp;Amount:
                        <asp:TextBox ID="txtAmount" runat="server" Width="40px"></asp:TextBox>
                    </h3>
                    <h3>
                        Is Luxury:
                        <asp:CheckBox ID="chkbxIsLuxury" runat="server" />
                    </h3>
                    <h3>
                        Comments:&nbsp;
                        <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
                    </h3>
                    <h3>
                        <asp:Button ID="btnInsertExpenseMobile" runat="server" Text="Insert" OnClick="btnInsertExpenseMobile_Click" />
                    </h3>
                    <h3>
                        <asp:Label ID="lblInsertStatus" runat="server"></asp:Label>
                    </h3>

                </div>
            </div>
            <div class="iLayer" id="waViewSummary" title="View Summary Layer">
                <div class="iBlock">
                <h1>View Summary</h1>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

