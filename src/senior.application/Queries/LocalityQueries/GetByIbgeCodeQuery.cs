using senior.domain.Abstractions.Messaging;

namespace senior.application.Queries.LocalityQueries;

public class GetByIbgeCodeQuery : IQuery
{
    public GetByIbgeCodeQuery(string ibgeCode)
    {
        IbgeCode = ibgeCode;
    }

    public string IbgeCode { get; }
}
