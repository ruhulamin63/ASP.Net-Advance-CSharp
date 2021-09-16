using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Controllers
{
    class ManagersController
    {
        static Database db = new Database();

        public static bool AddManager(dynamic manager)
        {
            if (manager.name.Length == 0 || manager.username.Length == 0 || manager.password.Length == 0)
            {
                MessageBox.Show("Fill all the required field", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var has = ManagersController.getSingleManager(manager.username);
            if (has != null)
            {
                MessageBox.Show("Username Already used", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            bool result = db.Managers.addManager(manager);
            if (result)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Could not Add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static List<Manager> getAllManager()
        {
            return db.Managers.getAllManager();
        }

        public static Manager getSingleManager(string username)
        {
            return db.Managers.getManager(username);
        }

        public static bool updateManager(dynamic manager)
        {
            if (manager.id == 0)
            {
                MessageBox.Show("Search a manager first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (manager.name.Length == 0 || manager.username.Length == 0 || manager.password.Length == 0)
            {
                MessageBox.Show("Fill all the required fields");
                return false;
            }
            var has = getSingleManager(manager.username);
            if(has != null) { MessageBox.Show("Username already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return db.Managers.updateManager(manager);
        }

        public static bool deleteManager(int id)
        {
            if (id == 0)
            {
                MessageBox.Show("Search a manager first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return db.Managers.deleteManager(id);
        }
    }
}
