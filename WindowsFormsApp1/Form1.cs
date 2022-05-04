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
        private string currentDirectory = "";
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
            try
            {
                if (Directory.Exists(e.Node.Text))
                {
                    string[] s = e.Node.Text.Split('\\');
                    currentDirectory += s[s.Length-1];
                    textBoxPath.Text = currentDirectory;
                    leftTree.Nodes.Clear();
                    foreach (string directory in Directory.GetDirectories(e.Node.Text))
                    {
                        leftTree.Nodes.Add(new TreeNode(directory));
                    }
                    foreach (string item in Directory.GetFiles(e.Node.Text))
                    {
                        leftTree.Nodes.Add(new TreeNode(item));
                    }
                }               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void rightTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (Directory.Exists(e.Node.Text))
                {
                    currentDirectory += e.Node.Text;
                    textBoxPath.Text = currentDirectory;
                    rightTree.Nodes.Clear();
                    foreach (string directory in Directory.GetDirectories(e.Node.Text))
                    {
                        rightTree.Nodes.Add(new TreeNode(directory));
                    }
                    foreach (string item in Directory.GetFiles(e.Node.Text))
                    {
                        rightTree.Nodes.Add(new TreeNode(item));
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        
    }
}
