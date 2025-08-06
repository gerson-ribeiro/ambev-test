using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

public class GetBranchQuery : IRequest<GetBranchResult>
{
    public Guid Id { get; set; }
}
