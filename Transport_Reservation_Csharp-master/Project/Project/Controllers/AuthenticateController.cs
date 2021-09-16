using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class AuthenticateController
    {
        public static AuthModel AuthController(string name, string password, string role)
        {
            return new Database().Authentication.Authenticate(name, password, role);
        }
    }
}
