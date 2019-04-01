using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Taksidermie
{
    class Datahandler
    {

        string conString = "Data Source=.;Initial Catalog=TDatabase;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        DataSet dataSet = null;

        public DataSet Read()
        {

            try
            {
                dataSet = new DataSet();
                conn = new SqlConnection(conString);
                conn.Open();

                string select = "SELECT * FROM  tblClientInfo";
                adapter = new SqlDataAdapter(select, conn);

                adapter.Fill(dataSet, "tblClientInfo");

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("List<User> Read()" + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return dataSet;
        }

        public DataSet DisplayPaid()
        {

            try
            {
                dataSet = new DataSet();
                conn = new SqlConnection(conString);
                conn.Open();

                string select = "SELECT * FROM  tblTrophee Where TropheeDepositPaid = 'True'";
                adapter = new SqlDataAdapter(select, conn);

                adapter.Fill(dataSet, "tblTrophee");

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("List<User> DisplayPaid()" + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return dataSet;
        }

        public DataSet DisplayPaidClient(int ID)
        {

            try
            {
                dataSet = new DataSet();
                conn = new SqlConnection(conString);
                conn.Open();

                string select = "SELECT * FROM  tblTrophee Where TropheeDepositPaid = 'True' and ClientID = '" + ID + "'";
                adapter = new SqlDataAdapter(select, conn);

                adapter.Fill(dataSet, "tblTrophee");

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("List<User> DisplayPaid()" + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return dataSet;
        }

        public DataSet DisplayUnPaid()
        {

            try
            {
                dataSet = new DataSet();
                conn = new SqlConnection(conString);
                conn.Open();

                string select = "SELECT * FROM  tblTrophee Where TropheeDepositPaid = 'False'";
                adapter = new SqlDataAdapter(select, conn);

                adapter.Fill(dataSet, "tblTrophee");

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("List<User> DisplayUnPaid()" + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return dataSet;
        }

        public DataSet DisplayUnPaidClient(int ID)
        {

            try
            {
                dataSet = new DataSet();
                conn = new SqlConnection(conString);
                conn.Open();

                string select = "SELECT * FROM  tblTrophee Where TropheeDepositPaid = 'False'and ClientID = '" + ID + "'";;
                adapter = new SqlDataAdapter(select, conn);

                adapter.Fill(dataSet, "tblTrophee");

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("List<User> DisplayUnPaid()" + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return dataSet;
        }

        public void UpdateClient(Client NewClient, int ID)
        {
            try
            {
                conn = new SqlConnection(conString);
                conn.Open();


                string Update = "UPDATE tblClientInfo SET ClientName = '" + NewClient.Name + "', ClientSurname = '" + NewClient.Surname +
                    "', ClienTCellNumber = '" + NewClient.Cell + "', ClientAddress = '" + NewClient.Address + "' WHERE ClientID = '" + ID + "'";
                SqlCommand cmd = new SqlCommand(Update, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("Update " + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public DataSet SearchTrophee(string Search, int ID)
        {
            dataSet = null;
            try
            {
                dataSet = new DataSet();
                conn = new SqlConnection(conString);
                conn.Open();

                string select = "SELECT * FROM tblTrophee WHERE ClientID = '" + ID + "' and TropheeAmount LIKE '%" + Search + "%' or TropheeAnimalType LIKE '%" + Search + "%' " +
                    "or TropheeDeposit LIKE '%" + Search + "%' or TropheeDepositPaid LIKE '%" + Search + "%' or TropheeID LIKE '%" + Search + "%' or " +
                    "TropheePrice LIKE '%" + Search + "%' or TropheeRemarks LIKE '%" + Search + "%' or TropheeType LIKE '%" + Search + "%' ";

                adapter = new SqlDataAdapter(select, conn);

                adapter.Fill(dataSet, "tblTrophee");

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("List<User> Read()" + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return dataSet;

        }

        public DataSet Search(string Search)
        {
            dataSet = null;
            try
            {
                dataSet = new DataSet();
                conn = new SqlConnection(conString);
                conn.Open();

                string select = "SELECT * FROM tblClientInfo WHERE TropheeAmount LIKE '%" + Search + "%' or TropheeAnimalType LIKE '%" + Search + "%' " +
                    "or TropheeDeposit LIKE '%" + Search + "%' or TropheeDepositPaid LIKE '%" + Search + "%' or TropheeID LIKE '%" + Search + "%' or " +
                    "TropheePrice LIKE '%" + Search + "%' or TropheeRemarks LIKE '%" + Search + "%' or TropheeType LIKE '%" + Search + "%' ";

                adapter = new SqlDataAdapter(select, conn);

                adapter.Fill(dataSet, "tblTrophee");

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("List<User> Read()" + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return dataSet;

        }


        public void AddClient(Client NewClient)
        {
            try
            {
                conn = new SqlConnection(conString);
                conn.Open();


                string insert = "INSERT INTO tblClientInfo (ClientName, ClientSurname, ClientCellNumber, ClientAddress)" +
                    " VALUES('" + NewClient.Name + "','" + NewClient.Surname + "','" + NewClient.Cell + "','" + NewClient.Address + "')";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("AddClient " + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public double ReturnPrice(string animals, string mount)
        {
            double price = 0;
            try
            {
                conn = new SqlConnection(conString);
                conn.Open();

                string add = "SELECT " + mount + " FROM tblPriceList WHERE Animal = '" + animals +"'";
                SqlCommand cmd = new SqlCommand(add, conn);
                price = (double)cmd.ExecuteScalar();

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("AddTrophee " + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return price;
        }

        public void AddTrophee(Animal NewAnimal)
        {
            try
            {
                conn = new SqlConnection(conString);
                conn.Open();


                string insert = "INSERT INTO tblTrophee (ClientID, TropheeAmount, TropheeAnimalType, TropheeType, TropheeRemarks" +
                    ", TropheePrice, TropheeDeposit, TropheeDepositPaid)" +
                    " VALUES('" + NewAnimal.Clientid + "','" + NewAnimal.Amount + "','" + NewAnimal.Animals + "','" +
                    NewAnimal.Tropheetype + "','"+ NewAnimal.Remark + "','"+ NewAnimal.Price + "','"+ NewAnimal.Deposit + "','"+ NewAnimal.Paid + "')";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("AddTrophee " + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public void DeleteClient(int ID)
        {
            try
            {
                conn = new SqlConnection(conString);
                conn.Open();

                string Delete1 = "DELETE FROM tblTrophee WHERE ClientID = '" + ID + "'";
                string Delete2 = "DELETE FROM tblClientInfo WHERE ClientID = '" + ID + "'";
                SqlCommand cmd1 = new SqlCommand(Delete1, conn);
                SqlCommand cmd = new SqlCommand(Delete2, conn);
                cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("DeleteClient  " + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }
        public DataSet ReadTrophee(int ID)
        {
            dataSet = null;
            try
            {
                dataSet = new DataSet();
                conn = new SqlConnection(conString);
                conn.Open();

                string select = "SELECT * FROM tblTrophee WHERE ClientID = " + ID;
                adapter = new SqlDataAdapter(select, conn);

                adapter.Fill(dataSet, "tblTrophee");

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("List<User> Read()" + e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return dataSet;

        }
    }
}
