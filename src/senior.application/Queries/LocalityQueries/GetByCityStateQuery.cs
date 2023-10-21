using senior.domain.Abstractions.Messaging;

namespace senior.application.Queries.LocalityQueries;

public class GetByCityStateQuery : IQuery
{
    public GetByCityStateQuery(string cityState)
    {
        CityState = cityState;
    }

    public string CityState { get; set; }
}
