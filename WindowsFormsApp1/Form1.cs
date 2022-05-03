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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                leftTree.Nodes.Add(new TreeNode(drive.Name));
            }
            foreach (TreeNode treeNode in leftTree.Nodes)
            {
                rightTree.Nodes.Add(new TreeNode(treeNode.Text));
            }
        }

        private void leftTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            leftTree.Nodes.Clear();
            foreach (string directory in Directory.GetDirectories(node.Text))
            {
                leftTree.Nodes.Add(new TreeNode(directory));
            }
            foreach (string item in Directory.GetFiles(node.Text))
            {
                leftTree.Nodes.Add(new TreeNode(item));
            }
        }

        private void rightTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            rightTree.Nodes.Clear();
            foreach (string directory in Directory.GetDirectories(node.Text))
            {
                rightTree.Nodes.Add(new TreeNode(directory));
            }
            foreach (string item in Directory.GetFiles(node.Text))
            {
                rightTree.Nodes.Add(new TreeNode(item));
            }
        }
    }
}
