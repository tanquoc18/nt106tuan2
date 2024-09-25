using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFileExplorer
{
    public partial class Form1 : Form
    {
        private string currentPath = @"C:\";

        public Form1()
        {
            InitializeComponent();
            LoadDirectories();
            AddContextMenu();
        }

        private void LoadDirectories()
        {
            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(currentPath);
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;

            foreach (DirectoryInfo subDir in subDirs)
            {
                try
                {
                    if ((subDir.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden &&
                        (subDir.Attributes & FileAttributes.System) != FileAttributes.System)
                    {
                        aNode = new TreeNode(subDir.Name, 0, 0);
                        aNode.Tag = subDir;
                        subSubDirs = subDir.GetDirectories();

                        if (subSubDirs.Length != 0)
                        {
                            GetDirectories(subSubDirs, aNode);
                        }

                        nodeToAddTo.Nodes.Add(aNode);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"Access denied to directory: {subDir.FullName}");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine($"Directory not found: {subDir.FullName}");
                }
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DirectoryInfo nodeDirInfo = (DirectoryInfo)e.Node.Tag;
            LoadFiles(nodeDirInfo.FullName);
        }

        private void LoadFiles(string path)
        {
            currentPath = path;
            txtPath.Text = currentPath;
            listView1.Items.Clear();

            DirectoryInfo dir = new DirectoryInfo(currentPath);
            try
            {
                foreach (FileInfo file in dir.GetFiles())
                {
                    ListViewItem item = new ListViewItem(file.Name, 1);
                    item.SubItems.Add(file.Length.ToString());
                    item.SubItems.Add(file.LastAccessTime.ToShortDateString());
                    listView1.Items.Add(item);
                }

                foreach (DirectoryInfo folder in dir.GetDirectories())
                {
                    ListViewItem item = new ListViewItem(folder.Name, 0);
                    item.SubItems.Add("<Folder>");
                    item.SubItems.Add(folder.LastAccessTime.ToShortDateString());
                    listView1.Items.Add(item);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Không có quyền truy cập!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DirectoryInfo parentDir = Directory.GetParent(currentPath);
            if (parentDir != null)
            {
                LoadFiles(parentDir.FullName);
            }
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            string newFolderPath = Path.Combine(currentPath, "New Folder");
            Directory.CreateDirectory(newFolderPath);
            LoadFiles(currentPath);
        }

        private void AddContextMenu()
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem copyItem = new MenuItem("Copy", CopyFile);
            MenuItem cutItem = new MenuItem("Cut", CutFile);
            MenuItem pasteItem = new MenuItem("Paste", PasteFile);
            MenuItem deleteItem = new MenuItem("Delete", DeleteFile);
            MenuItem newFolderItem = new MenuItem("New Folder", CreateNewFolder);

            contextMenu.MenuItems.Add(copyItem);
            contextMenu.MenuItems.Add(cutItem);
            contextMenu.MenuItems.Add(pasteItem);
            contextMenu.MenuItems.Add(deleteItem);
            contextMenu.MenuItems.Add(newFolderItem);

            listView1.ContextMenu = contextMenu;
        }

        private string fileToCopy = null;
        private void CopyFile(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                fileToCopy = Path.Combine(currentPath, listView1.SelectedItems[0].Text);
            }
        }

        private string fileToCut = null;
        private void CutFile(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                fileToCut = Path.Combine(currentPath, listView1.SelectedItems[0].Text);
            }
        }

        private void PasteFile(object sender, EventArgs e)
        {
            string destinationPath = Path.Combine(currentPath, Path.GetFileName(fileToCopy ?? fileToCut));
            if (fileToCopy != null)
            {
                File.Copy(fileToCopy, destinationPath);
            }
            else if (fileToCut != null)
            {
                File.Move(fileToCut, destinationPath);
                fileToCut = null;
            }
            LoadFiles(currentPath);
        }

        private void DeleteFile(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string fileToDelete = Path.Combine(currentPath, listView1.SelectedItems[0].Text);
                if (File.Exists(fileToDelete))
                {
                    File.Delete(fileToDelete);
                }
                else if (Directory.Exists(fileToDelete))
                {
                    Directory.Delete(fileToDelete, true);
                }
                LoadFiles(currentPath);
            }
        }

        private void CreateNewFolder(object sender, EventArgs e)
        {
            string newFolderPath = Path.Combine(currentPath, "New Folder");
            Directory.CreateDirectory(newFolderPath);
            LoadFiles(currentPath);
        }
    }
}
