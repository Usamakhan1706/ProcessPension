using System;

namespace ProcessPensionModule.Models
{
    public class PensionerDetail
    {
        public int Id { get; set; }
        public string AadharNumber { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PAN { get; set; }
        public double SalaryEarned { get; set; }
        public double Allowances { get; set; }
        public string PensionType { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string BankType { get; set; }
        public double PensionAmount { get; set; }
        public int BankServiceCharge { get; set; }
    }
}
