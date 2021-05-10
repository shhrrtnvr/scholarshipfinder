
namespace Know_Your_Scholarship_
{
    partial class ExploreScholarships
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.scholarship_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.funding_professor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.university_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subject_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.referring_alumni = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.referring_faculty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Info;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.scholarship_id,
            this.funding_professor,
            this.university_name,
            this.subject_name,
            this.referring_alumni,
            this.referring_faculty,
            this.status});
            this.listView1.Font = new System.Drawing.Font("Linotte-Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 181);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(960, 568);
            this.listView1.TabIndex = 181;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // scholarship_id
            // 
            this.scholarship_id.Text = "ID";
            this.scholarship_id.Width = 50;
            // 
            // funding_professor
            // 
            this.funding_professor.Text = "Funding Professor";
            this.funding_professor.Width = 179;
            // 
            // university_name
            // 
            this.university_name.Text = "University";
            this.university_name.Width = 151;
            // 
            // subject_name
            // 
            this.subject_name.Text = "Subject";
            this.subject_name.Width = 124;
            // 
            // referring_alumni
            // 
            this.referring_alumni.Text = "Referring Alumni";
            this.referring_alumni.Width = 160;
            // 
            // referring_faculty
            // 
            this.referring_faculty.Text = "Referring Faculty";
            this.referring_faculty.Width = 159;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 102;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Linotte-SemiBold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 144);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(281, 31);
            this.comboBox1.TabIndex = 182;
            this.comboBox1.Text = "Search By";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Linotte-SemiBold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(395, 144);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(577, 31);
            this.comboBox2.TabIndex = 183;
            this.comboBox2.Text = "Search";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TimeBurner", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(246, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(517, 68);
            this.label5.TabIndex = 185;
            this.label5.Text = "Scholarship Explorer";
            // 
            // ExploreScholarships
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ExploreScholarships";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExploreScholarships";
            this.Load += new System.EventHandler(this.ExploreScholarships_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader scholarship_id;
        private System.Windows.Forms.ColumnHeader funding_professor;
        private System.Windows.Forms.ColumnHeader university_name;
        private System.Windows.Forms.ColumnHeader subject_name;
        private System.Windows.Forms.ColumnHeader referring_alumni;
        private System.Windows.Forms.ColumnHeader referring_faculty;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.Label label5;
    }
}