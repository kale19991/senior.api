using AutoMapper;
using senior.application.Queries.LocalityQueries;
using senior.application.ViewModels.Locality;
using senior.domain.Abstractions.Messaging;
using senior.domain.Abstractions.Repositories;

namespace senior.application.Handlers;

public class LocalityQueryHandler : 
    IQueryHandler<GetByIbgeCodeQuery>,
    IQueryHandler<GetByCityNameQuery>,
    IQueryHandler<GetByCityStateQuery>
{
    private readonly ILocalityRepository _localityRepository;
    private readonly IMapper _mapper;

    public LocalityQueryHandler(
        ILocalityRepository localityRepository,
        IMapper mapper)
    {
        _localityRepository = localityRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<IQueryResult>> Handle(
        GetByIbgeCodeQuery query, 
        CancellationToken cancelationToken)
    {
        var localities = await _localityRepository.GetByIbgeAsync(query.IbgeCode);
        return _mapper.Map<IEnumerable<ListIbgeViewModel>>(localities);
    }

    public async Task<IEnumerable<IQueryResult>> Handle(
        GetByCityNameQuery query, 
        CancellationToken cancelationToken)
    {
        var localities = await _localityRepository.GetByCityNameAsync(query.CityName);
        return _mapper.Map<IEnumerable<ListIbgeViewModel>>(localities);
    }

    public async Task<IEnumerable<IQueryResult>> Handle(
        GetByCityStateQuery query, 
        CancellationToken cancelationToken)
    {
        var localities = await _localityRepository.GetByStateAsync(query.CityState);
        return _mapper.Map<IEnumerable<ListIbgeViewModel>>(localities);
    }
}
