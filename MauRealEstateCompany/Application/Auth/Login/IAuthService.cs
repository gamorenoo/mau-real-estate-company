using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.Login
{
    public interface IAuthService
    {
        /// <summary>
        /// Login in Api
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Login(string username, string password);

        /// <summary>
        /// Get Token actual sesion
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        string GetToken(string username);
    }
}
