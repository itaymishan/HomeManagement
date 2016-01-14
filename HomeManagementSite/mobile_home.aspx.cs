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
            if (hiddenFieldAmount.Value == "")
            {
                return;
            }
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
