using cloudstky.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cloudstky.Service.Interface
{
    public interface IProductsService
    {
        Task<List<TblProduct>> Products();

        Task<List<MtbUnitType>> GetUnitTypes();

        Task<int> SaveProduct(TblProduct tblProduct,List<TblProdGallery> tblProdGalleries);

    
      
        Task<List<TblProduct>> GetProducts();

        Task<List<TblProdGallery>> GetProdGallerys();
    }
}
