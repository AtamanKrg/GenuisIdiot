namespace GeniusIdiotWindowsFormsApp
{
    partial class ResultsForm
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
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiagnoseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.ResultColumn,
            this.DiagnoseColumn});
            this.resultsDataGridView.Location = new System.Drawing.Point(13, 13);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.RowHeadersWidth = 51;
            this.resultsDataGridView.RowTemplate.Height = 24;
            this.resultsDataGridView.Size = new System.Drawing.Size(428, 150);
            this.resultsDataGridView.TabIndex = 0;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Имя";
            this.NameColumn.MinimumWidth = 6;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 125;
            // 
            // ResultColumn
            // 
            this.ResultColumn.HeaderText = "Результат";
            this.ResultColumn.MinimumWidth = 6;
            this.ResultColumn.Name = "ResultColumn";
            this.ResultColumn.Width = 125;
            // 
            // DiagnoseColumn
            // 
            this.DiagnoseColumn.HeaderText = "Диагноз";
            this.DiagnoseColumn.MinimumWidth = 6;
            this.DiagnoseColumn.Name = "DiagnoseColumn";
            this.DiagnoseColumn.Width = 125;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 450);
            this.Controls.Add(this.resultsDataGridView);
            this.Name = "ResultsForm";
            this.Text = "Результаты";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiagnoseColumn;
    }
}