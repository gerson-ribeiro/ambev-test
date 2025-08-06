using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

public class CreateBranchCommand : IRequest<CreateBranchResult>
{
    public string BranchIdentifier { get; set; }
    public string BranchNumber { get; set; }
    public string CompanyName { get; set; }
    public string Partner { get; set; }
    public string Address { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public User CreatedBy { get; set; } = new User();
}
