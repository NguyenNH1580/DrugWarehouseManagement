using DrugWarehouseManagement_API.Data;
using DrugWarehouseManagement_API.Entities;

namespace DrugWarehouseManagement_API.Repositories
{
    public class UserRepository : CommonRepository<User>, IUserRepository
    {
        public UserRepository(DrugHousewareManagementDbContext context) : base(context)
        {
        
        }

        public void TestMethod()
        {
            Console.WriteLine("TestMethod");
        }
    }
}
