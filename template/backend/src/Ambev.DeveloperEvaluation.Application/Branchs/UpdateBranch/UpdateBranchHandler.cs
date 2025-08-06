using Ambev.DeveloperEvaluation.ORM.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;

public class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, UpdateBranchResult>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    public UpdateBranchHandler(IBranchRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    public async Task<UpdateBranchResult> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetByIdAsync(request.Id, cancellationToken);
        if (branch == null)
        {
            throw new KeyNotFoundException($"Branch with ID {request.Id} not found.");
        }
        _mapper.Map(request, branch);
        var updated = await _branchRepository.UpdateAsync(branch, cancellationToken);
        if (!updated)
        {
            throw new Exception("Failed to update the branch.");
        }
        return _mapper.Map<UpdateBranchResult>(branch);
    }
}
