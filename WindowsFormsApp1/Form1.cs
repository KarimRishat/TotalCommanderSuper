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
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string currentDirectoryLeft;
        private string currentDirectoryRight;
        public TreeView treeCurent;

        private TreeNode SelectedNode;
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
                SelectedNode = e.Node;
                if (Directory.Exists(String.Concat(currentDirectoryLeft,e.Node.Text)))
                {
                    if (String.IsNullOrEmpty(currentDirectoryLeft))
                    {
                        currentDirectoryLeft = e.Node.Text;
                    }
                    else
                    {
                        currentDirectoryLeft = currentDirectoryLeft + e.Node.Text+"\\";
                    }                    
                    textBoxPath1.Text = currentDirectoryLeft;
                    leftTree.Nodes.Clear();
                    
                    foreach (string directory in Directory.GetDirectories(currentDirectoryLeft))
                    {
                        DirectoryInfo directoryTmp = new DirectoryInfo(directory);
                        leftTree.Nodes.Add(new TreeNode(directoryTmp.Name));
                    }
                    foreach (string item in Directory.GetFiles(currentDirectoryLeft))
                    {
                        DirectoryInfo directoryTmp = new DirectoryInfo(item);
                        leftTree.Nodes.Add(new TreeNode(directoryTmp.Name));
                    }
                }
                else
                {
                    if (File.Exists(String.Concat(currentDirectoryLeft,e.Node.Text)))
                    {
                        Process.Start(String.Concat(currentDirectoryLeft, e.Node.Text));
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
                SelectedNode = e.Node;
                leftTree_NodeMouseClick(sender, e);
                if (Directory.Exists(String.Concat(currentDirectoryRight, e.Node.Text)))
                {
                    if (String.IsNullOrEmpty(currentDirectoryRight))
                    {
                        currentDirectoryRight = e.Node.Text;
                    }
                    else
                    {
                        currentDirectoryRight = currentDirectoryRight + e.Node.Text + "\\";
                    }
                    textBoxPath2.Text = currentDirectoryRight;
                    rightTree.Nodes.Clear();

                    foreach (string directory in Directory.GetDirectories(currentDirectoryRight))
                    {
                        DirectoryInfo directoryTmp = new DirectoryInfo(directory);
                        rightTree.Nodes.Add(new TreeNode(directoryTmp.Name));
                    }
                    foreach (string item in Directory.GetFiles(currentDirectoryRight))
                    {
                        DirectoryInfo directoryTmp = new DirectoryInfo(item);
                        rightTree.Nodes.Add(new TreeNode(directoryTmp.Name));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void toolStripButtonAddFile_Click(object sender, EventArgs e)
        {
            string s = "";
            TreeView tmp = new TreeView();
            if (leftTree.Equals(SelectedNode.TreeView))
            {
                s = currentDirectoryLeft;
                tmp = leftTree;
            }
            else
            {
                if (rightTree.Equals(SelectedNode.TreeView))
                {
                    s = currentDirectoryRight;
                    tmp = rightTree;
                }
            }
            AddFileDialog addFile = new AddFileDialog(s);
            addFile.Tmp = tmp;
            addFile.Show();
        }

        private void leftTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedNode = e.Node;
        }

        private void toolStripButtonAddDir_Click(object sender, EventArgs e)
        {
            string s = "";
            TreeView tmp = new TreeView();
            if (leftTree.Equals(SelectedNode.TreeView))
            {
                s = currentDirectoryLeft;
                tmp = leftTree;
            }
            else
            {
                if (rightTree.Equals(SelectedNode.TreeView))
                {
                    s = currentDirectoryRight;
                    tmp = rightTree;
                }
            }
            AddCatalogDialog addDir = new AddCatalogDialog(s);
            addDir.Tmp = tmp;
            addDir.Show();
        }

        private void toolStripButtonRename_Click(object sender, EventArgs e)
        {
            string s = "";
            TreeView tmp = new TreeView();
            if (leftTree.Equals(SelectedNode.TreeView))
            {
                s = currentDirectoryLeft;
                treeCurent = leftTree;
            }
            else
            {
                if (rightTree.Equals(SelectedNode.TreeView))
                {
                    s = currentDirectoryRight;
                    treeCurent = rightTree;
                }
            }
            RenameDialog rename = new RenameDialog(s);            
            rename.TmpNode = SelectedNode;
            rename.treeView = treeCurent;
            rename.Show();
        }
    }
}
