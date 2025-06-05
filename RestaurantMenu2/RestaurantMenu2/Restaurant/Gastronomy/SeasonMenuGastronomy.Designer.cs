namespace RestaurantMenu2.Restaurant.Gastronomy
{
    partial class SeasonMenuGastronomy
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewSM = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSM)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(141)))), ((int)(((byte)(51)))));
            this.button2.Location = new System.Drawing.Point(552, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 7;
            this.button2.Text = "Удалить\r\nблюдо";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(141)))), ((int)(((byte)(51)))));
            this.button1.Location = new System.Drawing.Point(437, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Добавить\r\nблюдо";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSM
            // 
            this.dataGridViewSM.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dataGridViewSM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSM.GridColor = System.Drawing.Color.LemonChiffon;
            this.dataGridViewSM.Location = new System.Drawing.Point(0, 48);
            this.dataGridViewSM.Name = "dataGridViewSM";
            this.dataGridViewSM.Size = new System.Drawing.Size(657, 308);
            this.dataGridViewSM.TabIndex = 5;
            this.dataGridViewSM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSM_CellContentClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Sans Serif Collection", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(141)))), ((int)(((byte)(51)))));
            this.label10.Location = new System.Drawing.Point(33, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(339, 59);
            this.label10.TabIndex = 34;
            this.label10.Text = "Сезонное меню";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeasonMenuGastronomy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(657, 451);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewSM);
            this.MaximumSize = new System.Drawing.Size(673, 490);
            this.MinimumSize = new System.Drawing.Size(673, 490);
            this.Name = "SeasonMenuGastronomy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeasonMenuGastronomy";
            this.Load += new System.EventHandler(this.SeasonMenuGastronomy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewSM;
        private System.Windows.Forms.Label label10;
    }
}