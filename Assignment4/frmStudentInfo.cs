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
    public partial class frmStudentInfo : Form
    {
        private string firstName; // Declares a private string variable to store the first name of the student.
        private string lastName; // Declares a private string variable to store the last name of the student.
        private OleDbConnection connection = new OleDbConnection(); // Declares and initializes a new OleDbConnection object.
        public frmStudentInfo(string firstName, string lastName) // Constructor that takes the first name and last name as parameters.
        {
            InitializeComponent(); // Initializes the components of the form.
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\Taha\Documents\Computer Science -12\Unit4\StudentInfo\Students.accdb"; // Sets the connection string for the OleDbConnection object.
            this.firstName = firstName; // Assigns the passed first name to the class-level firstName variable.
            this.lastName = lastName; // Assigns the passed last name to the class-level lastName variable.
            LoadStudentInfo(); // Calls the LoadStudentInfo() method to load the student information. 
           // Set the text boxes as read-only
            txtStudentID.ReadOnly = true; // This would set the txtStudent Id textbox as read Only
            txtFirstName.ReadOnly = true; // This would set the txtFirstName textbox as read Only
            txtLastName.ReadOnly = true; // This would set the txtLastName textbox as read Only
            txtDOB.ReadOnly = true; // This would set the txtDOB textbox as read Only
            txtBigBox.ReadOnly = true; // This would set the txtBigBox textbox which is to display marks as read Only
        }

        private void LoadStudentInfo()
        {
            try
            {
                connection.Open(); // Opens the database connection.
                OleDbCommand command = new OleDbCommand(); // Creates a new OleDbCommand object.
                command.Connection = connection; // Sets the connection for the OleDbCommand object.

                // Retrieve the student's information based on first name and last name
                string query = "SELECT StuID, FirstName, LastName, DOB FROM TblStudents WHERE FirstName = @FirstName AND LastName = @LastName";
                command.CommandText = query; // Sets the SQL query for the OleDbCommand object.
                command.Parameters.AddWithValue("@FirstName", firstName); // Sets the parameter value for the first name.
                command.Parameters.AddWithValue("@LastName", lastName); // Sets the parameter value for the last name.
                OleDbDataReader reader = command.ExecuteReader(); // Executes the query and retrieves the data.

                if (reader.Read()) // Checks if there is a row of data returned.
                {
                    // Populate the text boxes or labels with the retrieved information
                    txtStudentID.Text = reader["StuID"].ToString(); // Retrieves and sets the student ID.
                    txtFirstName.Text = reader["FirstName"].ToString(); // Retrieves and sets the first name.
                    txtLastName.Text = reader["LastName"].ToString(); // Retrieves and sets the last name.
                    txtDOB.Text = Convert.ToDateTime(reader["DOB"]).ToString("dd/MMM/yy"); // Retrieves and sets the date of birth.

                    reader.Close(); // Closes the data reader.

                    // Retrieve the student's marks from tblMarks
                    query = "SELECT Mark1, Mark2, Mark3, Mark4, Mark5 FROM tblMarks WHERE StuID = @StuID";
                    command.CommandText = query; // Sets the SQL query for retrieving marks.
                    command.Parameters.Clear(); // Clears the previous parameters.
                    command.Parameters.AddWithValue("@StuID", txtStudentID.Text); // Sets the parameter value for the student ID.
                    reader = command.ExecuteReader(); // Executes the query and retrieves the marks data.

                    // Clear the existing text in txtBigBox
                    txtBigBox.Text = "";

                    if (reader.Read()) // Checks if there is a row of marks data returned.
                    {
                        // Add the marks information to txtBigBox
                        txtBigBox.Text += $"Mark 1: {reader["Mark1"]}\r\n"; // Retrieves and adds Mark 1.
                        txtBigBox.Text += $"Mark 2: {reader["Mark2"]}\r\n"; // Retrieves and adds Mark 2.
                        txtBigBox.Text += $"Mark 3: {reader["Mark3"]}\r\n"; // Retrieves and adds Mark 3.
                        txtBigBox.Text += $"Mark 4: {reader["Mark4"]}\r\n"; // Retrieves and adds Mark 4.
                        txtBigBox.Text += $"Mark 5: {reader["Mark5"]}\r\n"; // Retrieves and adds Mark 5.
                    }
                    else
                    {
                        MessageBox.Show("Marks information not found."); // this tell user by displaying a message if in case marks information is not found
                    }
                }
                else
                {
                    MessageBox.Show("Student information not found."); // this tell user by displaying a message if in case student information is not found
                }

                reader.Close(); // Closes the data reader.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // this would dsiplay whhic error user is facing
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close(); // Closes the database connection if it is still open.
            }
        }


        private void btnChart_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open(); // Opens the database connection.
                OleDbCommand command = new OleDbCommand(); // Creates a new OleDbCommand object.
                command.Connection = connection; // Sets the connection for the OleDbCommand object.
                string query = "SELECT Mark1, Mark2, Mark3, Mark4, Mark5 FROM tblMarks WHERE StuID = " + txtStudentID.Text;
                command.CommandText = query; // Sets the SQL query for retrieving marks.
                OleDbDataReader reader = command.ExecuteReader(); // Executes the query and retrieves the marks data.

                // Clear the chart outside the while loop
                chartMarks.Series["Marks"].Points.Clear(); // Clears the existing points in the chart.

                while (reader.Read()) // Iterates through the retrieved data rows.
                {
                    for (int x = 0; x < 5; x++) // Loops through the marks columns.
                    {
                        chartMarks.Series["Marks"].Points.AddXY("Mark" + (x + 1), Convert.ToDouble(reader[x])); // Adds a data point to the chart for each mark value.
                    }
                }

                connection.Close(); // Closes the database connection.
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exits the application.
        }
    }
}
