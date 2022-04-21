namespace oracleDB
{
    partial class MainForm
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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.goodsPage = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dateFromTextBox = new System.Windows.Forms.TextBox();
            this.dateToTextBox = new System.Windows.Forms.TextBox();
            this.id2TextBox = new System.Windows.Forms.TextBox();
            this.id1TextBox = new System.Windows.Forms.TextBox();
            this.grownButton = new System.Windows.Forms.Button();
            this.demandButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.priorityTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.goodsGridView = new System.Windows.Forms.DataGridView();
            this.salesPage = new System.Windows.Forms.TabPage();
            this.transportButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.salesId = new System.Windows.Forms.TextBox();
            this.salesCreateDate = new System.Windows.Forms.TextBox();
            this.salesGoodCount = new System.Windows.Forms.TextBox();
            this.salesGoodId = new System.Windows.Forms.TextBox();
            this.salesGridView = new System.Windows.Forms.DataGridView();
            this.warehouse1Page = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ware1Id = new System.Windows.Forms.TextBox();
            this.ware1GoodCount = new System.Windows.Forms.TextBox();
            this.ware1GoodId = new System.Windows.Forms.TextBox();
            this.warehouse1GridView = new System.Windows.Forms.DataGridView();
            this.warehouse2Page = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ware2Id = new System.Windows.Forms.TextBox();
            this.ware2GoodCount = new System.Windows.Forms.TextBox();
            this.ware2GoodId = new System.Windows.Forms.TextBox();
            this.warehouse2GridView = new System.Windows.Forms.DataGridView();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.viewComboBox = new System.Windows.Forms.ComboBox();
            this.watchViewButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.idFindTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.idFindButton = new System.Windows.Forms.Button();
            this.mainTabControl.SuspendLayout();
            this.goodsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goodsGridView)).BeginInit();
            this.salesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesGridView)).BeginInit();
            this.warehouse1Page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warehouse1GridView)).BeginInit();
            this.warehouse2Page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warehouse2GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.goodsPage);
            this.mainTabControl.Controls.Add(this.salesPage);
            this.mainTabControl.Controls.Add(this.warehouse1Page);
            this.mainTabControl.Controls.Add(this.warehouse2Page);
            this.mainTabControl.Location = new System.Drawing.Point(12, 12);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(776, 505);
            this.mainTabControl.TabIndex = 0;
            // 
            // goodsPage
            // 
            this.goodsPage.Controls.Add(this.label17);
            this.goodsPage.Controls.Add(this.label16);
            this.goodsPage.Controls.Add(this.label15);
            this.goodsPage.Controls.Add(this.label14);
            this.goodsPage.Controls.Add(this.dateFromTextBox);
            this.goodsPage.Controls.Add(this.dateToTextBox);
            this.goodsPage.Controls.Add(this.id2TextBox);
            this.goodsPage.Controls.Add(this.id1TextBox);
            this.goodsPage.Controls.Add(this.grownButton);
            this.goodsPage.Controls.Add(this.demandButton);
            this.goodsPage.Controls.Add(this.label3);
            this.goodsPage.Controls.Add(this.idTextBox);
            this.goodsPage.Controls.Add(this.label2);
            this.goodsPage.Controls.Add(this.label1);
            this.goodsPage.Controls.Add(this.priorityTextBox);
            this.goodsPage.Controls.Add(this.nameTextBox);
            this.goodsPage.Controls.Add(this.goodsGridView);
            this.goodsPage.Location = new System.Drawing.Point(4, 22);
            this.goodsPage.Name = "goodsPage";
            this.goodsPage.Padding = new System.Windows.Forms.Padding(3);
            this.goodsPage.Size = new System.Drawing.Size(768, 479);
            this.goodsPage.TabIndex = 0;
            this.goodsPage.Text = "Goods";
            this.goodsPage.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(595, 428);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Date To:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(493, 428);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "Date From:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(592, 385);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "ID 2:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(493, 386);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "ID 1:";
            // 
            // dateFromTextBox
            // 
            this.dateFromTextBox.Location = new System.Drawing.Point(493, 444);
            this.dateFromTextBox.Name = "dateFromTextBox";
            this.dateFromTextBox.Size = new System.Drawing.Size(93, 20);
            this.dateFromTextBox.TabIndex = 12;
            // 
            // dateToTextBox
            // 
            this.dateToTextBox.Location = new System.Drawing.Point(593, 444);
            this.dateToTextBox.Name = "dateToTextBox";
            this.dateToTextBox.Size = new System.Drawing.Size(93, 20);
            this.dateToTextBox.TabIndex = 11;
            // 
            // id2TextBox
            // 
            this.id2TextBox.Location = new System.Drawing.Point(592, 402);
            this.id2TextBox.Name = "id2TextBox";
            this.id2TextBox.Size = new System.Drawing.Size(93, 20);
            this.id2TextBox.TabIndex = 10;
            // 
            // id1TextBox
            // 
            this.id1TextBox.Location = new System.Drawing.Point(493, 402);
            this.id1TextBox.Name = "id1TextBox";
            this.id1TextBox.Size = new System.Drawing.Size(93, 20);
            this.id1TextBox.TabIndex = 9;
            // 
            // grownButton
            // 
            this.grownButton.Location = new System.Drawing.Point(687, 442);
            this.grownButton.Name = "grownButton";
            this.grownButton.Size = new System.Drawing.Size(75, 23);
            this.grownButton.TabIndex = 8;
            this.grownButton.Text = "Grown";
            this.grownButton.UseVisualStyleBackColor = true;
            this.grownButton.Click += new System.EventHandler(this.grownButton_Click);
            // 
            // demandButton
            // 
            this.demandButton.Location = new System.Drawing.Point(687, 400);
            this.demandButton.Name = "demandButton";
            this.demandButton.Size = new System.Drawing.Size(75, 23);
            this.demandButton.TabIndex = 7;
            this.demandButton.Text = "Demand";
            this.demandButton.UseVisualStyleBackColor = true;
            this.demandButton.Click += new System.EventHandler(this.demandButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID:";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(255, 402);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(170, 20);
            this.idTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Priority:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // priorityTextBox
            // 
            this.priorityTextBox.Location = new System.Drawing.Point(7, 445);
            this.priorityTextBox.Name = "priorityTextBox";
            this.priorityTextBox.Size = new System.Drawing.Size(170, 20);
            this.priorityTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(7, 402);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(170, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // goodsGridView
            // 
            this.goodsGridView.AllowUserToAddRows = false;
            this.goodsGridView.AllowUserToDeleteRows = false;
            this.goodsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.goodsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.goodsGridView.Location = new System.Drawing.Point(6, 6);
            this.goodsGridView.Name = "goodsGridView";
            this.goodsGridView.ReadOnly = true;
            this.goodsGridView.Size = new System.Drawing.Size(756, 377);
            this.goodsGridView.TabIndex = 0;
            // 
            // salesPage
            // 
            this.salesPage.Controls.Add(this.transportButton);
            this.salesPage.Controls.Add(this.label7);
            this.salesPage.Controls.Add(this.label6);
            this.salesPage.Controls.Add(this.label5);
            this.salesPage.Controls.Add(this.label4);
            this.salesPage.Controls.Add(this.salesId);
            this.salesPage.Controls.Add(this.salesCreateDate);
            this.salesPage.Controls.Add(this.salesGoodCount);
            this.salesPage.Controls.Add(this.salesGoodId);
            this.salesPage.Controls.Add(this.salesGridView);
            this.salesPage.Location = new System.Drawing.Point(4, 22);
            this.salesPage.Name = "salesPage";
            this.salesPage.Padding = new System.Windows.Forms.Padding(3);
            this.salesPage.Size = new System.Drawing.Size(768, 479);
            this.salesPage.TabIndex = 1;
            this.salesPage.Text = "Sales";
            this.salesPage.UseVisualStyleBackColor = true;
            // 
            // transportButton
            // 
            this.transportButton.Location = new System.Drawing.Point(611, 400);
            this.transportButton.Name = "transportButton";
            this.transportButton.Size = new System.Drawing.Size(75, 23);
            this.transportButton.TabIndex = 9;
            this.transportButton.Text = "Transport";
            this.transportButton.UseVisualStyleBackColor = true;
            this.transportButton.Click += new System.EventHandler(this.transportButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(255, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Create Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Good Count:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 386);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Good ID:";
            // 
            // salesId
            // 
            this.salesId.Location = new System.Drawing.Point(255, 445);
            this.salesId.Name = "salesId";
            this.salesId.Size = new System.Drawing.Size(170, 20);
            this.salesId.TabIndex = 4;
            // 
            // salesCreateDate
            // 
            this.salesCreateDate.Location = new System.Drawing.Point(255, 402);
            this.salesCreateDate.Name = "salesCreateDate";
            this.salesCreateDate.Size = new System.Drawing.Size(170, 20);
            this.salesCreateDate.TabIndex = 3;
            // 
            // salesGoodCount
            // 
            this.salesGoodCount.Location = new System.Drawing.Point(7, 445);
            this.salesGoodCount.Name = "salesGoodCount";
            this.salesGoodCount.Size = new System.Drawing.Size(170, 20);
            this.salesGoodCount.TabIndex = 2;
            // 
            // salesGoodId
            // 
            this.salesGoodId.Location = new System.Drawing.Point(7, 402);
            this.salesGoodId.Name = "salesGoodId";
            this.salesGoodId.Size = new System.Drawing.Size(170, 20);
            this.salesGoodId.TabIndex = 1;
            // 
            // salesGridView
            // 
            this.salesGridView.AllowUserToAddRows = false;
            this.salesGridView.AllowUserToDeleteRows = false;
            this.salesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.salesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salesGridView.Location = new System.Drawing.Point(6, 6);
            this.salesGridView.Name = "salesGridView";
            this.salesGridView.ReadOnly = true;
            this.salesGridView.Size = new System.Drawing.Size(756, 377);
            this.salesGridView.TabIndex = 0;
            // 
            // warehouse1Page
            // 
            this.warehouse1Page.Controls.Add(this.label10);
            this.warehouse1Page.Controls.Add(this.label9);
            this.warehouse1Page.Controls.Add(this.label8);
            this.warehouse1Page.Controls.Add(this.ware1Id);
            this.warehouse1Page.Controls.Add(this.ware1GoodCount);
            this.warehouse1Page.Controls.Add(this.ware1GoodId);
            this.warehouse1Page.Controls.Add(this.warehouse1GridView);
            this.warehouse1Page.Location = new System.Drawing.Point(4, 22);
            this.warehouse1Page.Name = "warehouse1Page";
            this.warehouse1Page.Padding = new System.Windows.Forms.Padding(3);
            this.warehouse1Page.Size = new System.Drawing.Size(768, 479);
            this.warehouse1Page.TabIndex = 2;
            this.warehouse1Page.Text = "WareHouse1";
            this.warehouse1Page.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(255, 386);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 429);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Good Count:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Good ID:";
            // 
            // ware1Id
            // 
            this.ware1Id.Location = new System.Drawing.Point(255, 402);
            this.ware1Id.Name = "ware1Id";
            this.ware1Id.Size = new System.Drawing.Size(170, 20);
            this.ware1Id.TabIndex = 3;
            // 
            // ware1GoodCount
            // 
            this.ware1GoodCount.Location = new System.Drawing.Point(7, 445);
            this.ware1GoodCount.Name = "ware1GoodCount";
            this.ware1GoodCount.Size = new System.Drawing.Size(170, 20);
            this.ware1GoodCount.TabIndex = 2;
            // 
            // ware1GoodId
            // 
            this.ware1GoodId.Location = new System.Drawing.Point(7, 402);
            this.ware1GoodId.Name = "ware1GoodId";
            this.ware1GoodId.Size = new System.Drawing.Size(170, 20);
            this.ware1GoodId.TabIndex = 1;
            // 
            // warehouse1GridView
            // 
            this.warehouse1GridView.AllowUserToAddRows = false;
            this.warehouse1GridView.AllowUserToDeleteRows = false;
            this.warehouse1GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.warehouse1GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.warehouse1GridView.Location = new System.Drawing.Point(6, 6);
            this.warehouse1GridView.Name = "warehouse1GridView";
            this.warehouse1GridView.ReadOnly = true;
            this.warehouse1GridView.Size = new System.Drawing.Size(756, 377);
            this.warehouse1GridView.TabIndex = 0;
            // 
            // warehouse2Page
            // 
            this.warehouse2Page.Controls.Add(this.label11);
            this.warehouse2Page.Controls.Add(this.label12);
            this.warehouse2Page.Controls.Add(this.label13);
            this.warehouse2Page.Controls.Add(this.ware2Id);
            this.warehouse2Page.Controls.Add(this.ware2GoodCount);
            this.warehouse2Page.Controls.Add(this.ware2GoodId);
            this.warehouse2Page.Controls.Add(this.warehouse2GridView);
            this.warehouse2Page.Location = new System.Drawing.Point(4, 22);
            this.warehouse2Page.Name = "warehouse2Page";
            this.warehouse2Page.Padding = new System.Windows.Forms.Padding(3);
            this.warehouse2Page.Size = new System.Drawing.Size(768, 479);
            this.warehouse2Page.TabIndex = 3;
            this.warehouse2Page.Text = "WareHouse2";
            this.warehouse2Page.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(255, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 429);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Good Count:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 386);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Good ID:";
            // 
            // ware2Id
            // 
            this.ware2Id.Location = new System.Drawing.Point(255, 402);
            this.ware2Id.Name = "ware2Id";
            this.ware2Id.Size = new System.Drawing.Size(170, 20);
            this.ware2Id.TabIndex = 9;
            // 
            // ware2GoodCount
            // 
            this.ware2GoodCount.Location = new System.Drawing.Point(7, 445);
            this.ware2GoodCount.Name = "ware2GoodCount";
            this.ware2GoodCount.Size = new System.Drawing.Size(170, 20);
            this.ware2GoodCount.TabIndex = 8;
            // 
            // ware2GoodId
            // 
            this.ware2GoodId.Location = new System.Drawing.Point(7, 402);
            this.ware2GoodId.Name = "ware2GoodId";
            this.ware2GoodId.Size = new System.Drawing.Size(170, 20);
            this.ware2GoodId.TabIndex = 7;
            // 
            // warehouse2GridView
            // 
            this.warehouse2GridView.AllowUserToAddRows = false;
            this.warehouse2GridView.AllowUserToDeleteRows = false;
            this.warehouse2GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.warehouse2GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.warehouse2GridView.Location = new System.Drawing.Point(6, 6);
            this.warehouse2GridView.Name = "warehouse2GridView";
            this.warehouse2GridView.ReadOnly = true;
            this.warehouse2GridView.Size = new System.Drawing.Size(756, 377);
            this.warehouse2GridView.TabIndex = 1;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(709, 523);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(627, 523);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(546, 523);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 4;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // viewComboBox
            // 
            this.viewComboBox.FormattingEnabled = true;
            this.viewComboBox.Location = new System.Drawing.Point(23, 525);
            this.viewComboBox.Name = "viewComboBox";
            this.viewComboBox.Size = new System.Drawing.Size(170, 21);
            this.viewComboBox.TabIndex = 5;
            // 
            // watchViewButton
            // 
            this.watchViewButton.Location = new System.Drawing.Point(217, 523);
            this.watchViewButton.Name = "watchViewButton";
            this.watchViewButton.Size = new System.Drawing.Size(75, 23);
            this.watchViewButton.TabIndex = 6;
            this.watchViewButton.Text = "Watch View";
            this.watchViewButton.UseVisualStyleBackColor = true;
            this.watchViewButton.Click += new System.EventHandler(this.watchViewButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Users";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // idFindTextBox
            // 
            this.idFindTextBox.Location = new System.Drawing.Point(22, 564);
            this.idFindTextBox.Name = "idFindTextBox";
            this.idFindTextBox.Size = new System.Drawing.Size(170, 20);
            this.idFindTextBox.TabIndex = 8;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 550);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "ID";
            // 
            // idFindButton
            // 
            this.idFindButton.Location = new System.Drawing.Point(217, 562);
            this.idFindButton.Name = "idFindButton";
            this.idFindButton.Size = new System.Drawing.Size(75, 23);
            this.idFindButton.TabIndex = 10;
            this.idFindButton.Text = "Find";
            this.idFindButton.UseVisualStyleBackColor = true;
            this.idFindButton.Click += new System.EventHandler(this.idFindButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 596);
            this.Controls.Add(this.idFindButton);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.idFindTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.watchViewButton);
            this.Controls.Add(this.viewComboBox);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.mainTabControl);
            this.MaximumSize = new System.Drawing.Size(816, 635);
            this.MinimumSize = new System.Drawing.Size(816, 635);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.mainTabControl.ResumeLayout(false);
            this.goodsPage.ResumeLayout(false);
            this.goodsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goodsGridView)).EndInit();
            this.salesPage.ResumeLayout(false);
            this.salesPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesGridView)).EndInit();
            this.warehouse1Page.ResumeLayout(false);
            this.warehouse1Page.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warehouse1GridView)).EndInit();
            this.warehouse2Page.ResumeLayout(false);
            this.warehouse2Page.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warehouse2GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage goodsPage;
        private System.Windows.Forms.TabPage salesPage;
        private System.Windows.Forms.DataGridView goodsGridView;
        private System.Windows.Forms.TabPage warehouse1Page;
        private System.Windows.Forms.TabPage warehouse2Page;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox priorityTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.DataGridView salesGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.DataGridView warehouse1GridView;
        private System.Windows.Forms.DataGridView warehouse2GridView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox salesId;
        private System.Windows.Forms.TextBox salesCreateDate;
        private System.Windows.Forms.TextBox salesGoodCount;
        private System.Windows.Forms.TextBox salesGoodId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ware1Id;
        private System.Windows.Forms.TextBox ware1GoodCount;
        private System.Windows.Forms.TextBox ware1GoodId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox ware2Id;
        private System.Windows.Forms.TextBox ware2GoodCount;
        private System.Windows.Forms.TextBox ware2GoodId;
        private System.Windows.Forms.ComboBox viewComboBox;
        private System.Windows.Forms.Button watchViewButton;
        private System.Windows.Forms.Button transportButton;
        private System.Windows.Forms.Button demandButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox dateFromTextBox;
        private System.Windows.Forms.TextBox dateToTextBox;
        private System.Windows.Forms.TextBox id2TextBox;
        private System.Windows.Forms.TextBox id1TextBox;
        private System.Windows.Forms.Button grownButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox idFindTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button idFindButton;
    }
}