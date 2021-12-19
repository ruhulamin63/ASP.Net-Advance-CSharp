using BEL.ManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public partial class UserModel
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string usertype { get; set; }
        public string verification_status { get; set; }
        public string id_status { get; set; }

        public virtual  List<ServiceProviderModel> ServiceProviders { get; set; }
        public virtual List<ProfileModel> ProfilePictures { get; set; }
    }
}
