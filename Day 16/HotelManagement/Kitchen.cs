using MetroFramework.Forms;
using MetroFramework.Fonts;
using MetroFramework.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL.Context;
using DAL.Managers;
using DAL.Models;
namespace Hotel_Manager
{
    public partial class Kitchen : MetroForm
    {
        string cleaning, towel, surprise, queryString;
        int breakfast, lunch, dinner, foodBill;
        public Int32 primaryID;
        double totalBill;
        bool supply_status = false;

        SqlConnection connection = new SqlConnection(Hotel_Manager.Properties.Settings.Default.frontend_reservationConnectionString);
        SqlCommand query;
        SqlDataReader reader;
        
        public Kitchen()
        {
            InitializeComponent();

        }
        private void kitchen_Load(object sender, EventArgs e)
        {
            LoadForDataGridView();
            listBoxFromDataBase();
        }

        private void LoadForDataGridView()
        {
            try
            {

                var reservations = ReservationManager.DapperLoadKitchen();
                overviewDataGridView.DataSource = new BindingSource { DataSource = reservations };
                
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Error loading data: " + ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }


        private void resetEntries(Control controls)
        {
            foreach (Control control in controls.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                if (control.HasChildren)
                {
                    resetEntries(control);
                }
            }

        }
        private void listBoxFromDataBase()
        {
            queueListBox.Items.Clear(); 

            try
            {
                var reservations = ReservationManager.DapperLoadReservations();

                foreach (var reservation in reservations)
                {
                    string entry = $"{reservation.Id} | {reservation.FirstName} {reservation.LastName} | {reservation.PhoneNumber}";
                    queueListBox.Items.Add(entry);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Error loading data: " + ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }


        private void queueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetEntries(this);

            try
            {
                string selectedText = queueListBox.Text.Substring(0, 4).Replace(" ", string.Empty);
                if (!int.TryParse(selectedText, out int reservationId))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var reservation = ReservationManager.DapperGetReservationById(reservationId);

                if (reservation == null)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Reservation not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                firstNameTextBox.Text = reservation.FirstName;
                lastNameTextBox.Text = reservation.LastName;
                phoneNTextBox.Text = reservation.PhoneNumber;
                roomTypeTextBox.Text = reservation.RoomType;
                floorNTextBox.Text = reservation.RoomFloor;
                roomNTextBox.Text = reservation.RoomNumber;

                totalBill = reservation.TotalBill - reservation.FoodBill;
                foodBill = reservation.FoodBill;
                primaryID = reservation.Id;

                cleaningCheckBox.Checked = reservation.Cleaning;
                towelCheckBox.Checked = reservation.Towel;
                surpriseCheckBox.Checked = reservation.SSurprise;
                supplyCheckBox.Checked = reservation.SupplyStatus;

                breakfastTextBox.Text = reservation.BreakFast > 0 ? reservation.BreakFast.ToString() : "NONE";
                lunchTextBox.Text = reservation.Lunch > 0 ? reservation.Lunch.ToString() : "NONE";
                dinnerTextBox.Text = reservation.Dinner > 0 ? reservation.Dinner.ToString() : "NONE";
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Error loading reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void foodSelectionButton_Click(object sender, EventArgs e)
        {

            FoodMenu food_menu = new FoodMenu();
            food_menu.needPanel.Visible = false;

            food_menu.ShowDialog();

            breakfast = food_menu.BreakfastQ;
            lunch = food_menu.LunchQ;
            dinner = food_menu.DinnerQ;

            int bfast= 0, Lnch= 0, di_ner = 0;
            if (breakfast > 0)
            {
                bfast = 7 * breakfast;
            } if (lunch > 0)
            {
                Lnch = 15 * lunch;
            } if (dinner > 0)
            {
                di_ner = 15 * dinner;
            }
            foodBill += (bfast + Lnch + di_ner);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (primaryID > 1000)
                {
                    var updatedReserve = new Reservation() 
                    { 
                        Id = primaryID,TotalBill = totalBill, BreakFast = breakfast, 
                        Lunch = lunch, Dinner = dinner, SupplyStatus = supplyCheckBox.Checked, 
                        Cleaning = cleaningCheckBox.Checked, Towel = towelCheckBox.Checked, 
                        SSurprise = surpriseCheckBox.Checked, FoodBill = foodBill 
                    };
                    bool isUpdated = ReservationManager.DapperUpdateKitchenReservation(updatedReserve);

                    if (isUpdated)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Entry successfully updated for User ID: " + primaryID,
                                                            "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        listBoxFromDataBase(); 
                        LoadForDataGridView();  
                        resetEntries(this);  
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Selected ID doesn't exist or no update has been done.", "Error",
                                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Invalid User ID.", "Error",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Error updating data: " + ex.Message, "Error",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void supplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            cleaningCheckBox.Checked = false;
            cleaningCheckBox.Text = "Cleaned";
            towelCheckBox.Checked = false;
            towelCheckBox.Text = "Toweled";
            surpriseCheckBox.Checked = false;
            surpriseCheckBox.Text = "Surprised";
            supply_status = true;
        }
        private void kitchen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
