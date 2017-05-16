using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Globalization;

namespace WindowsFormsApplication2
{
    public partial class Cvor : Form
    {
        public string username;
        public int port;
        public string IP;
        public DateTime time;
        public string[] mjerenja;
        public List<Ocitanje> ocitanja = new List<Ocitanje>();
        UdpClient client = new UdpClient();
        public List<potvrde> potvrdee = new List<potvrde>();
        Dictionary<int, string> ports = new Dictionary<int, string>();

        public Cvor()
        {
            InitializeComponent();

            this.IP = "localhost";
            this.time = DateTime.Now;
            ucitajmjerenja();
            List<Ocitanje> ocitanja = new List<Ocitanje>();
      
        }

        public void Cvor_Load(object sender, EventArgs e)
        {
            Thread listener = new Thread(new ThreadStart(receive));
            listener.Start();
        }

        public void receive()
        {
            UdpClient server = new UdpClient(0);
            this.port = ((IPEndPoint)server.Client.LocalEndPoint).Port;

            while (true)
            {
                IPEndPoint rip = new IPEndPoint(IPAddress.Any, this.port);
                Byte[] recieved = server.Receive(ref rip);
                string output = System.Text.Encoding.UTF8.GetString(recieved);

                if (output.Split(' ')[0] == "potvrda")
                {
                    List<potvrde> nova = potvrdee;
                    foreach (potvrde p in nova)
                    {
                        if (p.kome==output.Split(' ')[1] && p.index==Int32.Parse(output.Split(' ')[2]))
                        { p.potvdeno = true; }
                    }
                    potvrdee = nova;
                } else
                {
                    Ocitanje oi = new Ocitanje();
                    oi.cije = output.Split(' ')[0];
                    oi.vrijednost = Int32.Parse(output.Split(' ')[1]);
                    oi.vrijeme = DateTime.Parse(output.Split(' ')[2] + output.Split(' ')[3]);
                    oi.index = Int32.Parse(output.Split(' ')[4]);
                    Thread.Sleep(2000);
                    potvrda(oi.cije, oi.index);
                    ocitanja.Add(oi);
                }
            }         
        }



        private void usernameButton_Click(object sender, EventArgs e)
        {
            groupBox.Enabled = true;

            this.username = usernameText.Text;
            usernameText.Enabled = false;
            usernameButton.Enabled = false;
            Cvor.ActiveForm.Text = username;

            portText.Text = port.ToString();
            IPText.Text = IP;

            string content = this.username + " " + this.port;

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("sockets.txt", true))
            {
                file.WriteLine(content);
            }

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            groupBox.Enabled = false;
            label3.Visible = true;

            Thread ispis = new Thread(new ThreadStart(ispisujocitanja));
            Thread broji = new Thread(new ThreadStart(brojac));
            ispis.Start();
            broji.Start();

            string[] readText = File.ReadAllLines("sockets.txt");
            

            foreach (string socket in readText)
            {
                string[] sockets = new string[2];
                sockets = socket.Split(' ');
                string destname = sockets[0];
                int destport = Int32.Parse(sockets[1]);
                if (destport != this.port)
                {
                    ports.Add(destport, destname);
                }
            }

            Thread senderr = new Thread(new ThreadStart(send));
            senderr.Start();

            
        }

        public void ispisujocitanja()
        {
            List<Ocitanje> nova = new List<Ocitanje>();
            while (true)
            {
                float srednja;
                int uk = 0;
                int broj = 0;
                double pet = 5;

                nova = ocitanja.Where(o => (DateTime.Now - o.vrijeme).Seconds <= 5 && o.vrijeme.Minute==DateTime.Now.Minute).ToList();
                nova.Sort(delegate (Ocitanje o1, Ocitanje o2) { return o1.vrijeme.CompareTo(o2.vrijeme); });

                foreach (Ocitanje o in nova)
                {
                    string output = o.vrijeme.ToString("HH:mm:ss:fff") + ": " + o.cije + "\t=" + o.vrijednost.ToString();
                    this.chatset(output);
                    uk += o.vrijednost;
                    broj++;
                }

                if (broj != 0)
                {
                    srednja = uk / broj;
                    this.srednjaLabelset(srednja.ToString("0.00", CultureInfo.InvariantCulture.NumberFormat));
                }
                Thread.Sleep(5000);
                this.chatset("clear");
            }
            
        }

        int index = 0;

