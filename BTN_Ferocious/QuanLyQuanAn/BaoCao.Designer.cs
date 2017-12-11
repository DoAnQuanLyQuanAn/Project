namespace QuanLyQuanAn
{
    partial class BaoCao
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btThongKe = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabDoanhThuTCN = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cbChonChiNhanh = new System.Windows.Forms.ComboBox();
            this.btThongKe2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabMonBanChay = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btThongKe3 = new System.Windows.Forms.Button();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabChiPhi = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btThongKe4 = new System.Windows.Forms.Button();
            this.dateTimePicker8 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker7 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabBieuDo = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabDoanhThuTCN.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabMonBanChay.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabChiPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabBieuDo.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDoanhThu);
            this.tabControl1.Controls.Add(this.tabDoanhThuTCN);
            this.tabControl1.Controls.Add(this.tabMonBanChay);
            this.tabControl1.Controls.Add(this.tabChiPhi);
            this.tabControl1.Controls.Add(this.tabBieuDo);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(858, 481);
            this.tabControl1.TabIndex = 0;
            // 
            // tabDoanhThu
            // 
            this.tabDoanhThu.Controls.Add(this.panel2);
            this.tabDoanhThu.Controls.Add(this.panel1);
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 22);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoanhThu.Size = new System.Drawing.Size(850, 455);
            this.tabDoanhThu.TabIndex = 0;
            this.tabDoanhThu.Text = "Doanh Thu Tổng";
            this.tabDoanhThu.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btThongKe);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(844, 50);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btThongKe
            // 
            this.btThongKe.Location = new System.Drawing.Point(711, 3);
            this.btThongKe.Name = "btThongKe";
            this.btThongKe.Size = new System.Drawing.Size(97, 44);
            this.btThongKe.TabIndex = 3;
            this.btThongKe.Text = "Xem Thống Kê";
            this.btThongKe.UseVisualStyleBackColor = true;
            this.btThongKe.Click += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(407, 13);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(213, 20);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đến Ngày";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(35, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(201, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 396);
            this.panel1.TabIndex = 0;
            // 
            // tabDoanhThuTCN
            // 
            this.tabDoanhThuTCN.Controls.Add(this.label3);
            this.tabDoanhThuTCN.Controls.Add(this.cbChonChiNhanh);
            this.tabDoanhThuTCN.Controls.Add(this.btThongKe2);
            this.tabDoanhThuTCN.Controls.Add(this.label2);
            this.tabDoanhThuTCN.Controls.Add(this.dateTimePicker4);
            this.tabDoanhThuTCN.Controls.Add(this.dateTimePicker3);
            this.tabDoanhThuTCN.Controls.Add(this.panel3);
            this.tabDoanhThuTCN.Location = new System.Drawing.Point(4, 22);
            this.tabDoanhThuTCN.Name = "tabDoanhThuTCN";
            this.tabDoanhThuTCN.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoanhThuTCN.Size = new System.Drawing.Size(850, 455);
            this.tabDoanhThuTCN.TabIndex = 1;
            this.tabDoanhThuTCN.Text = "Doanh Thu Theo Chi Nhánh";
            this.tabDoanhThuTCN.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chọn Chi Nhánh:";
            // 
            // cbChonChiNhanh
            // 
            this.cbChonChiNhanh.FormattingEnabled = true;
            this.cbChonChiNhanh.Location = new System.Drawing.Point(138, 8);
            this.cbChonChiNhanh.Name = "cbChonChiNhanh";
            this.cbChonChiNhanh.Size = new System.Drawing.Size(260, 21);
            this.cbChonChiNhanh.TabIndex = 5;
            // 
            // btThongKe2
            // 
            this.btThongKe2.Location = new System.Drawing.Point(708, 28);
            this.btThongKe2.Name = "btThongKe2";
            this.btThongKe2.Size = new System.Drawing.Size(99, 40);
            this.btThongKe2.TabIndex = 4;
            this.btThongKe2.Text = "Xem Thống Kê";
            this.btThongKe2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đến Ngày";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Location = new System.Drawing.Point(434, 48);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker4.TabIndex = 2;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(36, 48);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker3.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(0, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(850, 371);
            this.panel3.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(850, 371);
            this.dataGridView1.TabIndex = 1;
            // 
            // tabMonBanChay
            // 
            this.tabMonBanChay.Controls.Add(this.label4);
            this.tabMonBanChay.Controls.Add(this.btThongKe3);
            this.tabMonBanChay.Controls.Add(this.dateTimePicker6);
            this.tabMonBanChay.Controls.Add(this.dateTimePicker5);
            this.tabMonBanChay.Controls.Add(this.panel4);
            this.tabMonBanChay.Location = new System.Drawing.Point(4, 22);
            this.tabMonBanChay.Name = "tabMonBanChay";
            this.tabMonBanChay.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonBanChay.Size = new System.Drawing.Size(850, 455);
            this.tabMonBanChay.TabIndex = 2;
            this.tabMonBanChay.Text = "Món Bán Chạy";
            this.tabMonBanChay.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(314, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đến Ngày";
            // 
            // btThongKe3
            // 
            this.btThongKe3.Location = new System.Drawing.Point(707, 7);
            this.btThongKe3.Name = "btThongKe3";
            this.btThongKe3.Size = new System.Drawing.Size(100, 40);
            this.btThongKe3.TabIndex = 3;
            this.btThongKe3.Text = "Xem Thống Kê";
            this.btThongKe3.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.Location = new System.Drawing.Point(450, 27);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker6.TabIndex = 2;
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.Location = new System.Drawing.Point(61, 27);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView2);
            this.panel4.Location = new System.Drawing.Point(0, 61);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(850, 394);
            this.panel4.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(850, 391);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabChiPhi
            // 
            this.tabChiPhi.Controls.Add(this.label5);
            this.tabChiPhi.Controls.Add(this.btThongKe4);
            this.tabChiPhi.Controls.Add(this.dateTimePicker8);
            this.tabChiPhi.Controls.Add(this.dateTimePicker7);
            this.tabChiPhi.Controls.Add(this.dataGridView3);
            this.tabChiPhi.Location = new System.Drawing.Point(4, 22);
            this.tabChiPhi.Name = "tabChiPhi";
            this.tabChiPhi.Padding = new System.Windows.Forms.Padding(3);
            this.tabChiPhi.Size = new System.Drawing.Size(850, 455);
            this.tabChiPhi.TabIndex = 3;
            this.tabChiPhi.Text = "Chi Phí Phát Sinh";
            this.tabChiPhi.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(302, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Đến Ngày";
            // 
            // btThongKe4
            // 
            this.btThongKe4.Location = new System.Drawing.Point(700, 6);
            this.btThongKe4.Name = "btThongKe4";
            this.btThongKe4.Size = new System.Drawing.Size(104, 40);
            this.btThongKe4.TabIndex = 3;
            this.btThongKe4.Text = "Xem Thống Kê";
            this.btThongKe4.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker8
            // 
            this.dateTimePicker8.Location = new System.Drawing.Point(432, 26);
            this.dateTimePicker8.Name = "dateTimePicker8";
            this.dateTimePicker8.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker8.TabIndex = 2;
            // 
            // dateTimePicker7
            // 
            this.dateTimePicker7.Location = new System.Drawing.Point(56, 26);
            this.dateTimePicker7.Name = "dateTimePicker7";
            this.dateTimePicker7.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker7.TabIndex = 1;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(0, 67);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(850, 388);
            this.dataGridView3.TabIndex = 0;
            // 
            // tabBieuDo
            // 
            this.tabBieuDo.Controls.Add(this.panel5);
            this.tabBieuDo.Location = new System.Drawing.Point(4, 22);
            this.tabBieuDo.Name = "tabBieuDo";
            this.tabBieuDo.Padding = new System.Windows.Forms.Padding(3);
            this.tabBieuDo.Size = new System.Drawing.Size(850, 455);
            this.tabBieuDo.TabIndex = 4;
            this.tabBieuDo.Text = "Biểu Đồ Thống Kê";
            this.tabBieuDo.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chart1);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(850, 455);
            this.panel5.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(0, 3);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Doanh Thu";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(850, 449);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 505);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "BaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo";
            this.tabControl1.ResumeLayout(false);
            this.tabDoanhThu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabDoanhThuTCN.ResumeLayout(false);
            this.tabDoanhThuTCN.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabMonBanChay.ResumeLayout(false);
            this.tabMonBanChay.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabChiPhi.ResumeLayout(false);
            this.tabChiPhi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabBieuDo.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDoanhThu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btThongKe;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabDoanhThuTCN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabPage tabMonBanChay;
        private System.Windows.Forms.TabPage tabChiPhi;
        private System.Windows.Forms.TabPage tabBieuDo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbChonChiNhanh;
        private System.Windows.Forms.Button btThongKe2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btThongKe3;
        private System.Windows.Forms.DateTimePicker dateTimePicker6;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btThongKe4;
        private System.Windows.Forms.DateTimePicker dateTimePicker8;
        private System.Windows.Forms.DateTimePicker dateTimePicker7;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox1;
    }
}