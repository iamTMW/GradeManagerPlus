using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

/* Name: Taha Mohyuddin
 * Program: Assignment 4
 * Enhancements: All of the Enhacements are at the bottom of the frmlogin.cs page 
 * Purpose: This Program has two uses one that the admin can use and the other that the students can use, the admin can see all of the students marks and averages of each student including the new students that they add, they can also see the student marks graph. Wheras the student can only see their marks and can't change anything for more infromation go to the frmlogin.cs page 
 * Date: 2023-06-16
*/
namespace Assignment4
{
    public partial class frmNewStudent : Form
    { 
        private OleDbConnection connection = new OleDbConnection();  // Declaring a private OleDbConnection object named "connection".
        public event EventHandler StudentSaved; // declares an event named StudentSaved of type EventHandler. When the event is raised, the event handler method will be executed, allowing the subscribers to perform any necessary actions or respond to the event accordingly.
        public frmNewStudent()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\Taha\Documents\Computer Science -12\Unit4\StudentInfo\Students.accdb";  // Setting the connection string for the OleDbConnection object.
        }
        public string GetStudentName() //Making a new Method
        {
            string firstName = txtFirstName.Text; //This Retrieves the first name entered in the txtFirstName TextBox.
            string lastName = txtLastName.Text; // This Retrieves the last name entered in the txtLastName TextBox.
            string fullName = $"{firstName} {lastName}"; //This Combines the first name and last name to create the full name string.
            return fullName.Trim(); //This Removes any leading or trailing whitespace from the full name string.
        }

        protected virtual void OnStudentSaved()
        {
            StudentSaved?.Invoke(this, EventArgs.Empty); // This Raises the event "StudentSaved" to notify subscribers that a student has been saved.
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text) || string.IsNullOrWhiteSpace(txtDay.Text) || string.IsNullOrWhiteSpace(txtMonth.Text) || string.IsNullOrWhiteSpace(txtYear.Text))
            {
                MessageBox.Show("Not all information has been submitted. Please try again."); //This Checks if any of the required text fields are empty and displays an error message if so.
            }
            else
            {
                int count = 0; // Variable to track data input errors.
                int x; // Temporary variable for parsing.

                if (int.TryParse(txtDay.Text, out x) && int.TryParse(txtMonth.Text, out x) && int.TryParse(txtYear.Text, out x))
                {
                    if (!int.TryParse(txtFirstName.Text, out x) && !int.TryParse(txtLastName.Text, out x))
                    {
                        count = 1; // If day, month, and year can be parsed as integers and first name and last name cannot, count is set to 1.
                    }
                }

                if (count == 0)
                {
                    MessageBox.Show("Error in the data input."); // Displays an error message if count is 0, indicating an error in data input.
                }
                else
                {
                    string DOB = txtDay.Text + "-" + txtMonth.Text + "-" + txtYear.Text; // Constructs the date of birth string using day, month, and year.

                    try
                    {
                        connection.Open(); // Opens the database connection.
                        OleDbCommand command = new OleDbCommand(); // Creates a new OleDbCommand.
                        command.Connection = connection; // Sets the connection for the command.

                        // Save student information in tblStudents
                        command.CommandText = "INSERT INTO [tblStudents] ([FirstName], [LastName], [UserName], [Password], [DOB]) VALUES ('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtUser.Text + "','" + txtPass.Text + "','" + DOB + "')"; // Constructs the SQL command to insert student information into tblStudents.
                        command.ExecuteNonQuery(); // Executes the command to insert the student information.

                        // Retrieve the newly inserted student ID
                        command.CommandText = "SELECT @@IDENTITY"; // Constructs the SQL command to retrieve the newly inserted student ID.
                        int stuId = Convert.ToInt32(command.ExecuteScalar()); // Executes the command and converts the result to an integer representing the student ID.

                        // Save the marks in tblMarks
                        if (string.IsNullOrWhiteSpace(txtMark1.Text) || string.IsNullOrWhiteSpace(txtMark2.Text) || string.IsNullOrWhiteSpace(txtMark3.Text) || string.IsNullOrWhiteSpace(txtMark4.Text) || string.IsNullOrWhiteSpace(txtMark5.Text))
                        {
                            MessageBox.Show("Not all information has been submitted. Please try again."); // Checks if any of the mark fields are empty and displays an error message if so.
                        }
                        else
                        {
                            // Save the marks to the tblMarks table
                            string query = "INSERT INTO [tblMarks] ([StuID], [Mark1], [Mark2], [Mark3], [Mark4], [Mark5]) VALUES (" + stuId + "," + txtMark1.Text + "," + txtMark2.Text + "," + txtMark3.Text + "," + txtMark4.Text + "," + txtMark5.Text + ")"; // Constructs the SQL command to insert marks into tblMarks.

                            command.CommandText = query; // Assigns the query to the command.
                            command.ExecuteNonQuery(); // Executes the command to insert the marks.

                            connection.Close(); // Closes the database connection.

                            MessageBox.Show("Student information and marks have been saved to the database."); // Displays a success message.

                            // Trigger the StudentSaved event
                            OnStudentSaved(); // Calls a custom method to trigger the StudentSaved event.

                            this.Close(); // Closes the current form.
                        }

                        // Clear the input fields
                        txtFirstName.Text = string.Empty; // Clears the first name field.
                        txtLastName.Text = string.Empty; // Clears the last name field.
                        txtUser.Text = string.Empty; // Clears the username field.
                        txtPass.Text = string.Empty; // Clears the password field.
                        txtDay.Text = string.Empty; // Clears the day field.
                        txtMonth.Text = string.Empty; // Clears the month field.
                        txtYear.Text = string.Empty; // Clears the year field.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message); // Displays an error message if an exception occurs.
                        connection.Close(); // Closes the database connection.
                    }
                }
            }

            frmadmin frmAdmin = new frmadmin(); // Creates a new instance of the frmadmin form.
            frmAdmin.Show(); // Displays the frmadmin form.
            this.Hide(); // Hides the current form.
            frmAdmin.BringToFront(); // Brings the frmadmin form to the front.
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // This helps user exit the windows form, triggering necessary cleanup operations.
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmadmin frmAdmin = new frmadmin(); //creates a new instance of the frmadmin form
            frmAdmin.Show();//This Dsiplays the frmadmin form
            this.Hide();  // Hides the current form.
            frmAdmin.BringToFront(); //Brings the frmadmin form to the front. So that's the only form that the user can see
        }
    }
    
    
}
