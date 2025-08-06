using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Branch : BaseEntity
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
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User CreatedBy { get; set; } = new User();
    public virtual IList<Sale> Sales { get; set; } = new List<Sale>();
    public Branch()
    {
        
    }
    public Branch(string branchIdentifier, string branchNumber, string companyName, string partner, string address, string number, string city, string state, string country, string postalCode, string phoneNumber, string emailAddress, DateTime createdAt, DateTime updatedAt)
    {
        BranchIdentifier = branchIdentifier;
        BranchNumber = branchNumber;
        CompanyName = companyName;
        Partner = partner;
        Address = address;
        Number = number;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
        PhoneNumber = phoneNumber;
        EmailAddress = emailAddress;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}