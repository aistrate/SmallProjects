namespace Lissajous
{
    partial class Lissajous
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
            this.lblEquations = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.lblB = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.lblD = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.picDrawing = new System.Windows.Forms.PictureBox();
            this.lblBy = new System.Windows.Forms.Label();
            this.lblPi = new System.Windows.Forms.Label();
            this.txtDeltaT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDrawing)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEquations
            // 
            this.lblEquations.AutoSize = true;
            this.lblEquations.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquations.Location = new System.Drawing.Point(16, 10);
            this.lblEquations.Name = "lblEquations";
            this.lblEquations.Size = new System.Drawing.Size(226, 18);
            this.lblEquations.TabIndex = 0;
            this.lblEquations.Text = "x = sin(at+δ),     y = cos(bt)";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(16, 42);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(20, 14);
            this.lblA.TabIndex = 1;
            this.lblA.Text = "a:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(42, 38);
            this.txtA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(132, 22);
            this.txtA.TabIndex = 2;
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(473, 39);
            this.txtB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(132, 22);
            this.txtB.TabIndex = 4;
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(447, 42);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(20, 14);
            this.lblB.TabIndex = 3;
            this.lblB.Text = "b:";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(218, 39);
            this.txtD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(132, 22);
            this.txtD.TabIndex = 6;
            this.txtD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Location = new System.Drawing.Point(192, 42);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(20, 14);
            this.lblD.TabIndex = 5;
            this.lblD.Text = "δ:";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(689, 36);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(130, 24);
            this.btnDraw.TabIndex = 7;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(473, 8);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(130, 24);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // picDrawing
            // 
            this.picDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picDrawing.BackColor = System.Drawing.Color.White;
            this.picDrawing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDrawing.Location = new System.Drawing.Point(19, 98);
            this.picDrawing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picDrawing.Name = "picDrawing";
            this.picDrawing.Size = new System.Drawing.Size(800, 800);
            this.picDrawing.TabIndex = 9;
            this.picDrawing.TabStop = false;
            this.picDrawing.Click += new System.EventHandler(this.picDrawing_Click);
            // 
            // lblBy
            // 
            this.lblBy.AutoSize = true;
            this.lblBy.Location = new System.Drawing.Point(359, 42);
            this.lblBy.Name = "lblBy";
            this.lblBy.Size = new System.Drawing.Size(17, 14);
            this.lblBy.TabIndex = 10;
            this.lblBy.Text = "×";
            // 
            // lblPi
            // 
            this.lblPi.AutoSize = true;
            this.lblPi.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPi.Location = new System.Drawing.Point(373, 40);
            this.lblPi.Name = "lblPi";
            this.lblPi.Size = new System.Drawing.Size(16, 18);
            this.lblPi.TabIndex = 11;
            this.lblPi.Text = "π";
            // 
            // txtDeltaT
            // 
            this.txtDeltaT.AcceptsReturn = true;
            this.txtDeltaT.Location = new System.Drawing.Point(42, 68);
            this.txtDeltaT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDeltaT.Name = "txtDeltaT";
            this.txtDeltaT.Size = new System.Drawing.Size(132, 22);
            this.txtDeltaT.TabIndex = 13;
            this.txtDeltaT.Text = "0.01";
            this.txtDeltaT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Δt:";
            // 
            // Lissajous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 916);
            this.Controls.Add(this.txtDeltaT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPi);
            this.Controls.Add(this.lblBy);
            this.Controls.Add(this.picDrawing);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblEquations);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Lissajous";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lissajous";
            ((System.ComponentModel.ISupportInitialize)(this.picDrawing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEquations;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox picDrawing;
        private System.Windows.Forms.Label lblBy;
        private System.Windows.Forms.Label lblPi;
        private System.Windows.Forms.TextBox txtDeltaT;
        private System.Windows.Forms.Label label1;
    }
}

