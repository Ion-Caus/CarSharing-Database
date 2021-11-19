using System.Threading.Tasks;
using Database_EFC.Repositories;
using Entity.ModelData;
using HotChocolate;

namespace CarSharing_Database_GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<Account> AddAccount([Service] IAccountRepo accountRepo, Account account)
        {
            return await accountRepo.AddAsync(account);
        }
    }
}