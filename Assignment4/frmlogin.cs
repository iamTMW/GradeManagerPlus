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
 * Enhancements: All of the Enhacements are at the bottom of this code
 * Purpose: This Program has two uses one that the admin can use and the other that the students can use, the admin can see all of the students marks and averages of each student including the new students that they add, they can also see the student marks graph. Wheras the student can only see their marks and can't change anything for more infromation go to the frmlogin.cs page 
 * Date: 2023-06-16 
 * References at the buttom
*/
namespace Assignment4
{
    public partial class frmlogin : Form
    {
        private OleDbConnection connection = new OleDbConnection(); //This line declares and creates a private instance variable of type OleDbConnection named connection that can be used within the class to establish a connection to an OLE DB data source.
        public frmlogin()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\Taha\Documents\Computer Science -12\Unit4\StudentInfo\Students.accdb";  // Setting the connection string for the OleDbConnection object
            try // Within the try block, the code attempts to open the database connection using the connection.Open() statement.
            {
                connection.Open(); //Opening the data base connection
                lblShowConnection.Text = "Connected"; // of the data base conection has been opened sucessfully then in the lblShowConnection label it will display connected
                connection.Close(); // closing the data base connection
            }
            catch  //The catch block is used to handle the exception and provide an alternative course of action.
            {

                lblShowConnection.Text = "No Connection"; // if the data base did not open sucessfully then in the lblShowConnection it will display NO connection
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)  // This will only be triggered if the user presses the login clcik Button 
        {
            connection.Open(); // Opening the database connection
            OleDbCommand command = new OleDbCommand(); // Creating a new OleDbCommand object
            command.Connection = connection; //associating the new OleDbcommand with the OleDbConnection object

            command.CommandText = "SELECT * FROM tblStudents WHERE UserName='" + txtUserName.Text + "' AND Password ='" + txtPassword.Text + "'";   // Setting the SQL query to select records from the tblStudents table based on the entered username and password

            OleDbDataReader reader = command.ExecuteReader();  // Executing the SQL query and retrieving the results using an OleDbDataReader

            if (reader.Read()) //Here if statement is being used to determine if there is a matching record found in the database for the entered username and password. If reader.Read() returns true, it means that a row has been successfully read
            {
                string username = reader["UserName"].ToString();  // Retrieving value from the reader for the matched record 
                string password = reader["Password"].ToString(); // Retrieving value from the reader for the matched record
                string firstName = reader["FirstName"].ToString(); // Retrieving value from the reader for the matched record
                string lastName = reader["LastName"].ToString(); // Retrieving value from the reader for the matched record

                MessageBox.Show("Welcome " + firstName + " " + lastName); // Displaying a welcome message with the retrieved first name and last name
                this.Hide(); // Then hiding the message 

                if (username == "admin") // using an if statement to see if username is equal to admin, if it is then it goes through this statement
                {
                    frmadmin frmAdmin = new frmadmin();  // Creating an instance of the frmadmin form
                    frmAdmin.Show();  // Displaying the frmadmin form
                    this.Hide(); // This will hide the current form which in this case is the login form
                    // Bringing the frmadmin form to the front
                    frmAdmin.BringToFront(); // Bringing the frmStudentInfo form to the front after hiding the login form, so in this case only the admin form will be seen by the user
                }
                else //it would come to this statement if the username did not Equal admin, then in this else statement it would this that then the user is a student hence will take them to the student info page
                {
                    frmStudentInfo frmView = new frmStudentInfo(firstName, lastName); // Creating an instance of the frmStudentInfo form with first name and last name parameters
                    frmView.Show();  // Displaying the frmStudentInfo form
                    this.Hide(); // This will hide the current form which in this case is the login form
                    frmView.BringToFront(); // Bringing the frmStudentInfo form to the front after hiding the login form, so in this case only the Student info form will be seen by the user
                } 
            }
            else  // if it is about to go through this satement it means that the user entered something wrong 
            {
                MessageBox.Show("Invalid username or password. Please try again."); // This will display a message telling user what potentially they might of done wrong.
            }

            reader.Close();  //This wll Close the OleDbDataReader Connection
            connection.Close(); //This will Close the DataBase Connection
        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtUserName.Text; //Declaring a variable that will Get the entered username

            if (IsUsernameValid(enteredUsername)) // Check if the entered username matches the one in the database
            {
                frmForgetPassword forgetPasswordForm = new frmForgetPassword(); // Create an instance of the frmForgetPassword form

                if (forgetPasswordForm.ShowDialog() == DialogResult.OK) // Display the frmForgetPassword form and wait for user input
                {
                    string newPassword = forgetPasswordForm.NewPassword; // Get the new password entered by the user

                    if (UpdatePassword(enteredUsername, newPassword))  // Update the password in the database
                    {
                        MessageBox.Show("Password changed successfully!"); //if the update was sucessfully this message will be displayed
                    }
                    else
                    {
                        MessageBox.Show("Failed to change the password. Please try again."); //if the update was not sucessfully and it was the password that was wrong this message will be displayed
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid username. Please try again."); // if everything was fine that it has to been the username that was wrong and it will display this message
            }
        }

        private bool IsUsernameValid(string enteredUsername)
        {
            try
            {
                connection.Open(); //This Opens the database connection
                OleDbCommand command = new OleDbCommand(); // Create a new OleDbCommand object
                command.Connection = connection; // Associate the command with the connection
                command.CommandText = "SELECT UserName FROM tblStudents WHERE UserName = ?"; // SQL query to check if the username exists in the database
                command.Parameters.AddWithValue("@p1", enteredUsername); // Set the parameter value for the username

                object result = command.ExecuteScalar(); // Execute the query and retrieve the result
                connection.Close(); // This Closes the database connection

                return result != null; // This will Return true if the result is not null (username exists in the database)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking username: " + ex.Message); //This Displays an error message if an exception occurs
                return false;
            }
        }

        private bool UpdatePassword(string username, string newPassword)
        {
            try
            {
                connection.Open(); // Open the database connection
                OleDbCommand command = new OleDbCommand(); // Create a new OleDbCommand object
                command.Connection = connection; // Associate the command with the connection
                command.CommandText = "UPDATE tblStudents SET [Password] = ? WHERE [UserName] = ?"; // SQL query to update the password for the specified username
                command.Parameters.AddWithValue("@p1", newPassword); //This Set the parameter value for the new password
                command.Parameters.AddWithValue("@p2", username); //This Set the parameter value for the username
                int rowsAffected = command.ExecuteNonQuery(); //This Executes the query and get the number of affected rows
                connection.Close(); //This Closes the database connection

                return rowsAffected > 0; //This Returns true if at least one row was affected (password updated successfully)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating password: " + ex.Message); // This would Display an error message if an exception occurs
                return false;
            }
        }
    }  
}

/*Enhancements 
 * I added an forget passsword Button, The forget password feature allows users to reset their password if they forget it. They enter a new password, which is then validated and updated in the database. This ensures users can regain access to their accounts and enhances security.
 * Added so that when you click the new button it takes user to a spearate form and before that it asks uses permission that do they wanna enter a new student and if they say yes takes them to the new form
 * Added the Averge text box that shows the students current average by calculating marks from the data base of the current student chosen, in order to display information of that current student. 
 * It compares every singal mark with the students in the data base, it compares mark 1 to all of the mark 1's of every student of the data base, and then it does the same thing for mark2. mark3, mark4 and mark5.
 * I added Exit buttons and a back button, the exit button with let the user exit the program in a good manner and the back button will help the user go back to the previous form that he was on.
 * As a Side I also added Images to make the Program look better. 
 * That said This program takes marks from tblMarks and studentInformation from TblStudent instead of taking everything from one Tbl 
*/

/*Description Of The program
 * This prgram has two uses one that the Admin can use and the other that the students can use
 * You can consider admin as like a teacher who wants to manage his or her classroom by seeing the students numbers and class avg -- student avg(Enhancements)
 * The admin can add any new student he want from the program it self by clicking the new button on the admin page which then take him to frmNewStudent, where he can register a new student
 * Once admin has registered the new student he can see their marks, the graph and all of the student information
 * This program also has an student version in it, where students can log in with their username and passwrod, and see their marks.
*/

/* References
 * https://stackoverflow.com/questions/52898/what-is-the-use-of-the-square-brackets-in-sql-statements
 * https://stackoverflow.com/questions/3847832/understanding-private-setters 
 * https://stackoverflow.com/questions/39207362/how-would-i-validate-a-username-and-password-in-c
 * https://stackoverflow.com/questions/22162024/reading-an-empty-textbox-text-as-null-or-string-empty
 * https://stackoverflow.com/questions/30597904/implementing-eventargs-empty-correctly
 * https://stackoverflow.com/questions/22143203/what-exactly-does-cmd-executenonquery-do-in-my-program
*/



