using senior.domain.Entites;

namespace senior.test.Entites
{
    [TestClass]
    public class LocalityTest
    {
        private readonly Locality localityBase;
        private readonly Locality localityModified;

        public LocalityTest()
        {
            localityBase = new Locality(
                "5107602",
                "Rondonópolis",
                "MT");

            localityModified = new Locality(
                "5100300",
                "Alto Araguaia",
                "MT");
        }

        [TestMethod]
        public void ShouldAlterCityNameInPrivateClassMethods()
        {
            localityModified.AlterCity("Novo Nome");
            Assert.AreNotEqual(localityBase.City, localityModified.City);
        }

        [TestMethod]
        public void ShouldAlterLocalityStateInPrivateClassMethods()
        {
            localityModified.AlterState("Novo Estado");
            Assert.AreNotEqual(localityBase.State, localityModified.State);
        }
    }
}