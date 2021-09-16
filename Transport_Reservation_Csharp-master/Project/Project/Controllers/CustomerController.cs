using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Controllers
{
    public class CustomerController
    {
        static Database db = new Database();

        public static List<Customer> getAllCustomer()
        {
            return db.Customers.getAllCustomer();
        }
        public static bool addCustomer(dynamic customer)
        {
            return db.Customers.addCustomer(customer);
        }
        public static Customer searchCustomer(string phone)
        {
            return db.Customers.searchCustomer(phone);
        }
        public static bool deleteCustomer(int id)
        {
            if (id== 0)
            {
                MessageBox.Show("Search a customer first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return db.Customers.deleteCustomer(id);
        }
        public static bool updateCustomer(dynamic customer)
        {
            if (customer.id == 0)
            {
                MessageBox.Show("Search a customer first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (customer.name.Length == 0 || customer.phone.Length == 0)
            {
                MessageBox.Show("Fill all the required Fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var has = searchCustomer(customer.phone);
            if (has != null && customer.id != has.Id)
            {
                MessageBox.Show(string.Format("Error!! Phone number matched with {0}", has.Name), "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return db.Customers.updateCustomer(customer);
        }
    }
}
