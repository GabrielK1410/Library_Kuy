namespace CleanSneakers
{
    partial class FormAdminmain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminmain));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTahunterbit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPengarangbuku = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJudulbuku = new System.Windows.Forms.TextBox();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCari = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIDbuku = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(401, 538);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1149, 560);
            this.dataGridView1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(42, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hello, Admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(38, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-15, -3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(258, 1168);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(503, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(945, 128);
            this.label2.TabIndex = 10;
            this.label2.Text = "MANEJEMEN BUKU";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label3.Location = new System.Drawing.Point(395, 487);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 32);
            this.label3.TabIndex = 11;
            this.label3.Text = "Daftar Buku";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label6.Location = new System.Drawing.Point(519, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 32);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tahun Terbit";
            // 
            // txtTahunterbit
            // 
            this.txtTahunterbit.BackColor = System.Drawing.Color.OldLace;
            this.txtTahunterbit.Location = new System.Drawing.Point(525, 421);
            this.txtTahunterbit.Name = "txtTahunterbit";
            this.txtTahunterbit.Size = new System.Drawing.Size(305, 26);
            this.txtTahunterbit.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label5.Location = new System.Drawing.Point(519, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 32);
            this.label5.TabIndex = 17;
            this.label5.Text = "Pengarang Buku";
            // 
            // txtPengarangbuku
            // 
            this.txtPengarangbuku.BackColor = System.Drawing.Color.OldLace;
            this.txtPengarangbuku.Location = new System.Drawing.Point(525, 331);
            this.txtPengarangbuku.Name = "txtPengarangbuku";
            this.txtPengarangbuku.Size = new System.Drawing.Size(305, 26);
            this.txtPengarangbuku.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label4.Location = new System.Drawing.Point(519, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 32);
            this.label4.TabIndex = 15;
            this.label4.Text = "Judul Buku";
            // 
            // txtJudulbuku
            // 
            this.txtJudulbuku.BackColor = System.Drawing.Color.OldLace;
            this.txtJudulbuku.Location = new System.Drawing.Point(525, 242);
            this.txtJudulbuku.Name = "txtJudulbuku";
            this.txtJudulbuku.Size = new System.Drawing.Size(305, 26);
            this.txtJudulbuku.TabIndex = 14;
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(1077, 328);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(185, 33);
            this.btnHapus.TabIndex = 29;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(1077, 239);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(185, 33);
            this.btnTambah.TabIndex = 28;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1317, 328);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(185, 33);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(1317, 239);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(185, 33);
            this.btnCari.TabIndex = 30;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label7.Location = new System.Drawing.Point(865, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 32);
            this.label7.TabIndex = 33;
            this.label7.Text = "ID Buku";
            // 
            // txtIDbuku
            // 
            this.txtIDbuku.BackColor = System.Drawing.Color.OldLace;
            this.txtIDbuku.Location = new System.Drawing.Point(871, 242);
            this.txtIDbuku.Name = "txtIDbuku";
            this.txtIDbuku.Size = new System.Drawing.Size(151, 26);
            this.txtIDbuku.TabIndex = 32;
            this.txtIDbuku.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(1077, 414);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(185, 33);
            this.btnEdit.TabIndex = 34;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // FormAdminmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1678, 1144);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIDbuku);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTahunterbit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPengarangbuku);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJudulbuku);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "FormAdminmain";
            this.Text = "FormAdminmain";
            this.Load += new System.EventHandler(this.FormAdminmain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTahunterbit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPengarangbuku;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJudulbuku;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIDbuku;
        private System.Windows.Forms.Button btnEdit;
    }
}