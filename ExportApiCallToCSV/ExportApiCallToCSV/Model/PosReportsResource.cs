using System.Collections.Generic;

namespace ExportApiCallToCSV.Model
{
    public class PosReportsResource
    {
        public PosReportsResource()
        {
            Payments = new List<Payment>();
            Taxes = new List<Tax>();
        }
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int InvoicesSold { get; set; }
        public int InvoicesRef { get; set; }
        public int NetSold { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalInvoiced { get; set; }
        public decimal TotalCost { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal TotalDiscounted { get; set; }
        public IList<Payment> Payments { get; set; }
        public IList<Tax> Taxes { get; set; }
    }
}