using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Promotion : BaseEntity
{
    public string Identification { get; set; }
    public double Percent { get; set; }
    public int? MaxUnit { get; set; }
    public int MinUnit { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public Promotion(string identification, double percent, int? maxUnit, int minUnit, DateTime? expirationDate)
    {
        Identification = identification;
        Percent = percent;
        MaxUnit = maxUnit;
        MinUnit = minUnit;
        ExpirationDate = expirationDate;
    }

}