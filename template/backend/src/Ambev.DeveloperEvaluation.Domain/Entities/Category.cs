using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Category : BaseEntity
{
    public Category(string identification, string displayName)
    {
        Identification = identification;
        DisplayName = displayName;
    }

    public string Identification { get; set; }
    public string DisplayName { get; set; }

    public virtual IList<Promotion> Promotions { get; set; } = new List<Promotion>();
}
