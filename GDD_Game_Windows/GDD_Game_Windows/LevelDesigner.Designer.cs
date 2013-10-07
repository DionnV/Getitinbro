﻿namespace GDD_Game_Windows
{
    partial class LevelDesigner
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
            this.Pencil = new System.Windows.Forms.Button();
            this.Line = new System.Windows.Forms.Button();
            this.Ball = new System.Windows.Forms.Button();
            this.Square = new System.Windows.Forms.Button();
            this.Bucket = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.DeleteAll = new System.Windows.Forms.Button();
            this.GDD_View_LevelDesigner1 = new GDD_Library.GDD_View();
            this.Save = new System.Windows.Forms.Button();
            this.LevelName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreatorName = new System.Windows.Forms.Label();
            this.CreatorBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BackgroundBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.RotateBar = new System.Windows.Forms.TrackBar();
            this.SizeBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RotateBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Pencil
            // 
            this.Pencil.BackColor = System.Drawing.Color.Gray;
            this.Pencil.Location = new System.Drawing.Point(12, 12);
            this.Pencil.Name = "Pencil";
            this.Pencil.Size = new System.Drawing.Size(50, 50);
            this.Pencil.TabIndex = 0;
            this.Pencil.Text = "Pencil";
            this.Pencil.UseVisualStyleBackColor = false;
            this.Pencil.Click += new System.EventHandler(this.button1_Click);
            // 
            // Line
            // 
            this.Line.BackColor = System.Drawing.Color.Gray;
            this.Line.Location = new System.Drawing.Point(12, 68);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(50, 50);
            this.Line.TabIndex = 1;
            this.Line.Text = "Line";
            this.Line.UseVisualStyleBackColor = false;
            this.Line.Click += new System.EventHandler(this.button2_Click);
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.Gray;
            this.Ball.Location = new System.Drawing.Point(12, 124);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(50, 50);
            this.Ball.TabIndex = 2;
            this.Ball.Text = "Ball";
            this.Ball.UseVisualStyleBackColor = false;
            this.Ball.Click += new System.EventHandler(this.button3_Click);
            // 
            // Square
            // 
            this.Square.BackColor = System.Drawing.Color.Gray;
            this.Square.Location = new System.Drawing.Point(12, 180);
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(50, 50);
            this.Square.TabIndex = 3;
            this.Square.Text = "Square";
            this.Square.UseVisualStyleBackColor = false;
            this.Square.Click += new System.EventHandler(this.button4_Click);
            // 
            // Bucket
            // 
            this.Bucket.BackColor = System.Drawing.Color.Gray;
            this.Bucket.Location = new System.Drawing.Point(12, 236);
            this.Bucket.Name = "Bucket";
            this.Bucket.Size = new System.Drawing.Size(50, 50);
            this.Bucket.TabIndex = 4;
            this.Bucket.Text = "Bucket";
            this.Bucket.UseVisualStyleBackColor = false;
            this.Bucket.Click += new System.EventHandler(this.button5_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.BackColor = System.Drawing.Color.Gray;
            this.SelectButton.Location = new System.Drawing.Point(12, 292);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(50, 50);
            this.SelectButton.TabIndex = 5;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = false;
            this.SelectButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // DeleteAll
            // 
            this.DeleteAll.BackColor = System.Drawing.Color.Gray;
            this.DeleteAll.Location = new System.Drawing.Point(12, 348);
            this.DeleteAll.Name = "DeleteAll";
            this.DeleteAll.Size = new System.Drawing.Size(50, 50);
            this.DeleteAll.TabIndex = 6;
            this.DeleteAll.Text = "Delete all";
            this.DeleteAll.UseVisualStyleBackColor = false;
            this.DeleteAll.Click += new System.EventHandler(this.button7_Click);
            // 
            // GDD_View_LevelDesigner1
            // 
            this.GDD_View_LevelDesigner1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.GDD_View_LevelDesigner1.Location = new System.Drawing.Point(68, 0);
            this.GDD_View_LevelDesigner1.Name = "GDD_View_LevelDesigner1";
            this.GDD_View_LevelDesigner1.Size = new System.Drawing.Size(598, 439);
            this.GDD_View_LevelDesigner1.TabIndex = 0;
            this.GDD_View_LevelDesigner1.ViewingRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.GDD_View_LevelDesigner1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GDD_View_LevelDesigner1_MouseClick);
            this.GDD_View_LevelDesigner1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GDD_View_LevelDesigner1_MouseDown);
            this.GDD_View_LevelDesigner1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GDD_View_LevelDesigner1_MouseMove);
            this.GDD_View_LevelDesigner1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GDD_View_LevelDesigner1_MouseUp);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.Gray;
            this.Save.Location = new System.Drawing.Point(722, 12);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(50, 50);
            this.Save.TabIndex = 7;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // LevelName
            // 
            this.LevelName.Location = new System.Drawing.Point(672, 98);
            this.LevelName.Name = "LevelName";
            this.LevelName.Size = new System.Drawing.Size(100, 20);
            this.LevelName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(669, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Level name:";
            // 
            // CreatorName
            // 
            this.CreatorName.AutoSize = true;
            this.CreatorName.Location = new System.Drawing.Point(669, 121);
            this.CreatorName.Name = "CreatorName";
            this.CreatorName.Size = new System.Drawing.Size(73, 13);
            this.CreatorName.TabIndex = 10;
            this.CreatorName.Text = "Creator name:";
            // 
            // CreatorBox
            // 
            this.CreatorBox.Location = new System.Drawing.Point(672, 137);
            this.CreatorBox.Name = "CreatorBox";
            this.CreatorBox.Size = new System.Drawing.Size(100, 20);
            this.CreatorBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(669, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Background";
            // 
            // BackgroundBox
            // 
            this.BackgroundBox.Location = new System.Drawing.Point(672, 180);
            this.BackgroundBox.Name = "BackgroundBox";
            this.BackgroundBox.Size = new System.Drawing.Size(100, 20);
            this.BackgroundBox.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.Location = new System.Drawing.Point(710, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 20);
            this.button1.TabIndex = 14;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // RotateBar
            // 
            this.RotateBar.Location = new System.Drawing.Point(672, 267);
            this.RotateBar.Maximum = 360;
            this.RotateBar.Name = "RotateBar";
            this.RotateBar.Size = new System.Drawing.Size(104, 45);
            this.RotateBar.TabIndex = 15;
            this.RotateBar.TickFrequency = 45;
            this.RotateBar.Scroll += new System.EventHandler(this.RotateBar_Scroll);
            // 
            // SizeBar
            // 
            this.SizeBar.Location = new System.Drawing.Point(672, 348);
            this.SizeBar.Maximum = 100;
            this.SizeBar.Minimum = 10;
            this.SizeBar.Name = "SizeBar";
            this.SizeBar.Size = new System.Drawing.Size(104, 45);
            this.SizeBar.TabIndex = 16;
            this.SizeBar.TickFrequency = 10;
            this.SizeBar.Value = 10;
            this.SizeBar.Scroll += new System.EventHandler(this.SizeBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(672, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Rotation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(672, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Size";
            // 
            // LevelDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SizeBar);
            this.Controls.Add(this.RotateBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BackgroundBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CreatorBox);
            this.Controls.Add(this.CreatorName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LevelName);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.DeleteAll);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.Bucket);
            this.Controls.Add(this.Square);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.Pencil);
            this.Controls.Add(this.GDD_View_LevelDesigner1);
            this.Name = "LevelDesigner";
            this.Text = "LevelDesigner";
            this.Load += new System.EventHandler(this.LevelDesigner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RotateBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GDD_Library.GDD_View GDD_View_LevelDesigner1;
        private System.Windows.Forms.Button Pencil;
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button Ball;
        private System.Windows.Forms.Button Square;
        private System.Windows.Forms.Button Bucket;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button DeleteAll;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox LevelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CreatorName;
        private System.Windows.Forms.TextBox CreatorBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BackgroundBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar RotateBar;
        private System.Windows.Forms.TrackBar SizeBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}