using Microsoft.AspNetCore.JsonPatch;
using Specss.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Specss.API.Repository
{
    public interface ISpecssRepository
    {
        Task<List<SpecsModel>> GetAllSpecsAsync();

        Task<SpecsModel> GetSpecsByIDAsync(int specID);

        Task<int> AddSpecAsync(SpecsModel specModel);

        Task UpdateSpecsAsync(int specID, SpecsModel specModel);

        Task UpdateSpecPatchAsync(int specID, JsonPatchDocument specModel);

        Task DeleteSpecAsync(int specID);
    }
}
