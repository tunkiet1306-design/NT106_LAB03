using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
namespace LAB03
{
    public partial class FormClient06 : Form
    {
        private TcpClient client;

        private Thread receiveThread;

        public FormClient06()
        {
            InitializeComponent();

            CreateUI();
        }

        private Label lblIP;
        private Label lblUser;
        private Label lblMessage;
        private Label lblOnline;
        private bool isPrivateChat = false;

        private string selectedUser = "";
        private TextBox txtIP;
        private TextBox txtUser;
        private TextBox txtMessage;

        private Button btnConnect;
        private Button btnSend;
        private ListBox lstUsers;
        private Button btnImage;
        private RichTextBox rtbChat;
        private Button btnFile;
        private void CreateUI()
        {

            btnImage = new Button();

            btnImage.Text = "Image";
            btnImage.Location =
                new System.Drawing.Point(820, 482);

            btnImage.Size =
                new System.Drawing.Size(100, 35);

            btnImage.Click +=
                btnImage_Click;

            Controls.Add(btnImage);

            Text = "Chat Client";

            btnFile = new Button();

            btnFile.Text = "TXT";
            btnFile.Location =
                new System.Drawing.Point(820, 530);

            btnFile.Size =
                new System.Drawing.Size(100, 35);

            btnFile.Click +=
                btnFile_Click;

            Controls.Add(btnFile);
            Width = 980;
            Height = 650;

            lblIP = new Label();
            lblIP.Text = "IP Server:";
            lblIP.Location = new System.Drawing.Point(20, 30);
            lblIP.AutoSize = true;

            txtIP = new TextBox();
            txtIP.Location = new System.Drawing.Point(120, 25);
            txtIP.Size = new System.Drawing.Size(180, 27);
            txtIP.Text = "127.0.0.1";

            lblUser = new Label();
            lblUser.Text = "Username:";
            lblUser.Location = new System.Drawing.Point(330, 30);
            lblUser.AutoSize = true;

            txtUser = new TextBox();
            txtUser.Location = new System.Drawing.Point(430, 25);
            txtUser.Size = new System.Drawing.Size(180, 27);

            btnConnect = new Button();
            btnConnect.Text = "Connect";
            btnConnect.Location = new System.Drawing.Point(650, 22);
            btnConnect.Size = new System.Drawing.Size(120, 35);
            btnConnect.Click += btnConnect_Click;

            lblOnline = new Label();
            lblOnline.Text = "Online Users";
            lblOnline.Location = new System.Drawing.Point(20, 70);
            lblOnline.AutoSize = true;

            lstUsers = new ListBox();
            lstUsers.Location = new System.Drawing.Point(20, 95);
            lstUsers.Size = new System.Drawing.Size(220, 360);

            lstUsers.Items.Add("[GROUP CHAT]");

            lstUsers.SelectedIndexChanged +=
                lstUsers_SelectedIndexChanged;

            rtbChat = new RichTextBox();
            rtbChat.Location = new System.Drawing.Point(260, 95);
            rtbChat.Size = new System.Drawing.Size(670, 360);
            rtbChat.ReadOnly = true;

            lblMessage = new Label();
            lblMessage.Text = "Message:";
            lblMessage.Location = new System.Drawing.Point(20, 490);
            lblMessage.AutoSize = true;

            txtMessage = new TextBox();
            txtMessage.Location = new System.Drawing.Point(120, 485);
            txtMessage.Size = new System.Drawing.Size(550, 27);
            txtMessage.KeyDown +=
    txtMessage_KeyDown;

            btnSend = new Button();
            btnSend.Text = "Send";
            btnSend.Location = new System.Drawing.Point(700, 482);
            btnSend.Size = new System.Drawing.Size(100, 35);
            btnSend.Click += btnSend_Click;


            Controls.Add(lblIP);
            Controls.Add(txtIP);

            Controls.Add(lblUser);
            Controls.Add(txtUser);

            Controls.Add(btnConnect);

            Controls.Add(lblOnline);
            Controls.Add(lstUsers);

            Controls.Add(rtbChat);

            Controls.Add(lblMessage);
            Controls.Add(txtMessage);

            Controls.Add(btnSend);

        }
        private void txtMessage_KeyDown(
    object sender,
    KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                SendMessage();
            }
        }
        private void SendMessage()
        {
            try
            {
                if (client == null)
                    return;

                if (txtMessage.Text.Trim() == "")
                    return;

                string msg;

                if (isPrivateChat)
                {
                    msg =
                        "PM|" +
                        txtUser.Text +
                        "|" +
                        selectedUser +
                        "|" +
                        txtMessage.Text;
                }
                else
                {
                    msg =
                        "MSG|" +
                        txtUser.Text +
                        "|" +
                        txtMessage.Text;
                }

                byte[] data =
                    Encoding.UTF8.GetBytes(msg);

                client.GetStream()
                      .Write(
                          data,
                          0,
                          data.Length);

                txtMessage.Clear();
            }
            catch
            {
            }
        }

