using Exercise_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise_3.Repositorys
{
    public interface IAssignPartyRepository
    {
        Task<bool> DeleteAssignParty([FromRoute] int id);
        Task<int> EditAssignParty(AssignPartyModel model);
        List<AssignPartyModel> GetAllAssignParty();
        Task<List<ProductModel>> getProductsNotAssigned(int partyid);
        Task<int> SaveAssignParty(AssignPartyModel model);
        Task<List<AssignPartyModel>> UniqueParty();
    }
}