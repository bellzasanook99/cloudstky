using cloudstky.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cloudstky.Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<TblAccount>> GetAccount();

        Task<TblAccount> GetAccount(MdlLogin mdlLogin);
    }
}
