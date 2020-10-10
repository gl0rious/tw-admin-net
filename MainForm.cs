using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace tw_app
{
    public partial class MainForm  : Form
    {
        DB db = null;
        List<string> validRoles;
        List<string> userRoles;
        List<string> editedUserRoles = new List<string>();
        List<Tuple<string, string>> users;
        List<TreeNode> roleNodes = new List<TreeNode>();
        XElement configRoles;
        Font normalFont;
        Font boldFont;
        string selectedUser;

        public MainForm()
        {
            InitializeComponent();
        }
       
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm dialog = new LoginForm();
            if (dialog.ShowDialog() == DialogResult.Yes)
            {
                this.Text = string.Format("TW Admin [{0}]",dialog.Username);
            } else
                this.Close();
            normalFont = rolesTree.Font;
            boldFont = new Font(normalFont,FontStyle.Bold);
            configRoles = XElement.Load(@"form_roles.xml");
            db = dialog.DataBase;
            setValidRoles();
            initUsersTable();
        }
        
        private void setValidRoles()
        {            
            validRoles = db.Get_all_db_roles();
            List<string> configValidRoles = new List<string>();
            foreach (var appRoles in configRoles.Elements())
                foreach (var roleGroup in appRoles.Elements())
                    foreach (var role in roleGroup.Elements())
                        configValidRoles.Add(role.Name.LocalName);
            validRoles.RemoveAll(role => !configValidRoles.Contains(role));
        }

        private void initUsersTable()
        {
            users = db.GetUsersList();
            foreach (var user in users)
                usersGridView.Rows.Add(user.Item2,user.Item1);
            usersGridView.Sort(usersGridView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void usersGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedUser = usersGridView.Rows[e.RowIndex].Cells[0].Value as string;
            showUserTree();
        }

        private void showUserTree()
        {
            userRoles = db.GetUserRoles(selectedUser);
            userRoles.RemoveAll(role => !validRoles.Contains(role));
            editedUserRoles.Clear();
            editedUserRoles.AddRange(userRoles);
            rolesTree.Nodes.Clear();
            foreach (var appRoles in configRoles.Elements())
            {
                var appNode = new HiddenCheckBoxTreeNode(appRoles.Name.LocalName);
                appNode.Name = appRoles.Name.LocalName;
                int appCount = 0;
                foreach (var roleGroup in appRoles.Elements())
                {
                    var groupNode = new HiddenCheckBoxTreeNode(roleGroup.Name.LocalName);
                    groupNode.Name = roleGroup.Name.LocalName;
                    int groupCount = 0;
                    foreach (var role in roleGroup.Elements())
                    {
                        if (userRoles.Contains(role.Name.LocalName))
                        {
                            var roleNode = groupNode.Nodes.Add(role.Value.ToString());
                            roleNode.Name = role.Name.LocalName;
                            groupCount++;
                            appCount++;
                        }
                    }
                    if (groupNode.Nodes.Count > 0)
                    {
                        groupNode.Text = $"{groupNode.Name} [{groupCount}]";
                        appNode.Nodes.Add(groupNode);
                    }
                }
                if (appNode.Nodes.Count > 0) {
                    appNode.Text = $"{appNode.Name} [{appCount}]";
                    rolesTree.Nodes.Add(appNode);
                }
            }
            rolesTree.ExpandAll();
            rolesTree.Sort();
            userLabel.Text = selectedUser + $" [{editedUserRoles.Count()}]";
        }
        bool editMode = false;
        private void edit_sbtn_Click(object sender, EventArgs e)
        {
            usersGridView.Enabled = false;
            cancel_sbtn.Enabled = true;
            rolesTree.CheckBoxes = true;
            edit_sbtn.Enabled = false;
            save_sbtn.Enabled = true;
            copy_sbtn.Enabled = true;
            rolesTree.Nodes.Clear();
            editMode = true;            
            foreach (var appRoles in configRoles.Elements())
            {
                var appNode = new TreeNode(appRoles.Name.LocalName);
                appNode.Name = appRoles.Name.LocalName;
                foreach (var roleGroup in appRoles.Elements())
                {
                    var groupNode = new TreeNode(roleGroup.Name.LocalName);
                    groupNode.Name = roleGroup.Name.LocalName;
                    foreach (var role in roleGroup.Elements())
                    {
                        string roleName = role.Name.LocalName;
                        if (validRoles.Contains(roleName)) {
                            var roleNode = groupNode.Nodes.Add(role.Value.ToString());
                            roleNode.Name = roleName;
                            if (userRoles.Contains(roleName))
                            {
                                roleNode.Checked = true;
                                roleNode.NodeFont = boldFont;
                            }
                        }
                    }
                    appNode.Nodes.Add(groupNode);
                }
                rolesTree.Nodes.Add(appNode);
            }
            //rolesTree.Sort();
            editMode = false;
            foreach (TreeNode appNode in rolesTree.Nodes)
                setCount(appNode);
        }

        private void save_sbtn_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Save","Save changes!",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                saveUserRoles();
            }

            showUserTree();

            usersGridView.Enabled = true;
            cancel_sbtn.Enabled = false;
            rolesTree.CheckBoxes = false;
            rolesTree.ExpandAll();
            edit_sbtn.Enabled = true;
            save_sbtn.Enabled = false;
            copy_sbtn.Enabled = false;
        }

        private void saveUserRoles()
        {
            var userRoles = db.GetUserRoles(selectedUser);
            foreach (TreeNode appNode in rolesTree.Nodes)
            {
                foreach (TreeNode groupNode in appNode.Nodes)
                {
                    foreach (TreeNode roleNode in groupNode.Nodes)
                    {
                        string roleName = roleNode.Name;
                        if (roleNode.Checked && !userRoles.Contains(roleName))
                            db.addRoleToUser(selectedUser, roleName);
                        if (!roleNode.Checked && userRoles.Contains(roleName))
                            db.removeRoleFromUser(selectedUser, roleName);
                    }
                }
            }
        }

        private void cancel_sbtn_Click(object sender, EventArgs e)
        {
            usersGridView.Enabled = true;
            edit_sbtn.Enabled = true;
            cancel_sbtn.Enabled = false;
            save_sbtn.Enabled = false;
            copy_sbtn.Enabled = false;
            rolesTree.CheckBoxes = false;

            showUserTree();
        }

        private void rolesTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null && e.Node.Parent.Parent != null)
            {
                if (e.Node.Checked && !editedUserRoles.Contains(e.Node.Name))
                    editedUserRoles.Add(e.Node.Name);
                if (!e.Node.Checked && editedUserRoles.Contains(e.Node.Name))
                    editedUserRoles.Remove(e.Node.Name);
                if(!editMode)
                    setCount(e.Node.Parent.Parent);
                userLabel.Text = selectedUser + $" [{editedUserRoles.Count()}]";
            }
            e.Node.NodeFont = e.Node.Checked ? boldFont : normalFont;
        }

        void setCount(TreeNode appNode)
        {
            int appCount = 0;
            foreach (TreeNode groupNode in appNode.Nodes)
            {
                int count = groupNode.Nodes.Cast<TreeNode>().Count(node => node.Checked);
                groupNode.Checked = count > 0;
                groupNode.Text = groupNode.Name + (count > 0 ? $" [{count}]" : "");
                appCount += count;
            }
            appNode.Checked = appCount > 0;
            appNode.Text = appNode.Name + (appCount > 0 ? $" [{appCount}]" : "");
        }

        private void copy_sbtn_Click(object sender, EventArgs e)
        {
            CopyForm form = new CopyForm(users);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var fromUserRoles = db.GetUserRoles(form.selectedUser);
                foreach (TreeNode appNode in rolesTree.Nodes)
                {
                    foreach (TreeNode groupNode in appNode.Nodes)
                    {
                        foreach (TreeNode roleNode in groupNode.Nodes)
                        {
                            roleNode.Checked = fromUserRoles.Contains(roleNode.Name);
                        }
                    }
                }
            }
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rolesTree.ExpandAll();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rolesTree.CollapseAll();
        }
    }
}
