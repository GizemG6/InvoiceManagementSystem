using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementSystem.Enums
{
    public enum BillType
    {
        [Display(Name = "Aidat")]
        Dues = 0,

        [Display(Name = "Elektrik Faturası")]
        ElectricityBill = 1,

        [Display(Name = "Doğalgaz Faturası")]
        NaturalGasBill = 2,

        [Display(Name = "Su Faturası")]
        WaterBill = 3
    }
}
