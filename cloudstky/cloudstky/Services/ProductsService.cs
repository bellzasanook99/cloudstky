using cloudstky.Models;
using cloudstky.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cloudstky.Services
{
    public class ProductsService : IProductsService
    {
        private CloudStokyDBContext CloudStokyDBContext { get; }

        public ProductsService(CloudStokyDBContext cloudStokyDBContext)
        {
            CloudStokyDBContext = cloudStokyDBContext;
        }


        public async Task<List<TblProduct>> Products()
        {
            return await CloudStokyDBContext.TblProducts.ToListAsync();
        }

        public async Task<List<MtbUnitType>> GetUnitTypes()
        {
            return await CloudStokyDBContext.MtbUnitTypes.ToListAsync();
        }

        public async Task<int> SaveProduct(TblProduct  tblProduct,List<TblProdGallery> tblProdGalleries)
        {


            CloudStokyDBContext.TblProducts.Add(tblProduct);
           
         
            foreach(TblProdGallery tblProdGallery in tblProdGalleries)
            {
                CloudStokyDBContext.TblProdGalleries.Add(tblProdGallery);
            }
           


            return await CloudStokyDBContext.SaveChangesAsync();
        }


        public async Task<List<TblProduct>> GetProducts()
        {



            return await CloudStokyDBContext.TblProducts.ToListAsync();
        }

        public async Task<List<TblProdGallery>> GetProdGallerys()
        {



            return await CloudStokyDBContext.TblProdGalleries.ToListAsync();
        }
    }
}
