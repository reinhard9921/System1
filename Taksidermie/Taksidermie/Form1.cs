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

        private void Main_Load(object sender, EventArgs e)
        {
            dgvClientInfo.DataSource = dh.Read();
            dgvClientInfo.DataMember = "tblClientInfo";
            dgvTrophee.DataSource = dh.ReadTrophee(id);
            dgvTrophee.DataMember = "tblTrophee";

            txtID.Enabled = false;
            txtName.Enabled = false;
            txtSurname.Enabled = false;
            txtAddress.Enabled = false;
            txtCellphone.Enabled = false;
            btnClient.Visible = false;
            btnAddClient.Visible = false;


            UpdateTitles();


        }

        public void UpdateTitles()
        {
            dgvClientInfo.Columns[0].HeaderCell.Value = "ID";
            dgvClientInfo.Columns[1].HeaderCell.Value = "Name";
            dgvClientInfo.Columns[2].HeaderCell.Value = "Surname";
            dgvClientInfo.Columns[3].HeaderCell.Value = "Cell";
            dgvClientInfo.Columns[4].HeaderCell.Value = "Address";

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

        private void dgvClientInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void btnSearchTrophee_Click(object sender, EventArgs e)
        {




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

        private void btnSearch_Click(object sender, EventArgs e)
        {

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


    }
}