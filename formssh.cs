using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace SSHClient
{
    public partial class formssh : Form
    {
        static Client client;
        public formssh()
        {
            InitializeComponent();
           System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory+"server.exe");
        
           client = new Client();
         
        }

        private void connect_Click(object sender, EventArgs e)
        {
            client.connect();
          //textcmd.Text = ipaddress.Text + user.Text + password.Text;
          client.connectionServer(print,ipaddress.Text,user.Text,password.Text);
            if(print.Text.Contains("failure"))
            {
                
                etat.ForeColor=System.Drawing.Color.Red;
            }
            else
            {
                etat.Text = "online";
                etat.ForeColor=System.Drawing.Color.Green;
            }
         
        }

        private void cmd_Click(object sender, EventArgs e)
        {
              client.gestion(print,textcmd.Text);
           

        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            client.gestion(print, "end");
            etat.Text = "offline";
            etat.ForeColor = System.Drawing.Color.Red;
        }

       
    }
}