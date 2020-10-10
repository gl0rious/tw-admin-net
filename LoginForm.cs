using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tw_app
{
    public partial class LoginForm : Form
    {
        const string cnx_string = "Data Source=(DESCRIPTION="
                + "(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))"
                + "(CONNECT_DATA=(SERVICE_NAME={2})));"
                + "User Id={3};Password={4};";

        public DB DataBase { get; private set; }
        OracleConnection cnx;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void login_bt_Click(object sender, EventArgs e)
        {
            Username = user_tb.Text.Trim();
            password = password_tb.Text.Trim();
            connect();
        }

        private void cancel_bt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        public string Host { get; private set; }
        public string Port { get; private set; }
        public string Service { get; private set; }
        public string Username { get; private set; }
        string password;
        private void LoginForm_Load(object sender, EventArgs e)
        {
            cnx = new OracleConnection();
            Host = ConfigurationManager.AppSettings["Host"];
            if (Host == null)
            {
                MessageBox.Show("Host does not exist in config file");
                this.DialogResult = DialogResult.No;
            }
            Port = ConfigurationManager.AppSettings["Port"];
            if (Port == null)
            {
                MessageBox.Show("Port does not exist in config file");
                this.DialogResult = DialogResult.No;
            }
            Service = ConfigurationManager.AppSettings["Service"];
            if (Service == null)
            {
                MessageBox.Show("Service does not exist in config file");
                this.DialogResult = DialogResult.No;
            }
            Username = ConfigurationManager.AppSettings["Username"];
            if (Username != null)
                user_tb.Text = Username;
            password = ConfigurationManager.AppSettings["Password"];
            if(Username != null && password != null)
                connect();
        }
        private void connect()
        {
            if (Username == null || Username == "")
            {
                MessageBox.Show("Username is empty");
                return;
            }
            if (password == null || password == "")
            {
                MessageBox.Show("Password is empty");
                return;
            }

            cnx.ConnectionString = string.Format(cnx_string, Host, Port, Service, Username, password);

            try
            {
                cnx.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            DataBase = new DB(Username, cnx);
            if (!DataBase.Check_user_DBA_privilege())
            {
                MessageBox.Show($"\"{Username}\" not a DBA user, retry", "Login error");
                cnx.Close();
                return;
            }
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
