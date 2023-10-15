using senior.domain.Entites;
using senior.domain.ValueObjects;
using System.Linq.Expressions;

namespace senior.domain.Queries
{
    public static class LocalityQueries
    {
        public static Expression<Func<Locality, bool>> GetLocalityByIbgeCode(string ibgeCode)
        {
            return x => x.Id == ibgeCode;
        }

        public static Expression<Func<Locality, bool>> GetLocalityByState(CityState state)
        {
            return x => x.State == state;
        }

        public static Expression<Func<Locality, bool>> GetLocalityByCityName(CityName city)
        {
            return x => x.City == city;
        }
    }
}
