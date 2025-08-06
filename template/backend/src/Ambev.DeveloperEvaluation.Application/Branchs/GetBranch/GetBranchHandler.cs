using Ambev.DeveloperEvaluation.Application.Categories.GetCategory;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

public class GetBranchHandler : IRequestHandler<GetBranchQuery, GetBranchResult>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    public GetBranchHandler(IBranchRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }
    public async Task<GetBranchResult> Handle(GetBranchQuery request, CancellationToken cancellationToken)
    {
        var brach = await _branchRepository.GetByIdAsync(request.Id, cancellationToken);
        if (brach == null)
            throw new Exception($"Brach with ID {request.Id} not found.");

        return _mapper.Map<GetBranchResult>(brach);
    }
}