        private void btnImage_Click(
    object sender,
    EventArgs e)
        {
            try
            {
                OpenFileDialog ofd =
                    new OpenFileDialog();

                ofd.Filter =
                    "Image Files|*.png;*.jpg;*.jpeg";

                if (ofd.ShowDialog()
                    == DialogResult.OK)
                {
                    byte[] imageData =
                        File.ReadAllBytes(
                            ofd.FileName);

                    string base64 =
                        Convert.ToBase64String(
                            imageData);

                    string msg;

                    if (isPrivateChat)
                    {
                        msg =
                            "PIMG|" +
                            txtUser.Text +
                            "|" +
                            selectedUser +
                            "|" +
                            base64;
                    }
                    else
                    {
                        

                        if (isPrivateChat)
                        {
                            msg =
                                "PIMG|" +
                                txtUser.Text +
                                "|" +
                                selectedUser +
                                "|" +
                                base64;
                        }
                        else
                        {
                            msg =
                                "IMG|" +
                                txtUser.Text +
                                "|" +
                                base64;
                        }
                    }


                    byte[] data =
                        Encoding.UTF8.GetBytes(
                            msg);

                    client.GetStream()
                          .Write(
                              data,
                              0,
                              data.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
        private void btnConnect_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                client = new TcpClient();

                client.Connect(
                    txtIP.Text,
                    8080);

                string login =
                    "LOGIN|" +
                    txtUser.Text;

                byte[] data =
                    Encoding.UTF8.GetBytes(
                        login);

                client.GetStream()
                    .Write(
                        data,
                        0,
                        data.Length);

                receiveThread =
                    new Thread(
                        ReceiveData);

                receiveThread.IsBackground =
                    true;

                receiveThread.Start();

                MessageBox.Show(
                    "Connected!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void btnSend_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (client == null)
                {
                    MessageBox.Show(
                        "Connect first!");
                    return;
                }

                string msg =
                    "MSG|" +
                    txtUser.Text +
                    "|" +
                    txtMessage.Text;

                byte[] data =
                    Encoding.UTF8.GetBytes(
                        msg);

                client.GetStream()
                    .Write(
                        data,
                        0,
                        data.Length);

                txtMessage.Clear();
            }
            catch
            {
            }
        }


        private void ReceiveData()
        {
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

                    string receiveData =
    Encoding.UTF8.GetString(
        buffer,
        0,
        bytesRead);

                    string[] messages =
                        receiveData.Split(
                            '\n',
                            StringSplitOptions.RemoveEmptyEntries);

                    foreach (string msg in messages)
                    {

                        Invoke(new Action(() =>
                    {
                        if (msg.StartsWith(
                            "USERLIST|"))
                        {
                            lstUsers.Items.Clear();

                            lstUsers.Items.Add("[GROUP CHAT]");

                            string users =
                                msg.Split('|')[1];

                            string[] list =
                                users.Split(
                                    ',');

                            foreach (
                                string user in list)
                            {
                                if (user != "" &&
                                    user != txtUser.Text)
                                {
                                    lstUsers.Items
                                        .Add(user);
                                }
                            }
                        }

                        else if (
                            msg.StartsWith(
                            "MSG|"))
                        {
                            string[] p =
                                    msg.Split(
                                        '|',
                                        3);

                            rtbChat.AppendText(
                                p[1] +
                                ": " +
                                p[2] +
                                "\n");
                        }

                        else if (
                            msg.StartsWith(
                            "PM|"))
                        {
                            string[] p =
                                msg.Split('|');

                            rtbChat.AppendText(
                                "[PRIVATE] "
                                + p[1]
                                + ": "
                                + p[2]
                                + "\n");
                        }
                        else if (
                            msg.StartsWith(
                            "IMG|"))

                        {

                            string[] p =
                                msg.Split('|');

                            string senderName =
                                p[1];
                            byte[] imageBytes =
                                Convert.FromBase64String(
                                    p[2]);

                            MemoryStream ms =
                                new MemoryStream(
                                    imageBytes);

                            Image img =
                                Image.FromStream(ms);

                            Clipboard.SetImage(img);

                            rtbChat.AppendText(
                                senderName +
                                " sent an image:\n");

                            rtbChat.ReadOnly = false;

                            rtbChat.Paste();

                            rtbChat.AppendText("\n\n");

                            rtbChat.ReadOnly = true;
                        }
                        else if (
    msg.StartsWith(
    "PIMG|"))
                        {
                            string[] p =
                                msg.Split(
                                    '|',
                                    4);

                            string senderName =
                                p[1];

                            byte[] imageBytes =
                                Convert.FromBase64String(
                                    p[3]);

                            MemoryStream ms =
                                new MemoryStream(
                                    imageBytes);

                            Image img =
                                Image.FromStream(ms);

                            Clipboard.SetImage(img);

                            rtbChat.AppendText(
                                "[PRIVATE IMAGE] "
                                + senderName +
                                "\n");

                            rtbChat.ReadOnly = false;

                            rtbChat.Paste();

                            rtbChat.AppendText("\n\n");

                            rtbChat.ReadOnly = true;
                        }
                        else if (
    msg.StartsWith(
    "FILE|"))
                        {
                            string[] p =
                                msg.Split(
                                    '|',
                                    4);

                            string senderName =
                                p[1];

                            string fileName =
                                p[2];

                            string fileContent =
                                p[3];

                            string saveFolder =
    Path.Combine(
        Application.StartupPath,
        "ReceivedFiles");

                            Directory.CreateDirectory(
                                saveFolder);

                            string fullPath =
                                Path.Combine(
                                    saveFolder,
                                    fileName);

                            File.WriteAllText(
                                fullPath,
                                fileContent);

                            rtbChat.AppendText(
                                    "[FILE] " +
                                    senderName +
                                    ": " +
                                    fileName +
                                    "\n");

                        }
                        else if (
    msg.StartsWith(
    "PFILE|"))
                        {
                            rtbChat.AppendText(
    "[DEBUG] " +
    msg +
    "\n");
                            string[] p =
                                msg.Split(
                                    '|',
                                    5);

                            if (p.Length < 5)
                            {
                                rtbChat.AppendText(
                                    "[ERROR] Invalid PFILE format\n");

                                return;
                            }
                            string senderName =
                                p[1];

                            string fileName =
                                p[3];

                            string fileContent =
                                p[4];

                            string saveFolder =
                                Path.Combine(
                                    Application.StartupPath,
                                    "ReceivedFiles");

                            Directory.CreateDirectory(
                                saveFolder);

                            string fullPath =
                                Path.Combine(
                                    saveFolder,
                                    fileName);

                            File.WriteAllText(
                                fullPath,
                                fileContent);

                            rtbChat.AppendText(
                                "[PRIVATE FILE] "
                                + senderName +
                                " sent "
                                + fileName +
                                "\n");
                        }

                        else if (
                            msg.StartsWith(
                            "SYSTEM|"))
                        {
                            string[] p =
                                msg.Split('|');

                            rtbChat.AppendText(
                                "[SYSTEM] "
                                + p[1]
                                + "\n");
                        }
                    }));
                    }
                }
            }
            catch
            {
            }
        }

        private void lstUsers_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (lstUsers.SelectedItem == null)
                return;

            string user =
                lstUsers.SelectedItem.ToString();

            if (user == "[GROUP CHAT]")
            {
                isPrivateChat = false;
                selectedUser = "";
                Text = "Group Chat";
            }
            else
            {
                isPrivateChat = true;
                selectedUser = user;
                Text = "Chat with: " + user;
            }
        }

