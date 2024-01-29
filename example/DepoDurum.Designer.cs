namespace example
{
    partial class DepoDurum
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.exampleDataSet = new example.exampleDataSet();
            this.vÜrünTotalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_ÜrünTotalTableAdapter = new example.exampleDataSetTableAdapters.v_ÜrünTotalTableAdapter();
            this.ürünIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ürünAdıDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalProductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exampleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vÜrünTotalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-2, 398);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(756, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Geri Dön";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ürünIdDataGridViewTextBoxColumn,
            this.ürünAdıDataGridViewTextBoxColumn,
            this.totalProductDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.vÜrünTotalBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(53, 58);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(658, 300);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // exampleDataSet
            // 
            this.exampleDataSet.DataSetName = "exampleDataSet";
            this.exampleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vÜrünTotalBindingSource
            // 
            this.vÜrünTotalBindingSource.DataMember = "v_ÜrünTotal";
            this.vÜrünTotalBindingSource.DataSource = this.exampleDataSet;
            // 
            // v_ÜrünTotalTableAdapter
            // 
            this.v_ÜrünTotalTableAdapter.ClearBeforeFill = true;
            // 
            // ürünIdDataGridViewTextBoxColumn
            // 
            this.ürünIdDataGridViewTextBoxColumn.DataPropertyName = "ürünId";
            this.ürünIdDataGridViewTextBoxColumn.HeaderText = "Ürün ID";
            this.ürünIdDataGridViewTextBoxColumn.Name = "ürünIdDataGridViewTextBoxColumn";
            this.ürünIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.ürünIdDataGridViewTextBoxColumn.Width = 175;
            // 
            // ürünAdıDataGridViewTextBoxColumn
            // 
            this.ürünAdıDataGridViewTextBoxColumn.DataPropertyName = "ürünAdı";
            this.ürünAdıDataGridViewTextBoxColumn.HeaderText = "Ad";
            this.ürünAdıDataGridViewTextBoxColumn.Name = "ürünAdıDataGridViewTextBoxColumn";
            this.ürünAdıDataGridViewTextBoxColumn.ReadOnly = true;
            this.ürünAdıDataGridViewTextBoxColumn.Width = 200;
            // 
            // totalProductDataGridViewTextBoxColumn
            // 
            this.totalProductDataGridViewTextBoxColumn.DataPropertyName = "Total Product";
            this.totalProductDataGridViewTextBoxColumn.HeaderText = "Toplam Ürün";
            this.totalProductDataGridViewTextBoxColumn.Name = "totalProductDataGridViewTextBoxColumn";
            this.totalProductDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalProductDataGridViewTextBoxColumn.Width = 230;
            // 
            // DepoDurum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::example.Properties.Resources.Adsız_tasarım__8_;
            this.ClientSize = new System.Drawing.Size(750, 449);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DepoDurum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DepoDurum";
            this.Load += new System.EventHandler(this.DepoDurum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exampleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vÜrünTotalBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private exampleDataSet exampleDataSet;
        private System.Windows.Forms.BindingSource vÜrünTotalBindingSource;
        private exampleDataSetTableAdapters.v_ÜrünTotalTableAdapter v_ÜrünTotalTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ürünIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ürünAdıDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalProductDataGridViewTextBoxColumn;
    }
}