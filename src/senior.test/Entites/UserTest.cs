using senior.domain.Entites;

namespace senior.test.Entites
{
    [TestClass]
    public class UserTest
    {
        private readonly User userBase;
        private readonly User userModified;

        public UserTest()
        {
            userBase = new User(
                "Silvério Botelho de Rezende Carvalho",
                "silveriobrc@gmail.com");

            userModified = new User(
                 "Silvério Botelho de Rezende Carvalho",
                 "silveriobrc@gmail.com");
        }

        [TestMethod]
        public void ShouldAlterUserNameInPrivateClassMethods()
        {
            userModified.AlterName("Nome Alterado");
            Assert.AreNotEqual(userBase.Name, userModified.Name);
        }

        [TestMethod]
        public void ShouldAlterUserPasswordInPrivateClassMethods()
        {
            userModified.AlterPassword("Nova Senha");
            Assert.AreNotEqual(userBase.PasswordHash, userModified.PasswordHash);
        }
    }
}