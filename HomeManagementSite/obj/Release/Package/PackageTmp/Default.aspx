<%@ Page Title="Mishan Home Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HomeManagementSite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p>Currency:
            <asp:DropDownList ID="drpCurrencyMain" runat="server" OnTextChanged="drpCurrencyMain_TextChanged">
                <asp:ListItem>CAD</asp:ListItem>
                <asp:ListItem>ILS</asp:ListItem>
                <asp:ListItem>USD</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnChangeCurrencyMain" runat="server" OnClick="Button1_Click" Text="OK" />
        </p>
        <h1>Search Item</h1>
        <p class="lead">
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Confirm" />
            <asp:Button ID="btnHideSearchRes" runat="server" Text="Show\Hide" OnClick="btnHideSearchRes_Click" />
        </p>
        <p>
            <asp:GridView ID="grdviewSearchRes" runat="server" Visible="False" AllowSorting="True" ShowFooter="True" ShowHeader="False" OnRowDataBound="grdviewSearchRes_RowDataBound">
                <RowStyle HorizontalAlign="Right" />
                <FooterStyle BackColor="#FFFF66" Font-Bold="True" Font-Size="Medium" />
            </asp:GridView>
        </p>
        <p>

            Category:
            <asp:DropDownList ID="drpCategoryMain" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Name">
            </asp:DropDownList>
&nbsp;Year:<asp:DropDownList ID="drpYearMain" runat="server" AutoPostBack="True">
                <asp:ListItem>2013</asp:ListItem>
                <asp:ListItem>2014</asp:ListItem>
                <asp:ListItem Selected="True">2015</asp:ListItem>
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem>הכל</asp:ListItem>
            </asp:DropDownList>
&nbsp; Month:
            <asp:DropDownList ID="drpMonthMain" runat="server" AutoPostBack="True">
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
                <asp:ListItem>12</asp:ListItem>
                <asp:ListItem>הכל</asp:ListItem>
            </asp:DropDownList>
&nbsp;Person:
            <asp:DropDownList ID="drpPersonMain" runat="server" AutoPostBack="True">
                <asp:ListItem>איתי</asp:ListItem>
                <asp:ListItem>רעות</asp:ListItem>
                <asp:ListItem Selected="True">הכל</asp:ListItem>
            </asp:DropDownList>
&nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HomeMngmentDBConnectionString %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>

        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2 style="background:pink">Events</h2>
            <p>Add Event: 
                <asp:TextBox ID="txtBxAddEvent" runat="server"></asp:TextBox>
                <asp:Button ID="btnAddEvent" runat="server" OnClick="btnAddEvent_Click" Text="Add" />
                <asp:Label ID="lblAddEventStatus" runat="server"></asp:Label>
            </p>
            <p>
                <asp:GridView ID="grdviewEvents" runat="server" ShowHeader="False">
                </asp:GridView>
            </p>
        </div>
        <div class="col-md-4">
            <h2 style="background:pink">Totals:[
                <asp:Label ID="lblCurrentActiveCurrency" runat="server"></asp:Label>
                ]</h2>
                <h3>Total Income:
                    <asp:Label ID="lblTotalIncome" runat="server"></asp:Label>
            &nbsp;</h3>
            <h3>Total Expenses:
                <asp:Label ID="lblTotalExpense" runat="server"></asp:Label>
            </h3>
            <h3 style="background:chartreuse; color:black" >Total Savings:
                <asp:Label ID="lblTotalSavings" runat="server"></asp:Label>
            </h3>
        </div>
       <div class="col-md-4">
            <h2 style="background:pink">Income Table</h2>
            <p><strong>Group Table:</strong>
                <asp:CheckBox ID="ckbxGroupIncome" runat="server" ToolTip="check to group..." />
            </p>
            <asp:GridView ID="grdviewIncome" runat="server" CaptionAlign="Right" ShowHeader="False" OnRowDataBound="grdviewIncome_RowDataBound" ShowFooter="True">
                <RowStyle HorizontalAlign="Right"/>
                <FooterStyle BackColor="#FFFF66" Font-Bold="True" Font-Size="Medium" />
            </asp:GridView>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2 style="background:pink">Add New Expense</h2>
            <p>
                Category:
                <asp:DropDownList ID="drpCategory" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Name">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HomeMngmentDBConnectionString %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
            </p>
            <p>
                Person:&nbsp;
                <asp:DropDownList ID="drpPerson" runat="server">
                    <asp:ListItem>איתי</asp:ListItem>
                    <asp:ListItem>רעות</asp:ListItem>
                </asp:DropDownList>
                &nbsp;Type:
                <asp:DropDownList ID="drpExpensetype" runat="server">
                    <asp:ListItem>אישי</asp:ListItem>
                    <asp:ListItem Selected="True">משותף</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                Year:
                <asp:DropDownList ID="drpYear" runat="server">
                    <asp:ListItem Selected="True">2016</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                </asp:DropDownList>
                &nbsp;Month:
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
            </p>
            <p>
                Currency:&nbsp;
                <asp:DropDownList ID="drpCurrency" runat="server">
                    <asp:ListItem>CAD</asp:ListItem>
                    <asp:ListItem>ILS</asp:ListItem>
                    <asp:ListItem>USD</asp:ListItem>
                </asp:DropDownList>
                 &nbsp;Amount:
                <asp:TextBox ID="txtAmount" runat="server" Width="40px"></asp:TextBox>
            </p>
            <p>
                Is Luxury:
                <asp:CheckBox ID="chkbxIsLuxury" runat="server" />
            </p>
            <p>
                Comments:&nbsp;
                <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
            </p>
            <p>
                &nbsp;<asp:Button ID="btnSubmitExpense" runat="server" Text="Add" OnClick="btnSubmitExpense_Click" />
            &nbsp;<asp:Label ID="lblInsertStatus" runat="server"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <h2 style="background:pink">Expense Table</h2>
             <p>
                Delete id:<asp:TextBox ID="txtExpenseIdDelete" runat="server" Width="66px"></asp:TextBox>
                &nbsp;<asp:Button ID="btnDeleteExpense" runat="server" OnClick="btnDeleteExpense_Click" Text="Go" />
            &nbsp;Refresh Table:
                <asp:Button ID="btnRefreshTbl" runat="server" OnClick="btnRefreshTbl_Click" Text="Go" />
                 <p>Group Table:
                 <asp:CheckBox ID="chkbxGroupExpense" runat="server" Checked="True" /> </p>
            <p>
                <asp:GridView ID="grdviewExpenseTable" runat="server" ShowHeader="False" ShowFooter="True" OnRowDataBound="grdviewExpenseTable_RowDataBound">
                    <FooterStyle BackColor="#FFFF66" Font-Bold="True" Font-Size="Medium" />
                    <RowStyle HorizontalAlign="Right" />
                </asp:GridView>
            </p>
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-4">
            <h2 style="background:pink">Bussiness Expenses</h2>
            <p><strong>Bucket Amount: 
                <asp:Label ID="lblBussinnesBucket" runat="server"></asp:Label>
                </strong> </p>
            <p>
                Type: 
                <asp:DropDownList ID="drpBussinessExpenseType" runat="server">
                    <asp:ListItem Value="Paid">Paid</asp:ListItem>
                    <asp:ListItem Value="Refunded">Refunded</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                Amount: 
                <asp:TextBox ID="txtAmountBussinessExpense" runat="server" Width="45px"></asp:TextBox>
&nbsp;Currency:
                <asp:DropDownList ID="drpCurrencyBussinesExpense" runat="server">
                    <asp:ListItem>CAD</asp:ListItem>
                    <asp:ListItem>USD</asp:ListItem>
                    <asp:ListItem>ILS</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                Comments:
                <asp:TextBox ID="txtCommentsBussinessExpense" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnBussinessExpense" runat="server" OnClick="btnBussinessExpense_Click" Text="Add" />
                <asp:Label ID="lblBussinessExpenseInsertIndication" runat="server"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
            <h2 style="background:pink">Add Income</h2>
                <p>Year:
                    <asp:TextBox ID="txtYearInsertIncome" runat="server" Width="48px"></asp:TextBox>
&nbsp;Month:
                    <asp:TextBox ID="txtMonthInsertIncome" runat="server" Width="39px"></asp:TextBox>
&nbsp;</p>
            <p>Source:
                <asp:DropDownList ID="drpIncomeSrcInsertIncome" runat="server" DataSourceID="SqlDataSource3" DataTextField="Name" DataValueField="Name">
                </asp:DropDownList>
&nbsp;</p>
            <p>Amount:
                <asp:TextBox ID="txtAmountInsertIncome" runat="server" Width="56px"></asp:TextBox>
&nbsp;Currency:<asp:DropDownList ID="drpCurrencyInsertIncome" runat="server">
                    <asp:ListItem>CAD</asp:ListItem>
                    <asp:ListItem>ILS</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>Comments:
                <asp:TextBox ID="txtCommentsInsertIncome" runat="server"></asp:TextBox>
            </p>
            <p>&nbsp;<asp:Button ID="btnInsertIncome" runat="server" OnClick="btnInsertIncome_Click" Text="Add" />
                <asp:Label ID="lblIncomeInsertIndication" runat="server"></asp:Label>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:HomeMngmentDBConnectionString %>" SelectCommand="SELECT * FROM [IncomeSrc]"></asp:SqlDataSource>
            </p>
        </div>

    </div>


</asp:Content>
