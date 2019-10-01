namespace DurakUI
{
    partial class frmPlayTime
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
            this.pnlMachine = new System.Windows.Forms.Panel();
            this.pnlHuman = new System.Windows.Forms.Panel();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.pbDeck = new System.Windows.Forms.PictureBox();
            this.pbTrump = new System.Windows.Forms.PictureBox();
            this.pbDiscard = new System.Windows.Forms.PictureBox();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.lblHumanName = new System.Windows.Forms.Label();
            this.lblComputerName = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDeckCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrump)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDiscard)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMachine
            // 
            this.pnlMachine.Location = new System.Drawing.Point(488, 0);
            this.pnlMachine.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMachine.Name = "pnlMachine";
            this.pnlMachine.Size = new System.Drawing.Size(712, 242);
            this.pnlMachine.TabIndex = 2;
            // 
            // pnlHuman
            // 
            this.pnlHuman.Location = new System.Drawing.Point(488, 552);
            this.pnlHuman.Name = "pnlHuman";
            this.pnlHuman.Size = new System.Drawing.Size(712, 242);
            this.pnlHuman.TabIndex = 3;
            // 
            // pnlTable
            // 
            this.pnlTable.Location = new System.Drawing.Point(320, 240);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(1048, 296);
            this.pnlTable.TabIndex = 4;
            // 
            // pbDeck
            // 
            this.pbDeck.Location = new System.Drawing.Point(32, 272);
            this.pbDeck.Name = "pbDeck";
            this.pbDeck.Size = new System.Drawing.Size(152, 216);
            this.pbDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDeck.TabIndex = 26;
            this.pbDeck.TabStop = false;
            // 
            // pbTrump
            // 
            this.pbTrump.Location = new System.Drawing.Point(56, 312);
            this.pbTrump.Name = "pbTrump";
            this.pbTrump.Size = new System.Drawing.Size(216, 152);
            this.pbTrump.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTrump.TabIndex = 27;
            this.pbTrump.TabStop = false;
            // 
            // pbDiscard
            // 
            this.pbDiscard.Location = new System.Drawing.Point(1392, 272);
            this.pbDiscard.Name = "pbDiscard";
            this.pbDiscard.Size = new System.Drawing.Size(152, 216);
            this.pbDiscard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDiscard.TabIndex = 28;
            this.pbDiscard.TabStop = false;
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.BackColor = System.Drawing.Color.IndianRed;
            this.btnEndTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndTurn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnEndTurn.Location = new System.Drawing.Point(336, 568);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(120, 40);
            this.btnEndTurn.TabIndex = 29;
            this.btnEndTurn.Text = "End Turn";
            this.btnEndTurn.UseVisualStyleBackColor = false;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // lblHumanName
            // 
            this.lblHumanName.AutoSize = true;
            this.lblHumanName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHumanName.Location = new System.Drawing.Point(1224, 592);
            this.lblHumanName.Name = "lblHumanName";
            this.lblHumanName.Size = new System.Drawing.Size(136, 20);
            this.lblHumanName.TabIndex = 30;
            this.lblHumanName.Text = "lblHumanName";
            // 
            // lblComputerName
            // 
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputerName.Location = new System.Drawing.Point(1216, 200);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(158, 20);
            this.lblComputerName.TabIndex = 31;
            this.lblComputerName.Text = "lblComputerName";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(1368, 32);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 64);
            this.btnExit.TabIndex = 32;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDeckCounter
            // 
            this.lblDeckCounter.AutoSize = true;
            this.lblDeckCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeckCounter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDeckCounter.Location = new System.Drawing.Point(72, 216);
            this.lblDeckCounter.Name = "lblDeckCounter";
            this.lblDeckCounter.Size = new System.Drawing.Size(55, 39);
            this.lblDeckCounter.TabIndex = 33;
            this.lblDeckCounter.Text = "24";
            // 
            // frmPlayTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.MintCream;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1588, 800);
            this.Controls.Add(this.lblDeckCounter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblComputerName);
            this.Controls.Add(this.lblHumanName);
            this.Controls.Add(this.btnEndTurn);
            this.Controls.Add(this.pbDeck);
            this.Controls.Add(this.pbTrump);
            this.Controls.Add(this.pbDiscard);
            this.Controls.Add(this.pnlHuman);
            this.Controls.Add(this.pnlMachine);
            this.Controls.Add(this.pnlTable);
            this.Name = "frmPlayTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Play Time";
            this.Load += new System.EventHandler(this.frmPlayTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTrump)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDiscard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlMachine;
        private System.Windows.Forms.Panel pnlHuman;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.PictureBox pbDeck;
        private System.Windows.Forms.PictureBox pbTrump;
        private System.Windows.Forms.PictureBox pbDiscard;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Label lblHumanName;
        private System.Windows.Forms.Label lblComputerName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDeckCounter;
    }
}