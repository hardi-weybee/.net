using Microsoft.AspNetCore.JsonPatch;
using SpecsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecsAPI.Repository
{
    public interface ISpecssRepository
    {
        Task<List<SpecModel>> GetAllSpecsAsync();

        Task<SpecModel> GetSpecsByIDAsync(int specID);

        Task<int> AddSpecAsync(SpecModel specModel);

        Task UpdateSpecsAsync(int specID, SpecModel specModel);

        Task UpdateSpecPatchAsync(int specID, JsonPatchDocument specModel);

        Task DeleteSpecAsync(int specID);
    }
}
