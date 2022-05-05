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
    public partial class RenameDialog : Form
    {
        private string Path;
        public TreeNode TmpNode;
        public TreeView treeView;
        public RenameDialog()
        {
            InitializeComponent();
        }
        public RenameDialog(string s)
        {
            InitializeComponent();
            Path = s;
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Path))
            {
                Directory.Move(Path,Path + "\\" + textBoxRename.Text);               
                treeView.Nodes.Remove(TmpNode);
                treeView.Nodes.Add(new TreeNode(textBoxRename.Text));
            }
            else
            {
                if (File.Exists(Path))
                {
                    
                    File.Move(Path, Path + "\\" + textBoxRename.Text);
                    treeView.Nodes.Remove(TmpNode);
                    treeView.Nodes.Add(new TreeNode(textBoxRename.Text));
                }
            }
            Close();
        }
    }
}
