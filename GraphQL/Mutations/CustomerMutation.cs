using System.Threading.Tasks;
using Database_EFC.Repositories;
using Entity.ModelData;
using HotChocolate;

namespace CarSharing_Database_GraphQL.Mutations
{
    public partial class Mutation
    {
        public async Task<Customer> AddCustomer([Service] ICustomerRepo customerRepo, Customer customer)
        {
            return await customerRepo.AddAsync(customer);
        }
        
        public async Task<Customer> UpdateCustomer([Service] ICustomerRepo customerRepo, Customer customer)
        {
            return await customerRepo.UpdateAsync(customer);
        }
        
        public async Task<bool> RemoveCustomer([Service] ICustomerRepo customerRepo, string cpr)
        {
            return await customerRepo.RemoveAsync(cpr);
        }
    }
}