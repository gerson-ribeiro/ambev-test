using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public Guid CustomerId { get; set; }
    public User Customer { get; set; }
    public double Total { get; set; }
    public Branch Branch { get; set; }
    public Guid BranchId { get; set; }
    public SaleStatus Status { get; set; }
    public virtual List<SaleItem> Items { get; set; }
    public Sale(int saleNumber, DateTime date, double total, SaleStatus status)
    {
        SaleNumber = saleNumber;
        Date = date;
        Total = total;
        Status = status;
    }
}