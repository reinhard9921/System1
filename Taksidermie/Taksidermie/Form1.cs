using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taksidermie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        int id;
        Datahandler dh = new Datahandler();
        DataSet ds = new DataSet();

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        string sName;

        

        public void UpdateTitles()
        {
            dgvClientInfo.Columns[0].HeaderCell.Value = "ID";
            dgvClientInfo.Columns[1].HeaderCell.Value = "Name";
            dgvClientInfo.Columns[2].HeaderCell.Value = "Surname";
            dgvClientInfo.Columns[3].HeaderCell.Value = "Cell";
            dgvClientInfo.Columns[4].HeaderCell.Value = "Email Address";

            dgvTrophee.Columns[0].HeaderCell.Value = "Trophee ID";
            dgvTrophee.Columns[1].HeaderCell.Value = "Client ID";
            dgvTrophee.Columns[2].HeaderCell.Value = "Amount";
            dgvTrophee.Columns[3].HeaderCell.Value = "Animal Type";
            dgvTrophee.Columns[4].HeaderCell.Value = "Trophee Type";
            dgvTrophee.Columns[5].HeaderCell.Value = "Remarks";
            dgvTrophee.Columns[6].HeaderCell.Value = "Price";
            dgvTrophee.Columns[7].HeaderCell.Value = "Deposit";
            dgvTrophee.Columns[8].HeaderCell.Value = "Paid";

        }

        public void update()
        {
            dgvTrophee.DataSource = null;
            dgvTrophee.DataSource = dh.ReadTrophee(id);
            dgvTrophee.DataMember = "tblTrophee";
        }
        private void dgvClientInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientInfo.CurrentCell != null)
            {
                try
                {
                    int index = dgvClientInfo.CurrentCell.RowIndex;

                    id = (int)dgvClientInfo.Rows[index].Cells[0].Value;
                    dgvTrophee.DataSource = dh.ReadTrophee(id);
                    dgvTrophee.DataMember = "tblTrophee";
                    update();

                    string ID = dgvClientInfo.Rows[index].Cells[0].Value.ToString();
                    txtID.Text = ID;
                    sName = dgvClientInfo.Rows[index].Cells[1].Value.ToString();
                    txtName.Text = sName;
                    string Surname = dgvClientInfo.Rows[index].Cells[2].Value.ToString();
                    txtSurname.Text = Surname;
                    string Cell = dgvClientInfo.Rows[index].Cells[3].Value.ToString();
                    txtCellphone.Text = Cell;
                    string Address = dgvClientInfo.Rows[index].Cells[4].Value.ToString();
                    txtAddress.Text = Address;

                    txtID.Enabled = false;
                    txtName.Enabled = false;
                    txtSurname.Enabled = false;
                    txtAddress.Enabled = false;
                    txtCellphone.Enabled = false;
                    btnClient.Visible = false;
                    btnAddClient.Visible = false;

                    UpdateTitles();
                }
                catch (Exception r)
                {

                    MessageBox.Show("Selection Change " + r);
                }


            }
            update();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtName.Enabled = true;
            txtSurname.Enabled = true;
            txtAddress.Enabled = true;
            txtCellphone.Enabled = true;
            btnAddClient.Enabled = true;

            btnAddClient.Visible = true;
            btnClient.Visible = false;

            txtID.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtAddress.Text = "";
            txtCellphone.Text = "";
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;
            string surname = txtSurname.Text;
            string address = txtAddress.Text;
            string cell = txtCellphone.Text;

            Client cl = new Client(0, name, surname, cell, address);
            dh.AddClient(cl);
            dgvClientInfo.DataSource = null;
            dgvClientInfo.DataSource = dh.Read();
            dgvClientInfo.DataMember = "tblClientInfo";

            txtID.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtAddress.Text = "";
            txtCellphone.Text = "";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Delete = MessageBox.Show("Are you sure you want to delete " + sName, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Delete == DialogResult.Yes)
            {
                dh.DeleteClient(id);
                dgvClientInfo.DataSource = null;
                dgvClientInfo.DataSource = dh.Read();
                dgvClientInfo.DataMember = "tblClientInfo";
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtName.Enabled = true;
            txtSurname.Enabled = true;
            txtAddress.Enabled = true;
            txtCellphone.Enabled = true;
            btnAddClient.Enabled = true;

            btnAddClient.Visible = false;
            btnClient.Visible = true;



        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            DialogResult Update = MessageBox.Show("Are you sure you want to Update " + sName, "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Update == DialogResult.Yes)
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string address = txtAddress.Text;
                string cell = txtCellphone.Text;

                Client cl = new Client(0, name, surname, cell, address);

                dh.UpdateClient(cl, id);
                dgvClientInfo.DataSource = null;
                dgvClientInfo.DataSource = dh.Read();
                dgvClientInfo.DataMember = "tblClientInfo";

                txtID.Text = "";
                txtName.Text = "";
                txtSurname.Text = "";
                txtAddress.Text = "";
                txtCellphone.Text = "";
            }
        }

 

        private void btnAdd_Click(object sender, EventArgs e)
        {

            int amount = int.Parse(txtAmount.Text);
            string animals = cmbAnimal.Text;
            string tropheetype = cmbTrophee.Text;
            string remark = richedit.Text;
            double price;
            double deposit;
            bool paid = chkPaid.Checked;

            price = dh.ReturnPrice(animals, tropheetype);

            price = price * amount;
            deposit = price / 2;

            Animal animal = new Animal(0, id, amount, animals, tropheetype, remark, price, deposit, paid);
            dh.AddTrophee(animal);

            dgvTrophee.DataSource = null;
            dgvTrophee.DataSource = dh.ReadTrophee(id);
            dgvTrophee.DataMember = "tblTrophee";

            txtAmount.Text = "";
            cmbAnimal.Text = "";
            cmbTrophee.Text = "";
            richedit.Text = "";

        }




        private void txtFilterTrophee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFilterTrophee.Text == "Deposit Paid")
            {
                if (cbClient.Checked == true)
                {
                    dgvTrophee.DataSource = null;
                    dgvTrophee.DataSource = dh.DisplayPaidClient(id);
                    dgvTrophee.DataMember = "tblTrophee";
                }
                else
                {
                    dgvTrophee.DataSource = null;
                    dgvTrophee.DataSource = dh.DisplayPaid();
                    dgvTrophee.DataMember = "tblTrophee";
                }


            }
            else if (txtFilterTrophee.Text == "Deposit Not Paid")
            {
                if (cbClient.Checked == true)
                {
                    dgvTrophee.DataSource = null;
                    dgvTrophee.DataSource = dh.DisplayUnPaidClient(id);
                    dgvTrophee.DataMember = "tblTrophee";
                }
                else
                {
                    dgvTrophee.DataSource = null;
                    dgvTrophee.DataSource = dh.DisplayUnPaid();
                    dgvTrophee.DataMember = "tblTrophee";
                }


            }
            else
            {

                dgvTrophee.DataSource = null;
                dgvTrophee.DataSource = dh.ReadTrophee(id);
                dgvTrophee.DataMember = "tblTrophee";

            }
        }

        private void cbClient_CheckedChanged(object sender, EventArgs e)
        {
            if (txtFilterTrophee.Text == "Deposit Paid")
            {
                if (cbClient.Checked == true)
                {
                    dgvTrophee.DataSource = null;
                    dgvTrophee.DataSource = dh.DisplayPaidClient(id);
                    dgvTrophee.DataMember = "tblTrophee";
                }
                else
                {
                    dgvTrophee.DataSource = null;
                    dgvTrophee.DataSource = dh.DisplayPaid();
                    dgvTrophee.DataMember = "tblTrophee";
                }


            }
            else if (txtFilterTrophee.Text == "Deposit Not Paid")
            {
                if (cbClient.Checked == true)
                {
                    dgvTrophee.DataSource = null;
                    dgvTrophee.DataSource = dh.DisplayUnPaidClient(id);
                    dgvTrophee.DataMember = "tblTrophee";
                }
                else
                {
                    dgvTrophee.DataSource = null;
                    dgvTrophee.DataSource = dh.DisplayUnPaid();
                    dgvTrophee.DataMember = "tblTrophee";
                }


            }
            else
            {

                dgvTrophee.DataSource = null;
                dgvTrophee.DataSource = dh.ReadTrophee(id);
                dgvTrophee.DataMember = "tblTrophee";

            }
        }



        private void txtSearchTrophee_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchTrophee.Text == "")
            {
                dgvTrophee.DataSource = null;
                dgvTrophee.DataSource = dh.ReadTrophee(id);
                dgvTrophee.DataMember = "tblTrophee";
            }
            else
            {
                dgvTrophee.DataSource = null;
                dgvTrophee.DataSource = dh.SearchTrophee(txtSearchTrophee.Text, id);
                dgvTrophee.DataMember = "tblTrophee";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                dgvClientInfo.DataSource = null;
                dgvClientInfo.DataSource = dh.Read();
                dgvClientInfo.DataMember = "tblClientInfo";
            }
            else
            {
                dgvClientInfo.DataSource = null;
                dgvClientInfo.DataSource = dh.Search(txtSearch.Text);
                dgvClientInfo.DataMember = "tblClientInfo";
            }
        }



        private void btnDeleteTrophee_Click(object sender, EventArgs e)
        {
            DialogResult Delete = MessageBox.Show("Are you sure you want to delete " + sName, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (Delete == DialogResult.Yes)
            {
                dh.DeleteClient(id);
                dgvClientInfo.DataSource = null;
                dgvClientInfo.DataSource = dh.ReadTrophee(id);
                dgvClientInfo.DataMember = "tblTrophee";
            }
        }

        private void dgvTrophee_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTrophee.CurrentCell != null)
            {
                try
                {
                    int index = dgvTrophee.CurrentCell.RowIndex;

                    id = (int)dgvTrophee.Rows[index].Cells[0].Value;
                    update();

                    string ID = dgvTrophee.Rows[index].Cells[0].Value.ToString();
                    txtName.Text = sName;
                    string Amount = dgvTrophee.Rows[index].Cells[2].Value.ToString();
                    txtAmount.Text = Amount;
                    string Type = dgvTrophee.Rows[index].Cells[3].Value.ToString();
                    cmbAnimal.Text = Type;
                    string tropheeType = dgvTrophee.Rows[index].Cells[4].Value.ToString();
                    cmbTrophee.Text = tropheeType;
                    string Remarks = dgvTrophee.Rows[index].Cells[5].Value.ToString();
                    richedit.Text = Remarks;
                    string price = dgvTrophee.Rows[index].Cells[6].Value.ToString();
                    txtPrice.Text = price;
                    string deposit = dgvTrophee.Rows[index].Cells[7].Value.ToString();
                    txtDeposit.Text = deposit;
                    string depositPaid = dgvTrophee.Rows[index].Cells[8].Value.ToString();
                    if (depositPaid == "true")
                    {
                        chkPaid.Checked = true;
                    }
                    else
                    {
                        chkPaid.Checked = false;
                    }


                    UpdateTitles();
                }
                catch (Exception r)
                {

                    MessageBox.Show("Selection Change " + r);
                }


            }
            update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvClientInfo.DataSource = dh.Read();
            dgvClientInfo.DataMember = "tblClientInfo";
            dgvTrophee.DataSource = dh.ReadTrophee(id);
            dgvTrophee.DataMember = "tblTrophee";
            dgvInvoiceActive.DataSource = dh.ReadInvoiceActive();
            dgvInvoiceActive.DataMember = "tblInvoice";
            dgvInvoiceInactive.DataSource = dh.ReadInvoiceInactive();
            dgvInvoiceInactive.DataMember = "tblInvoice";


            txtID.Enabled = false;
            txtName.Enabled = false;
            txtSurname.Enabled = false;
            txtAddress.Enabled = false;
            txtCellphone.Enabled = false;
            btnClient.Visible = false;
            btnAddClient.Visible = false;


            UpdateTitles();
        }



        private void txtSearchInvoiceActive_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchInvoiceActive.Text == "")
            {
                dgvInvoiceActive.DataSource = null;
                dgvInvoiceActive.DataSource = dh.ReadInvoiceActive();
                dgvInvoiceActive.DataMember = "tblInvoice";
            }
            else
            {
                dgvInvoiceActive.DataSource = null;
                dgvInvoiceActive.DataSource = dh.SearchInvoice(txtSearchTrophee.Text, "true");
                dgvInvoiceActive.DataMember = "tblInvoice";
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchInactive_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchInvoiceActive.Text == "")
            {
                dgvInvoiceInactive.DataSource = null;
                dgvInvoiceInactive.DataSource = dh.ReadInvoiceInactive();
                dgvInvoiceInactive.DataMember = "tblInvoice";
            }
            else
            {
                dgvInvoiceInactive.DataSource = null;
                dgvInvoiceInactive.DataSource = dh.SearchInvoice(txtSearchTrophee.Text, "false");
                dgvInvoiceInactive.DataMember = "tblInvoice";
            }
        }
    }
}