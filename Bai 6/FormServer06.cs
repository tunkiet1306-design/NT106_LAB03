using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB03
{
    public partial class FormServer06 : Form
    {
        private TcpListener listener;

        private Dictionary<string, TcpClient>
            clients =
            new Dictionary<string, TcpClient>();
        private List<string> chatHistory =
    new List<string>();
        public FormServer06()
        {
            InitializeComponent();

            CreateUI();
        }

        private Button btnStart = null!;
        private RichTextBox rtbLog = null!;

        private Label lblPort = null!;
        private TextBox txtPort = null!;

        private void CreateUI()
        {
            Text = "Chat Server";

            btnStart = new Button();

            btnStart.Text = "Start Server";
            btnStart.Size = new System.Drawing.Size(
                150,
                40);

            btnStart.Location =
                new System.Drawing.Point(
                    20,
                    20);
            lblPort = new Label();

            lblPort.Text = "Port:";
            lblPort.Location =
                new System.Drawing.Point(
                    200,
                    30);

            lblPort.AutoSize = true;

            txtPort = new TextBox();

            txtPort.Text = "8080";
            txtPort.Location =
                new System.Drawing.Point(
                    250,
                    27);

            txtPort.Width = 100;

            btnStart.Click +=
                btnStart_Click;

            rtbLog = new RichTextBox();

            rtbLog.Location =
                new System.Drawing.Point(
                    20,
                    80);

            rtbLog.Size =
                new System.Drawing.Size(
                    740,
                    380);

            rtbLog.ReadOnly =
                true;

            Controls.Add(btnStart);

            Controls.Add(lblPort);
            Controls.Add(txtPort);

            Controls.Add(rtbLog);
        }

        private void btnStart_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                int port;

                if (!int.TryParse(
                        txtPort.Text,
                        out port))
                {
                    MessageBox.Show(
                        "Port không hợp lệ!");

                    return;
                }

                listener =
                    new TcpListener(
                        IPAddress.Any,
                        port);

                listener.Start();

                Thread t =
                    new Thread(
                        ListenClient);

                t.IsBackground =
                    true;

                t.Start();

                rtbLog.AppendText(
                    "Server Started...\n");

                btnStart.Enabled =
                    false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void ListenClient()
        {
            while (true)
            {
                try
                {
                    TcpClient client =
                        listener.AcceptTcpClient();

                    Thread t =
                        new Thread(
                            () => HandleClient(client));

                    t.IsBackground =
                        true;

                    t.Start();
                }
                catch
                {
                    break;
                }
            }
        }

        private void HandleClient(
            TcpClient client)
        {
            string username = "";

            try
            {
                NetworkStream stream =
                    client.GetStream();

                byte[] buffer =
                    new byte[1024 * 1024];

                while (true)
                {
                    int bytesRead =
                        stream.Read(
                            buffer,
                            0,
                            buffer.Length);

                    if (bytesRead == 0)
                        break;

                    string msg =
                        Encoding.UTF8.GetString(
                            buffer,
                            0,
                            bytesRead);

                    string[] parts =
                        msg.Split('|');

                    if (parts[0] == "LOGIN")
                    {
                        username =
                            parts[1];

                        if (clients.ContainsKey(username))
                        {
                            SendToClient(
                                client,
                                "USERNAME_EXISTS");

                            client.Close();

                            return;
                        }

                        clients[username] = client;

                        clients[username] =
                            client;

                        // Gửi lại lịch sử chat cho client mới

                        foreach (string oldMsg in chatHistory)
                        {
                            SendToClient(
                                client,
                                oldMsg);
                        }

                        Invoke(new Action(() =>
                        {
                            rtbLog.AppendText(
                                username +
                                " Connected\n");
                        }));

                        UpdateUserList();

                        string systemMsg =
                            "SYSTEM|" +
                            username +
                            " joined";

                        chatHistory.Add(
                            systemMsg);

                        Broadcast(
                            systemMsg);
                    }

                    else if (parts[0] == "MSG")
                    {
                        chatHistory.Add(msg);

                        Broadcast(msg);
                    }
                    else if (parts[0] == "IMG")

                    {
                        foreach (TcpClient c in clients.Values)
                        {
                            try
                            {
                                byte[] data =
                                    Encoding.UTF8.GetBytes(msg);

                                c.GetStream().Write(
                                    data,
                                    0,
                                    data.Length);
                            }
                            catch
                            {
                            }
                        }
                    }
                    else if (parts[0] == "PIMG")
                    {
                        string from = parts[1];
                        string to = parts[2];

                        if (clients.ContainsKey(to))
                        {
                            SendToClient(
                                clients[to],
                                msg);
                        }

                        if (clients.ContainsKey(from))
                        {
                            SendToClient(
                                clients[from],
                                msg);
                        }
                    }
                    else if (parts[0] == "FILE")
                    {
                        foreach (TcpClient c in clients.Values)
                        {
                            try
                            {
                                byte[] data =
                                    Encoding.UTF8.GetBytes(
                                        msg + "\n");

                                c.GetStream().Write(
                                    data,
                                    0,
                                    data.Length);
                            }
                            catch
                            {
                            }
                        }

                        Invoke(new Action(() =>
                        {
                            rtbLog.AppendText(
                                "TXT File Sent\n");
                        }));
                    }
                    else if (parts[0] == "PFILE")
                    {
                        string from = parts[1];
                        string to = parts[2];

                        if (clients.ContainsKey(to))
                        {
                            SendToClient(
                                clients[to],
                                msg);
                        }

                        if (clients.ContainsKey(from))
                        {
                            SendToClient(
                                clients[from],
                                msg);
                        }
                    }
                    else if (parts[0] == "PM")
                    {
                        string from =
                            parts[1];

                        string to =
                            parts[2];

                        string content =
                            parts[3];

                        string privateMsg =
                            "PM|" +
                            from +
                            "|" +
                            content;

                        // Gửi cho người nhận
                        if (clients.ContainsKey(to))
                        {
                            SendToClient(
                                clients[to],
                                privateMsg);
                        }

                        // Gửi lại cho người gửi
                        if (clients.ContainsKey(from))
                        {
                            SendToClient(
                                clients[from],
                                privateMsg);
                        }
                    }
                }
            }
            catch
            {
            }

            if (username != "")
            {
                if (clients.ContainsKey(username))
                {
                    clients.Remove(
                        username);

                    UpdateUserList();

                    Invoke(new Action(() =>
                    {
                        rtbLog.AppendText(
                            username +
                            " Disconnected\n");
                    }));
                }
            }

            client.Close();
        }

        private void Broadcast(
    string message)
        {
            byte[] data =
                Encoding.UTF8.GetBytes(
                    message + "\n");

            foreach (TcpClient client in clients.Values)
            {
                try
                {
                    client.GetStream()
                        .Write(
                            data,
                            0,
                            data.Length);
                }
                catch
                {
                }
            }
        }


        private void SendToClient(
    TcpClient client,
    string message)
        {
            byte[] data =
                Encoding.UTF8.GetBytes(
                    message + "\n");

            client.GetStream()
                .Write(
                    data,
                    0,
                    data.Length);
        }

        private void UpdateUserList()
        {
            string users =
                string.Join(
                    ",",
                    clients.Keys);

            Broadcast(
                "USERLIST|" +
                users);
        }

        private void FormServer06_Load(
            object sender,
            EventArgs e)
        {

        }

        protected override void OnFormClosing(
        FormClosingEventArgs e)
        {
            try
            {
                if (listener != null)
                {
                    listener.Stop();
                }

                foreach (TcpClient client in clients.Values)
                {
                    try
                    {
                        client.Close();
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }

            base.OnFormClosing(e);
        }
    }
}