using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeManagementSite
{
    public partial class mobile_home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillIncome();
            FillBucket();
        }

        protected void btnInsertQuickIncomeMobile_Click(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            string buttonId = button.ID;
            MonthlyIncome income = BuildQuickIncome(buttonId);

            if (null == income)
            {
                Response.Write("<script>alert('Failed!!!');</script>");
                return;
            }
            using (var ctx = new HomeMngmentDBEntities())
            {
                ctx.MonthlyIncomes.Add(income);
                ctx.SaveChanges();
            }
            Response.Write("<script>alert('Success!!!');</script>");
        }

        private MonthlyIncome BuildQuickIncome(string buttonId)
        {
            MonthlyIncome income = new MonthlyIncome();
            income.Year         = DateTime.Now.Year;
            income.Month        = DateTime.Now.Month;
            income.Amount       = Convert.ToInt32(hiddenFieldAmount.Value);
            income.Currency     = "CAD";
            income.Comments     = hiddenFieldComments.Value;

            switch (buttonId)
            {
                case "btnAirBnb":
                    income.IncomeSrc = "AirBnB";
                    break;
                case "btnTaxReturn":
                    income.IncomeSrc = "החזר מס";
                    break;
                case "btnRamchal4":
                    income.IncomeSrc = "שכר דירה רמחל 4";
                    break;
                case "btnRamchal1":
                    income.IncomeSrc = "שכר דירה רמחל 1";
                    break;
                case "btnItaySalary":
                    income.IncomeSrc = "משכורת איתי";
                    break;
                case "btnReutSalary":
                    income.IncomeSrc = "משכורת רעות";
                    break;
                default:
                    break;
            }
            return income;
        }

        private void FillIncome()
        {
            int month   = DateTime.Now.Month;
            int year = DateTime.Now.Year;

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
                                 count = grp.Count()
                             }).OrderByDescending(p => p.amount).ToList();

                grdviewMonthIncome.DataSource = query.ToList();
                grdviewMonthIncome.DataBind();
            }
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


        protected void btnInsertExpenseMobile_Click(object sender, EventArgs e)
        {
            Expense ex = new Expense();
            ex.Year = Convert.ToInt32(drpYear.SelectedValue);
            ex.Month = Convert.ToInt32(drpMonth.SelectedValue);
            ex.Category = drpCategory.SelectedValue;
            ex.Currency = drpCurrency.SelectedValue;
            ex.Comments = txtComments.Text;
            ex.Amount = Convert.ToInt32(txtAmount.Text);
            ex.IsLuxury = chkbxIsLuxury.Checked ? "כן" : "לא";
            ex.Person = drpPerson.Text;
            ex.ExpenseType = drpExpensetype.SelectedValue;

            using (var ctx = new HomeMngmentDBEntities())
            {
                ctx.Expenses.Add(ex);
                ctx.SaveChanges();
            }
            Response.Write("<script>alert('Success!!!');</script>");
        }
        
        protected void btnInsertQuickExpenseMobile_Click(object sender, EventArgs e)
        {
            ImageButton button  = (ImageButton)sender;
            string buttonId     = button.ID;
            Expense ex = BuildQuickExpense(buttonId);

            if (null == ex)
            {
                Response.Write("<script>alert('Failed!!!');</script>");
                return;
            }
            using (var ctx = new HomeMngmentDBEntities())
            {
                ctx.Expenses.Add(ex);
                ctx.SaveChanges();
            }
            Response.Write("<script>alert('Success!!!');</script>");
        }

        private Expense BuildQuickExpense(string buttonId)
        {
            if (hiddenFieldAmount.Value == "")
            {
                Response.Write("<script>alert('Failed!!!');</script>");
                return null;
            }
            Expense ex  = new Expense();
            ex.Year     = Convert.ToInt32(drpYear.SelectedValue);
            ex.Month    = Convert.ToInt32(drpMonth.SelectedValue);
            ex.Currency = drpCurrency.SelectedValue;
            ex.Person   = "איתי";
            ex.ExpenseType  = "משותף";
            ex.Comments     = hiddenFieldComments.Value;
            ex.Amount       = Convert.ToInt32(hiddenFieldAmount.Value);

            switch (buttonId)
            {
                case "btnZipCar":
                    ex.Category = "ZipCar";
                    ex.IsLuxury = "לא";
                    break;
                case "btnGrocery":
                    ex.Category = "קניות בסופר";
                    ex.IsLuxury = "לא";
                    break;
                case "btnElectricityBill":
                    ex.Category = "חשמל";
                    ex.IsLuxury = "לא";
                    break;
                case "btnInternetBill":
                    ex.Category = "אינטרנט";
                    ex.IsLuxury = "לא";
                    break;
                case "btnPartyRest":
                    ex.Category = "בילויים ומסעדות";
                    ex.IsLuxury = "כן";
                    break;
                case "btnVaction":
                    ex.Category = "ZipCar";
                    ex.IsLuxury = "כן";
                    break;
                case "btnMortgage":
                    ex.Category = "ZipCar";
                    ex.IsLuxury = "לא";
                    break;
                case "btnTTC":
                    ex.Category = "תחבורה ציבורית";
                    ex.IsLuxury = "לא";
                    ex.Comments = "TTC";
                    break;
                case "btnCellular":
                    ex.Category = "פלאפון";
                    ex.IsLuxury = "לא";
                    break;
                default:
                    break;
            }
            return ex;
        }
    }
} 
