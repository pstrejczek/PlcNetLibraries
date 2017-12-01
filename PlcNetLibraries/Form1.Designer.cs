namespace PlcNetLibraries
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cLibrarySelect = new System.Windows.Forms.ComboBox();
            this.libraryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bDisconnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lCState = new System.Windows.Forms.Label();
            this.bConnect = new System.Windows.Forms.Button();
            this.tSlot = new System.Windows.Forms.TextBox();
            this.tRack = new System.Windows.Forms.TextBox();
            this.tIpAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bStop = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.tCurrentValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bSet = new System.Windows.Forms.Button();
            this.tSetPoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.libraryBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.bDisconnect);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.bConnect);
            this.groupBox1.Controls.Add(this.tSlot);
            this.groupBox1.Controls.Add(this.tRack);
            this.groupBox1.Controls.Add(this.tIpAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(842, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cLibrarySelect);
            this.groupBox4.Location = new System.Drawing.Point(416, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(373, 52);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Library";
            // 
            // cLibrarySelect
            // 
            this.cLibrarySelect.DataSource = this.libraryBindingSource;
            this.cLibrarySelect.DisplayMember = "Name";
            this.cLibrarySelect.FormattingEnabled = true;
            this.cLibrarySelect.Location = new System.Drawing.Point(20, 19);
            this.cLibrarySelect.Name = "cLibrarySelect";
            this.cLibrarySelect.Size = new System.Drawing.Size(337, 21);
            this.cLibrarySelect.TabIndex = 0;
            this.cLibrarySelect.ValueMember = "Id";
            // 
            // libraryBindingSource
            // 
            this.libraryBindingSource.DataSource = typeof(PlcNetLibraries.Library);
            // 
            // bDisconnect
            // 
            this.bDisconnect.Location = new System.Drawing.Point(106, 145);
            this.bDisconnect.Name = "bDisconnect";
            this.bDisconnect.Size = new System.Drawing.Size(146, 23);
            this.bDisconnect.TabIndex = 8;
            this.bDisconnect.Text = "DISCONNECT";
            this.bDisconnect.UseVisualStyleBackColor = true;
            this.bDisconnect.Click += new System.EventHandler(this.bDisconnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lCState);
            this.groupBox2.Location = new System.Drawing.Point(416, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection state";
            // 
            // lCState
            // 
            this.lCState.AutoSize = true;
            this.lCState.BackColor = System.Drawing.Color.Red;
            this.lCState.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lCState.ForeColor = System.Drawing.Color.White;
            this.lCState.Location = new System.Drawing.Point(15, 31);
            this.lCState.Name = "lCState";
            this.lCState.Size = new System.Drawing.Size(344, 42);
            this.lCState.TabIndex = 0;
            this.lCState.Text = "NOT CONNECTED";
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(106, 116);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(146, 23);
            this.bConnect.TabIndex = 6;
            this.bConnect.Text = "CONNECT";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // tSlot
            // 
            this.tSlot.Location = new System.Drawing.Point(106, 90);
            this.tSlot.Name = "tSlot";
            this.tSlot.Size = new System.Drawing.Size(146, 20);
            this.tSlot.TabIndex = 5;
            this.tSlot.Validating += new System.ComponentModel.CancelEventHandler(this.tSlot_Validating);
            // 
            // tRack
            // 
            this.tRack.Location = new System.Drawing.Point(106, 59);
            this.tRack.Name = "tRack";
            this.tRack.Size = new System.Drawing.Size(146, 20);
            this.tRack.TabIndex = 4;
            this.tRack.Validating += new System.ComponentModel.CancelEventHandler(this.tRack_Validating);
            // 
            // tIpAddress
            // 
            this.tIpAddress.Location = new System.Drawing.Point(106, 28);
            this.tIpAddress.Name = "tIpAddress";
            this.tIpAddress.Size = new System.Drawing.Size(146, 20);
            this.tIpAddress.TabIndex = 3;
            this.tIpAddress.Validating += new System.ComponentModel.CancelEventHandler(this.tIpAddress_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Slot:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rack:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bStop);
            this.groupBox3.Controls.Add(this.bStart);
            this.groupBox3.Controls.Add(this.tCurrentValue);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.bSet);
            this.groupBox3.Controls.Add(this.tSetPoint);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(842, 222);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Exchange";
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(329, 162);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(146, 23);
            this.bStop.TabIndex = 13;
            this.bStop.Text = "STOP";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(329, 133);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(146, 23);
            this.bStart.TabIndex = 12;
            this.bStart.Text = "START";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // tCurrentValue
            // 
            this.tCurrentValue.Location = new System.Drawing.Point(329, 85);
            this.tCurrentValue.Name = "tCurrentValue";
            this.tCurrentValue.ReadOnly = true;
            this.tCurrentValue.Size = new System.Drawing.Size(146, 20);
            this.tCurrentValue.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Current Value:";
            // 
            // bSet
            // 
            this.bSet.Location = new System.Drawing.Point(481, 36);
            this.bSet.Name = "bSet";
            this.bSet.Size = new System.Drawing.Size(68, 23);
            this.bSet.TabIndex = 8;
            this.bSet.Text = "SET";
            this.bSet.UseVisualStyleBackColor = true;
            this.bSet.Click += new System.EventHandler(this.bSet_Click);
            // 
            // tSetPoint
            // 
            this.tSetPoint.Location = new System.Drawing.Point(329, 37);
            this.tSetPoint.Name = "tSetPoint";
            this.tSetPoint.Size = new System.Drawing.Size(146, 20);
            this.tSetPoint.TabIndex = 9;
            this.tSetPoint.Validating += new System.ComponentModel.CancelEventHandler(this.tSetPoint_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Set Point:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(329, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 11;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 425);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "PlcNetLibraries";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.libraryBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lCState;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.TextBox tSlot;
        private System.Windows.Forms.TextBox tRack;
        private System.Windows.Forms.TextBox tIpAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bSet;
        private System.Windows.Forms.TextBox tSetPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bDisconnect;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cLibrarySelect;
        private System.Windows.Forms.BindingSource libraryBindingSource;
        private System.Windows.Forms.TextBox tCurrentValue;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

