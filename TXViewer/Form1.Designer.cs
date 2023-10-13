﻿using static System.Net.WebRequestMethods;

namespace TXViewer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            menuStrip1 = new MenuStrip();
            menuItemLoad = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(63, 34);
            webView21.Name = "webView21";
            webView21.Dock = DockStyle.Fill;
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            webView21.EnsureCoreWebView2Async(null);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuItemLoad });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuItemLoad
            // 
            menuItemLoad.Name = "menuItemLoad";
            menuItemLoad.Size = new Size(54, 20);
            menuItemLoad.Text = "Load...";
            menuItemLoad.Click += menuItemLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Padding = new Padding(0, 0, 0, 0);
            Controls.Add(webView21);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "TX Text Control Document Viewer";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();

            this.Load += Form1_Load1;

            ResumeLayout(false);
        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            webView21.Source = new Uri("http://127.0.0.1:8888/viewer.html?id=" + Guid.NewGuid().ToString());
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuItemLoad;
        private OpenFileDialog openFileDialog1;
    }
}