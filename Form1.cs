/* Student Name: Samreen Fathima
 * Student ID: 22101335
 * Date:13/10/2022
 * Assignment: 2
 * Assignment: Create a software that generates prices and bookings for courses provided by a software programming
 * courses in locations accross Ireland.
 */


using System;
using System.Drawing;
using System.Windows.Forms;

namespace L2P_Assignment2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //Constant Variable declaration for Course List Box 
        const string COURSE1 = "C# Fundamentals", COURSE2 = "C# Basic for Beginners", COURSE3 = "C# Intermediate", 
            COURSE4 = "C# Advanced topics",COURSE5 = "ASP.NET with C# Part A", COURSE6 = "ASP.NET with C# Part B";

        //Constant Variable declaration for Course fees
        const decimal FUNDAMENTAL_FEE = 900m; const decimal BASIC_FEE = 1500m; const decimal INTERMEDIATE_FEE = 1800m;
        const decimal ADVANCED_FEE = 2300m; const decimal PARTA_FEE = 1250m; const decimal PARTB_FEE = 1250m;

        //Constant Variable declaration for course days 
        const int COURSE1_DAYS = 2;const int COURSE2_DAYS = 4; const int COURSE3_DAYS = 4;
        const int COURSE4_DAYS = 2; const int COURSE5_DAYS = 5;const int COURSE6_DAYS = 5;

        //Constant Variable declaration for Location names in Location list box
        const string LOCATION1 = "Belmullet", LOCATION2 = "Clifden", LOCATION3 = "Cork", LOCATION4 = "Dublin",
            LOCATION5 = "Killarney", LOCATION6 = "Lettekenny", LOCATION7 = "Sligo";

        //Constant Variable decalaration for Location fees
        const decimal LOCATION1_FEE = 219.99m; const decimal LOCATION2_FEE = 119.99m; const decimal LOCATION3_FEE = 149.99m;
        const decimal LOCATION4_FEE = 179.99m; const decimal LOCATION5_FEE = 149.99m; const decimal LOCATION6_FEE = 89.99m;
        const decimal LOCATION7_FEE = 119.99m;
       
        //Below variables are referred to in multiple event handlers so global declaration is done
        decimal Upgrade_Type = 0m; decimal Certificate_Fee = 0m; decimal Total_Cost = 0m;
        decimal Lodging_Fee = 0m;decimal LodgingFeeWithUpgrade = 0m; decimal TotalUpgradeCost = 0m;
        decimal Course_Fee = 0m; string Course_Name = ""; string location = "";

        //Upgrade fields Variable declaration
        const decimal MASTER_SUITE = 99.99m; const decimal EXEC_SUITE = 69.99m; const decimal JUNIOR_SUITE = 49.99m;
        const decimal CERTIFICATE_FEE = 39.99m;
        
        /*Variable declaration for values to be shown in Summary Label , these variables are called in Summary and 
        Booking event handlers */
        int TotalNoOfBooking = 0; int NoOfGroupDiscounts = 0;      
        int TotalNoOfGroupDiscount;
        decimal TotalEnrollmentFee = 0m; decimal TotalLodgingFee = 0m;
        decimal TotalRevenue = 0m; decimal AverageRevenue;
        decimal TotalRoomUpgradeValue = 0m;decimal TotalCertificateValue = 0m;

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            DiscountLabel.Visible = false;
            SummaryLabel.Visible = true;
            DisplayOutputLabel.Visible = false;

            /*Company Summary variables that are calculated and incremented for every successfull confirmation
             of booking are output to Summary Label */
            SummaryLabel.Text = "\n" + "Company Summary: " + 
                                "\n" + "Total number of bookings                        : " + TotalNoOfBooking.ToString() + 
                                "\n" + "Total Enrollment fees                                : " + "\u20AC " + TotalEnrollmentFee.ToString("n2") +
                                "\n" + "Total lodging fees                                     : " + "\u20AC " + TotalLodgingFee.ToString("n2") + 
                                "\n" + "Total number of group discounts            : " + TotalNoOfGroupDiscount.ToString() +
                                "\n" + "Total value of room upgrades                  : " + "\u20AC " + TotalRoomUpgradeValue.ToString("n2") +
                                "\n" + "Total Value of digital certificates availed : " + "\u20AC" + TotalCertificateValue.ToString("n2") +
                                "\n" + "Total revenue                                             :" + "\u20AC" + TotalRevenue.ToString("n2") +
                                "\n" + "Average revenue                                       : " + "\u20AC" + AverageRevenue.ToString("n2");
        }
      
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            
            SummaryLabel.Visible = false;   
            decimal AttendeesTotal = AttendeesDropDown.Value;
            //Local variable declaration
            
            decimal Location_Fee = 0m; int Days = 0;

            //Variables declared for index values
            int CourseIndex, LocationIndex;

            //Exception handling using if for attendees NumericUpDown Box
            if (AttendeesTotal != 0)
            {
                //Exception Handling using if for Course List Box
                if (CourseListBox.SelectedIndex != -1)
                {
                    //Exception Handling using if for Location list box
                    if (LocationListBox.SelectedIndex != -1)
                    {
                        //Assigning selection index values in list boxes to variables declared locally above
                        CourseIndex = CourseListBox.SelectedIndex;
                        LocationIndex = LocationListBox.SelectedIndex;
                        BookButton.Enabled = true;
                        DisplayOutputLabel.Visible = true;

                        //Swtich case used to assign the selected value from the list box to the variable
                        switch (CourseIndex)
                        {
                            case 0: Course_Name = COURSE1; Course_Fee = FUNDAMENTAL_FEE; Days = COURSE1_DAYS; break;
                            case 1: Course_Name = COURSE2; Course_Fee = BASIC_FEE; Days=COURSE2_DAYS; break;
                            case 2: Course_Name = COURSE3; Course_Fee = INTERMEDIATE_FEE; Days = COURSE3_DAYS; break;
                            case 3: Course_Name = COURSE4; Course_Fee = ADVANCED_FEE; Days = COURSE4_DAYS; break;
                            case 4: Course_Name = COURSE5; Course_Fee = PARTA_FEE; Days = COURSE5_DAYS; break;
                            case 5: Course_Name = COURSE6; Course_Fee = PARTB_FEE; Days = COURSE6_DAYS; break;

                        }
                        switch (LocationIndex)
                        {
                            case 0: location = LOCATION1; Location_Fee = LOCATION1_FEE; break;
                            case 1: location = LOCATION2; Location_Fee = LOCATION2_FEE; break;
                            case 2: location = LOCATION3; Location_Fee = LOCATION3_FEE; break;
                            case 3: location = LOCATION4; Location_Fee = LOCATION4_FEE; break;
                            case 4: location = LOCATION5; Location_Fee = LOCATION5_FEE; break;
                            case 5: location = LOCATION6; Location_Fee = LOCATION6_FEE; break;
                            case 6: location = LOCATION7; Location_Fee = LOCATION7_FEE; break;
                        }
                        
                        //if else used to serve room upgrade conditions for the checked radio button
                        if(JuniorSuiteRadioButton.Checked)
                        {
                            Upgrade_Type = JUNIOR_SUITE;
                            
                        }
                        else if(ExecutiveSuiteRadioButton.Checked)
                        {
                            Upgrade_Type = EXEC_SUITE;
                        }
                        else if (MasterSuiteRadioButton.Checked)
                        {
                            Upgrade_Type = MASTER_SUITE;
                        }
                        /*Ghost button appears only when booking confirmation is set to no and upgrade_type value
                        is set to 0 to ensure null value during total cost calculation */
                        else if (NoneRadioButton.Checked)
                        {
                            Upgrade_Type = 0m;
                            DiscountLabel.Visible = false;
                        }
                  
                        if (CertificateCheckBox.Checked)
                        {
                            Certificate_Fee = CERTIFICATE_FEE;                     
                        }

                        //Calcuation for Total cost and individual lodging fee with and without upgrade and total upgrade cost 

                        Total_Cost = (Course_Fee + (Location_Fee * Days) + Upgrade_Type + Certificate_Fee) * AttendeesTotal;
                        Lodging_Fee = Location_Fee * Days * AttendeesTotal;
                        LodgingFeeWithUpgrade = (Location_Fee + Upgrade_Type) * Days * AttendeesTotal;
                        TotalUpgradeCost = Upgrade_Type * Days * AttendeesTotal;

                        //Below if block is for discount which is applicable 2 conditions are met 
                        if (AttendeesTotal >= 3 && Upgrade_Type > 0m)
                        {
                            Course_Fee = Course_Fee -(Course_Fee * 0.075m);
                            Lodging_Fee = Lodging_Fee -(Lodging_Fee * 0.075m);
                            LodgingFeeWithUpgrade = Lodging_Fee - (LodgingFeeWithUpgrade * 0.075m);
                            Total_Cost = Total_Cost-(Total_Cost * 0.075m);
                            TotalUpgradeCost = TotalUpgradeCost - (TotalUpgradeCost * 0.075m);
                            NoOfGroupDiscounts++;
                            DiscountLabel.Text="7.5% discount is applied!!";
                            DiscountLabel.Visible = true;

                        }
                        
                        //Values are sent to output lable 
                        DisplayOutputLabel.Text = "Your selection:" +
                            "\n" + "Course                     : " + Course_Name + 
                            "\n" + "Location:                  : " + location +                         
                            "\n" + "Enrollment fee:        : " + "\u20AC" + Course_Fee.ToString("n2") + 
                            "\n" + "Lodging Fee:            : " + "\u20AC" + Lodging_Fee.ToString("n2") +
                            "\n" + "Room upgrade cost: " + "\u20AC" + TotalUpgradeCost.ToString("n2") +
                            "\n" + "Total Cost:                : " + "\u20AC" + Total_Cost.ToString("n2") ;
                                              
                    }
                    else { MessageBox.Show("Please select the location", "Location required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                }
                else { MessageBox.Show("Please select the course", "Course required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else { MessageBox.Show("Please select the number of Attendees", "Number of Attendees required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            }

        private void BookButton_Click(object sender, EventArgs e)
        {
            SummaryButton.Enabled = true;
        DialogResult BookingSelection = MessageBox.Show("Your booking information: " + "\n" + "Course: " + Course_Name + "\n" + "Location: " + location
                    + "\n" + "Total Cost: " + Total_Cost.ToString("C") + "\n" + "Confirm Booking?","Booking Confirmation", MessageBoxButtons.YesNo , MessageBoxIcon.Question);
          
            /*On every booking confirmation, variables are incremented by one in order to store company summary data
          If condition to execute block if user selects Yes for booking confirmation , variables valuable for company
          summary data is incremented by one and referred to in the Summary event handler */
            if (BookingSelection==DialogResult.Yes)
            {
                BookButton.Enabled = false;
                SelectionPanel.Enabled = false;              
                DisplayButton.Enabled = false;
                TotalNoOfBooking++;
                TotalRevenue += Total_Cost;
                AverageRevenue = TotalRevenue / TotalNoOfBooking;
                TotalRoomUpgradeValue += Upgrade_Type;
                TotalLodgingFee += Lodging_Fee;
                TotalNoOfGroupDiscount = NoOfGroupDiscounts;
                TotalEnrollmentFee += Course_Fee;
                TotalCertificateValue += Certificate_Fee;

                //Message box to display booking confirmation 

                MessageBox.Show("Your booking is confirmed!", "Booking confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }  
          /*Selection of NO button in the booking confirmation prompt box allows user to select "None" as the 
          room upgrade type and visibility and enabling of buttons and labels is toggled*/
          else if(BookingSelection==DialogResult.No)
            {
                NoneRadioButton.Visible = true;
                BookButton.Enabled = false;
                DisplayOutputLabel.Visible = false;
                DiscountLabel.Visible = false;
                if (TotalNoOfBooking>=1)
                { SummaryButton.Enabled = true; }
                else { SummaryButton.Enabled = false; }
            }

        }

        /*Clear buttons deselects all prior selections and resets the state of the application back to
        *how it was when it initially started*/

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SummaryButton.Enabled = false;
            DisplayButton.Enabled = true;
            NoneRadioButton.Visible = false;
            SelectionPanel.Enabled = true;
            CourseListBox.ClearSelected();
            LocationListBox.ClearSelected();
            AttendeesDropDown.Value= 0;
            JuniorSuiteRadioButton.Checked = false;
            ExecutiveSuiteRadioButton.Checked= false;
            MasterSuiteRadioButton.Checked = false;
            CertificateCheckBox.Checked = false;
            SummaryLabel.Visible = false;
            //Summary button will be enabled only if minimum of 1 booking has taken place
            if (TotalNoOfBooking>=1)
            {
                SummaryButton.Enabled = true;
            }                     
            BookButton.Enabled = false;
            DisplayOutputLabel.Visible = false;           
            NoneRadioButton.Visible = false;
            DiscountLabel.Visible = false;

        }
    }
 }
