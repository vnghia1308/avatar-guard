using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace Avatar_Guard
{
    public partial class Guard : Form
    {
        public Guard()
        {
            InitializeComponent();
        }

        private void Login(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();

            login.FormClosed += delegate
            {
                if(Value.access_token != "")
                {
                    access_token.Text = Value.access_token; //add access_token to textbox
                    Value.access_token = ""; //reset access_token value
                }
            };
        }

        private void startGuardProtect(object sender, EventArgs e)
        {
            if(access_token.Text != "")
            {
                access_token.Enabled = false; guardAvatar.Enabled = false; unGuard.Enabled = false; loginToken.Enabled = false;

                try
                {
                    string profile = new WebClient().DownloadString("https://graph.facebook.com/me?access_token=" + access_token.Text);

                    if (profile.Contains("id"))
                    {
                        string URI = "https://nghia.org/public/api/v1/jsonCompile.php"; //API parse JSON (because project no use Newtonsoft JSON)
                        string GetID = "str=" + profile + "&value=id";

                        using (WebClient wc = new WebClient())
                        {
                            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                            string id = wc.UploadString(URI, GetID);

                            SendtoAPI(id, "true");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong access_token!", "Guard error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Wrong access_token!", "Guard error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { access_token.Enabled = true; guardAvatar.Enabled = true; unGuard.Enabled = true; loginToken.Enabled = true; }
            }
            else
            {
                MessageBox.Show("access_token require not null!", "Guard warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Un_Guard(object sender, EventArgs e)
        {
            if (access_token.Text != "")
            {
                access_token.Enabled = false; guardAvatar.Enabled = false; unGuard.Enabled = false; loginToken.Enabled = false;

                try
                {
                    string profile = new WebClient().DownloadString("https://graph.facebook.com/me?access_token=" + access_token.Text);

                    if (profile.Contains("id"))
                    {
                        string URI = "https://nghia.org/public/api/v1/jsonCompile.php"; //API parse JSON (because project no use Newtonsoft JSON)
                        string GetID = "str=" + profile + "&value=id";

                        using (WebClient wc = new WebClient())
                        {
                            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                            string id = wc.UploadString(URI, GetID);

                            SendtoAPI(id, "false");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong access_token!", "Un-Guard error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Wrong access_token!", "Un-Guard error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { access_token.Enabled = true; guardAvatar.Enabled = true; unGuard.Enabled = true; loginToken.Enabled = true; }
            }
            else
            {
                MessageBox.Show("access_token require not null!", "Guard warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SendtoAPI(string id, string GuardType)
        {
            try
            {
                string PostData = "variables={\"0\":{\"is_shielded\":" + GuardType + ",\"session_id\":\"9b78191c-84fd-4ab6-b0aa-19b39f04a6bc\",\"actor_id\":\"" + id + "\",\"client_mutation_id\":\"b0316dd6-3fd6-4beb-aed4-bb29c5dc64b0\"}}&method=post&doc_id=1477043292367183&query_name=IsShieldedSetMutation&strip_defaults=true&strip_nulls=true&locale=en_US&client_country_code=US&fb_api_req_friendly_name=IsShieldedSetMutation&fb_api_caller_class=IsShieldedSetMutation";
                string GraphURI = "https://graph.facebook.com/graphql";
                
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    wc.Headers[HttpRequestHeader.Authorization] = "OAuth " + access_token.Text;
                    string rep = wc.UploadString(GraphURI, PostData);

                    if(GuardType == "true")
                    {
                        if (rep.Contains("true"))
                        {
                            MessageBox.Show("Your avatar has protected!", "Guard Successfully", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            MessageBox.Show("Can't turn on Guard for your avatar!", "Guard Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Removed shield in your avatar!", "Un-Guard Successfully", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    
                }
            }
            catch (Exception o)
            {
                MessageBox.Show("Response server has crashed! ", "Guard Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guard_Load(object sender, EventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    //... internet connection detected
                }
            }
            catch (Exception o)
            {
                //Connect failed to internet
                access_token.Enabled = false; guardAvatar.Enabled = false; loginToken.Enabled = false;
                MessageBox.Show("Please connect to internet!", "Internet require", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void CoprightClick(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/nghiadev");
        }
    }
}
