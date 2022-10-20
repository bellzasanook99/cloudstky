using cloudstky.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cloudstky.Service.Interface
{
    public interface IProductsService
    {
        Task<List<TblProduct>> Products();

        Task<List<MtbUnitType>> GetUnitTypes();
    }
}
