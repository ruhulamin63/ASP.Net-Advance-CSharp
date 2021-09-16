using Project.Controllers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Views
{
    public partial class SalesmanDashboard : Form
    {
        string bustype = "";
        int ticketId = 0;
        int managerId = 0;
        int salesmanId = 0;
        int customerId = 0;
        int busId = 0;

        public SalesmanDashboard()
        {
            InitializeComponent();

            reloadTickets();
            reloadManager();
            reloadSalesman();
            reloadCustomer();
            reloadBuses();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }
        private void logoutLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void managerLabel_Click(object sender, EventArgs e)
        {
            managerLabel.BackColor = Color.Teal;

            ticketsLabel.BackColor = Color.DimGray;
            salesmanLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            AdminPanel.Hide();
            salesmanPanel.Hide();
            managersPanel.Show();
            ticketsPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            homeLabel.Visible = true;

        }

        private void salesmanLabel_Click(object sender, EventArgs e)
        {
            salesmanLabel.BackColor = Color.Teal;

            ticketsLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            AdminPanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Show();
            ticketsPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            homeLabel.Visible = true;
        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            salesmanLabel.BackColor = Color.DimGray;
            ticketsLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            AdminPanel.Show();
            managersPanel.Hide();
            salesmanPanel.Hide();
            ticketsPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            homeLabel.Visible = false;
        }

        private void tickets_Click_2(object sender, EventArgs e)
        {
            ticketsLabel.BackColor = Color.Teal;

            salesmanLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            AdminPanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            ticketsPanel.Show();

            homeLabel.Visible = true;
        }

        private void busesLabel_Click(object sender, EventArgs e)
        {
            busesLabel.BackColor = Color.Teal;

            ticketsLabel.BackColor = Color.DimGray;
            salesmanLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            AdminPanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Hide();
            ticketsPanel.Hide();
            customersPanel.Hide();

            busesPanel.Show();

            homeLabel.Visible = true;
        }

        private void customersLabel_Click(object sender, EventArgs e)
        {
            customersLabel.BackColor = Color.Teal;

            ticketsLabel.BackColor = Color.DimGray;
            salesmanLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;

            AdminPanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Hide();
            ticketsPanel.Hide();
            busesPanel.Hide();

            customersPanel.Show();

            homeLabel.Visible = true;
        }

        public void reloadManager()
        {

            managerName.Text = "";
            managerUsername.Text = "";
            managerPassword.Text = "";
            managerSearchBox.Text = "";

            managerId = 0;
            managerTrash.Visible = false;
            //managerAddBtn.Enabled = true;

            dynamic managerlist = ManagersController.getAllManager();
            managerGridView.DataSource = managerlist;
        }
        public void reloadTickets()
        {
            ticketId = 0;
            customerName.Text = "";
            phoneBox.Text = "";
            ticketSource.Text = "From";
            ticketDest.Text = "To";
            coachBox.Text = "Coach";
            acRadioButton.Checked = false;
            nonAcRadioButton.Checked = false;
            journeyDate.Text = DateTime.Now.ToShortDateString();
            journeyTime.Text = "Time";

            journeyDate.MinDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            // for manager and salesman
            journeyDate.MaxDate = DateTime.Parse(DateTime.Now.AddDays(2).ToShortDateString());

            var coachlist = BusesController.getAllBus();
            coachBox.Items.Clear();
            foreach (var a in coachlist)
            {
                coachBox.Items.Add(a.Coach);
            }

            reserve = "";
            booked = "";
            seatList = allSeat();
            reloadSeat();

            ticketBookBtn.Enabled = true;
            trashTicket.Visible = false;

            var tickets = TicketsController.getAllTickets();
            ticketsGridView.DataSource = tickets;

            var reservation = ReservationController.getAllReservations();
            reservationGridView.DataSource = reservation;
        }
        public void reloadSalesman()
        {
            salesmanName.Text = "";
            salesmanUsername.Text = "";
            salesmanPassword.Text = "";
            salesmanSearchBox.Text = "";

            salesmanId = 0;
            //salesmanAddBtn.Enabled = true;
            salesmanTrash.Visible = false;

            dynamic salesmanlist = SalesmanController.getAllSalesman();
            salesmanGridView.DataSource = salesmanlist;
        }
        public void reloadCustomer()
        {
            customerId = 0;
            customerNameBox.Text = "";
            customerPhoneBox.Text = "";
            customerSearchBox.Text = "";
            customerTrash.Visible = false;

            var customerlist = CustomerController.getAllCustomer();
            customerGridView.DataSource = customerlist;
        }
        public void reloadBuses()
        {
            busSearchBox.Text = "";
            busCoachBox.Text = "";
            busAcRadio.Checked = false;
            busNonAcRadio.Checked = false;
            busesTime.Text = "Time";

            busId = 0;

            busTrash.Visible = false;
            //busAddBtn.Enabled = true;

            var bus = BusesController.getAllBus();
            busGridView.DataSource = bus;
        }

        ////
        ///
        //////// TICKET PANEL  ///////
        private void ticketBookBtn_Click(object sender, EventArgs e)
        {
            var ticket = new
            {
                name = customerName.Text.Trim(),
                phone = phoneBox.Text.Trim(),
                source = ticketSource.Text.Trim(),
                destination = ticketDest.Text.Trim(),
                coach = coachBox.Text.Trim(),
                type = bustype,
                date = journeyDate.Value.ToShortDateString(),
                time = journeyTime.Text.Trim(),
                author = Author.Name,
                seat = reserve,
                booked
            };

            bool res = TicketsController.boolTicket(ticket);
            if (res) { reloadTickets(); reloadCustomer(); MessageBox.Show("Ticket booked", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void acRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bustype = "AC";
        }

        private void nonAcRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bustype = "Non AC";
        }
        private void ticketsGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.ticketsGridView.Rows[e.RowIndex];
                ticketId = Int32.Parse(row.Cells["Id"].Value.ToString());
                customerName.Text = row.Cells["Name"].Value.ToString();
                phoneBox.Text = row.Cells["Phone"].Value.ToString();
                ticketSource.Text = row.Cells["Source"].Value.ToString();
                ticketDest.Text = row.Cells["Destination"].Value.ToString();
                coachBox.Text = row.Cells["Coach"].Value.ToString();
                journeyTime.Text = row.Cells["Time"].Value.ToString();



                DateTime date = DateTime.Parse(row.Cells["Date"].Value.ToString());
                if (date < journeyDate.MinDate)
                {
                    MessageBox.Show("You cannot modify or delete previous Tickets", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    reloadTickets();
                    return;
                }
                else if (date > journeyDate.MaxDate)
                {
                    MessageBox.Show("You cannot modify or delete this type of special tickets", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    reloadTickets();
                    return;
                }
                else journeyDate.Text = date.ToString();

                var abustype = row.Cells["BusType"].Value.ToString();
                if (abustype.Equals("AC"))
                {
                    acRadioButton.Checked = true;
                    nonAcRadioButton.Checked = false;
                }
                else if (abustype == "Non AC")
                {
                    nonAcRadioButton.Checked = true;
                    acRadioButton.Checked = false;
                }
                else
                {
                    acRadioButton.Checked = false;
                    nonAcRadioButton.Checked = false;
                }

                if (ticketId > 0)
                {
                    ticketBookBtn.Enabled = false;
                }
                trashTicket.Visible = true;

                ///seat selection////
                ///
                foreach (var s in seatList) s.Checked = false;
                reserve = row.Cells["Seat"].Value.ToString();
                seatSelectBtn.Text = reserve;

                if (reserve.Length > 0)
                {
                    char[] separator = { ',' };
                    string[] seats = reserve.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var seat in seats)
                    {
                        foreach (var seatlist in seatList)
                        {
                            if (seatlist.Text.Equals(seat.Trim()))
                            {
                                seatlist.Enabled = true;
                                seatlist.Checked = true;
                            }
                        }
                    }
                }
            }
        }

        private void coachBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var coach = BusesController.searchBus(coachBox.Text);
            if (coach != null)
            {
                bustype = coach.Type;
                if (bustype.Equals("AC"))
                {
                    acRadioButton.Checked = true;
                    nonAcRadioButton.Checked = false;
                }
                else if (bustype == "Non AC")
                {
                    nonAcRadioButton.Checked = true;
                    acRadioButton.Checked = false;
                }
                journeyTime.Text = coach.Time;
            }
        }

        private void ticketTrash_Click_1(object sender, EventArgs e)
        {
            reloadTickets();
        }

        private void ticketCancelBtn_Click(object sender, EventArgs e)
        {
            bool res = TicketsController.cancelTicket(ticketId);
            if (res) { reloadTickets(); MessageBox.Show("Ticket Cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void ticketUpdateBtn_Click(object sender, EventArgs e)
        {
            var ticket = new
            {
                id = ticketId,
                name = customerName.Text.Trim(),
                phone = phoneBox.Text.Trim(),
                source = ticketSource.Text.Trim(),
                destination = ticketDest.Text.Trim(),
                coach = coachBox.Text.Trim(),
                type = bustype,
                date = journeyDate.Value.ToShortDateString(),
                time = journeyTime.Text.Trim(),
                author = Author.Name,
                seat = reserve,
                booked
            };

            bool res = TicketsController.updateTicket(ticket);
            if (res) { reloadTickets(); MessageBox.Show("Ticket updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void ticketSearchBtn_Click(object sender, EventArgs e)
        {
            string phone = phoneBox.Text;
            var customer = CustomerController.searchCustomer(phone);
            if (customer != null)
            {
                customerName.Text = customer.Name;
            }
            else customerName.Text = "";
        }

        /////////// MANAGER PANEL //////////////

        private void managerAddBtn_Click(object sender, EventArgs e)
        {
            var manager = new
            {
                name = managerName.Text.Trim(),
                username = managerUsername.Text.Trim(),
                password = managerPassword.Text.Trim(),
            };
            bool res = ManagersController.AddManager(manager);
            if (res) { reloadManager(); MessageBox.Show("Manager Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        private void managerTrash_Click(object sender, EventArgs e)
        {
            reloadManager();
        }

        private void managerSearchBtn_Click(object sender, EventArgs e)
        {
            string username = managerSearchBox.Text;
            var manager = ManagersController.getSingleManager(username);

            if (manager == null)
            {
                MessageBox.Show("Manager not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                managerName.Text = manager.Name;
                managerUsername.Text = manager.Username;
                managerPassword.Text = manager.Password;
            }
            managerId = manager.Id;
            managerTrash.Visible = true;
            //managerAddBtn.Enabled = false;
        }

        private void managerUpdateBtn_Click(object sender, EventArgs e)
        {
            var newManager = new
            {
                id = managerId,
                name = managerName.Text,
                username = managerUsername.Text,
                password = managerPassword.Text
            };

            bool res = ManagersController.updateManager(newManager);
            if (res) { reloadManager(); MessageBox.Show("Manager updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void managerDeleteBtn_Click(object sender, EventArgs e)
        {
            bool res = ManagersController.deleteManager(managerId);
            if (res) { reloadManager(); MessageBox.Show("Manager Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        /////  SALESMAN PANEL /////

        private void salesmanAddBtn_Click(object sender, EventArgs e)
        {
            var salesman = new
            {
                name = salesmanName.Text.Trim(),
                username = salesmanUsername.Text.Trim(),
                password = salesmanPassword.Text.Trim()
            };

            bool res = SalesmanController.addSalesman(salesman);
            if (res) { reloadSalesman(); MessageBox.Show("Salesman Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void salesmanSearchBtn_Click(object sender, EventArgs e)
        {
            string username = salesmanSearchBox.Text.Trim();
            dynamic salesman = SalesmanController.searchSalesman(username);
            if (salesman == null)
            {
                MessageBox.Show("Salesman not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            salesmanId = salesman.Id;
            //salesmanAddBtn.Enabled = false;
            salesmanTrash.Visible = true;

            salesmanName.Text = salesman.Name;
            salesmanUsername.Text = salesman.Username;
            salesmanPassword.Text = salesman.Password;
        }

        private void salesmanUpdateBtn_Click(object sender, EventArgs e)
        {
            var newSalesman = new
            {
                id = salesmanId,
                name = salesmanName.Text.Trim(),
                username = salesmanUsername.Text.Trim(),
                password = salesmanPassword.Text.Trim()
            };

            bool res = SalesmanController.updateSalesman(newSalesman);
            if (res)
            {
                reloadSalesman();
                MessageBox.Show("Salesman Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void salesmanDeleteBtn_Click(object sender, EventArgs e)
        {
            bool res = SalesmanController.deleteSalesman(salesmanId);
            if (res) { reloadSalesman(); MessageBox.Show("Salesman Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void salesmanTrash_Click(object sender, EventArgs e)
        {
            reloadSalesman();
        }

        ///// BUSES PANEL /////
        string busType = "";
        private void busAcRadio_CheckedChanged(object sender, EventArgs e)
        {
            busType = "AC";
        }

        private void busNonAcRadio_CheckedChanged(object sender, EventArgs e)
        {
            busType = "Non AC";
        }

        private void busAddBtn_Click(object sender, EventArgs e)
        {
            var bus = new
            {
                coach = busCoachBox.Text.Trim(),
                type = busType,
                time = busesTime.Text.Trim()
            };

            bool res = BusesController.addBus(bus);
            if (res) { reloadBuses(); reloadTickets(); MessageBox.Show("Bus Added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void busSearchBtn_Click(object sender, EventArgs e)
        {
            string coach = busSearchBox.Text.Trim();
            var bus = BusesController.searchBus(coach);
            if (bus == null)
            {
                MessageBox.Show("Bus not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            busCoachBox.Text = bus.Coach;
            if (bus.Type == "AC") busAcRadio.Checked = true;
            else busNonAcRadio.Checked = true;
            busesTime.Text = bus.Time;

            busId = bus.Id;

            //busAddBtn.Enabled = false;
            busTrash.Visible = true;
        }

        private void busTrash_Click(object sender, EventArgs e)
        {
            reloadBuses();
        }

        private void busUpdateBtn_Click(object sender, EventArgs e)
        {
            var bus = new
            {
                id = busId,
                coach = busCoachBox.Text.Trim(),
                type = busType,
                time = busesTime.Text.Trim()
            };

            bool res = BusesController.updateBus(bus);
            if (res) { reloadBuses(); reloadTickets(); MessageBox.Show("Bus updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void busRemoveBtn_Click(object sender, EventArgs e)
        {
            bool res = BusesController.deleteBus(busId);
            if (res) { reloadBuses(); reloadTickets(); MessageBox.Show("Bus deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        ///// CUSTOMERS PANEL  /////

        private void customerSearchBtn_Click(object sender, EventArgs e)
        {
            string phone = customerSearchBox.Text;
            var customer = CustomerController.searchCustomer(phone);
            if (customer == null)
            {
                MessageBox.Show("Customer not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            customerId = customer.Id;
            customerNameBox.Text = customer.Name;
            customerPhoneBox.Text = customer.Phone;
            customerTrash.Visible = true;
        }

        private void customerTrash_Click(object sender, EventArgs e)
        {
            reloadCustomer();
        }

        private void customerRemoveBtn_Click(object sender, EventArgs e)
        {
            bool res = CustomerController.deleteCustomer(customerId);
            if (res) { reloadCustomer(); MessageBox.Show("Customer Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void customerUpdateBtn_Click(object sender, EventArgs e)
        {
            var newCustomer = new
            {
                id = customerId,
                name = customerNameBox.Text,
                phone = customerPhoneBox.Text
            };

            bool res = CustomerController.updateCustomer(newCustomer);
            if (res) { reloadCustomer(); MessageBox.Show("Customer Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        ///////////////////// SEAT PANEL  /////////////////////

        List<CheckBox> seatList = null;

        private void seatSelectBtn_Click(object sender, EventArgs e)
        {
            if (seatSelectBtn.Text.Equals("Select Seat")) reloadSeat();

            if (coachBox.Text.Equals("Coach")) { MessageBox.Show("Select a coach first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (ticketSource.Text.Equals("From")) { MessageBox.Show("Select a source first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (ticketDest.Text.Equals("To")) { MessageBox.Show("Select a destination first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var coachInfo = new
            {
                coach = coachBox.Text.Trim(),
                source = ticketSource.Text.Trim(),
                destination = ticketDest.Text.Trim(),
                date = journeyDate.Text.Trim(),
                time = journeyTime.Text.Trim()
            };
            var reservedCoach = ReservationController.getSingleCoachReservation(coachInfo);
            if (reservedCoach == null)
            {
                coachNameSeat.Text = coachInfo.coach;
                bookedCount.Text = "0";
                availableCount.Text = "40";
                foreach (var s in seatList)
                {
                    //s.Checked = false;
                    s.Enabled = true;
                    s.BackColor = Color.Transparent;
                }
            }
            else
            {
                coachNameSeat.Text = coachInfo.coach;
                bookedCount.Text = reservedCoach.Booked.ToString();
                availableCount.Text = reservedCoach.Available.ToString();
                char[] separator = { ',' };
                string[] bookedSeats = reservedCoach.Seats.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                string[] reservedSeats = reserve.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in seatList) { s.Checked = false; s.Enabled = true; s.BackColor = Color.Transparent; }

                foreach (var s in seatList)
                {
                    foreach (var bs in bookedSeats)
                    {
                        if (s.Text.Equals(bs.Trim()))
                        {
                            s.BackColor = Color.DimGray;
                            s.Enabled = false;
                        }
                    }
                    foreach (var rs in reservedSeats)
                    {
                        if (s.Text.Equals(rs.Trim()))
                        {
                            s.Enabled = true;
                            s.Checked = true;
                            s.BackColor = Color.Transparent;
                        }
                    }
                }
            }
            trashSeat.Visible = false;
            seatPanel.Show();
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            if (reserve.Length > 0)
            {
                seatSelectBtn.Text = reserve;
            }
            else seatSelectBtn.Text = "Select Seat";
            seatPanel.Hide();
        }

        public List<CheckBox> allSeat()
        {
            List<CheckBox> seat = new List<CheckBox>();
            seat.Add(a1); seat.Add(a2); seat.Add(a3); seat.Add(a4);
            seat.Add(b1); seat.Add(b2); seat.Add(b3); seat.Add(b4);
            seat.Add(c1); seat.Add(c2); seat.Add(c3); seat.Add(c4);
            seat.Add(d1); seat.Add(d2); seat.Add(d3); seat.Add(d4);
            seat.Add(e1); seat.Add(e2); seat.Add(e3); seat.Add(e4);
            seat.Add(f1); seat.Add(f2); seat.Add(f3); seat.Add(f4);
            seat.Add(g1); seat.Add(g2); seat.Add(g3); seat.Add(g4);
            seat.Add(h1); seat.Add(h2); seat.Add(h3); seat.Add(h4);
            seat.Add(i1); seat.Add(i2); seat.Add(i3); seat.Add(i4);
            seat.Add(j1); seat.Add(j2); seat.Add(j3); seat.Add(j4);
            return seat;
        }

        private void TrashSeatBtn_Click(object sender, EventArgs e)
        {
            reloadSeat();
        }

        private void reloadSeat()
        {
            foreach (var seat in seatList)
            {
                seat.Checked = false;
                seat.BackColor = Color.Transparent;
            }
            trashSeat.Visible = false;
            seatSelectBtn.Text = "Select Seat";
        }

        string reserve = "";
        string booked = "";
        List<string> reserveList;
        List<string> bookedList;
        private void seat_CheckedChanged(object sender, EventArgs e)
        {
            reserveList = new List<string>();
            bookedList = new List<string>();

            foreach (var seat in seatList)
            {
                if (seat.Checked == true)
                {
                    reserveList.Add(seat.Text);
                }

                if (seat.Checked == true || seat.Enabled == false)
                {
                    bookedList.Add(seat.Text);
                }

                if (reserveList.Count > 0) trashSeat.Visible = true;
                else trashSeat.Visible = false;
            }

            reserve = string.Join(", ", reserveList);
            reserveString.Text = reserve;

            booked = string.Join(", ", bookedList);
        }

        private void ticketListLabel_Click(object sender, EventArgs e)
        {
            if (seatSelectBtn.Text.Equals("Select Seat")) reloadSeat();

            ticketListLabel.BackColor = SystemColors.MenuHighlight;
            ticketsGridView.Visible = true;

            reservationLabel.BackColor = Color.DimGray;
            reservationGridView.Visible = false;
        }

        private void reservationLabel_Click(object sender, EventArgs e)
        {
            if (ticketId > 0) reloadTickets();

            ticketListLabel.BackColor = Color.DimGray;
            ticketsGridView.Visible = false;

            reservationLabel.BackColor = SystemColors.MenuHighlight;
            reservationGridView.Visible = true;
        }

        private void reservationGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                foreach (var s in seatList) s.Checked = false;

                DataGridViewRow row = this.reservationGridView.Rows[e.RowIndex];
                booked = row.Cells["Seats"].Value.ToString();
                coachNameSeat.Text = row.Cells["Coach"].Value.ToString();
                bookedCount.Text = row.Cells["Booked"].Value.ToString();
                availableCount.Text = row.Cells["Available"].Value.ToString();

                char[] separator = { ',' };
                string[] book = booked.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var b in book)
                {
                    foreach (var s in seatList)
                    {
                        if (b.Trim().Equals(s.Text))
                        {
                            s.CheckState = CheckState.Checked;
                            s.Enabled = false;
                        }
                        else s.Enabled = false;
                    }
                }
                trashSeat.Visible = false;
                reserve = "";
                seatPanel.Visible = true;
            }
        }
    }
}
