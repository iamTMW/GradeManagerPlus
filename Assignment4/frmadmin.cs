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
    public partial class frmadmin : Form
    {
        private OleDbConnection connection = new OleDbConnection();  //This line declares and creates a private instance variable of type OleDbConnection named connection that can be used within the class to establish a connection to an OLE DB data source.
        int[] marks = new int[5]; // Declaring an integer array named "marks" which has a size of 5.
        public frmadmin()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\Taha\Documents\Computer Science -12\Unit4\StudentInfo\Students.accdb";  // Setting the connection string for the OleDbConnection object.
            frmNewStudent newStudentForm = new frmNewStudent(); // Creating a new instance of the frmNewStudent form.
            newStudentForm.StudentSaved += FrmNewStudent_StudentSaved;  // Subscribing to the StudentSaved event of the newStudentForm.
        }
   
        public void enableUpdate()
        {
            txtFirstName.Enabled = true; // Enabling the following first name textbox for updating
            txtLastName.Enabled = true; // Enabling the following last name textbox for updating
            txtDOB.Enabled = true; // Enabling the following DOB textbox for updating
            btnSave.Visible = true; // making the following save button visible for updating
            btnDelete.Visible = true; // making the following delete button visible for updating
            txtAverage.Enabled = true; // Enabling the following average textbox for updating
            txtClassAv.Enabled = true; // Enabling the following classAv textbox for updating
            btnSave.Enabled = true; // Enabling the following save button for updating

        }
        public void disableUpdate()
        {
            txtFirstName.Enabled = false; // disabling the following first name textbox for updating
            txtLastName.Enabled = false; // diabling the following last name textbox for updating
            txtDOB.Enabled = false; // disabling the following DOB textbox for updating
            txtStudentID.Enabled = false; // disabling the following TsudentId textbox for updating
            btnSave.Enabled = false;  // disabling the following save button for updating

            btnDelete.Enabled = false; // disabling the following delete button for updating
            txtAverage.Enabled = false; // disabling the following average textbox for updating
            txtClassAv.Enabled = false;  // disabling the following classAv textbox for updating
            btnSave.Enabled = false;  // disabling the following save button for updating

        }

        private void frmadmin_Load(object sender, EventArgs e)
        { 

            PopulateCmbName(); // Calling a method which will populate the cmbNames combo box.
            disableUpdate(); // Disabling update functionality.
            ResetAv();//this calculates the average of all the marks from all the students
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("you are about to enter edit mode. make your changes and hit save"); // Displaying a message box with a notification. Telling the user they are about to eneter edit mode
            enableUpdate(); // Enabling update functionality.
        }
        private void PopulateCmbName()
        {
            try
            {
                connection.Open();  // Opening the database connection.
                OleDbCommand command = new OleDbCommand(); // Creating a new OleDbCommand object.
                command.Connection = connection;  // Assigning the connection to the command.
                string query = "SELECT LastName, FirstName FROM tblStudents"; // SQL query to select last names and first names from a table.
                command.CommandText = query; // Assigning the query to the command.
                OleDbDataReader reader = command.ExecuteReader(); // Executing the command and creating a data reader.


                cmbNames.Items.Clear(); //// Clearing existing items in the cmbNames combo box.

                while (reader.Read())
                {
                    cmbNames.Items.Add(reader[0].ToString() + "," + reader[1].ToString());  // Adding items to the cmbNames combo box by concatenating last names and first names.
                }

                reader.Close(); // Closing the data reader.
                connection.Close(); // Closing the database connection.
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString()); // This will Display an error message if an exception occurs.
                connection.Close(); // Closing the database connection.
            }
        }
        // Enabling various text boxes and combo boxes for adding new data.
        private void enableNew()
        {
            txtBigBox.Enabled = true;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtDOB.Enabled = true;

            cmbNames.Enabled = true;

            
        }
        // Clearing the text of various text boxes and combo boxes.
        private void clearText()
        {
            txtBigBox.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDOB.Text = "";

            cmbNames.Text = "";
        }


        private void btnChart_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection.Open(); // Opening the database connection.
                OleDbCommand command = new OleDbCommand(); // Creating a new OleDbCommand object.
                command.Connection = connection; // Assigning the connection to the command.
                string query = "SELECT Mark1, Mark2, Mark3, Mark4, Mark5 FROM tblMarks WHERE StuID = " + txtStudentID.Text; // SQL query to select marks from a table.
                command.CommandText = query; // Assigning the query to the command.
                OleDbDataReader reader = command.ExecuteReader(); // Executing the command and creating a data reader.

                // Clear the chart outside the while loop
                chartMarks.Series["Marks"].Points.Clear();

                while (reader.Read())
                {
                    for (int x = 0; x < 5; x++) //using a forloop that will loop 5 times to take those 5 marks entered by the user of storted already
                    {
                        chartMarks.Series["Marks"].Points.AddXY("Mark" + (x + 1), Convert.ToDouble(reader[x])); //// Reading the marks from the data reader and storing them in the marks array.
                    }
                }

                connection.Close(); // Closing the database connection.
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
            }
        }

        private void cmbNames_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                txtBigBox.Text = ""; // Clearing the text box for marks
                connection.Open(); // Opening the database connection.
                OleDbCommand command = new OleDbCommand(); // Creating a new OleDbCommand.
                command.Connection = connection; // Setting the connection for the command.

                string query = "SELECT FirstName, LastName, DOB, StuID FROM TblStudents WHERE LastName + ',' + FirstName=@Name";  // Selecting the FirstName, LastName, DOB, and StuID from TblStudents where the LastName + ',' + FirstName is equal to the selected name from the cmbNames ComboBox.
                command.CommandText = query; // Assigning the query to the command.
                command.Parameters.AddWithValue("@Name", cmbNames.Text); // Adding the selected name as a parameter.

                OleDbDataReader reader = command.ExecuteReader(); // Executing the command and creating a data reader.

                if (reader.Read())
                {
                    // Enable and make the delete button visible
                    btnDelete.Enabled = true;
                    btnDelete.Visible = true;
                    // Displaying the student's information in the respective TextBoxes.
                    txtFirstName.Text = reader["FirstName"].ToString();
                    txtLastName.Text = reader["LastName"].ToString();
                    txtStudentID.Text = reader["StuID"].ToString();
                    txtDOB.Text = Convert.ToDateTime(reader["DOB"].ToString()).ToString("dd//MMM/yy");

                    reader.Close(); // Closing the data reader.

                    // Fetch the student's marks from tblMarks
                    query = "SELECT Mark1, Mark2, Mark3, Mark4, Mark5 FROM tblMarks WHERE StuID=@StuID"; // Selecting the Mark1, Mark2, Mark3, Mark4, and Mark5 from tblMarks where the StuID is equal to the student's StuID.
                    command.CommandText = query; // Assigning the query to the command.
                    command.Parameters.Clear(); // Clearing any previous parameters.
                    command.Parameters.AddWithValue("@StuID", Convert.ToInt32(txtStudentID.Text));  // Adding the student's StuID as a parameter.

                    reader = command.ExecuteReader(); // Executing the command again to fetch the marks.

                    while (reader.Read())
                    {
                        for (int i = 0; i < 5; i++) //using a forloop that will go on 5 times as their are 5 marks 
                        {
                            if (!reader.IsDBNull(i))
                            {
                                txtBigBox.Text += reader[i].ToString() + Environment.NewLine;  // Adding each mark to the txtBigBox TextBox.
                            }
                        }
                    }

                    reader.Close(); // This will Close the data reader.
                }
                else // If no student is found, clear the textboxes and disable/delete button
                {
                    txtFirstName.Text = string.Empty;  //This would clear the firstname textbox 
                    txtLastName.Text = string.Empty; // this would clear the lastname textbox 
                    txtStudentID.Text = string.Empty; //this would clear the student id textbox
                    txtDOB.Text = string.Empty; //this will clear the DOB textbox 
                    txtBigBox.Text = string.Empty; // This will clear the BigBox textBox which is used for marks
                    btnDelete.Enabled = false; // this is Disabling the delete button
                    btnDelete.Visible = false; // This now making the delete buttin not visable 
                }

                connection.Close();  //This will Close the database connection.
                Refresh(Convert.ToInt32(txtStudentID.Text)); // This is Calling the Refresh method to update the display.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());  //This will Display any exception that occurred.
            }
        }

        private void btnClearChart_Click(object sender, EventArgs e)
        {
            chartMarks.Series["Marks"].Points.Clear(); //This is Clearing the data points in the "Marks" series of the chart.
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Enter new data?", "Entering data", MessageBoxButtons.YesNo); // This woud ask the user if they wanna enter a new data, it will provide them with an option of yes and no
            if (dialogResult == DialogResult.Yes) // if the user clicks yes then it will go through thus if statement
            {
                frmNewStudent frmNewStu = new frmNewStudent(); // since user clicked yes he will be taken to the new student form where he can input every important information of the new student
                frmNewStu.StudentSaved += FrmNewStudent_StudentSaved; // Subscribe to the StudentSaved event 
                frmNewStu.Show(); // this will show the newStudent form
                this.Hide(); // this will hide the current form user is on before going to the new student form in this case user is on the frmadmin
                frmNewStu.BringToFront(); // This would bring the New student form to the front and then it will be the only form that the user can see
            }

        }
        public void Populate()
        {
            connection.Open(); // Opening the database connection.
            cmbNames.Items.Clear(); // Clearing the items in the cmbNames ComboBox.
            OleDbCommand command = new OleDbCommand(); // Creating a new OleDbCommand.
            command.Connection = connection; // Setting the connection for the command.
            string query = "SELECT FirstName, LastName FROM tblStudents WHERE tblStudents.UserName NOT IN ('admin') ORDER BY FirstName";  // Selecting the FirstName and LastName from tblStudents where the UserName is not 'admin' and ordering the results by FirstName.
            command.CommandText = query;  // Assigning the query to the command.
            OleDbDataReader reader = command.ExecuteReader(); // Executing the command and creating a data reader.
            while (reader.Read())
            {
                cmbNames.Items.Add(Convert.ToString(reader[0]) + " " + Convert.ToString(reader[1]));  // Adding each first and last name to the cmbNames ComboBox.
            }
            connection.Close();  // Closing the database connection.
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID;
                if (!int.TryParse(txtStudentID.Text, out studentID))
                {
                    MessageBox.Show("Invalid student ID. Please enter a numeric value."); // This message will be displayed if a wrong student id has been found
                    return;
                }

                // Delete student's marks from tblMarks
                connection.Open(); // Opening the database connection.
                OleDbCommand marksCommand = new OleDbCommand(); // Creating a new OleDbCommand.
                marksCommand.Connection = connection; // Setting the connection for the command.
                string marksQuery = "DELETE FROM tblMarks WHERE StuID = @StudentID";
                // Deleting records from the tblMarks table where StuID matches the provided student ID.
                marksCommand.CommandText = marksQuery; // Assigning the query to the command.
                marksCommand.Parameters.AddWithValue("@StudentID", studentID); // Binding the student ID parameter.
                marksCommand.ExecuteNonQuery(); // Executing the query to delete the student's marks.
                connection.Close(); // Closing the database connection.

                // Delete student from tblStudents
                connection.Open(); // Opening the database connection.
                OleDbCommand command = new OleDbCommand(); // Creating a new OleDbCommand.
                command.Connection = connection; // Setting the connection for the command.
                string studentQuery = "DELETE FROM tblStudents WHERE StuID = @StudentID";
                // Deleting the student record from the tblStudents table where StuID matches the provided student ID.
                command.CommandText = studentQuery; // Assigning the query to the command.
                command.Parameters.AddWithValue("@StudentID", studentID); // Binding the student ID parameter.
                command.ExecuteNonQuery(); // Executing the query to delete the student from tblStudents.
                connection.Close(); // Closing the database connection.

                MessageBox.Show("Data Deleted"); // Displaying a message box indicating that the data was successfully deleted.

                // Remove the deleted student from cmbNames
                cmbNames.Items.Remove(cmbNames.SelectedItem); // Removing the selected student from the cmbNames ComboBox.

                // Reset the form
                clearText(); // Calling the clearText() method to clear the form fields.
                disableUpdate(); // Calling the disableUpdate() method to disable the update functionality.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting student: " + ex.Message); // Displaying an error message if an exception occurs.
                connection.Close(); // Closing the database connection.
            }
        }

        public void Refresh(int stuId)
        {
            connection.Open(); // Opening the database connection.
            lstAverage.Items.Clear(); // Clearing the items in the lstAverage ListBox.
            chartMarks.Series.Clear(); // Clearing the series in the chartMarks chart.
            chartMarks.Series.Add("Marks"); // Adding a new series named "Marks" to the chartMarks chart.
            connection.Close(); // Closing the database connection.

            ResetAv(); // Calling the ResetAv() method.

            try
            {
                connection.Open(); // Opening the database connection.
                OleDbCommand command = new OleDbCommand(); // Creating a new OleDbCommand.
                command.Connection = connection; // Setting the connection for the command.
                string query = "SELECT Mark1, Mark2, Mark3, Mark4, Mark5 FROM tblMarks WHERE StuID = " + Convert.ToString(stuId);
                // Retrieving the marks (Mark1, Mark2, Mark3, Mark4, Mark5) for the student with the specified stuId.
                command.CommandText = query; // Assigning the query to the command.
                OleDbDataReader reader = command.ExecuteReader(); // Executing the query and obtaining a data reader.

                int mark1 = 0; // Variable to store Mark1.
                int mark2 = 0; // Variable to store Mark2.
                int mark3 = 0; // Variable to store Mark3.
                int mark4 = 0; // Variable to store Mark4.
                int mark5 = 0; // Variable to store Mark5.

                while (reader.Read())
                {
                    mark1 = Convert.ToInt32(reader["Mark1"]); // Reading and converting Mark1 from the data reader.
                    mark2 = Convert.ToInt32(reader["Mark2"]); // Reading and converting Mark2 from the data reader.
                    mark3 = Convert.ToInt32(reader["Mark3"]); // Reading and converting Mark3 from the data reader.
                    mark4 = Convert.ToInt32(reader["Mark4"]); // Reading and converting Mark4 from the data reader.
                    mark5 = Convert.ToInt32(reader["Mark5"]); // Reading and converting Mark5 from the data reader.
                }

                reader.Close(); // Closing the data reader.
                connection.Close(); // Closing the database connection.

                int average = (mark1 + mark2 + mark3 + mark4 + mark5) / 5; // Calculating the average of the marks.
                txtAverage.Text = Convert.ToString(average); // Displaying the average in the txtAverage TextBox.

                // Displaying marks in txtBigBox
                txtBigBox.Text = $"Mark 1: {mark1}\r\n"; // Displaying Mark1 in the txtBigBox TextBox.
                txtBigBox.Text += $"Mark 2: {mark2}\r\n"; // Displaying Mark2 in the txtBigBox TextBox.
                txtBigBox.Text += $"Mark 3: {mark3}\r\n"; // Displaying Mark3 in the txtBigBox TextBox.
                txtBigBox.Text += $"Mark 4: {mark4}\r\n"; // Displaying Mark4 in the txtBigBox TextBox.
                txtBigBox.Text += $"Mark 5: {mark5}\r\n"; // Displaying Mark5 in the txtBigBox TextBox.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); // Displaying an error message if an exception occurs.
            }
        }
        public void ResetAv()
        {
            try
            {
                lstAverage.Items.Clear(); // Clearing the items in the lstAverage ListBox.

                OleDbCommand command = new OleDbCommand(); // Creating a new OleDbCommand.
                command.Connection = connection; // Setting the connection for the command.

                connection.Open(); // Opening the database connection.

                command.CommandText = "SELECT AVG(Mark1) FROM tblMarks"; // Query to calculate the average of Mark1.
                int avgM1 = Convert.ToInt16(command.ExecuteScalar()); // Executing the query and retrieving the average value.
                lstAverage.Items.Add(avgM1); // Adding the average value to the lstAverage ListBox.

                command.CommandText = "SELECT AVG(Mark2) FROM tblMarks"; // Query to calculate the average of Mark2.
                int avgM2 = Convert.ToInt16(command.ExecuteScalar()); // Executing the query and retrieving the average value.
                lstAverage.Items.Add(avgM2); // Adding the average value to the lstAverage ListBox.

                command.CommandText = "SELECT AVG(Mark3) FROM tblMarks"; // Query to calculate the average of Mark3.
                int avgM3 = Convert.ToInt16(command.ExecuteScalar()); // Executing the query and retrieving the average value.
                lstAverage.Items.Add(avgM3); // Adding the average value to the lstAverage ListBox.

                command.CommandText = "SELECT AVG(Mark4) FROM tblMarks"; // Query to calculate the average of Mark4.
                int avgM4 = Convert.ToInt16(command.ExecuteScalar()); // Executing the query and retrieving the average value.
                lstAverage.Items.Add(avgM4); // Adding the average value to the lstAverage ListBox.

                command.CommandText = "SELECT AVG(Mark5) FROM tblMarks"; // Query to calculate the average of Mark5.
                int avgM5 = Convert.ToInt16(command.ExecuteScalar()); // Executing the query and retrieving the average value.
                lstAverage.Items.Add(avgM5); // Adding the average value to the lstAverage ListBox.

                int totalAvg = (avgM1 + avgM2 + avgM3 + avgM4 + avgM5) / 5; // Calculating the total average.
                txtClassAv.Text = Convert.ToString(totalAvg); // Displaying the total average in the txtClassAv TextBox.

                connection.Close(); // This will Close the database connection.
            }
            catch
            {
                MessageBox.Show("Error getting average"); // This will Display an error message if an exception occurs.
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int studentID;
                if (!int.TryParse(txtStudentID.Text, out studentID))
                {
                    MessageBox.Show("Invalid student ID. Please enter a numeric value."); // This would display a message saying that Invalid Stu id, please enter a numeric value, this would basically warn the user.
                    return; //this would return it
                }

                OleDbCommand studentCommand = new OleDbCommand(); // Creating a new OleDbCommand for updating student information.
                studentCommand.Connection = connection; // Setting the connection for the studentCommand.

                string studentQuery = "UPDATE tblStudents SET FirstName = @FirstName, LastName = @LastName WHERE StuID = @StudentID"; // Query to update student information.
                studentCommand.CommandText = studentQuery; // Assigning the query to the studentCommand.

                studentCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text); // Adding the FirstName parameter and its value to the studentCommand.
                studentCommand.Parameters.AddWithValue("@LastName", txtLastName.Text); // Adding the LastName parameter and its value to the studentCommand.
                studentCommand.Parameters.AddWithValue("@StudentID", studentID); // Adding the StudentID parameter and its value to the studentCommand.

                connection.Open(); // Opening the database connection.
                studentCommand.ExecuteNonQuery(); // Executing the studentCommand to update the student information in tblStudents.
                connection.Close(); // Closing the database connection.

                OleDbCommand marksCommand = new OleDbCommand(); // Creating a new OleDbCommand for updating marks.
                marksCommand.Connection = connection; // Setting the connection for the marksCommand.

                string[] marks = txtBigBox.Text.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); // Splitting the text in txtBigBox into an array of individual lines.
                int[] updatedMarks = new int[marks.Length]; // Creating an array to store the updated marks.

                for (int i = 0; i < marks.Length; i++)
                {
                    string markValue = marks[i].Substring(marks[i].IndexOf(":") + 1).Trim(); // Extracting the mark value from each line in the format "Mark x: value".
                    updatedMarks[i] = int.Parse(markValue); // Parsing the mark value and storing it in the updatedMarks array.

                    marksCommand.Parameters.Clear(); // Clearing any previously added parameters.

                    string marksQuery = $"UPDATE tblMarks SET Mark{i + 1} = @Mark{i + 1} WHERE StuID = @StudentID"; // Query to update a specific mark in tblMarks.
                    marksCommand.CommandText = marksQuery; // Assigning the query to the marksCommand.

                    marksCommand.Parameters.AddWithValue($"@Mark{i + 1}", updatedMarks[i]); // Adding the mark parameter and its value to the marksCommand.
                    marksCommand.Parameters.AddWithValue("@StudentID", studentID); // Adding the StudentID parameter and its value to the marksCommand.

                    connection.Open(); // Opening the database connection.
                    marksCommand.ExecuteNonQuery(); // Executing the marksCommand to update the mark in tblMarks.
                    connection.Close(); // Closing the database connection.
                }

                MessageBox.Show("Student information and marks updated successfully."); // Displaying a success message.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student information and marks: " + ex.Message); // Displaying an error message if an exception occurs.
            }
        }
  
        private void FrmNewStudent_StudentSaved(object sender, EventArgs e)
        {
            PopulateCmbName(); // This will Refresh the cmbNames dropdown with the updated student list

            (sender as frmNewStudent).Close(); // This will Close the frmNewStudent form
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // This helps user exit the windows form, triggering necessary cleanup operations.
        }
    }
}
