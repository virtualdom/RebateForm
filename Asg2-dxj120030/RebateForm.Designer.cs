namespace Asg2_dxj120030
{
    partial class RebateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RebateForm));
            this.saveBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.fNameLbl = new System.Windows.Forms.Label();
            this.fName = new System.Windows.Forms.TextBox();
            this.mInitLbl = new System.Windows.Forms.Label();
            this.mInit = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.TextBox();
            this.lNameLbl = new System.Windows.Forms.Label();
            this.addr1Lbl = new System.Windows.Forms.Label();
            this.addr1 = new System.Windows.Forms.TextBox();
            this.addr2Lbl = new System.Windows.Forms.Label();
            this.addr2 = new System.Windows.Forms.TextBox();
            this.cityLbl = new System.Windows.Forms.Label();
            this.city = new System.Windows.Forms.TextBox();
            this.stateLbl = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.TextBox();
            this.zipLbl = new System.Windows.Forms.Label();
            this.zip = new System.Windows.Forms.TextBox();
            this.phoneLbl = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.emailLbl = new System.Windows.Forms.Label();
            this.proofIncluded = new System.Windows.Forms.CheckBox();
            this.dateReceived = new System.Windows.Forms.DateTimePicker();
            this.dateReceivedLbl = new System.Windows.Forms.Label();
            this.rebateListLbl = new System.Windows.Forms.Label();
            this.rebateList = new System.Windows.Forms.ListView();
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phoneCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clearBtn = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.GroupBox();
            this.addressBox = new System.Windows.Forms.GroupBox();
            this.contactInfo = new System.Windows.Forms.GroupBox();
            this.rebateInformation = new System.Windows.Forms.GroupBox();
            this.nameBox.SuspendLayout();
            this.addressBox.SuspendLayout();
            this.contactInfo.SuspendLayout();
            this.rebateInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(707, 541);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 12;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(788, 541);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 13;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // fNameLbl
            // 
            this.fNameLbl.AutoSize = true;
            this.fNameLbl.Location = new System.Drawing.Point(11, 24);
            this.fNameLbl.Name = "fNameLbl";
            this.fNameLbl.Size = new System.Drawing.Size(57, 13);
            this.fNameLbl.TabIndex = 3;
            this.fNameLbl.Text = "First Name";
            // 
            // fName
            // 
            this.fName.Location = new System.Drawing.Point(14, 43);
            this.fName.MaxLength = 20;
            this.fName.MinimumSize = new System.Drawing.Size(20, 4);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(226, 20);
            this.fName.TabIndex = 0;
            this.fName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimer);
            this.fName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enableSaveButton);
            this.fName.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // mInitLbl
            // 
            this.mInitLbl.AutoSize = true;
            this.mInitLbl.Location = new System.Drawing.Point(242, 27);
            this.mInitLbl.Name = "mInitLbl";
            this.mInitLbl.Size = new System.Drawing.Size(55, 13);
            this.mInitLbl.TabIndex = 16;
            this.mInitLbl.Text = "Middle Init";
            // 
            // mInit
            // 
            this.mInit.Location = new System.Drawing.Point(255, 43);
            this.mInit.MaxLength = 1;
            this.mInit.Name = "mInit";
            this.mInit.Size = new System.Drawing.Size(27, 20);
            this.mInit.TabIndex = 1;
            this.mInit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimer);
            this.mInit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enableSaveButton);
            this.mInit.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // lName
            // 
            this.lName.Location = new System.Drawing.Point(302, 43);
            this.lName.MaxLength = 20;
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(226, 20);
            this.lName.TabIndex = 2;
            this.lName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimer);
            this.lName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enableSaveButton);
            this.lName.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // lNameLbl
            // 
            this.lNameLbl.AutoSize = true;
            this.lNameLbl.Location = new System.Drawing.Point(299, 27);
            this.lNameLbl.Name = "lNameLbl";
            this.lNameLbl.Size = new System.Drawing.Size(58, 13);
            this.lNameLbl.TabIndex = 19;
            this.lNameLbl.Text = "Last Name";
            // 
            // addr1Lbl
            // 
            this.addr1Lbl.AutoSize = true;
            this.addr1Lbl.Location = new System.Drawing.Point(8, 25);
            this.addr1Lbl.Name = "addr1Lbl";
            this.addr1Lbl.Size = new System.Drawing.Size(77, 13);
            this.addr1Lbl.TabIndex = 20;
            this.addr1Lbl.Text = "Address Line 1";
            // 
            // addr1
            // 
            this.addr1.Location = new System.Drawing.Point(11, 41);
            this.addr1.MaxLength = 35;
            this.addr1.Name = "addr1";
            this.addr1.Size = new System.Drawing.Size(514, 20);
            this.addr1.TabIndex = 3;
            this.addr1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimer);
            this.addr1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enableSaveButton);
            this.addr1.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // addr2Lbl
            // 
            this.addr2Lbl.AutoSize = true;
            this.addr2Lbl.Location = new System.Drawing.Point(8, 73);
            this.addr2Lbl.Name = "addr2Lbl";
            this.addr2Lbl.Size = new System.Drawing.Size(74, 13);
            this.addr2Lbl.TabIndex = 22;
            this.addr2Lbl.Text = "Address Line2";
            // 
            // addr2
            // 
            this.addr2.Location = new System.Drawing.Point(11, 89);
            this.addr2.MaxLength = 35;
            this.addr2.Name = "addr2";
            this.addr2.Size = new System.Drawing.Size(514, 20);
            this.addr2.TabIndex = 4;
            this.addr2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimer);
            this.addr2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enableSaveButton);
            this.addr2.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // cityLbl
            // 
            this.cityLbl.AutoSize = true;
            this.cityLbl.Location = new System.Drawing.Point(8, 121);
            this.cityLbl.Name = "cityLbl";
            this.cityLbl.Size = new System.Drawing.Size(24, 13);
            this.cityLbl.TabIndex = 24;
            this.cityLbl.Text = "City";
            // 
            // city
            // 
            this.city.Location = new System.Drawing.Point(11, 137);
            this.city.MaxLength = 25;
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(306, 20);
            this.city.TabIndex = 5;
            this.city.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimer);
            this.city.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enableSaveButton);
            this.city.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // stateLbl
            // 
            this.stateLbl.AutoSize = true;
            this.stateLbl.Location = new System.Drawing.Point(323, 121);
            this.stateLbl.Name = "stateLbl";
            this.stateLbl.Size = new System.Drawing.Size(32, 13);
            this.stateLbl.TabIndex = 26;
            this.stateLbl.Text = "State";
            this.stateLbl.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // state
            // 
            this.state.Location = new System.Drawing.Point(326, 137);
            this.state.MaxLength = 2;
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(29, 20);
            this.state.TabIndex = 6;
            this.state.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimer);
            this.state.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enableSaveButton);
            this.state.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // zipLbl
            // 
            this.zipLbl.AutoSize = true;
            this.zipLbl.Location = new System.Drawing.Point(361, 121);
            this.zipLbl.Name = "zipLbl";
            this.zipLbl.Size = new System.Drawing.Size(50, 13);
            this.zipLbl.TabIndex = 28;
            this.zipLbl.Text = "Zip Code";
            this.zipLbl.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // zip
            // 
            this.zip.Location = new System.Drawing.Point(364, 137);
            this.zip.MaxLength = 9;
            this.zip.Name = "zip";
            this.zip.Size = new System.Drawing.Size(161, 20);
            this.zip.TabIndex = 7;
            this.zip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimer);
            this.zip.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enableSaveButton);
            this.zip.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // phoneLbl
            // 
            this.phoneLbl.AutoSize = true;
            this.phoneLbl.Location = new System.Drawing.Point(8, 67);
            this.phoneLbl.Name = "phoneLbl";
            this.phoneLbl.Size = new System.Drawing.Size(78, 13);
            this.phoneLbl.TabIndex = 30;
            this.phoneLbl.Text = "Phone Number";
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(11, 83);
            this.phone.MaxLength = 21;
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(240, 20);
            this.phone.TabIndex = 9;
            this.phone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimer);
            this.phone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enableSaveButton);
            this.phone.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(11, 40);
            this.email.MaxLength = 60;
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(514, 20);
            this.email.TabIndex = 8;
            this.email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimer);
            this.email.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enableSaveButton);
            this.email.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Location = new System.Drawing.Point(8, 24);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(32, 13);
            this.emailLbl.TabIndex = 33;
            this.emailLbl.Text = "Email";
            // 
            // proofIncluded
            // 
            this.proofIncluded.AutoSize = true;
            this.proofIncluded.Location = new System.Drawing.Point(300, 43);
            this.proofIncluded.Name = "proofIncluded";
            this.proofIncluded.Size = new System.Drawing.Size(143, 17);
            this.proofIncluded.TabIndex = 11;
            this.proofIncluded.Text = "Purchase Proof Included";
            this.proofIncluded.UseVisualStyleBackColor = true;
            this.proofIncluded.CheckedChanged += new System.EventHandler(this.startTimer);
            this.proofIncluded.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // dateReceived
            // 
            this.dateReceived.Location = new System.Drawing.Point(10, 43);
            this.dateReceived.MaxDate = new System.DateTime(2017, 1, 29, 0, 0, 0, 0);
            this.dateReceived.Name = "dateReceived";
            this.dateReceived.Size = new System.Drawing.Size(197, 20);
            this.dateReceived.TabIndex = 10;
            this.dateReceived.Value = new System.DateTime(2017, 1, 29, 0, 0, 0, 0);
            this.dateReceived.ValueChanged += new System.EventHandler(this.startTimer);
            this.dateReceived.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimer);
            this.dateReceived.Leave += new System.EventHandler(this.enableSaveButton);
            // 
            // dateReceivedLbl
            // 
            this.dateReceivedLbl.AutoSize = true;
            this.dateReceivedLbl.Location = new System.Drawing.Point(7, 27);
            this.dateReceivedLbl.Name = "dateReceivedLbl";
            this.dateReceivedLbl.Size = new System.Drawing.Size(79, 13);
            this.dateReceivedLbl.TabIndex = 35;
            this.dateReceivedLbl.Text = "Date Received";
            // 
            // rebateListLbl
            // 
            this.rebateListLbl.AutoSize = true;
            this.rebateListLbl.Location = new System.Drawing.Point(9, 10);
            this.rebateListLbl.Name = "rebateListLbl";
            this.rebateListLbl.Size = new System.Drawing.Size(70, 13);
            this.rebateListLbl.TabIndex = 36;
            this.rebateListLbl.Text = "Customer List";
            // 
            // rebateList
            // 
            this.rebateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCol,
            this.phoneCol});
            this.rebateList.FullRowSelect = true;
            this.rebateList.HideSelection = false;
            this.rebateList.Location = new System.Drawing.Point(12, 26);
            this.rebateList.MultiSelect = false;
            this.rebateList.Name = "rebateList";
            this.rebateList.Size = new System.Drawing.Size(398, 538);
            this.rebateList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.rebateList.TabIndex = 15;
            this.rebateList.UseCompatibleStateImageBehavior = false;
            this.rebateList.View = System.Windows.Forms.View.Details;
            this.rebateList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.rebateList_ColumnClick);
            this.rebateList.SelectedIndexChanged += new System.EventHandler(this.rebateList_SelectedIndexChanged);
            // 
            // nameCol
            // 
            this.nameCol.Text = "Name";
            this.nameCol.Width = 200;
            // 
            // phoneCol
            // 
            this.phoneCol.Text = "Phone";
            this.phoneCol.Width = 150;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(869, 541);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 14;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // nameBox
            // 
            this.nameBox.Controls.Add(this.fName);
            this.nameBox.Controls.Add(this.fNameLbl);
            this.nameBox.Controls.Add(this.mInitLbl);
            this.nameBox.Controls.Add(this.mInit);
            this.nameBox.Controls.Add(this.lName);
            this.nameBox.Controls.Add(this.lNameLbl);
            this.nameBox.Location = new System.Drawing.Point(416, 26);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(536, 74);
            this.nameBox.TabIndex = 0;
            this.nameBox.TabStop = false;
            this.nameBox.Text = "Customer Name";
            // 
            // addressBox
            // 
            this.addressBox.Controls.Add(this.zip);
            this.addressBox.Controls.Add(this.zipLbl);
            this.addressBox.Controls.Add(this.state);
            this.addressBox.Controls.Add(this.stateLbl);
            this.addressBox.Controls.Add(this.city);
            this.addressBox.Controls.Add(this.cityLbl);
            this.addressBox.Controls.Add(this.addr2);
            this.addressBox.Controls.Add(this.addr2Lbl);
            this.addressBox.Controls.Add(this.addr1);
            this.addressBox.Controls.Add(this.addr1Lbl);
            this.addressBox.Location = new System.Drawing.Point(419, 106);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(532, 169);
            this.addressBox.TabIndex = 3;
            this.addressBox.TabStop = false;
            this.addressBox.Text = "Address Information";
            // 
            // contactInfo
            // 
            this.contactInfo.Controls.Add(this.emailLbl);
            this.contactInfo.Controls.Add(this.email);
            this.contactInfo.Controls.Add(this.phone);
            this.contactInfo.Controls.Add(this.phoneLbl);
            this.contactInfo.Location = new System.Drawing.Point(419, 290);
            this.contactInfo.Name = "contactInfo";
            this.contactInfo.Size = new System.Drawing.Size(532, 119);
            this.contactInfo.TabIndex = 8;
            this.contactInfo.TabStop = false;
            this.contactInfo.Text = "Contact Information";
            // 
            // rebateInformation
            // 
            this.rebateInformation.Controls.Add(this.dateReceivedLbl);
            this.rebateInformation.Controls.Add(this.dateReceived);
            this.rebateInformation.Controls.Add(this.proofIncluded);
            this.rebateInformation.Location = new System.Drawing.Point(420, 428);
            this.rebateInformation.Name = "rebateInformation";
            this.rebateInformation.Size = new System.Drawing.Size(532, 76);
            this.rebateInformation.TabIndex = 10;
            this.rebateInformation.TabStop = false;
            this.rebateInformation.Text = "Rebate Information";
            // 
            // RebateForm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 574);
            this.Controls.Add(this.rebateInformation);
            this.Controls.Add(this.contactInfo);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.rebateList);
            this.Controls.Add(this.rebateListLbl);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.nameBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RebateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rebate Form";
            this.Load += new System.EventHandler(this.RebateForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enableSaveButton);
            this.nameBox.ResumeLayout(false);
            this.nameBox.PerformLayout();
            this.addressBox.ResumeLayout(false);
            this.addressBox.PerformLayout();
            this.contactInfo.ResumeLayout(false);
            this.contactInfo.PerformLayout();
            this.rebateInformation.ResumeLayout(false);
            this.rebateInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label fNameLbl;
        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.Label mInitLbl;
        private System.Windows.Forms.TextBox mInit;
        private System.Windows.Forms.TextBox lName;
        private System.Windows.Forms.Label lNameLbl;
        private System.Windows.Forms.Label addr1Lbl;
        private System.Windows.Forms.TextBox addr1;
        private System.Windows.Forms.Label addr2Lbl;
        private System.Windows.Forms.TextBox addr2;
        private System.Windows.Forms.Label cityLbl;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.Label stateLbl;
        private System.Windows.Forms.TextBox state;
        private System.Windows.Forms.Label zipLbl;
        private System.Windows.Forms.TextBox zip;
        private System.Windows.Forms.Label phoneLbl;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.CheckBox proofIncluded;
        private System.Windows.Forms.DateTimePicker dateReceived;
        private System.Windows.Forms.Label dateReceivedLbl;
        private System.Windows.Forms.Label rebateListLbl;
        private System.Windows.Forms.ListView rebateList;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ColumnHeader phoneCol;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.GroupBox nameBox;
        private System.Windows.Forms.GroupBox addressBox;
        private System.Windows.Forms.GroupBox contactInfo;
        private System.Windows.Forms.GroupBox rebateInformation;
    }
}

