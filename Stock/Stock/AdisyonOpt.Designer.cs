namespace Stock
{
    partial class AdisyonOpt
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
            this.xnxx = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // xnxx
            // 
            this.xnxx.Location = new System.Drawing.Point(1, 3);
            this.xnxx.Name = "xnxx";
            this.xnxx.Size = new System.Drawing.Size(683, 731);
            this.xnxx.TabIndex = 0;
            // 
            // AdisyonOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1430, 735);
            this.Controls.Add(this.xnxx);
            this.Name = "AdisyonOpt";
            this.Text = "AdisyonOpt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel xnxx;
    }
}