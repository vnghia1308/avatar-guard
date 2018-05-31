using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace Avatar_Guard
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "")
            {
                username.Enabled = false; password.Enabled = false; LoginFacebook.Enabled = false;

                string URI = "https://nghia.org/public/api/v1/buildLogin.php"; //API build login url 
                string loginContent = "u=" + username.Text + "&p=" + password.Text;

                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        string loginResult = wc.UploadString(URI, loginContent);
                        string loginString = new WebClient().DownloadString(loginResult);

                    
                        string URI2 = "https://nghia.org/public/api/v1/jsonCompile.php";
                        string loginData = "str=" + loginString + "&value=access_token";

                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        string access_token = wc.UploadString(URI2, loginData);

                        if(access_token.Length > 100)
                        {
                            Value.access_token = access_token;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Can't not login, please try again!", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Response server has crashed!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally { username.Enabled = true; password.Enabled = true; LoginFacebook.Enabled = true; }
                }
            }
            else
            {
                MessageBox.Show("Please don't leave the login information blank!", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
