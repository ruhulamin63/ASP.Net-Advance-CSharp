using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Controllers
{
    class SalesmanController
    {
        static Database db = new Database();

        public static List<Salesman> getAllSalesman()
        {
            return db.Sellers.getAllSalesman();
        }
        public static bool addSalesman(dynamic salesman)
        {
            if (salesman.name.Length == 0 || salesman.username.Length == 0 || salesman.password.Length == 0)
            {
                MessageBox.Show("Fill all the required field", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var has = searchSalesman(salesman.username);
            if (has != null)
            {
                MessageBox.Show("Username already used", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return db.Sellers.addSalesMan(salesman);
        }
        public static Salesman searchSalesman(string username)
        {
            return db.Sellers.searchSalesman(username);
        }
        public static bool updateSalesman(dynamic salesman)
        {
            if (salesman.id == 0)
            {
                MessageBox.Show("Search a Salesman First", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (salesman.name.Length == 0 || salesman.username.Length == 0 || salesman.password.Length == 0)
            {
                MessageBox.Show("Fill all the required fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var has = searchSalesman(salesman.username);
            if (has != null) { MessageBox.Show("Username already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return db.Sellers.updateSalesman(salesman);
        }
        public static bool deleteSalesman(int id)
        {
            if (id == 0)
            {
                MessageBox.Show("Search a Salesman First", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return db.Sellers.deleteSalesman(id);
        }
    }
}
