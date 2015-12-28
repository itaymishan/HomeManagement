using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq.SqlClient;
using System.Data.Entity.Core.Objects;

namespace HomeManagementSite
{
    public partial class _Default : Page
    {
        private int month;
        private int year;
        private string category;
        private string person;
        private int totalAmount_expense_calc = 0;
        private int totalAmount_income_calc = 0;
        private int totalsExpenseAmount = 0;
        private int totalsIncomeAmount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) { AdjustDropDowns(); }
            RefreshData();
        }

        private void AdjustDropDowns()
        {
            drpYear.SelectedValue       = DateTime.Now.Year.ToString();
            drpMonth.SelectedValue      = DateTime.Now.Month.ToString();
            drpYearMain.SelectedValue   = DateTime.Now.Year.ToString();
            drpMonthMain.SelectedValue  = DateTime.Now.Month.ToString();
            drpCurrencyMain.Text        = ((Global)this.Context.ApplicationInstance).ActiveCurrency;
        }

        private void FillExpense()
        {
            category    = drpCategoryMain.SelectedValue.Trim().Equals("הכל") ? null : drpCategoryMain.SelectedValue.Trim();
            person      = drpPersonMain.SelectedValue.Trim().Equals("הכל") ? null : drpPersonMain.SelectedValue;
            month       = drpMonthMain.SelectedValue.Trim().Equals("הכל") ? 0 : Convert.ToInt32(drpMonthMain.SelectedValue);
            year        = drpYearMain.SelectedValue.Trim().Equals("הכל") ? 0 : Convert.ToInt32(drpYearMain.SelectedValue);

            using (var ctx = new HomeMngmentDBEntities())
            {
                if (chkbxGroupExpense.Checked)
                {
                    var query = (from expense in ctx.Expenses
                                 where (expense.Month == month || month == 0) &&
                                      (year == expense.Year || year == 0) &&
                                      (string.IsNullOrEmpty(category) || expense.Category == category) &&
                                      (string.IsNullOrEmpty(person) || expense.Person == person)
                                 group expense by new { expense.Category, expense.Currency }
                                 into grp
                                 select new
                                 {
                                     grp.Key.Category,
                                     grp.Key.Currency,
                                     amount = grp.Sum(t => t.Amount),
                                     count = grp.Count()
                                 }).OrderByDescending(p => p.amount).ToList();
                    grdviewExpenseTable.DataSource = query.ToList();
                    grdviewExpenseTable.DataBind();
                }
                else
                {
                    var query = from ex in ctx.Expenses
                                where (ex.Month == month || month == 0) &&
                                        (year == ex.Year || year == 0) &&
                                        (string.IsNullOrEmpty(category) || ex.Category == category) &&
                                        (string.IsNullOrEmpty(person) || ex.Person == person)
                                select new { ex.Comments, ex.Currency, ex.Amount, ex.Person, ex.Category, ex.Id };
                    grdviewExpenseTable.DataSource = query.ToList();
                    grdviewExpenseTable.DataBind();
                }
            }
        }

        private void FillTotals()
        {
            lblTotalExpense.Text = totalsExpenseAmount.ToString();
            lblTotalIncome.Text = totalsIncomeAmount.ToString();
            lblTotalSavings.Text = (totalsIncomeAmount - totalsExpenseAmount).ToString();
        }

        private void FillBucket()
        {
            using (var ctx = new HomeMngmentDBEntities())
            {
                var sum_in = ctx.work_expenses_in.Sum(x => x.amount);
                var sum_out = ctx.work_expenses_out.Sum(x => x.amount);
                lblBussinnesBucket.Text = (sum_in - sum_out).ToString();
            }
        }


        private void FillEvents()
        {
            month = drpMonthMain.SelectedValue.Trim().Equals("הכל") ? 0 : Convert.ToInt32(drpMonthMain.SelectedValue);
            year = drpYearMain.SelectedValue.Trim().Equals("הכל") ? 0 : Convert.ToInt32(drpYearMain.SelectedValue);

            using (var ctx = new HomeMngmentDBEntities())
            {
                var query = from ev in ctx.SpecialEvents
                            where (ev.Month == month || month == 0) &&
                                  (year == ev.Year || year == 0)
                            select new { ev.EventDescription };
                grdviewEvents.DataSource = query.ToList();
                grdviewEvents.DataBind();
            }
        }

        private void FillIncome()
        {
            month = drpMonthMain.SelectedValue.Trim().Equals("הכל") ? 0 : Convert.ToInt32(drpMonthMain.SelectedValue);
            year = drpYearMain.SelectedValue.Trim().Equals("הכל") ? 0 : Convert.ToInt32(drpYearMain.SelectedValue);

            using (var ctx = new HomeMngmentDBEntities())
            {
                var query = (from income in ctx.MonthlyIncomes
                             where (income.Month == month || month == 0) &&
                                  (year == income.Year || year == 0)
                             group income by new { income.IncomeSrc, income.Currency }
                             into grp
                             select new
                             {
                                 grp.Key.IncomeSrc,
                                 grp.Key.Currency,
                                 amount = grp.Sum(t => t.Amount),
                                 count  = grp.Count()
                             }).OrderByDescending(p => p.amount).ToList();

                grdviewIncome.DataSource = query.ToList();
                grdviewIncome.DataBind();
              }
           }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length < 1)
                return;

            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(txtSearch.Text);
            using (var ctx = new HomeMngmentDBEntities())
            {
                string wildcard = "%"+txtSearch.Text+"%";
                string customWhere = string.Format("WHERE Comments LIKE '{0}' OR Category LIKE '{0}' ", wildcard);
                var query = ctx.Expenses.SqlQuery("SELECT * FROM dbo.Expense " + customWhere);

                grdviewSearchRes.DataSource = query.ToList();
                grdviewSearchRes.DataBind();
                grdviewSearchRes.Visible = true;
            }
        }

        protected void btnSubmitExpense_Click(object sender, EventArgs e)
        {
            Expense ex = new Expense();
            ex.Year     = Convert.ToInt32(drpYear.SelectedValue);
            ex.Month    = Convert.ToInt32(drpMonth.SelectedValue);
            ex.Category = drpCategory.SelectedValue;
            ex.Currency = drpCurrency.SelectedValue;
            ex.Comments = txtComments.Text;
            ex.Amount   = Convert.ToInt32(txtAmount.Text);
            ex.IsLuxury = chkbxIsLuxury.Checked ? "כן" : "לא";
            ex.Person   = drpPerson.Text;
            ex.ExpenseType = drpExpensetype.SelectedValue;

            using (var ctx = new HomeMngmentDBEntities())
            {
                ctx.Expenses.Add(ex);
                ctx.SaveChanges();
            }
            lblInsertStatus.Text = "Success";
        }

        protected void btnDeleteExpense_Click(object sender, EventArgs e)
        {
            using (var ctx = new HomeMngmentDBEntities())
            {
                var ex = new Expense { Id = Convert.ToInt32(txtExpenseIdDelete.Text) };
                ctx.Expenses.Attach(ex);
                ctx.Expenses.Remove(ex);
                ctx.SaveChanges();
            }
        }

        protected void btnHideSearchRes_Click(object sender, EventArgs e)
        {
            grdviewSearchRes.Visible = !grdviewSearchRes.Visible;
        }

        protected void btnRefreshTbl_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        protected void grdviewExpenseTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int amount = Convert.ToInt32(e.Row.Cells[2].Text);
                string from = e.Row.Cells[1].Text;
                string to = (((Global)this.Context.ApplicationInstance).ActiveCurrency);
                totalAmount_expense_calc += GetEntryValueBasedOnActiveCurrency(amount, from, to);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total:";
                e.Row.Cells[2].Text = totalAmount_expense_calc.ToString();
                e.Row.Font.Bold = true;
                totalsExpenseAmount = totalAmount_expense_calc;
                totalAmount_expense_calc = 0;
            }
        }

        private int GetEntryValueBasedOnActiveCurrency(GridViewRow row)
        {
            int value = Convert.ToInt32(row.Cells[2].Text);
            string from = row.Cells[1].Text;
            string to = ( ((Global)this.Context.ApplicationInstance).ActiveCurrency);
            double rate = CurrencyConverter.GetConvertionRate(from, to);
            value = (int) (value * rate);
            return value;
        }

        private int GetEntryValueBasedOnActiveCurrency(int amount, string from_currency, string to_currency)
        {
            double rate = CurrencyConverter.GetConvertionRate(from_currency, to_currency);
            int value = (int)(amount * rate);
            return value;
        }

        private void RefreshData()
        {
            lblCurrentActiveCurrency.Text = ((Global)this.Context.ApplicationInstance).ActiveCurrency;
            FillExpense();
            FillIncome();
            FillTotals();
            FillEvents();
            FillBucket();
        }

        protected void drpCurrencyMain_TextChanged(object sender, EventArgs e)
        {
            ((Global)this.Context.ApplicationInstance).ActiveCurrency = drpCurrencyMain.Text;
            lblCurrentActiveCurrency.Text = ((Global)this.Context.ApplicationInstance).ActiveCurrency;
        }

        protected void btnInsertIncome_Click(object sender, EventArgs e)
        {
            MonthlyIncome income = new MonthlyIncome();
            income.Year = Convert.ToInt32(txtYearInsertIncome.Text);
            income.Month = Convert.ToInt32(txtMonthInsertIncome.Text);
            income.Amount = Convert.ToInt32(txtAmountInsertIncome.Text);
            income.IncomeSrc = drpIncomeSrcInsertIncome.SelectedValue;
            income.Currency = drpCurrencyInsertIncome.SelectedValue;
            income.Comments = txtCommentsInsertIncome.Text;

            using (var ctx = new HomeMngmentDBEntities())
            {
                ctx.MonthlyIncomes.Add(income);
                ctx.SaveChanges();
            }
            lblIncomeInsertIndication.Text = "Success";
        }

        protected void btnBussinessExpense_Click(object sender, EventArgs e)
        {
            switch (drpBussinessExpenseType.SelectedValue)
            {
                case "Paid":
                    {
                        work_expenses_out workEx = new work_expenses_out();
                        workEx.amount   = Convert.ToInt32(txtAmountBussinessExpense.Text);
                        workEx.currency = drpCurrencyBussinesExpense.SelectedValue;
                        workEx.comments = txtCommentsBussinessExpense.Text;
                        using (var ctx = new HomeMngmentDBEntities())
                        {
                            ctx.work_expenses_out.Add(workEx);
                            ctx.SaveChanges();
                        }
                        lblBussinessExpenseInsertIndication.Text = "Success";
                    }
                    break;
                case "Refunded":
                    {
                        work_expenses_in workIn = new work_expenses_in();
                        workIn.amount = Convert.ToInt32(txtAmountBussinessExpense.Text);
                        workIn.currency = drpCurrencyBussinesExpense.SelectedValue;
                        workIn.comments = txtCommentsBussinessExpense.Text;
                        using (var ctx = new HomeMngmentDBEntities())
                        {
                            ctx.work_expenses_in.Add(workIn);
                            ctx.SaveChanges();
                        }
                        lblBussinessExpenseInsertIndication.Text = "Success";
                    }
                    break;
                default:
                    break;
            }
        }

        protected void grdviewIncome_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int amount = Convert.ToInt32(e.Row.Cells[2].Text);
                string from = e.Row.Cells[1].Text;
                string to = (((Global)this.Context.ApplicationInstance).ActiveCurrency);
                totalAmount_income_calc += GetEntryValueBasedOnActiveCurrency(amount, from, to);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total:";
                e.Row.Cells[2].Text = totalAmount_income_calc.ToString();
                e.Row.Font.Bold = true;
                totalsIncomeAmount = totalAmount_income_calc;
                totalAmount_income_calc = 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        protected void grdviewSearchRes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int amount  = Convert.ToInt32(e.Row.Cells[7].Text);
                string from = e.Row.Cells[12].Text;
                string to   = (((Global)this.Context.ApplicationInstance).ActiveCurrency);
                totalAmount_income_calc += GetEntryValueBasedOnActiveCurrency(amount, from, to);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total:";
                e.Row.Cells[2].Text = totalAmount_income_calc.ToString();
                e.Row.Font.Bold = true;
                totalAmount_income_calc = 0;
            }
        }

        protected void btnAddEvent_Click(object sender, EventArgs e)
        {
            SpecialEvent ev = new SpecialEvent();
            ev.Year  = Convert.ToInt16(drpYearMain.SelectedValue);
            ev.Month = Convert.ToInt16(drpMonthMain.SelectedValue);
            ev.EventDescription = txtBxAddEvent.Text;
            using (var ctx = new HomeMngmentDBEntities())
            {
                ctx.SpecialEvents.Add(ev);
                ctx.SaveChanges();
            }
            lblAddEventStatus.Text = "Success";
        }
    }
}