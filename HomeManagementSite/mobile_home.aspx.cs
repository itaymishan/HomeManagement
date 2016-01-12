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
            lblInsertStatus.Text = "Success";
        }
        
        protected void btnInsertQuickExpenseMobile_Click(object sender, EventArgs e)
        {
            Expense ex = new Expense();
            ex.Year = Convert.ToInt32(drpYear.SelectedValue);
            ex.Month = Convert.ToInt32(drpMonth.SelectedValue);
            ex.Currency = drpCurrency.SelectedValue;
            
            switch(sender)
            {
                case 0:
                {
                    ex.Category = drpCategory.SelectedValue;
                    ex.Comments = txtComments.Text;
                    ex.Amount = Convert.ToInt32(txtAmount.Text);
                    ex.IsLuxury = chkbxIsLuxury.Checked ? "כן" : "לא";
                    ex.Person = drpPerson.Text;
                    ex.ExpenseType = drpExpensetype.SelectedValue;
                }
                break;
                case 1:
                break;
                defualt:
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
