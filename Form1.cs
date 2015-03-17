using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Web;

using System.Security.Cryptography;

using System.IO;


   

namespace IM_Thing
{
    public partial class Form1 : Form
    {
        const bool DEBUG = false;

        Socket mySocket;
        EndPoint epLocal, epRemote;
        bool connected = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialise the socket
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            mySocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            
            debugMessage("Socket Initialised");

            tb_ipLocal.Text = getLocalIP();

            debugMessage("Local IP Found");

            loadDGVFromFile(dgv_friends, "friends.txt");
           
        }

        private string getLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";



        }

        private void but_connect_Click(object sender, EventArgs e)
        {
            if(!connected)
            {
                try
                {
                    string remoteIP;
                    try
                    {
                        debugMessage("trying to parse IP:");
                        remoteIP = IPAddress.Parse(tb_ipRemote.Text).ToString();
                    }
                    catch
                    {
                        debugMessage("Failed");
                        remoteIP = resolveIP(tb_ipRemote.Text);
                    }
                    debugMessage("target ip is: " + remoteIP);
                   // MessageBox.Show(remoteIP);
                    
                    byte[] buffer = new byte[1700];
                    //Bind the socket
                    epLocal = new IPEndPoint(IPAddress.Parse(tb_ipLocal.Text), Convert.ToInt32(tb_portLocal.Text));
                    mySocket.Bind(epLocal);
                    debugMessage("Socket Bound to " + epLocal.ToString());

                    //Connect to Remote IP
                    epRemote = new IPEndPoint(IPAddress.Parse(remoteIP), Convert.ToInt32(tb_portRemote.Text));
                    mySocket.Connect(epRemote);
                    debugMessage("Connected to Remote IP");

                    //Start Listening
                    buffer = new byte[1500];
                    mySocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageReceived), buffer);
                    debugMessage("Started Listening");
                    printMessage("Connection to " + epRemote.ToString() + " established.");


                    sendMessage("systemCONNECTmessage", mySocket);
                    connected = true;
                    but_connect.Text = "Disconnect";
                    but_Send.Enabled = true;
                    tb_ipLocal.Enabled = false;
                    tb_ipRemote.Enabled = false;
                    tb_portLocal.Enabled = false;
                    tb_portRemote.Enabled = false;
                }
                catch(Exception ex)
                {
                    lb_messages.Items.Add("ERROR: " + ex.Message);
                }

            }
            else
            {
                disconnect();


            }
        }

        private void MessageReceived(IAsyncResult result)
        {

            byte[] receivedData = new byte[1500];
            receivedData = (byte[])result.AsyncState;

            if (receivedData != new byte[1500])
            {

                string receivedMessage = byteToString(receivedData);
                receivedMessage = Decrypt(receivedMessage, generateKey());

                if (receivedMessage != "")
                {
                    receivedMessage = chatFilter(receivedMessage);
                    printMessage(receivedMessage);
                }
                debugMessage("Message received - Size: " + receivedMessage.Length);



                if (connected)
                {
                    byte[] buffer = new byte[1100];
                    mySocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageReceived), buffer);
                }
            }
            return;



        }

        private string chatFilter(string message)
        {
            string targetName = tb_name.Text;
            if (targetName == "")
            {
                targetName = "Your partner";
            }

            if (message == "systemCONNECTmessage")
            {
                sendMessage("systemALREADYCONNECTEDmessage",mySocket);
                return "--" + targetName + " has connected--";
            }
            else if (message == "systemALREADYCONNECTEDmessage")
            {
                return "--" + targetName + " is already connected--";
            }
            else if (message == "systemDISCONNECTINGmessage")
            {
                return "--" + targetName + " has disconnected--";
            }


            if (targetName == "Your partner")
            {
                targetName = "Partner";
            }

            return targetName + ": " + message;
        }

        private void debugMessage(string message)
        {
            if(DEBUG)
            {
                printMessage("DEBUG: " + message);
            }
        }

        private void but_Send_Click(object sender, EventArgs e)
        {

            if(tb_message.Text == "")
            {
                debugMessage("Can't send an empty string");
                return;
            }

            sendMessage(tb_message.Text, mySocket);

            printMessage("You: " + tb_message.Text);
            tb_message.Text = "";
            lb_messages.TopIndex = lb_messages.Items.Count - 1;
        }

        private void tb_message_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (connected)
                {
                    but_Send_Click(sender, e);
                }
            }
        }

        private void sendMessage(string message, Socket sock)
        {

                string encryptedMessage = Encrypt(message, generateKey());
                sock.Send(stringToByte(encryptedMessage));
 
        }


        private string byteToString(byte[] theByteArray)
        {
            int index = -1;
            int i;
            for (i = theByteArray.Length -1; i >= 0; i--)
            {
                if(theByteArray[i] != 0)
                {
                    index = i;

                    break;
                }
            }

            byte[] myByteArray = new byte[sizeof(char) * (index+1)];

            for (i = 0; i < index + 1; i++)
            {
                myByteArray[i] = theByteArray[i];
            }

            ASCIIEncoding aEncode = new ASCIIEncoding();
            string receivedMessage = aEncode.GetString(myByteArray);
            receivedMessage = receivedMessage.Substring(0, i);



            return receivedMessage;

        }

        private byte[] stringToByte(string theMessage)
        {
            ASCIIEncoding aEncode = new ASCIIEncoding();
            byte[] byteMessage = new byte[theMessage.Length * sizeof(char)];
            byteMessage = aEncode.GetBytes(theMessage);

            return byteMessage;
        }

        private void printMessage(string message)
        {
            Invoke(new MethodInvoker(delegate { lb_messages.Items.Add(DateTime.Now.ToShortTimeString() + " | " + message); }));
            Invoke(new MethodInvoker(delegate { lb_messages.TopIndex = lb_messages.Items.Count - 1; ; }));    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveDGVToFile(dgv_friends, "friends.txt");
            if(connected)
            {
                disconnect();

            }
            
        }

        private void disconnect()
        {
            connected = false;
            sendMessage("systemDISCONNECTINGmessage",mySocket);
            mySocket.Close();
            debugMessage("Disconnected");
            printMessage("--You have disconnected from your partner--");
            but_Send.Enabled = false;
            but_connect.Text = "Connect";
            tb_ipLocal.Enabled = true;
            tb_ipRemote.Enabled = true;
            tb_portLocal.Enabled = true;
            tb_portRemote.Enabled = true;

            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            mySocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }

        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        private string generateKey()
        {
            string chars = (DateTime.UtcNow.ToString("dd:hh:mm tt yyyy") + DateTime.UtcNow.ToString("dh:hm:dd mt yyyy"));
          //  MessageBox.Show("Chars: " + chars);
            if(chars.Length > 24)
            {
                chars = chars.Substring(0, 24);
            }

            char[] nums = new char[(tb_portRemote.Text + tb_portLocal.Text).ToCharArray().Length];
            if(int.Parse(tb_portRemote.Text) > int.Parse(tb_portLocal.Text))
            {
                nums = (tb_portRemote.Text + tb_portLocal.Text).ToCharArray();
            }
            else
            {
                nums = (tb_portLocal.Text + tb_portRemote.Text).ToCharArray();
            }


            int[] numArray = new int[nums.Length];


            for (int i = 0; i < nums.Length;i++)
            {
                numArray[i] = int.Parse(nums[i].ToString());
            }
            Array.Sort(numArray);

            string numString = string.Empty;
            for (int i = 0; i < nums.Length; i++)
            {
                numString = numString + numArray[i].ToString();
            }
           // MessageBox.Show("num string: " + numString);
            string key1 = Encrypt(numString, chars);

           // MessageBox.Show(key1);
            string key2 = Encrypt(key1, chars);
           // MessageBox.Show(key2);

            if (key2.Length > 24)
            {
                key2 = key2.Substring(0, 24);
            }
            return key2;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generateKey();
        }

        private string resolveIP(string hostName)
        {
            IPHostEntry Host = Dns.GetHostEntry(hostName);
            return Host.AddressList[0].ToString();
        }

        private void saveDGVToFile(DataGridView dgv, string filePath)
        {
            File.WriteAllText(filePath, "");
            for (int i = 0; i < dgv.RowCount-1;i++)
            {
                for (int j = 0; j < dgv.ColumnCount;j++)
                {
                    File.AppendAllText(filePath,dgv.Rows[i].Cells[j].Value.ToString() + " ");
                }
                File.AppendAllText(filePath, "\r\n");
                
            }
        }

        private void loadDGVFromFile(DataGridView dgv, string filePath)
        {
            if(File.Exists(filePath))
            {
                StreamReader file = new StreamReader(filePath);
                string line;
                string[] splitLines;
                while((line = file.ReadLine()) != null)
                {
                   splitLines = line.Split(' ');
                   dgv.Rows.Add(splitLines[0],splitLines[1],splitLines[2]);
                }
                file.Close();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(!connected)
            {

            }
        }

        private void dgv_friends_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (dgv_friends.SelectedCells[0].RowIndex +1 != dgv_friends.RowCount)
                {
                    dgv_friends.Rows.RemoveAt(dgv_friends.SelectedCells[0].RowIndex);
                }
            }
        }

      }
    }