        private void FormClient06_Load(
            object sender,
            EventArgs e)
        {
        }
        private void btnFile_Click(
    object sender,
    EventArgs e)
        {
            try
            {
                OpenFileDialog ofd =
                    new OpenFileDialog();

                ofd.Filter =
                    "Text Files|*.txt";

                if (ofd.ShowDialog()
                    == DialogResult.OK)
                {
                    string fileName =
    Path.GetFileName(
        ofd.FileName);
                    string filename =
                        Path.GetFileName(
                            ofd.FileName);

                    string content =
                        File.ReadAllText(
                            ofd.FileName);

                    string msg;

                    if (isPrivateChat)
                    {
                        msg =
                            "PFILE|" +
                            txtUser.Text +
                            "|" +
                            selectedUser +
                            "|" +
                            fileName +
                            "|" +
                            content;
                    }
                    else
                    {


                        if (isPrivateChat)
                        {
                            msg =
                                "PFILE|" +
                                txtUser.Text +
                                "|" +
                                selectedUser +
                                "|" +
                                fileName +
                                "|" +
                                content;
                        }
                        else
                        {
                            msg =
                                "FILE|" +
                                txtUser.Text +
                                "|" +
                                fileName +
                                "|" +
                                content;
                        }
                    }

                    byte[] data =
                        Encoding.UTF8.GetBytes(
                            msg);

                    client.GetStream()
                          .Write(
                              data,
                              0,
                              data.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

    }
}