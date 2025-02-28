
namespace CustomGameManager
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
            this.Save = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ButtonColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ColorButton = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.Add = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.Taskbar = new System.Windows.Forms.Panel();
            this.delete = new System.Windows.Forms.Button();
            this.settingsPanel.SuspendLayout();
            this.Taskbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(853, 3);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(76, 23);
            this.Save.TabIndex = 16;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(714, 4);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(75, 23);
            this.Settings.TabIndex = 17;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.settingsPanel.Controls.Add(this.label3);
            this.settingsPanel.Controls.Add(this.comboBox1);
            this.settingsPanel.Controls.Add(this.ButtonColor);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Controls.Add(this.ColorButton);
            this.settingsPanel.Controls.Add(this.update);
            this.settingsPanel.Controls.Add(this.label1);
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(964, 428);
            this.settingsPanel.TabIndex = 18;
            this.settingsPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Button Style";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Standerd",
            "Flat"});
            this.comboBox1.Location = new System.Drawing.Point(161, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ButtonColor
            // 
            this.ButtonColor.Location = new System.Drawing.Point(161, 47);
            this.ButtonColor.Name = "ButtonColor";
            this.ButtonColor.Size = new System.Drawing.Size(21, 23);
            this.ButtonColor.TabIndex = 5;
            this.ButtonColor.UseVisualStyleBackColor = true;
            this.ButtonColor.Click += new System.EventHandler(this.ButtonColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Button Color";
            // 
            // ColorButton
            // 
            this.ColorButton.Location = new System.Drawing.Point(161, 13);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(21, 23);
            this.ColorButton.TabIndex = 3;
            this.ColorButton.UseVisualStyleBackColor = true;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(857, 394);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 2;
            this.update.Text = "Update Settings";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Background Color";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(935, 9);
            this.vScrollBar1.Maximum = 20;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(14, 408);
            this.vScrollBar1.TabIndex = 19;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(824, 4);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(23, 22);
            this.Add.TabIndex = 20;
            this.Add.Text = "+";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // minus
            // 
            this.minus.Location = new System.Drawing.Point(795, 4);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(23, 22);
            this.minus.TabIndex = 21;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // Taskbar
            // 
            this.Taskbar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Taskbar.Controls.Add(this.delete);
            this.Taskbar.Controls.Add(this.Settings);
            this.Taskbar.Controls.Add(this.minus);
            this.Taskbar.Controls.Add(this.Save);
            this.Taskbar.Controls.Add(this.Add);
            this.Taskbar.Location = new System.Drawing.Point(0, 384);
            this.Taskbar.Name = "Taskbar";
            this.Taskbar.Size = new System.Drawing.Size(932, 44);
            this.Taskbar.TabIndex = 22;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(12, 7);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(136, 23);
            this.delete.TabIndex = 22;
            this.delete.Text = "Enable delete mode";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(961, 426);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.Taskbar);
            this.Controls.Add(this.vScrollBar1);
            this.Name = "Form1";
            this.Text = "Custom App manager by therealmastermind";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.Taskbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.Button ButtonColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Panel Taskbar;
        private System.Windows.Forms.Button delete;
    }
}

