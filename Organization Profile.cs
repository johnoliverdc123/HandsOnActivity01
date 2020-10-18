using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public long StudentNumber(string studNum)
        {

            _StudentNo = long.Parse(studNum);

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }
            else
            {
                throw new FormatException();
                throw new ArgumentNullException();
                throw new OverflowException();
                throw new IndexOutOfRangeException();
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            else
            { 
                throw new ArgumentNullException();
            }

            return _FullName;
        }


        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }
            else
            {
                throw new FormatException();
                throw new ArgumentNullException();
                throw new OverflowException();
                throw new IndexOutOfRangeException();
            }

            return _Age;
        }
       
        

            public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListofProgram = new string[]{
                "BS Information Technology",
                    "BS Computer Science",
                    "BS Information System",
                    "BS Computer Engineering",
                    "BS Accountancy",
                    "BS Tourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListofProgram[i].ToString());
            }
            string[] Gender = new string[]{
                "Male",
                    "Female"
            };
            foreach (String item in Gender)
            {
                cbGender.Items.Add(item);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                frmConfirmation frm = new frmConfirmation();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    
                    cbPrograms.ResetText();
                    txtLastName.ResetText();
                    txtFirstName.ResetText();
                    txtMiddleInitial.ResetText();
                    txtStudentNo.ResetText();
                    txtAge.ResetText();
                    txtContactNo.ResetText();
                    cbGender.ResetText();
                }
                else
                {
                    frm.Dispose();
                }


            }
            catch (FormatException fe)
            {

                MessageBox.Show(fe.Message);  
            }
            catch (ArgumentNullException ane)
            {

                MessageBox.Show(ane.Message);
            }
            catch (OverflowException ofe)
            {

                MessageBox.Show(ofe.Message);
            }
            catch (IndexOutOfRangeException iore)
            {

                MessageBox.Show(iore.Message);
            }
        }
    }
}
