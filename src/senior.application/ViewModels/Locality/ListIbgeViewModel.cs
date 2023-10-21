using senior.domain.Abstractions.Messaging;

namespace senior.application.ViewModels.Locality
{
    public class ListIbgeViewModel : IQueryResult
    {
        public string IbgeCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
    }
}
