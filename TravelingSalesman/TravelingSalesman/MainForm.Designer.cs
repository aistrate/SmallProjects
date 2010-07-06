namespace TravelingSalesman
{
    partial class MainForm
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
            this.btnGo = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabList = new System.Windows.Forms.TabPage();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.tabGraph = new System.Windows.Forms.TabPage();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.tabDrawGraph = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.picDrawGraph = new System.Windows.Forms.PictureBox();
            this.cboGraphType = new System.Windows.Forms.ComboBox();
            this.cboAlgorithm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPermutations = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabList.SuspendLayout();
            this.tabGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.tabDrawGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDrawGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(12, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabList);
            this.tabControl.Controls.Add(this.tabGraph);
            this.tabControl.Controls.Add(this.tabDrawGraph);
            this.tabControl.Location = new System.Drawing.Point(12, 41);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1158, 634);
            this.tabControl.TabIndex = 2;
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.txtResults);
            this.tabList.Location = new System.Drawing.Point(4, 22);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(1150, 608);
            this.tabList.TabIndex = 0;
            this.tabList.Text = "List";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(0, 2);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(1144, 600);
            this.txtResults.TabIndex = 2;
            // 
            // tabGraph
            // 
            this.tabGraph.Controls.Add(this.picGraph);
            this.tabGraph.Location = new System.Drawing.Point(4, 22);
            this.tabGraph.Name = "tabGraph";
            this.tabGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabGraph.Size = new System.Drawing.Size(1150, 608);
            this.tabGraph.TabIndex = 1;
            this.tabGraph.Text = "Graph";
            this.tabGraph.UseVisualStyleBackColor = true;
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.Transparent;
            this.picGraph.Location = new System.Drawing.Point(7, 6);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(1137, 596);
            this.picGraph.TabIndex = 0;
            this.picGraph.TabStop = false;
            // 
            // tabDrawGraph
            // 
            this.tabDrawGraph.Controls.Add(this.btnClear);
            this.tabDrawGraph.Controls.Add(this.btnStartStop);
            this.tabDrawGraph.Controls.Add(this.picDrawGraph);
            this.tabDrawGraph.Location = new System.Drawing.Point(4, 22);
            this.tabDrawGraph.Name = "tabDrawGraph";
            this.tabDrawGraph.Size = new System.Drawing.Size(1150, 608);
            this.tabDrawGraph.TabIndex = 2;
            this.tabDrawGraph.Text = "Draw Graph";
            this.tabDrawGraph.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(252, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(14, 9);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // picDrawGraph
            // 
            this.picDrawGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picDrawGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDrawGraph.Location = new System.Drawing.Point(4, 38);
            this.picDrawGraph.Name = "picDrawGraph";
            this.picDrawGraph.Size = new System.Drawing.Size(1143, 567);
            this.picDrawGraph.TabIndex = 0;
            this.picDrawGraph.TabStop = false;
            this.picDrawGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDrawGraph_MouseClick);
            // 
            // cboGraphType
            // 
            this.cboGraphType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGraphType.FormattingEnabled = true;
            this.cboGraphType.Items.AddRange(new object[] {
            "Cycle",
            "Straight Line",
            "Rows And Columns",
            "All Three",
            "Custom"});
            this.cboGraphType.Location = new System.Drawing.Point(157, 12);
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.Size = new System.Drawing.Size(121, 21);
            this.cboGraphType.TabIndex = 3;
            this.cboGraphType.SelectedIndexChanged += new System.EventHandler(this.cboGraphType_SelectedIndexChanged);
            // 
            // cboAlgorithm
            // 
            this.cboAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlgorithm.FormattingEnabled = true;
            this.cboAlgorithm.Items.AddRange(new object[] {
            "Nearest Neighbor",
            "Nearest Neighbor (All)",
            "Closest Pair",
            "Optimal TSP",
            "Incremental Insertion",
            "Incremental Insertion (All)",
            "Rough Scan",
            "Scan",
            "Radial Scan",
            "Random Path"});
            this.cboAlgorithm.Location = new System.Drawing.Point(368, 12);
            this.cboAlgorithm.Name = "cboAlgorithm";
            this.cboAlgorithm.Size = new System.Drawing.Size(147, 21);
            this.cboAlgorithm.TabIndex = 4;
            this.cboAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cboAlgorithm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Graph:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Algorithm:";
            // 
            // btnPermutations
            // 
            this.btnPermutations.Location = new System.Drawing.Point(765, 12);
            this.btnPermutations.Name = "btnPermutations";
            this.btnPermutations.Size = new System.Drawing.Size(115, 23);
            this.btnPermutations.TabIndex = 7;
            this.btnPermutations.Text = "Permutations";
            this.btnPermutations.UseVisualStyleBackColor = true;
            this.btnPermutations.Click += new System.EventHandler(this.btnPermutations_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(551, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cost:";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(588, 15);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(27, 13);
            this.lblCost.TabIndex = 9;
            this.lblCost.Text = "     ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 687);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPermutations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAlgorithm);
            this.Controls.Add(this.cboGraphType);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnGo);
            this.Name = "MainForm";
            this.Text = "Traveling Salesman";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            this.tabList.PerformLayout();
            this.tabGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.tabDrawGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDrawGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.TabPage tabGraph;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.ComboBox cboGraphType;
        private System.Windows.Forms.ComboBox cboAlgorithm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPermutations;
        private System.Windows.Forms.TabPage tabDrawGraph;
        private System.Windows.Forms.PictureBox picDrawGraph;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCost;
    }
}

