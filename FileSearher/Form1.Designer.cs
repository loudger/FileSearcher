﻿namespace FileSearher
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Start_Pause = new System.Windows.Forms.Button();
            this.path_box = new System.Windows.Forms.TextBox();
            this.filename_box = new System.Windows.Forms.TextBox();
            this.content_box = new System.Windows.Forms.TextBox();
            this.path_label = new System.Windows.Forms.Label();
            this.filename_label = new System.Windows.Forms.Label();
            this.content_label = new System.Windows.Forms.Label();
            this.path_butt = new System.Windows.Forms.Button();
            this.dropping_bt = new System.Windows.Forms.Button();
            this.current_file_label = new System.Windows.Forms.Label();
            this.count_of_files_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(422, 453);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Start_Pause
            // 
            this.Start_Pause.Location = new System.Drawing.Point(451, 159);
            this.Start_Pause.Name = "Start_Pause";
            this.Start_Pause.Size = new System.Drawing.Size(127, 75);
            this.Start_Pause.TabIndex = 1;
            this.Start_Pause.Text = "Пуск";
            this.Start_Pause.UseVisualStyleBackColor = true;
            this.Start_Pause.Click += new System.EventHandler(this.Start_Pause_Click);
            // 
            // path_box
            // 
            this.path_box.Location = new System.Drawing.Point(584, 37);
            this.path_box.Name = "path_box";
            this.path_box.Size = new System.Drawing.Size(140, 20);
            this.path_box.TabIndex = 2;
            // 
            // filename_box
            // 
            this.filename_box.Location = new System.Drawing.Point(584, 78);
            this.filename_box.Name = "filename_box";
            this.filename_box.Size = new System.Drawing.Size(140, 20);
            this.filename_box.TabIndex = 3;
            // 
            // content_box
            // 
            this.content_box.Location = new System.Drawing.Point(584, 120);
            this.content_box.Name = "content_box";
            this.content_box.Size = new System.Drawing.Size(140, 20);
            this.content_box.TabIndex = 4;
            // 
            // path_label
            // 
            this.path_label.AutoSize = true;
            this.path_label.Location = new System.Drawing.Point(532, 40);
            this.path_label.Name = "path_label";
            this.path_label.Size = new System.Drawing.Size(29, 13);
            this.path_label.TabIndex = 5;
            this.path_label.Text = "Path";
            // 
            // filename_label
            // 
            this.filename_label.AutoSize = true;
            this.filename_label.Location = new System.Drawing.Point(532, 81);
            this.filename_label.Name = "filename_label";
            this.filename_label.Size = new System.Drawing.Size(46, 13);
            this.filename_label.TabIndex = 6;
            this.filename_label.Text = "filename";
            // 
            // content_label
            // 
            this.content_label.AutoSize = true;
            this.content_label.Location = new System.Drawing.Point(532, 123);
            this.content_label.Name = "content_label";
            this.content_label.Size = new System.Drawing.Size(43, 13);
            this.content_label.TabIndex = 7;
            this.content_label.Text = "content";
            // 
            // path_butt
            // 
            this.path_butt.Location = new System.Drawing.Point(451, 35);
            this.path_butt.Name = "path_butt";
            this.path_butt.Size = new System.Drawing.Size(75, 23);
            this.path_butt.TabIndex = 8;
            this.path_butt.Text = "Browse";
            this.path_butt.UseVisualStyleBackColor = true;
            this.path_butt.Click += new System.EventHandler(this.path_butt_Click);
            // 
            // dropping_bt
            // 
            this.dropping_bt.Location = new System.Drawing.Point(597, 159);
            this.dropping_bt.Name = "dropping_bt";
            this.dropping_bt.Size = new System.Drawing.Size(127, 75);
            this.dropping_bt.TabIndex = 9;
            this.dropping_bt.Text = "Сброс";
            this.dropping_bt.UseVisualStyleBackColor = true;
            this.dropping_bt.Click += new System.EventHandler(this.dropping_bt_Click);
            // 
            // current_file_label
            // 
            this.current_file_label.AutoSize = true;
            this.current_file_label.Location = new System.Drawing.Point(448, 440);
            this.current_file_label.Name = "current_file_label";
            this.current_file_label.Size = new System.Drawing.Size(0, 13);
            this.current_file_label.TabIndex = 10;
            // 
            // count_of_files_label
            // 
            this.count_of_files_label.AutoSize = true;
            this.count_of_files_label.Location = new System.Drawing.Point(448, 416);
            this.count_of_files_label.Name = "count_of_files_label";
            this.count_of_files_label.Size = new System.Drawing.Size(0, 13);
            this.count_of_files_label.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 469);
            this.Controls.Add(this.count_of_files_label);
            this.Controls.Add(this.current_file_label);
            this.Controls.Add(this.dropping_bt);
            this.Controls.Add(this.path_butt);
            this.Controls.Add(this.content_label);
            this.Controls.Add(this.filename_label);
            this.Controls.Add(this.path_label);
            this.Controls.Add(this.content_box);
            this.Controls.Add(this.filename_box);
            this.Controls.Add(this.path_box);
            this.Controls.Add(this.Start_Pause);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button Start_Pause;
        private System.Windows.Forms.TextBox path_box;
        private System.Windows.Forms.TextBox filename_box;
        private System.Windows.Forms.TextBox content_box;
        private System.Windows.Forms.Label path_label;
        private System.Windows.Forms.Label filename_label;
        private System.Windows.Forms.Label content_label;
        private System.Windows.Forms.Button path_butt;
        private System.Windows.Forms.Button dropping_bt;
        private System.Windows.Forms.Label current_file_label;
        private System.Windows.Forms.Label count_of_files_label;
        private System.Windows.Forms.Timer timer1;
    }
}

