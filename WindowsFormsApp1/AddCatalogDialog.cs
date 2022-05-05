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
    public partial class AddCatalogDialog : Form
    {
        private string Path;
        public TreeView Tmp;
        public AddCatalogDialog(string s)
        {
            InitializeComponent();
            Path = s;
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path + "\\" + textBoxAddCatalog.Text);
                Tmp.Nodes.Add(textBoxAddCatalog.Text);
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    
    }
}
