using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Name: Taha Mohyuddin
 * Program: Assignment 4
 * Enhancements: All of the Enhacements are at the bottom of the frmlogin.cs page 
 * Purpose: This Program has two uses one that the admin can use and the other that the students can use, the admin can see all of the students marks and averages of each student including the new students that they add, they can also see the student marks graph. Wheras the student can only see their marks and can't change anything for more infromation go to the frmlogin.cs page 
 * Date: 2023-06-16
*/
namespace Assignment4
{
    public partial class frmForgetPassword : Form
    {
        public string NewPassword { get; private set; }
        public frmForgetPassword()
        {
            InitializeComponent();
        }

        private void btnConirm_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                NewPassword = txtNewPassword.Text; // Assigning the value of the new password entered by the user
                DialogResult = DialogResult.OK; // Seting the form's DialogResult to OK
                Close(); // Close the form
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text) || string.IsNullOrEmpty(txtReEnterPass.Text)) //This if statement will make sure that no password is left empty
            {
                MessageBox.Show("Please enter a new password."); //This will Display an error message if the new password field is empty
                return false;
            }

            if (txtNewPassword.Text != txtReEnterPass.Text) // this if statement will check whether the new password entered and the re enter new passowrd match or not
            {
                MessageBox.Show("The entered passwords do not match. Please re-enter your new password."); //This will Display an error message if the entered passwords do not match
                txtNewPassword.Text = string.Empty; // This will Clear the new password textbox
                txtReEnterPass.Text = string.Empty; // This will Clear the re-enter password textbox
                txtNewPassword.Focus(); // Set the focus back to the new password textbox
                return false;
            }

            return true; //This will Return true if all fields are valid
        }
    }
}
