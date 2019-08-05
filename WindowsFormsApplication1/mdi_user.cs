using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class mdi_user : Form
    {
        private int i = 0;

        public mdi_user()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form mdichildForm in MdiChildren)
            {
                mdichildForm.Close();
            }
        }

        private void addNewMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //navigates to new media 
            add_media am = new add_media();
            am.Show();
        }

        private void viewMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //navigates to view media 
            view_media vm = new view_media();
            vm.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //navigates to add student info 
            add_student_info asi = new add_student_info();
            asi.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //navigates to view student info 
            view_student_info vsi = new view_student_info();
            vsi.Show();
        }

        private void issueMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //nagigates to issue media tool strip menu 
            issue_media ib = new issue_media();
            ib.Show();
        }

        private void returnMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // navigates to return media 
            return_media rm = new return_media();
            rm.Show();
        }
        
        private void MediaStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //navigates to media stock page 
            media_stock ms = new media_stock();
            ms.Show();
        }
       
        private void Button1_Click(object sender, EventArgs e)
        {
            // navigates to the home page when the user needs to log out
            login LI = new login();
            LI.Show();
            this.Hide();
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form mdichildForm = new Form();
            mdichildForm.MdiParent = this;
            mdichildForm.Text = "Window " + i++;
            mdichildForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog DialogueOpen = new OpenFileDialog();
            DialogueOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            DialogueOpen.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (DialogueOpen.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = DialogueOpen.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialogue = new SaveFileDialog();
            saveDialogue.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveDialogue.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveDialogue.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveDialogue.FileName;
            }
        }

        private void Mdi_user_Load(object sender, EventArgs e)
        {

        }
    }
}
