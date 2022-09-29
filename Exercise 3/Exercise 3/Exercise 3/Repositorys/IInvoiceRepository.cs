using Exercise_3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise_3.Repositorys
{
    public interface IInvoiceRepository
    {
        Task<int> AddInvoice(InvoiceModel model, int id);
        Task<List<InvoiceModel>> DisplayTable(int _partyid);
        Task<List<AssignPartyModel>> getProductByParty(int partyid);
        Task<int> getRateByProduct(int productid);
    }
}