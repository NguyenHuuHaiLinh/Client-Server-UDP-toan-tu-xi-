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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        byte[] data = new byte[1024];
        IPEndPoint ipep = new IPEndPoint(
                        IPAddress.Parse("127.0.0.1"), 9050);
        Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint sender = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
        EndPoint Remote;
        string input;
        public Form1()
        {
            InitializeComponent();
           // string welcome = "Hello, are you there?";
           // data = Encoding.ASCII.GetBytes(welcome);
            server.SendTo(data, data.Length, SocketFlags.None, ipep);
            Remote = (EndPoint)sender;
            data = new byte[1024];
        }

        private void btnBao_Click(object sender, EventArgs e)
        {
            txtChon.Text = "Bao";
            input = "3";
            server.SendTo(Encoding.ASCII.GetBytes(input), Remote);
            // ser.sendto la gửi tới server
            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref Remote);
            string k = Encoding.ASCII.GetString(data, 0, recv);
            kq(input, k);

        }
        public void kq(string input, string k)
        {
            if (input == "1")
            {
                if (k == "1")
                {
                    //svselecttxt.Text = "Búa";
                    txtKetqua.Text = "Hòa";
                }
                if (k == "2")
                {
                    //svselecttxt.Text = "Kéo";
                    txtKetqua.Text = "Thắng";
                }
                if (k == "3")
                {
                    //svselecttxt.Text = "Bao";
                    txtKetqua.Text = "Thua";
                }
            }
            if (input == "2")
            {
                if (k == "1")
                {
                    //svselecttxt.Text = "Búa";
                    txtKetqua.Text = "Thua";
                }
                if (k == "2")
                {
                    //svselecttxt.Text = "Kéo";
                    txtKetqua.Text = "Hòa";
                }
                if (k == "3")
                {
                    //svselecttxt.Text = "Bao";
                    txtKetqua.Text = "Thắng";
                }
            }
            if (input == "3")
            {
                if (k == "1")
                {
                    //svselecttxt.Text = "Búa";
                    txtKetqua.Text = "Thắng";
                }
                if (k == "2")
                {
                    //svselecttxt.Text = "Kéo";
                    txtKetqua.Text = "Thua";
                }
                if (k == "3")
                {
                   // svselecttxt.Text = "Bao";
                    txtKetqua.Text = "Hòa";
                }
            }
        }

        private void btnKeo_Click(object sender, EventArgs e)
        {
            txtChon.Text = "Kéo";
            input = "2";
            server.SendTo(Encoding.ASCII.GetBytes(input), Remote);
            // ser.sendto la gửi tới server
            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref Remote);
            string k = Encoding.ASCII.GetString(data, 0, recv);
            kq(input, k);
        }

        private void btnBua_Click(object sender, EventArgs e)
        {
            txtChon.Text = "Búa";
            input = "1";
            server.SendTo(Encoding.ASCII.GetBytes(input), Remote);
            // ser.sendto la gửi tới server
            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref Remote);
            string k = Encoding.ASCII.GetString(data, 0, recv);
            kq(input, k);
        }
    }
}
