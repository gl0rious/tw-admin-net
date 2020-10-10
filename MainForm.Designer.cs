﻿using System.Windows.Forms;

namespace tw_app
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.usersGridView = new System.Windows.Forms.DataGridView();
            this.username_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullname_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rolesTree = new System.Windows.Forms.TreeView();
            this.treeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.edit_sbtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancel_sbtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.save_sbtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copy_sbtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.userLabel = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.treeMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usersGridView
            // 
            this.usersGridView.AllowUserToAddRows = false;
            this.usersGridView.AllowUserToDeleteRows = false;
            this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.username_cl,
            this.fullname_cl});
            this.usersGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersGridView.Location = new System.Drawing.Point(0, 0);
            this.usersGridView.Name = "usersGridView";
            this.usersGridView.ReadOnly = true;
            this.usersGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.usersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersGridView.Size = new System.Drawing.Size(344, 560);
            this.usersGridView.TabIndex = 3;
            this.usersGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.usersGridView_RowEnter);
            // 
            // username_cl
            // 
            this.username_cl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.username_cl.HeaderText = "Username";
            this.username_cl.Name = "username_cl";
            this.username_cl.ReadOnly = true;
            this.username_cl.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.username_cl.Width = 80;
            // 
            // fullname_cl
            // 
            this.fullname_cl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fullname_cl.HeaderText = "Fullname";
            this.fullname_cl.Name = "fullname_cl";
            this.fullname_cl.ReadOnly = true;
            this.fullname_cl.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.usersGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rolesTree);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1034, 560);
            this.splitContainer1.SplitterDistance = 344;
            this.splitContainer1.TabIndex = 4;
            // 
            // rolesTree
            // 
            this.rolesTree.ContextMenuStrip = this.treeMenu;
            this.rolesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rolesTree.Indent = 40;
            this.rolesTree.Location = new System.Drawing.Point(0, 25);
            this.rolesTree.Name = "rolesTree";
            this.rolesTree.Size = new System.Drawing.Size(686, 535);
            this.rolesTree.TabIndex = 5;
            this.rolesTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.rolesTree_AfterCheck);
            // 
            // treeMenu
            // 
            this.treeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandAllToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.Size = new System.Drawing.Size(128, 48);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.expandAllToolStripMenuItem.Text = "Expand all";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.expandAllToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.closeAllToolStripMenuItem.Text = "Close all";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edit_sbtn,
            this.toolStripSeparator1,
            this.cancel_sbtn,
            this.toolStripSeparator4,
            this.save_sbtn,
            this.toolStripSeparator2,
            this.copy_sbtn,
            this.toolStripSeparator3,
            this.userLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(686, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // edit_sbtn
            // 
            this.edit_sbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.edit_sbtn.Image = ((System.Drawing.Image)(resources.GetObject("edit_sbtn.Image")));
            this.edit_sbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.edit_sbtn.Name = "edit_sbtn";
            this.edit_sbtn.Size = new System.Drawing.Size(31, 22);
            this.edit_sbtn.Text = "Edit";
            this.edit_sbtn.Click += new System.EventHandler(this.edit_sbtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cancel_sbtn
            // 
            this.cancel_sbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cancel_sbtn.Enabled = false;
            this.cancel_sbtn.Image = ((System.Drawing.Image)(resources.GetObject("cancel_sbtn.Image")));
            this.cancel_sbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancel_sbtn.Name = "cancel_sbtn";
            this.cancel_sbtn.Size = new System.Drawing.Size(47, 22);
            this.cancel_sbtn.Text = "Cancel";
            this.cancel_sbtn.Click += new System.EventHandler(this.cancel_sbtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // save_sbtn
            // 
            this.save_sbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.save_sbtn.Enabled = false;
            this.save_sbtn.Image = ((System.Drawing.Image)(resources.GetObject("save_sbtn.Image")));
            this.save_sbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save_sbtn.Name = "save_sbtn";
            this.save_sbtn.Size = new System.Drawing.Size(35, 22);
            this.save_sbtn.Text = "Save";
            this.save_sbtn.Click += new System.EventHandler(this.save_sbtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // copy_sbtn
            // 
            this.copy_sbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.copy_sbtn.Enabled = false;
            this.copy_sbtn.Image = ((System.Drawing.Image)(resources.GetObject("copy_sbtn.Image")));
            this.copy_sbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copy_sbtn.Name = "copy_sbtn";
            this.copy_sbtn.Size = new System.Drawing.Size(39, 22);
            this.copy_sbtn.Text = "Copy";
            this.copy_sbtn.Click += new System.EventHandler(this.copy_sbtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // userLabel
            // 
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(38, 22);
            this.userLabel.Text = "count";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 560);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.treeMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView usersGridView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton edit_sbtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton save_sbtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton copy_sbtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn username_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullname_cl;
        private System.Windows.Forms.ToolStripLabel userLabel;
        //private MixedCheckBoxesTreeView rolesTree;
        private TreeView rolesTree;
        private System.Windows.Forms.ToolStripButton cancel_sbtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ContextMenuStrip treeMenu;
        private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
    }
}

