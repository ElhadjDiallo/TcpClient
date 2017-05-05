using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SSHClient
{
    class Client
    {
        TcpClient client;
        Int32 port = 13214;
        String server = "127.0.0.1";
        StreamReader sr;
        StreamWriter sw;
        NetworkStream stream;
        private static int cont=0;
        private static List<String> listeMessage;
       
        public void connect()
        {
            try
            {

                client = new TcpClient(server, port);
                stream = client.GetStream();
                sr = new StreamReader(stream);
                sw = new StreamWriter(stream);
            
                /*
                sr = new StreamReader(stream);
                sw = new StreamWriter(stream);
                String data = "";
                String datareceive = null;
                datareceive = sr.ReadLine();
                Console.WriteLine(datareceive);


                do
                {



                    Console.WriteLine("Entrer quelque chose à envoyer");
                    data = System.Console.ReadLine();
                    sw.WriteLine(data);
                    sw.Flush();
                    Console.WriteLine("envoie {0}", data);

                    datareceive = sr.ReadLine();
                    Console.WriteLine("recu {0}", datareceive);

                } while (!data.Equals("end"));

                sr.Close();
                sw.Close();*/

            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.ToString());
            }
         

        }
        public void connectionServer(RichTextBox textbox,String ipadrress,String user,String mdp)
        {
            textbox.Text= "";
                     
            String datareceive = null;
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    sw.WriteLine(ipadrress);
                    sw.Flush();
                }
                else if (i==1)
                {
                    sw.WriteLine(user);
                    sw.Flush();
                }
                else 
                {
                    sw.WriteLine(mdp);
                    sw.Flush();
                }
            }
            datareceive = sr.ReadLine();
            textbox.Focus();
            textbox.AppendText("" + datareceive + "\n");
            textbox.ScrollToCaret();
           // textbox.Text+= ""+datareceive+"\n";
            listeMessage = new List<string>();

        }

        public void gestion(RichTextBox textbox,String message)
        {
            
            try
            {

                

                String data =message;
                String datareceive = null;
             


        



               
                    sw.WriteLine(data);
                    sw.Flush();
                    listeMessage.Add(">:" + data + "\n");
                   // textbox.Text += ;

                    datareceive = sr.ReadLine();
                    listeMessage.Add(datareceive);
                    //textbox.Text += datareceive+"\n";
                    String s = "";
                   
                    foreach (String mes in listeMessage)
                    {
                        s +=""+ mes + "\n";
                    }
                    textbox.Focus();
                    textbox.AppendText(s);
                    textbox.ScrollToCaret();
                    //textbox.Text = s;
                    if (data.Equals("end"))
                    {
                        textbox.Text = ">Disconnected";
                        sr.Close();
                        sw.Close();
                    }

            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.ToString());
            }
         
        }
    }
}
