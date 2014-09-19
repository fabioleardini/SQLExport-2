namespace SQLExport
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
            this.importTXT = new System.Windows.Forms.Button();
            this.selectTask = new System.Windows.Forms.ComboBox();
            this.task = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // importTXT
            // 
            this.importTXT.Location = new System.Drawing.Point(93, 107);
            this.importTXT.Name = "importTXT";
            this.importTXT.Size = new System.Drawing.Size(97, 23);
            this.importTXT.TabIndex = 0;
            this.importTXT.Text = "Importar TXT";
            this.importTXT.UseVisualStyleBackColor = true;
            this.importTXT.Click += new System.EventHandler(this.importTXT_Click);
            // 
            // selectTask
            // 
            this.selectTask.FormattingEnabled = true;
            this.selectTask.Location = new System.Drawing.Point(93, 80);
            this.selectTask.Name = "selectTask";
            this.selectTask.Size = new System.Drawing.Size(121, 21);
            this.selectTask.TabIndex = 2;
            // 
            // task
            // 
            this.task.AutoSize = true;
            this.task.Location = new System.Drawing.Point(64, 83);
            this.task.Name = "task";
            this.task.Size = new System.Drawing.Size(23, 13);
            this.task.TabIndex = 3;
            this.task.Text = "Fila";
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(93, 137);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(97, 23);
            this.close.TabIndex = 4;
            this.close.Text = "Fechar";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.close);
            this.Controls.Add(this.task);
            this.Controls.Add(this.selectTask);
            this.Controls.Add(this.importTXT);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exporte XLS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importTXT;
        private System.Windows.Forms.ComboBox selectTask;
        private System.Windows.Forms.Label task;
        private System.Windows.Forms.Button close;
    }
}

