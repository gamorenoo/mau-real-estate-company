using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.Login
{
    public interface IAuthService
    {
        bool Login(string username, string password);

        string GetToken(string username);
    }
}
