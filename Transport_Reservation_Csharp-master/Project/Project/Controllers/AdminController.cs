using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Controllers
{
    public class AdminController
    {
        static Database db = new Database();
        public static List<Admin> getAllAdmin()
        {
            return db.Admins.getAllAdmin();
        }

        public static bool addAdmin(dynamic admin)
        {
            if(admin.name.Length==0 || admin.username.Length==0 || admin.password.Length == 0)
            {
                MessageBox.Show("Fill all the required fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var has = searchAdmin(admin.username);
            if (has != null)
            {
                MessageBox.Show("Username already exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            bool res = db.Admins.addAdmin(admin);
            if (res) return true;
            else MessageBox.Show("Could not added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public static Admin searchAdmin(string username)
        {
            return db.Admins.searchAdmin(username); 
        }

        public static bool deleteAdmin(int id)
        {
            if (id == 0)
            {
                MessageBox.Show("Search a admin first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return db.Admins.deleteAdmin(id);
        }

        public static bool updateAdmin(dynamic admin)
        {
            if (admin.id == 0)
            {
                MessageBox.Show("Search a admin first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (admin.name.Length == 0 || admin.username.Length == 0 || admin.password.Length == 0)
            {
                MessageBox.Show("Fill all the required fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var has = searchAdmin(admin.username);
            if (has != null && has.Id != admin.id)
            {
                MessageBox.Show("Username already exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            bool res = db.Admins.updateAdmin(admin);
            if (res) return true;
            else
            {
                MessageBox.Show("Could not updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
