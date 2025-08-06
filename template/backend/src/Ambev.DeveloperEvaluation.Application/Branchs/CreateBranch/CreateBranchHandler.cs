using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

public  class CreateBranchHandler : IRequestHandler<CreateBranchCommand, CreateBranchResult>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;
    public CreateBranchHandler(IBranchRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }
    public async Task<CreateBranchResult> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = _mapper.Map<Branch>(request);
        var createdBranch = await _branchRepository.CreateAsync(branch, cancellationToken);
        return _mapper.Map<CreateBranchResult>(createdBranch);
    }
}
