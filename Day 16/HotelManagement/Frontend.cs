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
using System.Configuration;
using Twilio;
using System.Runtime.Remoting.Contexts;
using DAL.Managers;
using DAL.Context;
using DAL.Models;
namespace Hotel_Manager
{
    public partial class Frontend : MetroForm
    {
        string AccountSid = "ACcb86dacb791bef978628a2e16b1f7a24";
        string AuthToken = "3f344a07336d2e0ac5e467f72a1e650d";
        string RecvPhoneNumber = "";
        public Frontend()
        {
            InitializeComponent();
            CenterToScreen();
            entryDatePicker.MinDate = DateTime.Today;
            depDatePicker.MinDate = DateTime.Today.AddDays(1);

            LoadForDataGridView();
            GetOccupiedRoom();
            ReservedRoom();
            getChecked();

            this.roomOccupiedListBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.roomOccupiedListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.roomOccupiedListBox_DrawItem);
            this.roomReservedListBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.roomReservedListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.roomReservedListBox_DrawItem);
        }



        private void roomOccupiedListBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            this.roomOccupiedListBox.IntegralHeight = false;
            this.roomOccupiedListBox.ItemHeight = 25;
            e.DrawBackground();
            Font listBoxFont;
            Brush brush;

            int i = e.Index;

            listBoxFont = new Font("Segoe UI Symbol", 12.0f, FontStyle.Regular);
            brush = Brushes.Black;
            e.Graphics.DrawString(roomOccupiedListBox.Items[i].ToString(), listBoxFont, brush, e.Bounds, StringFormat.GenericTypographic);

        }
        private void roomReservedListBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            this.roomReservedListBox.IntegralHeight = false;
            this.roomReservedListBox.ItemHeight = 25;
            e.DrawBackground();
            Font listBoxFont;
            Brush brush;

            int i = e.Index;

            listBoxFont = new Font("Segoe UI Symbol", 12.0f, FontStyle.Regular);
            brush = Brushes.Black;
            e.Graphics.DrawString(roomReservedListBox.Items[i].ToString(), listBoxFont, brush, e.Bounds, StringFormat.GenericTypographic);

        }


        private string getval;

        public string Getval
        {
            get { return getval; }
            set { getval = value; }
        }

        public string towelS, cleaningS, surpriseS;

        public int foodBill;
        public string birthday = "";

        public string food_menu = "";
        public int totalAmount = 0;
        public int checkin = 0;
        public int foodStatus = 0;
        public Int32 primartyID = 0;
        public Boolean taskFinder = false;
        public Boolean editClicked = false;
        public string FPayment, FCnumber, FcardExpOne, FcardExpTwo, FCardCVC;
        private double finalizedTotalAmount = 0.0;
        private string paymentType;
        private string paymentCardNumber;
        private string MM_YY_Of_Card;
        private string CVC_Of_Card;
        private string CardType;

        private int lunch = 0; private int breakfast = 0; private int dinner = 0;
        private string cleaning; private string towel;
        private string surprise;

        private void MainTab_Load(object sender, EventArgs e)
        {
            foodSupplyCheckBox.Enabled = false;
           
        }

        public void foodMenuButton_Click(object sender, EventArgs e)
        {

            FoodMenu food_menu = new FoodMenu();
            if (taskFinder)
            {
                if (breakfast > 0)
                {
                    food_menu.breakfastCheckBox.Checked = true;
                    food_menu.breakfastQTY.Text = Convert.ToString(breakfast);
                }
                if (lunch > 0)
                {
                    food_menu.lunchCheckBox.Checked = true;

                    food_menu.lunchQTY.Text = Convert.ToString(lunch);
                }
                if (dinner > 0)
                {
                    food_menu.dinnerCheckBox.Checked = true;
                    food_menu.dinnerQTY.Text = Convert.ToString(dinner);
                }
                if (cleaning == "1")
                {
                    food_menu.cleaningCheckBox.Checked = true;
                }
                if (towel == "1")
                {
                    food_menu.towelsCheckBox.Checked = true;
                }
                if (surprise == "1")
                {
                    food_menu.surpriseCheckBox.Checked = true;
                }
            }
            food_menu.ShowDialog();

            breakfast = food_menu.BreakfastQ;
            lunch = food_menu.LunchQ;
            dinner = food_menu.DinnerQ;

            cleaning = food_menu.Cleaning.Replace(" ", string.Empty) == "Cleaning" ? "1" : "0";
            towel = food_menu.Towel.Replace(" ", string.Empty) == "Towels" ? "1" : "0";

            surprise = food_menu.Surprise.Replace(" ", string.Empty) == "Sweetestsurprise" ? "1" : "0";

            if (breakfast > 0 || lunch > 0 || dinner > 0)
            {
                int bfast = 7 * breakfast;
                int Lnch = 15 * lunch;
                int di_ner = 15 * dinner;
                foodBill = bfast + Lnch + di_ner;
            }
        }
     
        private void roomTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (roomTypeComboBox.SelectedItem.Equals("Single"))
            {
                totalAmount = 149;
                floorComboBox.SelectedItem = "1";
            }
            else if (roomTypeComboBox.SelectedItem.Equals("Double"))
            {
                totalAmount = 299;
                floorComboBox.SelectedItem = "2";
            }
            else if (roomTypeComboBox.SelectedItem.Equals("Twin"))
            {
                totalAmount = 349;
                floorComboBox.SelectedItem = "3";
            }
            else if (roomTypeComboBox.SelectedItem.Equals("Duplex"))
            {
                totalAmount = 399;
                floorComboBox.SelectedItem = "4";
            }
            else if (roomTypeComboBox.SelectedItem.Equals("Suite"))
            {
                totalAmount = 499;
                floorComboBox.SelectedItem = "5";
            }
            int selectedTemp = 0;
            string selected;
            bool temp = int.TryParse(qtGuestComboBox.SelectedItem.ToString(), out selectedTemp);
            if (!temp)
            {
                MetroFramework.MetroMessageBox.Show(this, "Enter # of guests first", "Error parsing", MessageBoxButtons.OK);
            }
            else
            {
                selected = qtGuestComboBox.SelectedItem.ToString();
                selectedTemp = Convert.ToInt32(selected);
                if (selectedTemp >= 3)
                {
                    totalAmount += (selectedTemp * 5);
                }
            }


        }

        private void editButton_Click(object sender, EventArgs e)
        {
            editClicked = true;
            entryDatePicker.MinDate = new DateTime(2014, 4, 1);
            entryDatePicker.CustomFormat = "MM-dd-yyyy";
            entryDatePicker.Format = DateTimePickerFormat.Custom;

            depDatePicker.MinDate = new DateTime(2014, 4, 1);
            depDatePicker.CustomFormat = "MM-dd-yyyy";
            depDatePicker.Format = DateTimePickerFormat.Custom;

            submitButton.Visible = false;
            updateButton.Visible = true;
            deleteButton.Visible = true;
            resEditButton.Visible = true;

            ComboBoxItemsFromDataBase();
            LoadForDataGridView();
            reset_frontend();
        }

        
        private void finalizeButton_Click(object sender, EventArgs e)
        {
            if (breakfast == 0 && lunch == 0 && dinner == 0 && cleaning == "0" && towel == "0" && surprise == "0")
            {
                foodSupplyCheckBox.Checked = true;
            }
            updateButton.Enabled = true;

            FinalizePayment finalizebil = new FinalizePayment();
            finalizebil.totalAmountFromFrontend = totalAmount;
            finalizebil.foodBill = foodBill;
            if (taskFinder)
            {
                finalizebil.paymentComboBox.SelectedItem = FPayment.Replace(" ", string.Empty);
                finalizebil.phoneNComboBox.Text = FCnumber;
                finalizebil.monthComboBox.SelectedItem = FcardExpOne;
                finalizebil.yearComboBox.SelectedItem = FcardExpTwo;
                finalizebil.cvcComboBox.Text = FCardCVC;
            }

            finalizebil.ShowDialog();

            finalizedTotalAmount = finalizebil.FinalTotalFinalized;
            paymentType = finalizebil.PaymentType;
            paymentCardNumber = finalizebil.PaymentCardNumber;
            MM_YY_Of_Card = finalizebil.MM_YY_Of_Card1;
            CVC_Of_Card = finalizebil.CVC_Of_Card1;
            CardType = finalizebil.CardType1;

            if (!editClicked)
            {
                submitButton.Visible = true;
            }
        }

        //private void SendSMS(int secondUserID)
        //{
        //    //creating an instance of twilio rest
        //    var twilio = new TwilioRestClient(AccountSid, AuthToken);
        //    string name = firstNameTextBox.Text + " " + lastNameTextBox.Text;

        //    string end_num = paymentCardNumber.Substring(paymentCardNumber.Length - Math.Min(4, paymentCardNumber.Length));

        //    if (smsCheckBox.Checked)
        //    {
        //        //building message for twilio
        //        string buildMesage = "Hello " + name + "! Your unique ID# " + secondUserID + " Total bill of $" + finalizedTotalAmount + " is charged on your card # ending-" + end_num;
        //        //creating message 
        //        var message = twilio.SendMessage("+12034562736", RecvPhoneNumber, buildMesage, "");
        //        //sending message
        //        Console.WriteLine(message.Sid);
        //        smsCheckBox.Text = "SMS Sent";
        //    }
        //}
      
        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                var reservation = new Reservation
                {
                    FirstName = firstNameTextBox.Text,
                    LastName = lastNameTextBox.Text,
                    BirthDay = $"{monthComboBox.SelectedItem}-{dayComboBox.SelectedIndex + 1}-{yearTextBox.Text}",
                    Gender = genderComboBox.SelectedItem?.ToString(),
                    PhoneNumber = phoneNumberTextBox.Text,
                    EmailAddress = emailTextBox.Text,
                    NumberGuest = qtGuestComboBox.SelectedIndex + 1,
                    StreetAddress = addLabel.Text,
                    AptSuite = aptTextBox.Text,
                    City = cityTextBox.Text,
                    State = stateComboBox.SelectedItem?.ToString(),
                    ZipCode = zipComboBox.Text,
                    RoomType = roomTypeComboBox.SelectedItem?.ToString(),
                    RoomFloor = floorComboBox.SelectedItem?.ToString(),
                    RoomNumber = roomNComboBox.SelectedItem?.ToString(),
                    TotalBill = finalizedTotalAmount,
                    PaymentType = paymentType,
                    CardType = CardType,
                    CardNumber = paymentCardNumber,
                    CardExp = MM_YY_Of_Card,
                    CardCvc = CVC_Of_Card,
                    ArrivalTime = entryDatePicker.Value,
                    LeavingTime = depDatePicker.Value,
                    CheckIn = checkin == 1,
                    BreakFast = breakfast,
                    Lunch = lunch,
                    Dinner = dinner,
                    SupplyStatus = foodStatus == 1,
                    Cleaning = cleaning == "1",
                    Towel = towel == "1",
                    SSurprise = surprise == "1",
                    FoodBill = foodBill
                };

                var insertedID = ReservationManager.InsertReservation(reservation);
                MetroFramework.MetroMessageBox.Show(this, "Entry successfully inserted into database. " + "\n\n" +
                    "Provide this unique ID to the customer." + "\n\n" +
                "USER UNIQUE ID: " + insertedID, "Report", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ComboBoxItemsFromDataBase();
            LoadForDataGridView();
            reset_frontend();
            GetOccupiedRoom();
            ReservedRoom();
            getChecked();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            submitButton.Visible = false;
            updateButton.Visible = false;
            deleteButton.Visible = false;
            resEditButton.Visible = false;
            reset_frontend();
        }
        public void ClearAllTextBoxes(Control controls)
        {
            foreach (Control control in controls.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                if (control.HasChildren)
                {
                    ClearAllTextBoxes(control);
                }
            }
        }
        public void ClearAllComboBox(Control controls){
            foreach(Control control in controls.Controls){
                if (control == roomTypeComboBox)
                {
                    continue;
                }
                else if(control is ComboBox){
                    ((ComboBox)control).SelectedIndex = -1;
                }
                if (control.HasChildren) {
                    ClearAllComboBox(control);
                }
            }
        }
        private void reset_frontend()
        {
            try
            {

                resEditButton.Items.Clear();
                checkinCheckBox.Checked = false;
                foodSupplyCheckBox.Checked = false;

                ClearAllComboBox(this);
                ClearAllTextBoxes(this);

                ComboBoxItemsFromDataBase();

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void frontend_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (primartyID > 1000)
            {
                try
                {
                    var deleted = ReservationManager.RemoveReservation(primartyID);


                    if(deleted)
                    MetroFramework.MetroMessageBox.Show(this, "Reservation For the UNIQUE USER ID of: " + "\n\n" +
                " " + primartyID + " is DELETED.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        MetroFramework.MetroMessageBox.Show(this, "Reservation For the UNIQUE USER ID of: " + "\n\n" +
                " " + primartyID + " is NOT DELETED.", "NOT Deleted", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Selected ID doesn't exist." + ex.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Selected ID doesn't exist.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            ComboBoxItemsFromDataBase();
            LoadForDataGridView();
            reset_frontend();
            GetOccupiedRoom();
            ReservedRoom();
            getChecked();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var updatedReservation = new Reservation
                {
                    Id = primartyID,
                    FirstName = firstNameTextBox.Text,
                    LastName = lastNameTextBox.Text,

                    BirthDay = $"{monthComboBox.SelectedItem}-{dayComboBox.SelectedIndex + 1}-{yearTextBox.Text}",

                    Gender = genderComboBox.SelectedItem?.ToString(),
                    PhoneNumber = phoneNumberTextBox.Text,
                    EmailAddress = emailTextBox.Text,
                    NumberGuest = qtGuestComboBox.SelectedIndex + 1,
                    StreetAddress = addLabel.Text,
                    AptSuite = aptTextBox.Text,
                    City = cityTextBox.Text,
                    State = stateComboBox.SelectedItem?.ToString(),
                    ZipCode = zipComboBox.Text,
                    RoomType = roomTypeComboBox.SelectedItem?.ToString(),
                    RoomFloor = floorComboBox.SelectedItem?.ToString(),
                    RoomNumber = roomNComboBox.SelectedItem?.ToString(),
                    TotalBill = finalizedTotalAmount,
                    PaymentType = paymentType,
                    CardType = CardType,
                    CardNumber = paymentCardNumber,
                    CardExp = MM_YY_Of_Card,
                    CardCvc = CVC_Of_Card,

                    ArrivalTime = entryDatePicker.Value,
                    LeavingTime = depDatePicker.Value,

                    BreakFast = breakfast,
                    Lunch = lunch,
                    Dinner = dinner,
                    CheckIn = checkin == 1,
                    SupplyStatus = foodStatus == 1,
                    Cleaning = cleaning == "1",
                    Towel = towel == "1",
                    SSurprise = surprise == "1",
                    FoodBill = foodBill
                };

                var updated = ReservationManager.UpdateReservation(updatedReservation);
                if(updated)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Reservation For the UNIQUE USER ID of: " + "\n\n" +
                                    " " + primartyID + " is UPDATED.", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Reservation For the UNIQUE USER ID of: " + "\n\n" +
                " " + primartyID + " is NOT UPDATED.", "NOT UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ComboBoxItemsFromDataBase();

            reset_frontend();
            LoadForDataGridView();
            GetOccupiedRoom();
            ReservedRoom();
            getChecked();
        }

        private void checkinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkinCheckBox.Checked)
            {
                checkinCheckBox.Text = "Checked in";
                checkin = 1;
            }
            else
            {
                checkin = 0;
                checkinCheckBox.Text = "Check in ?";
            }
        }

        private void resEditButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            getChecked();
            int reservationId = int.Parse(resEditButton.Text.Substring(0, 4).Trim());

            var reservation = ReservationManager.GetReservationById(reservationId);

            if (reservation == null)
            {
                MessageBox.Show("Reservation not found.");
                return;
            }

            taskFinder = true;

            firstNameTextBox.Text = reservation.FirstName;
            lastNameTextBox.Text = reservation.LastName;
            phoneNumberTextBox.Text = reservation.PhoneNumber;
            genderComboBox.SelectedItem = reservation.Gender;

            DateTime birthDate = DateTime.Parse(reservation.BirthDay);
            monthComboBox.SelectedIndex = birthDate.Month - 1;
            dayComboBox.SelectedItem = birthDate.Day.ToString("00");
            yearTextBox.Text = birthDate.Year.ToString();

            emailTextBox.Text = reservation.EmailAddress;
            qtGuestComboBox.SelectedItem = reservation.NumberGuest.ToString();
            addLabel.Text = reservation.StreetAddress;
            aptTextBox.Text = reservation.AptSuite;
            cityTextBox.Text = reservation.City;
            stateComboBox.SelectedItem = reservation.State;
            zipComboBox.Text = reservation.ZipCode;

            roomTypeComboBox.SelectedItem = reservation.RoomType;
            floorComboBox.SelectedItem = reservation.RoomFloor;
            roomNComboBox.SelectedItem = reservation.RoomNumber;
            roomNComboBox.Items.Add(reservation.RoomNumber);

            checkinCheckBox.Checked = reservation.CheckIn;

            FPayment = reservation.PaymentType ?? "Debit";
            FCnumber = reservation.CardNumber ?? "9999-9999-9999";
            FCardCVC = reservation.CardCvc ?? "123";
            if (!string.IsNullOrEmpty(reservation.CardExp))
            {
                string[] expParts = reservation.CardExp.Split('/');
                if (expParts.Length == 2)
                {
                    FcardExpOne = expParts[0];
                    FcardExpTwo = expParts[1];
                }
            }

            cleaning = reservation.Cleaning ? "1" : "0";
            towel = reservation.Towel ? "1" : "0";
            surprise = reservation.SSurprise ? "1" : "0";

            foodSupplyCheckBox.Checked = reservation.SupplyStatus;
            breakfast = reservation.BreakFast;
            lunch = reservation.Lunch;
            dinner = reservation.Dinner;
            foodBill = reservation.FoodBill;

            entryDatePicker.Value = reservation.ArrivalTime;
            depDatePicker.Value = reservation.LeavingTime;

            primartyID = reservation.Id;
        }


        private void ComboBoxItemsFromDataBase()
        {
            try
            {
                var reservations = ReservationManager.LoadAllReservations();

                foreach(var reservation in reservations )
                {
                    resEditButton.Items.Add(reservation.Id + "  | " + reservation.FirstName + "  " + reservation.LastName + " | " + reservation.PhoneNumber);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadForDataGridView()
        {
            try
            {
                resTotalDataGridView.DataSource = ReservationManager.LoadAllReservations();
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Error loading data", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.None);
            }
        }

        private void foodSupplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (foodSupplyCheckBox.Checked)
            {
                foodSupplyCheckBox.Text = "Food/Supply: Complete";
                foodStatus = 1;
            }
            else
            {
                foodStatus = 0;
                foodSupplyCheckBox.Text = "Food/Supply status?";
            }
        }

        private void GetOccupiedRoom()
        {
            try
            {
                var occupiedRooms = ReservationManager.OccupiedRooms();

                foreach (var room in occupiedRooms)
                {
                    roomOccupiedListBox.Items.Add($"[{room.RoomNumber.Trim()}] {room.RoomType.Trim()} {room.Id} [{room.FirstName} {room.LastName}] {room.PhoneNumber}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ReservedRoom()
        {
            roomReservedListBox.Items.Clear();
            try
            {
                var reservedRooms = ReservationManager.ReservedRooms();

                foreach (var room in reservedRooms)
                {
                    string roomInfo = $"[{room.RoomNumber.Trim()}] {room.RoomType.Trim()} {room.Id} {room.FirstName} {room.LastName} {room.PhoneNumber} {room.ArrivalTime.ToString("MM-dd-yyyy")} {room.LeavingTime.ToString("MM-dd-yyyy")}";
                    roomReservedListBox.Items.Add(roomInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        

        private void getChecked()
        {
            try
            {
                List<string> TakenRoomList = ReservationManager.TakenRooms();

                foreach (string room in TakenRoomList)
                {
                    if (roomNComboBox.Items.Contains(room))
                    {
                        roomNComboBox.Items.Remove(room);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void phoneNumberTextBox_Leave(object sender, EventArgs e)
        {
            RecvPhoneNumber = "+1"+phoneNumberTextBox.Text.Replace(" ", string.Empty);
            long getphn = Convert.ToInt64(phoneNumberTextBox.Text);
            string formatString = String.Format("{0:(000)000-0000}", getphn);
            phoneNumberTextBox.Text = formatString;
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.Trim();

            var results = ReservationManager.SearchReservations(searchText);

            searchDataGridView.DataSource = results;

            if (results.Any())
            {
                searchButton.Location = new Point(752, 7);
                searchTextBox.Location = new Point(68, 7);
                searchDataGridView.Visible = true;
                SearchError.Visible = false;
            }
            else
            {
                searchDataGridView.Visible = false;
                SearchError.Visible = true;
                SearchError.Text = $"SORRY DUDE :(\nI ran out of gas trying to search for {searchText}\nI sure will find it next time.";
            }
        }

    }
}
