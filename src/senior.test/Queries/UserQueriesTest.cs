using senior.domain.Entites;
using senior.domain.Queries;

namespace senior.test.Queries
{
    [TestClass]
    public class UserQueriesTest
    {
        private IList<User> _users;

        public UserQueriesTest()
        {
            _users = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                _users.Add(
                    new User(
                        $"Nome {i}", 
                        "silveriobrc@gmail.com"));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenEmailNotExist()
        {
            var exp = UserQueries.GetUserByEmail("silveriobrc@hotmail.com");
            var loc = _users.AsQueryable().Where(exp).FirstOrDefault();

            Assert.IsNull(loc);
        }
    }
}