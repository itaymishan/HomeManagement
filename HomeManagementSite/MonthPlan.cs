//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeManagementSite
{
    using System;
    using System.Collections.Generic;
    
    public partial class MonthPlan
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int ItayIncomePaycheck { get; set; }
        public int ReutIncomePaycheck { get; set; }
        public Nullable<int> OtherIncome { get; set; }
        public Nullable<int> RentIncomeRamachal1 { get; set; }
        public Nullable<int> RentIncomeRamachal4 { get; set; }
        public int ItayLuxuryBudget { get; set; }
        public int ReutLuxuryBudget { get; set; }
        public Nullable<int> MonthSavingDestination { get; set; }
    }
}
