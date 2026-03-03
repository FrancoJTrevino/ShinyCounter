namespace ShinyCounter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnAdd = new Button();
            btnReset = new Button();
            lblCounter = new Label();
            cmbPokemon = new ComboBox();
            label1 = new Label();
            lblStartingDate = new Label();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.Enabled = false;
            btnAdd.Font = new Font("Arial", 12F);
            btnAdd.Location = new Point(267, 155);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(210, 56);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add to counter (F6)";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.None;
            btnReset.Enabled = false;
            btnReset.Font = new Font("Arial", 12F);
            btnReset.Location = new Point(12, 155);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(210, 56);
            btnReset.TabIndex = 1;
            btnReset.Text = "Reset counter (F9)";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // lblCounter
            // 
            lblCounter.Anchor = AnchorStyles.None;
            lblCounter.Font = new Font("Arial", 36F);
            lblCounter.Location = new Point(12, 63);
            lblCounter.Name = "lblCounter";
            lblCounter.Size = new Size(465, 69);
            lblCounter.TabIndex = 2;
            lblCounter.Text = "0";
            lblCounter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbPokemon
            // 
            cmbPokemon.Anchor = AnchorStyles.None;
            cmbPokemon.FormattingEnabled = true;
            cmbPokemon.Location = new Point(116, 12);
            cmbPokemon.Name = "cmbPokemon";
            cmbPokemon.Size = new Size(354, 31);
            cmbPokemon.TabIndex = 3;
            cmbPokemon.SelectedIndexChanged += cmbPokemon_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(98, 23);
            label1.TabIndex = 4;
            label1.Text = "Pokémon:";
            // 
            // lblStartingDate
            // 
            lblStartingDate.Anchor = AnchorStyles.None;
            lblStartingDate.AutoSize = true;
            lblStartingDate.Location = new Point(12, 225);
            lblStartingDate.Name = "lblStartingDate";
            lblStartingDate.Size = new Size(123, 23);
            lblStartingDate.TabIndex = 5;
            lblStartingDate.Text = "Hunt started:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 258);
            Controls.Add(lblStartingDate);
            Controls.Add(label1);
            Controls.Add(cmbPokemon);
            Controls.Add(lblCounter);
            Controls.Add(btnReset);
            Controls.Add(btnAdd);
            Font = new Font("Arial", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shiny Counter";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnReset;
        private Label lblCounter;
        private ComboBox cmbPokemon;
        private Label label1;
        private Label lblStartingDate;
    }
}
