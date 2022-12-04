namespace AutosplitGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MapSelection = new System.Windows.Forms.ListBox();
            this.AddToSplitsButton = new System.Windows.Forms.Button();
            this.Splits = new System.Windows.Forms.ListBox();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.LoadLocalMapsButton = new System.Windows.Forms.Button();
            this.FilterCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.UseFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // MapSelection
            // 
            this.MapSelection.FormattingEnabled = true;
            this.MapSelection.ItemHeight = 15;
            this.MapSelection.Location = new System.Drawing.Point(28, 63);
            this.MapSelection.Name = "MapSelection";
            this.MapSelection.Size = new System.Drawing.Size(264, 214);
            this.MapSelection.TabIndex = 0;
            this.MapSelection.DoubleClick += new System.EventHandler(this.MapSelection_DoubleClick);
            // 
            // AddToSplitsButton
            // 
            this.AddToSplitsButton.Location = new System.Drawing.Point(338, 128);
            this.AddToSplitsButton.Name = "AddToSplitsButton";
            this.AddToSplitsButton.Size = new System.Drawing.Size(52, 53);
            this.AddToSplitsButton.TabIndex = 1;
            this.AddToSplitsButton.Text = "->";
            this.AddToSplitsButton.UseVisualStyleBackColor = true;
            this.AddToSplitsButton.Click += new System.EventHandler(this.AddToSplitsButton_Click);
            // 
            // Splits
            // 
            this.Splits.FormattingEnabled = true;
            this.Splits.ItemHeight = 15;
            this.Splits.Location = new System.Drawing.Point(433, 63);
            this.Splits.Name = "Splits";
            this.Splits.Size = new System.Drawing.Size(231, 214);
            this.Splits.TabIndex = 2;
            this.Splits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Splits_KeyDown);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Location = new System.Drawing.Point(670, 112);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(35, 36);
            this.MoveUpButton.TabIndex = 3;
            this.MoveUpButton.Text = "^";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Location = new System.Drawing.Point(670, 154);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(35, 38);
            this.MoveDownButton.TabIndex = 4;
            this.MoveDownButton.Text = "v";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(670, 198);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(71, 58);
            this.RemoveButton.TabIndex = 5;
            this.RemoveButton.Text = "remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(240, 312);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(237, 92);
            this.GenerateButton.TabIndex = 6;
            this.GenerateButton.Text = "Generate!";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // LoadLocalMapsButton
            // 
            this.LoadLocalMapsButton.Location = new System.Drawing.Point(28, 12);
            this.LoadLocalMapsButton.Name = "LoadLocalMapsButton";
            this.LoadLocalMapsButton.Size = new System.Drawing.Size(120, 32);
            this.LoadLocalMapsButton.TabIndex = 7;
            this.LoadLocalMapsButton.Text = "load local mapfile";
            this.LoadLocalMapsButton.UseVisualStyleBackColor = true;
            this.LoadLocalMapsButton.Click += new System.EventHandler(this.LoadLocalMapsButton_Click);
            // 
            // FilterCheckListBox
            // 
            this.FilterCheckListBox.CheckOnClick = true;
            this.FilterCheckListBox.Enabled = false;
            this.FilterCheckListBox.FormattingEnabled = true;
            this.FilterCheckListBox.Location = new System.Drawing.Point(46, 328);
            this.FilterCheckListBox.Name = "FilterCheckListBox";
            this.FilterCheckListBox.Size = new System.Drawing.Size(102, 76);
            this.FilterCheckListBox.TabIndex = 8;
            this.FilterCheckListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.FilterCheckListBox_ItemCheck);
            // 
            // UseFilterCheckBox
            // 
            this.UseFilterCheckBox.AutoSize = true;
            this.UseFilterCheckBox.Location = new System.Drawing.Point(46, 294);
            this.UseFilterCheckBox.Name = "UseFilterCheckBox";
            this.UseFilterCheckBox.Size = new System.Drawing.Size(78, 19);
            this.UseFilterCheckBox.TabIndex = 9;
            this.UseFilterCheckBox.Text = "use Filters";
            this.UseFilterCheckBox.UseVisualStyleBackColor = true;
            this.UseFilterCheckBox.CheckedChanged += new System.EventHandler(this.UseFilterCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UseFilterCheckBox);
            this.Controls.Add(this.FilterCheckListBox);
            this.Controls.Add(this.LoadLocalMapsButton);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.MoveDownButton);
            this.Controls.Add(this.MoveUpButton);
            this.Controls.Add(this.Splits);
            this.Controls.Add(this.AddToSplitsButton);
            this.Controls.Add(this.MapSelection);
            this.Name = "Form1";
            this.Text = "Burndi\'s Botched Split Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox MapSelection;
        private Button AddToSplitsButton;
        private ListBox Splits;
        private Button MoveUpButton;
        private Button MoveDownButton;
        private Button RemoveButton;
        private Button GenerateButton;
        private Button LoadLocalMapsButton;
        private CheckedListBox FilterCheckListBox;
        private CheckBox UseFilterCheckBox;
    }
}