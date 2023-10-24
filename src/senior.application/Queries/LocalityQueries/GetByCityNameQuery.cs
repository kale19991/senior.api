using senior.domain.Abstractions.Messaging;

namespace senior.application.Queries.LocalityQueries;

public class GetByCityNameQuery : IQuery
{
    public GetByCityNameQuery(string cityName)
        => CityName = cityName;

    public string CityName { get; }
}
