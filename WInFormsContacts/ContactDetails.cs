using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WInFormsContacts
{
    public partial class ContactDetails : Form
    {
        private BusinessLogicLayers _businessLogicLayers;
        private Contact _contact;
        public ContactDetails()
        {
            InitializeComponent();
            _businessLogicLayers = new BusinessLogicLayers();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveContact();
            this.Close();
            ((Main)this.Owner).Populatecontacts();
        }
        #region PRIVATE METHODS
        private void SaveContact() {

            Contact contact = new Contact();
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
            contact.Phone = txtPhone.Text;
            contact.Address = txtAddress.Text;

            contact.Id = _contact != null ? _contact.Id : 0;

            _businessLogicLayers.SaveContact(contact);
        }
        #endregion

        public void LoadContact(Contact contact)
        {
            _contact = contact;
            if (contact != null)
            {
                ClearFrom();

                txtFirstName.Text = contact.FirstName;
                txtLastName.Text = contact.LastName;
                txtPhone.Text = contact.Phone;
                txtAddress.Text = contact.Address;
            }
             
        }
        private void ClearFrom()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
    }
}
