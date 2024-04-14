namespace WinFormsDemo;

partial class Main
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
        label1 = new Label();
        BtnCredencial = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AllowDrop = true;
        label1.AutoSize = true;
        label1.Location = new Point(49, 9);
        label1.Name = "label1";
        label1.Size = new Size(167, 15);
        label1.TabIndex = 0;
        label1.Text = "CREDENCIALES ACTUALES GIT";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // BtnCredencial
        // 
        BtnCredencial.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnCredencial.Location = new Point(49, 37);
        BtnCredencial.Name = "BtnCredencial";
        BtnCredencial.Size = new Size(167, 74);
        BtnCredencial.TabIndex = 1;
        BtnCredencial.Text = "Cargando...";
        BtnCredencial.UseVisualStyleBackColor = true;
        BtnCredencial.Click += BtnCredenciales_click;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(257, 123);
        Controls.Add(BtnCredencial);
        Controls.Add(label1);
        Name = "Main";
        Text = "Alternador GIT";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Button BtnCredencial;
}
