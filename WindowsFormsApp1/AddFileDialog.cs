using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class AddFileDialog : Form
    {
        public AddFileDialog()
        {
            InitializeComponent();
        }
        private string Path;
        public TreeView Tmp;
        public AddFileDialog(string s)
        {
            InitializeComponent();
            Path = s;
        }
        private void AddFileDialog_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Path))
            {
                File.Create(Path + "\\" + textBoxAddFile.Text);
                Tmp.Nodes.Add(textBoxAddFile.Text);
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
