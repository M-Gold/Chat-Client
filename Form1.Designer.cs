namespace IM_Thing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ipLocal = new System.Windows.Forms.TextBox();
            this.tb_portLocal = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ipRemote = new System.Windows.Forms.TextBox();
            this.tb_portRemote = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_messages = new System.Windows.Forms.ListBox();
            this.but_connect = new System.Windows.Forms.Button();
            this.but_Send = new System.Windows.Forms.Button();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.but_loadFriend = new System.Windows.Forms.Button();
            this.dgv_friends = new System.Windows.Forms.DataGridView();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friends)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // tb_ipLocal
            // 
            this.tb_ipLocal.Location = new System.Drawing.Point(50, 20);
            this.tb_ipLocal.Name = "tb_ipLocal";
            this.tb_ipLocal.Size = new System.Drawing.Size(100, 20);
            this.tb_ipLocal.TabIndex = 2;
            // 
            // tb_portLocal
            // 
            this.tb_portLocal.Location = new System.Drawing.Point(50, 46);
            this.tb_portLocal.Name = "tb_portLocal";
            this.tb_portLocal.Size = new System.Drawing.Size(100, 20);
            this.tb_portLocal.TabIndex = 3;
            this.tb_portLocal.Text = "1337";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_portLocal);
            this.groupBox1.Controls.Add(this.tb_ipLocal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Local";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port:";
            // 
            // tb_ipRemote
            // 
            this.tb_ipRemote.Location = new System.Drawing.Point(50, 17);
            this.tb_ipRemote.Name = "tb_ipRemote";
            this.tb_ipRemote.Size = new System.Drawing.Size(100, 20);
            this.tb_ipRemote.TabIndex = 4;
            // 
            // tb_portRemote
            // 
            this.tb_portRemote.Location = new System.Drawing.Point(50, 43);
            this.tb_portRemote.Name = "tb_portRemote";
            this.tb_portRemote.Size = new System.Drawing.Size(100, 20);
            this.tb_portRemote.TabIndex = 5;
            this.tb_portRemote.Text = "1337";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_name);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tb_portRemote);
            this.groupBox2.Controls.Add(this.tb_ipRemote);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(4, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 97);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(50, 67);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(100, 20);
            this.tb_name.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Name:";
            // 
            // lb_messages
            // 
            this.lb_messages.FormattingEnabled = true;
            this.lb_messages.HorizontalScrollbar = true;
            this.lb_messages.Location = new System.Drawing.Point(187, 8);
            this.lb_messages.Name = "lb_messages";
            this.lb_messages.Size = new System.Drawing.Size(495, 199);
            this.lb_messages.TabIndex = 2;
            // 
            // but_connect
            // 
            this.but_connect.Location = new System.Drawing.Point(4, 211);
            this.but_connect.Name = "but_connect";
            this.but_connect.Size = new System.Drawing.Size(177, 23);
            this.but_connect.TabIndex = 3;
            this.but_connect.Text = "Connect";
            this.but_connect.UseVisualStyleBackColor = true;
            this.but_connect.Click += new System.EventHandler(this.but_connect_Click);
            // 
            // but_Send
            // 
            this.but_Send.Enabled = false;
            this.but_Send.Location = new System.Drawing.Point(607, 213);
            this.but_Send.Name = "but_Send";
            this.but_Send.Size = new System.Drawing.Size(75, 20);
            this.but_Send.TabIndex = 4;
            this.but_Send.Text = "Send";
            this.but_Send.UseVisualStyleBackColor = true;
            this.but_Send.Click += new System.EventHandler(this.but_Send_Click);
            // 
            // tb_message
            // 
            this.tb_message.Location = new System.Drawing.Point(187, 213);
            this.tb_message.Multiline = true;
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(414, 20);
            this.tb_message.TabIndex = 5;
            this.tb_message.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_message_KeyUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(694, 263);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.but_connect);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.tb_message);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.but_Send);
            this.tabPage1.Controls.Add(this.lb_messages);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(686, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chat";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.dgv_friends);
            this.tabPage2.Controls.Add(this.but_loadFriend);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(686, 237);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Friends";
            // 
            // but_loadFriend
            // 
            this.but_loadFriend.Location = new System.Drawing.Point(7, 162);
            this.but_loadFriend.Name = "but_loadFriend";
            this.but_loadFriend.Size = new System.Drawing.Size(75, 23);
            this.but_loadFriend.TabIndex = 1;
            this.but_loadFriend.Text = "Load Friend";
            this.but_loadFriend.UseVisualStyleBackColor = true;
            this.but_loadFriend.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dgv_friends
            // 
            this.dgv_friends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_friends.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Name,
            this.col_IP,
            this.col_Port});
            this.dgv_friends.Location = new System.Drawing.Point(7, 6);
            this.dgv_friends.MultiSelect = false;
            this.dgv_friends.Name = "dgv_friends";
            this.dgv_friends.RowHeadersVisible = false;
            this.dgv_friends.ShowEditingIcon = false;
            this.dgv_friends.Size = new System.Drawing.Size(303, 150);
            this.dgv_friends.TabIndex = 2;
            this.dgv_friends.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgv_friends_KeyUp);
            // 
            // col_Name
            // 
            this.col_Name.HeaderText = "Name";
            this.col_Name.Name = "col_Name";
            // 
            // col_IP
            // 
            this.col_IP.HeaderText = "Address";
            this.col_IP.Name = "col_IP";
            // 
            // col_Port
            // 
            this.col_Port.HeaderText = "Port";
            this.col_Port.Name = "col_Port";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 263);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_friends)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ipLocal;
        private System.Windows.Forms.TextBox tb_portLocal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_ipRemote;
        private System.Windows.Forms.TextBox tb_portRemote;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lb_messages;
        private System.Windows.Forms.Button but_connect;
        private System.Windows.Forms.Button but_Send;
        private System.Windows.Forms.TextBox tb_message;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button but_loadFriend;
        private System.Windows.Forms.DataGridView dgv_friends;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Port;


    }
}

