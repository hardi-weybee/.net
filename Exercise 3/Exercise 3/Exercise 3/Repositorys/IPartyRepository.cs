using Exercise_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise_3.Repositorys
{
    public interface IPartyRepository
    {
        Task<bool> DeleteParty([FromRoute] int id);
        Task<int> EditParty(PartyModel model, [FromRoute] int id);
        Task<List<PartyModel>> GetAllParty();
        Task<int> SaveParty(PartyModel model);
    }
}