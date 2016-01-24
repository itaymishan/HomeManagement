<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="mobile_home.aspx.cs" Inherits="HomeManagementSite.mobile_home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="hiddenFieldAmount" runat="server" />
    <asp:HiddenField ID="hiddenFieldComments" runat="server" />
    <script>
        function PopUpAmountComments() {
        var amount = prompt("Please enter amount:");
        var comments = prompt("Please enter comments:");
        if (amount != null) {
            document.getElementById("<%=hiddenFieldAmount.ClientID%>").value = amount;
        }
        if (comments != null) {
            document.getElementById("<%=hiddenFieldComments.ClientID%>").value = comments;
        }
    }
    </script>
    <div id="WebApp">
        <div id="iHeader">
            <a href="#" id="waBackButton">Back</a>
            <span id="waHeadTitle">Mishan Home</span>
        </div>
        <div id="iGroup">
            <div class="iLayer" id="waHome" title="Home">
                <div class="iMenu">
                    <h3>Choose Action</h3>
                    <ul class="iArrow">
                        <li><a href="#_InsertExpense"><img src="http://www.lessystems.com/wp-content/uploads/2014/04/n2f-travel-expenses-report-icon.png" height="42" width="42"/>Insert Expense</a></li>
                        <li><a href="#_QuickInsert"><img src="http://descargar.info/wp-content/uploads/2014/01/My-Fast-VPN.png" height="42" width="42"/>Quick Insert</a></li>
                        <li><a href="#_ViewSummary"><img src="https://cdn2.iconfinder.com/data/icons/multimedia-17/80/list_summary_options_preferences_app_ui_menu-128.png" height="42" width="42"/>Month Totals</a></li>
                        <li><a href="#_InsertIncome"><img src="http://images.clipartpanda.com/coin-clip-art-acq7ygzcM.png" height="42" width="42"/>View Summary</a></li>
                        <li><a href="#_InsertBusinessExpense"><img src="https://machetera.files.wordpress.com/2008/05/cash_bucket.png" height="42" width="42"/>View Summary</a></li>
                        <li><a href="#_x3"><img src="/" height="42" width="42"/>View Summary</a></li>
                        <li><a href="#_x3"><img src="/" height="42" width="42"/>View Summary</a></li>
                        <li><a href="#_x3"><img src="/" height="42" width="42"/>View Summary</a></li>
                    </ul>
                </div>
            </div>
            <div class="iLayer" id="waInsertIncome" title="Insert Income">
                <div class="iBlock">
                    <h1>Insert Income</h1>
                    <table style="width: 100%;">
                        <tr>
                            <td><asp:ImageButton ID="btnReutSalary" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickIncomeMobile_Click" ImageUrl="http://www.itsmf.ca/images/fck/Image/NSP/IBM-cmyk_small(1).png" Height="80px" Width="80px"/></td>
                            <td><asp:ImageButton ID="btnItaySalary" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickIncomeMobile_Click" ImageUrl="https://www.platterz.ca/images/PlatterzLogo.36034897.png" Height="80px" Width="80px" /></td>
                        </tr>
                        <tr>
                            <td><asp:ImageButton ID="btnRamchal1" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickIncomeMobile_Click" ImageUrl="http://findicons.com/files/icons/1261/sticker_system/256/home.png" Height="80px" Width="80px" /></td>
                            <td><asp:ImageButton ID="btnRamchal4" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickIncomeMobile_Click" ImageUrl="http://www.clker.com/cliparts/K/s/8/f/l/V/simple-orange-house-md.png" Height="80px" Width="80px"/></td>

                        </tr>
                        <tr>
                            <td><asp:ImageButton ID="btnTaxReturn" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickIncomeMobile_Click" ImageUrl="http://host26.qnop.net/~virtual/wp-content/themes/sol/images/Icon_Tax.png" Height="80px" Width="80px"/></td>
                            <td><asp:ImageButton ID="btnAirBnb" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickIncomeMobile_Click" ImageUrl="https://a2.muscache.com/airbnb/static/about/resources/airbnb-logo-293-5b1924f36d180a53fdca602da3e5bc6c.png" Height="80px" Width="80px" /></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="iLayer" id="waIncomeMonth" title="Monthly Income">
                <div class="iBlock">
                    <h1>Monthly Income</h1>
                    <asp:GridView ID="grdviewMonthIncome" runat="server"></asp:GridView>
                </div>
            </div>
            <div class="iLayer" id="waInsertBusinessExpense" title="Insert to bucket">
                <div class="iBlock">
                    <h1>waInsertBusinessExpense</h1>
                </div>
            </div>
            <div class="iLayer" id="waViewLastTransactions" title="ViewLastTransactions">
                <div class="iBlock">
                    <h1>ViewLastTransactions</h1>
                </div>
            </div>
            <div class="iLayer" id="waViewBucket" title="Bucket">
                <div class="iBlock">
                    <h1><asp:Label ID="lblBussinnesBucket" runat="server" Text="NA" Font-Size="XX-Large"></asp:Label></h1>
                </div>
            </div>
            <div class="iLayer" id="waQuickInsertExpense" title="Quick Insert Expense">
                <div class="iBlock">
                    <table style="width: 100%;">
                        <tr>
                            <td><asp:ImageButton ID="btnGrocery" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickExpenseMobile_Click" ImageUrl="https://d30y9cdsu7xlg0.cloudfront.net/png/28468-200.png" Height="70px" Width="70px"/></td>
                            <td><asp:ImageButton ID="btnElectricityBill" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickExpenseMobile_Click" ImageUrl="http://js.syncfusion.com/UG/Web/Content/electricity.png" Height="70px" Width="70px" /></td>
                            <td><asp:ImageButton ID="btnZipCar" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickExpenseMobile_Click" ImageUrl="https://upload.wikimedia.org/wikipedia/en/thumb/5/59/Zipcar_Logo.svg/399px-Zipcar_Logo.svg.png" Height="70px" Width="70px" /></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td><asp:ImageButton ID="btnInternetBill" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickExpenseMobile_Click" ImageUrl="http://findicons.com/files/icons/1741/170_dock/256/wifi.png" Height="70px" Width="70px" /></td>
                            <td><asp:ImageButton ID="btnPartyRest" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickExpenseMobile_Click" ImageUrl="http://www.icone-png.com/png/29/28791.png" Height="70px" Width="70px"/></td>
                            <td><asp:ImageButton ID="btnVaction" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickExpenseMobile_Click" ImageUrl="http://icons.iconarchive.com/icons/visualpharm/vacation/256/beach-chair-icon.png" Height="70px" Width="70px"/></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td><asp:ImageButton ID="btnMortgage" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickExpenseMobile_Click" ImageUrl="http://media.point2.com/p2a/htmltext/092c/05f5/eca0/fa98fd4f9c04e7f26ac3/original.png" Height="70px" Width="70px"/></td>
                            <td><asp:ImageButton ID="btnTTC" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickExpenseMobile_Click" ImageUrl="https://hookmeup.files.wordpress.com/2011/01/ttc-logo.png?w=600" Height="70px" Width="70px" /></td>
                            <td><asp:ImageButton ID="btnCellular" runat="server" OnClientClick="PopUpAmountComments()" OnClick="btnInsertQuickExpenseMobile_Click" ImageUrl="http://images.clipartpanda.com/phone-clipart-mobile-phone-md.png" Height="70px" Width="70px" /></td>
                            <td></td>
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
        </div>
        <div id="iFooter">

        </div>
    </div>
</asp:Content>

