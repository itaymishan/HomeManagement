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
        
        protected Expense BuildQuickExpense(sender)
        {
            if (hiddenFieldAmount.Value == "")
                return;
            ImageButton button  = (ImageButton)sender;
            string buttonId     = button.ID;
            Expense ex          = new Expense();
            ex.Year             = Convert.ToInt32(drpYear.SelectedValue);
            ex.Month            = Convert.ToInt32(drpMonth.SelectedValue);
            ex.Currency         = drpCurrency.SelectedValue;
            
            switch(buttonId)
            {
                case "":
                break;
                default:
                break;
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
            lblInsertStatus.Text = "Success";
        }
        
        protected void btnInsertQuickExpenseMobile_Click(object sender, EventArgs e)
        {
            if (hiddenFieldAmount.Value == "")
                return;
            ImageButton button = (ImageButton)sender;
            string buttonId = button.ID;
            Expense ex  = new Expense();
            ex.Year     = Convert.ToInt32(drpYear.SelectedValue);
            ex.Month    = Convert.ToInt32(drpMonth.SelectedValue);
            ex.Currency = drpCurrency.SelectedValue;

            switch (buttonId)
            {
                case "btnZipCar":
                    {
                        ex.Category     = "ZipCar";
                        ex.Comments     = txtComments.Text;
                        ex.Amount       = Convert.ToInt32(hiddenFieldAmount.Value);
                        ex.IsLuxury     =  "לא";
                        ex.Person       = "איתי";
                        ex.ExpenseType  = "משותף";
                    }
                    break;
            }

            using (var ctx = new HomeMngmentDBEntities())
            {
                ctx.Expenses.Add(ex);
                ctx.SaveChanges();
            }
            lblInsertStatus.Text = "Success";
        }
    }
}