        public void send()
        {

            while (true)
            {

                string sendstring = username + " " + dohvatimjerenje() + " " + DateTime.Now.ToString() + " " + index.ToString();
                byte[] senddata = Encoding.ASCII.GetBytes(sendstring);


                foreach (KeyValuePair<int, string> entry in ports)
                {
                    client.Send(senddata, senddata.Length, "localhost", entry.Key);
                    potvrde potvrda = new WindowsFormsApplication2.potvrde();
                    potvrda.kome = entry.Value;
                    potvrda.index = index;

                    potvrdee.Add(potvrda);

                    string paketinfo = index.ToString()+". za " +entry.Value;
                    paketiset(paketinfo);

                    Thread cekapotvrdu = new Thread(() => cekampotvrdu(entry.Value, index, sendstring));
                    cekapotvrdu.Start();
                }
                index++;
            }
        }

        public void cekampotvrdu(string name, int index, string sendstring)
        {
            bool stigla = false;
            while (!stigla)
            {
                Thread.Sleep(5000);

                List<potvrde> nova = potvrdee;

                bool potvrdeno = false;

                potvrdeno = potvrdee.Find(item => item.kome == name && item.index == index).potvdeno;

                if (potvrdeno)
                {
                    stigla = true;
                    string potvrdainfo = index.ToString() + ". za " + name + " potvrđen";
                    potvrdeset(potvrdainfo);
                }
                else
                {

                    byte[] senddata = Encoding.ASCII.GetBytes(sendstring);

                }

                /*
                foreach (potvrde p in nova)
                {
                    if (p.kome == name && p.index == index)
                    {
                        if (p.potvdeno)
                        {
                            stigla = true;
                            string potvrdainfo = index.ToString() + ". za" + name + " potvrđen";
                            potvrdeset(potvrdainfo);
                        }
                        else
                        {
                            byte[] senddata = Encoding.ASCII.GetBytes(sendstring);
                        }
                    }  
                }
                potvrdee = nova; 
                */
            }
        }

        public void potvrda(string sender, int indexp)
        {
            string sendstring = "potvrda "+ username+" " + indexp.ToString();
            byte[] senddata = Encoding.ASCII.GetBytes(sendstring);

            string[] readText = File.ReadAllLines("sockets.txt");

            foreach (string socket in readText)
            {
                string[] sockets = new string[2];
                sockets = socket.Split(' ');
                if (sender == sockets[0])
                {
                    client.Send(senddata, senddata.Length, "localhost", Int32.Parse(sockets[1]));
                }
            }
        }

        public string dohvatimjerenje()
        {
            int i = 0;
            double broj_aktivnih_sekundi = (DateTime.Now-time).TotalSeconds;
            int broj = Convert.ToInt32(broj_aktivnih_sekundi);
            int redni_broj = (broj % 100) + 1;

            foreach(string mjerenje in mjerenja)
            {
                if (i == redni_broj)
                {
                    string ocitanje = mjerenje.Split(',')[3];
                    Ocitanje o = new Ocitanje();
                    o.vrijednost = Int32.Parse(ocitanje);
                    o.vrijeme = DateTime.Now;
                    o.cije = this.username;
                    o.index = index;
                    ocitanja.Add(o);
                    Thread.Sleep(1000);
                    return mjerenje.Split(',')[3];
                }
                    
                i++;
            }
            return null;

        }

        public void ucitajmjerenja()
        {
            mjerenja = File.ReadAllLines("mjerenja.csv");
            
        }

        private void brojac()
        {
            while (true)
            {
                for (int i=1; i<=5; i++)
                {
                    this.counterset(i.ToString());
                    Thread.Sleep(1000);
                }
            }
        }

        delegate void SetTextCallback(string text);

        private void srednjaLabelset(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.srednjaLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(srednjaLabelset);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.srednjaLabel.Text = text;
            }
        }

        private void counterset(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.counter.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(counterset);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.counter.Text = text;
            }
        }

        private void chatset(string output)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.chat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(chatset);
                this.Invoke(d, new object[] { output });
            }
            else
            {
                if (output == "clear") this.chat.Items.Clear();
                else this.chat.Items.Add(output);
            }
        }

        private void paketiset(string output)

        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.paketibox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(paketiset);
                this.Invoke(d, new object[] { output });
            }
            else
            {
                this.paketibox.Items.Add(output);
            }
        }

        private void potvrdeset(string output)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.potvrdebox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(potvrdeset);
                this.Invoke(d, new object[] { output });
            }
            else
            {
                this.potvrdebox.Items.Add(output);
            }
        }


    }
}
