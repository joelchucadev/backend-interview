using Code.Handlers.Factory;
using Code.Handlers.RequestModel;
using Code.Repository;
using Code.Service;
using MediatR;

namespace Code.Handlers
{
    //Part of Command Handler pattern
    public class InfoRequestHandler : IRequestHandler<InfoRequest, string>
    {
        private readonly IPatternSolver _patterSolver;
        private readonly IResultRepository _patternRepository;
        private readonly IResultFactory _factory;

        public InfoRequestHandler(IPatternSolver patterSolver, IResultRepository repository, IResultFactory factory)
        {
            _patterSolver = patterSolver;
            _patternRepository = repository;
            _factory = factory;
        }

        public Task<string> Handle(InfoRequest request, CancellationToken cancellationToken)
        {
            // Here is the complete operation
            // 1. Find the pattern
            var result = _patterSolver.FindPattern(request.Input);
            // 2. Generate the entity which will be persisted
            var resultEntity = _factory.CreateResultEntity(request, result);
            // 3. Save the entity to the repository
            _patternRepository.SaveResult(resultEntity);

            return Task.FromResult(result);
        }
    }
}