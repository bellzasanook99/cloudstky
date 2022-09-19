using cloudstky.Models;
using cloudstky.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cloudstky.Services
{
    public class UserService : IUserService
    {
        private CloudStokyDBContext CloudStokyDBContext { get; }

        public UserService(CloudStokyDBContext cloudStokyDBContext)
        {
            CloudStokyDBContext = cloudStokyDBContext;
        }

        public async Task<IEnumerable<TblAccount>> GetAccount()
        {
            return await CloudStokyDBContext.TblAccounts.ToListAsync();
        }

        public async Task<TblAccount> GetAccount(MdlLogin mdlLogin)
        {
            return await CloudStokyDBContext.TblAccounts.FirstOrDefaultAsync(m => ( m.AccEmail == mdlLogin.Username && m.AccPwd == mdlLogin.Password));
        }
    }
}
