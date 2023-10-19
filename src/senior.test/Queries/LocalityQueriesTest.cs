using senior.domain.Entites;
using senior.domain.Queries;
using senior.domain.ValueObjects;

namespace senior.test.Queries;

[TestClass]
public class LocalityQueriesTest
{
    private IList<Locality> _locality;
    public LocalityQueriesTest()
    {        
        _locality = new List<Locality>();

        for (int i = 10; i <= 30; i++)
        {
            _locality.Add(
                new Locality(
                    new IbgeCode($"{i}11111"),
                    new CityName($"Cidade {i}"),
                    new CityState($"{i}")));
        }
    }

    [TestMethod]
    public void ShouldReturnNullWhenIbgeCodeNotExists()
    {
        var exp = LocalityQueries.GetLocalityByIbgeCode("9911111");
        var loc = _locality.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreEqual(null, loc);
    }

    [TestMethod]
    public void ShouldReturnNullWhenStateNotExists()
    {
        var exp = LocalityQueries.GetLocalityByState("99");
        var loc = _locality.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreEqual(null, loc);
    }

    [TestMethod]
    public void ShouldReturnNullWhenCityNotExists()
    {
        var exp = LocalityQueries.GetLocalityByCityName("Cidade 99");
        var loc = _locality.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreEqual(null, loc);
    }
}
