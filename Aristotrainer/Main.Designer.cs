namespace Aristotrainer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.fieldDamageCap = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxKami = new System.Windows.Forms.CheckBox();
            this.checkBoxTeleport = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxNDFA = new System.Windows.Forms.CheckBox();
            this.tabBot = new System.Windows.Forms.TabPage();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxLoot = new System.Windows.Forms.CheckBox();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxMP = new System.Windows.Forms.CheckBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxHP = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.checkBoxAttack = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldDamageCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.tabBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(370, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(140, 263);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Threads:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Information:";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(6, 19);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(358, 263);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(81, 228);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.morphBox_OnValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Morph Hack:";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabInfo);
            this.tabControl2.Controls.Add(this.tabSettings);
            this.tabControl2.Controls.Add(this.tabBot);
            this.tabControl2.Location = new System.Drawing.Point(-1, 1);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(530, 338);
            this.tabControl2.TabIndex = 7;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.label5);
            this.tabInfo.Controls.Add(this.label2);
            this.tabInfo.Controls.Add(this.listView1);
            this.tabInfo.Controls.Add(this.label1);
            this.tabInfo.Controls.Add(this.listView2);
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(522, 312);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "Information";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Position: X: 0 Y: 0";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.fieldDamageCap);
            this.tabSettings.Controls.Add(this.label6);
            this.tabSettings.Controls.Add(this.listView3);
            this.tabSettings.Controls.Add(this.label8);
            this.tabSettings.Controls.Add(this.numericUpDown4);
            this.tabSettings.Controls.Add(this.checkBoxKami);
            this.tabSettings.Controls.Add(this.checkBoxTeleport);
            this.tabSettings.Controls.Add(this.comboBox1);
            this.tabSettings.Controls.Add(this.label4);
            this.tabSettings.Controls.Add(this.checkBoxNDFA);
            this.tabSettings.Controls.Add(this.label3);
            this.tabSettings.Controls.Add(this.numericUpDown1);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(522, 312);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // fieldDamageCap
            // 
            this.fieldDamageCap.Location = new System.Drawing.Point(393, 277);
            this.fieldDamageCap.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.fieldDamageCap.Name = "fieldDamageCap";
            this.fieldDamageCap.Size = new System.Drawing.Size(92, 20);
            this.fieldDamageCap.TabIndex = 28;
            this.fieldDamageCap.ValueChanged += new System.EventHandler(this.fieldDamageCap_OnValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Damage Cap:";
            // 
            // listView3
            // 
            this.listView3.CheckBoxes = true;
            this.listView3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listView3.Location = new System.Drawing.Point(0, 0);
            this.listView3.MultiSelect = false;
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(522, 222);
            this.listView3.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView3.TabIndex = 26;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.List;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(367, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Delay (ms):";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(432, 251);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(53, 20);
            this.numericUpDown4.TabIndex = 24;
            this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxKami
            // 
            this.checkBoxKami.AutoSize = true;
            this.checkBoxKami.Location = new System.Drawing.Point(318, 252);
            this.checkBoxKami.Name = "checkBoxKami";
            this.checkBoxKami.Size = new System.Drawing.Size(49, 17);
            this.checkBoxKami.TabIndex = 23;
            this.checkBoxKami.Text = "Kami";
            this.checkBoxKami.UseVisualStyleBackColor = true;
            this.checkBoxKami.CheckedChanged += new System.EventHandler(this.checkBoxKami_OnCheckedChanged);
            // 
            // checkBoxTeleport
            // 
            this.checkBoxTeleport.AutoSize = true;
            this.checkBoxTeleport.Location = new System.Drawing.Point(318, 229);
            this.checkBoxTeleport.Name = "checkBoxTeleport";
            this.checkBoxTeleport.Size = new System.Drawing.Size(91, 17);
            this.checkBoxTeleport.TabIndex = 22;
            this.checkBoxTeleport.Text = "Click Teleport";
            this.checkBoxTeleport.UseVisualStyleBackColor = true;
            this.checkBoxTeleport.CheckedChanged += new System.EventHandler(this.checkBoxTeleport_OnCheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Wind Archer #13101002",
            "Wild Hunter #33100009",
            "Mercedes #23100006",
            "Evan(Final Spark) #22150004",
            "Aran #21100010",
            "Mihile #51100002",
            "BaM #32111010"});
            this.comboBox1.Location = new System.Drawing.Point(39, 271);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_OnSelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Job:";
            // 
            // checkBoxNDFA
            // 
            this.checkBoxNDFA.AutoSize = true;
            this.checkBoxNDFA.Location = new System.Drawing.Point(9, 254);
            this.checkBoxNDFA.Name = "checkBoxNDFA";
            this.checkBoxNDFA.Size = new System.Drawing.Size(101, 17);
            this.checkBoxNDFA.TabIndex = 19;
            this.checkBoxNDFA.Tag = "NDFinalAttack";
            this.checkBoxNDFA.Text = "ND Final Attack";
            this.checkBoxNDFA.UseVisualStyleBackColor = true;
            this.checkBoxNDFA.CheckedChanged += new System.EventHandler(this.checkBoxNDFA_OnCheckedChanged);
            // 
            // tabBot
            // 
            this.tabBot.Controls.Add(this.comboBox4);
            this.tabBot.Controls.Add(this.comboBox3);
            this.tabBot.Controls.Add(this.numericUpDown6);
            this.tabBot.Controls.Add(this.label10);
            this.tabBot.Controls.Add(this.checkBoxLoot);
            this.tabBot.Controls.Add(this.numericUpDown5);
            this.tabBot.Controls.Add(this.label9);
            this.tabBot.Controls.Add(this.numericUpDown3);
            this.tabBot.Controls.Add(this.checkBoxMP);
            this.tabBot.Controls.Add(this.numericUpDown2);
            this.tabBot.Controls.Add(this.checkBoxHP);
            this.tabBot.Controls.Add(this.comboBox2);
            this.tabBot.Controls.Add(this.checkBoxAttack);
            this.tabBot.Location = new System.Drawing.Point(4, 22);
            this.tabBot.Name = "tabBot";
            this.tabBot.Size = new System.Drawing.Size(522, 312);
            this.tabBot.TabIndex = 2;
            this.tabBot.Text = "Bot";
            this.tabBot.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Home"});
            this.comboBox4.Location = new System.Drawing.Point(155, 71);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(94, 21);
            this.comboBox4.TabIndex = 14;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "End"});
            this.comboBox3.Location = new System.Drawing.Point(155, 45);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(93, 21);
            this.comboBox3.TabIndex = 13;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(202, 95);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown6.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(94, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "when Item Count >=";
            // 
            // checkBoxLoot
            // 
            this.checkBoxLoot.AutoSize = true;
            this.checkBoxLoot.Location = new System.Drawing.Point(9, 96);
            this.checkBoxLoot.Name = "checkBoxLoot";
            this.checkBoxLoot.Size = new System.Drawing.Size(85, 17);
            this.checkBoxLoot.TabIndex = 10;
            this.checkBoxLoot.Text = "AutoLoot (Z)";
            this.checkBoxLoot.UseVisualStyleBackColor = true;
            this.checkBoxLoot.CheckedChanged += new System.EventHandler(this.checkBoxLoot_CheckedChanged);
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(325, 18);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown5.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(199, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "when Monster Count >=";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(90, 72);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown3.TabIndex = 5;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxMP
            // 
            this.checkBoxMP.AutoSize = true;
            this.checkBoxMP.Location = new System.Drawing.Point(9, 73);
            this.checkBoxMP.Name = "checkBoxMP";
            this.checkBoxMP.Size = new System.Drawing.Size(76, 17);
            this.checkBoxMP.TabIndex = 4;
            this.checkBoxMP.Text = "AutoMP at";
            this.checkBoxMP.UseVisualStyleBackColor = true;
            this.checkBoxMP.CheckedChanged += new System.EventHandler(this.checkBoxMP_CheckedChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(90, 46);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown2.TabIndex = 3;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBoxHP
            // 
            this.checkBoxHP.AutoSize = true;
            this.checkBoxHP.Location = new System.Drawing.Point(9, 47);
            this.checkBoxHP.Name = "checkBoxHP";
            this.checkBoxHP.Size = new System.Drawing.Size(75, 17);
            this.checkBoxHP.TabIndex = 2;
            this.checkBoxHP.Text = "AutoHP at";
            this.checkBoxHP.UseVisualStyleBackColor = true;
            this.checkBoxHP.CheckedChanged += new System.EventHandler(this.checkBoxHP_CheckedChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Control",
            "Delete"});
            this.comboBox2.Location = new System.Drawing.Point(97, 17);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(93, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // checkBoxAttack
            // 
            this.checkBoxAttack.AutoSize = true;
            this.checkBoxAttack.Location = new System.Drawing.Point(9, 19);
            this.checkBoxAttack.Name = "checkBoxAttack";
            this.checkBoxAttack.Size = new System.Drawing.Size(82, 17);
            this.checkBoxAttack.TabIndex = 0;
            this.checkBoxAttack.Text = "Auto Attack";
            this.checkBoxAttack.UseVisualStyleBackColor = true;
            this.checkBoxAttack.CheckedChanged += new System.EventHandler(this.checkBoxAttack_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 339);
            this.Controls.Add(this.tabControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_OnFormClosing);
            this.Load += new System.EventHandler(this.Main_OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabInfo.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldDamageCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.tabBot.ResumeLayout(false);
            this.tabBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.CheckBox checkBoxNDFA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabBot;
        private System.Windows.Forms.CheckBox checkBoxAttack;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBoxHP;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.CheckBox checkBoxMP;
        private System.Windows.Forms.CheckBox checkBoxTeleport;
        private System.Windows.Forms.CheckBox checkBoxKami;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.CheckBox checkBoxLoot;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.NumericUpDown fieldDamageCap;
        private System.Windows.Forms.Label label6;

    }
}

