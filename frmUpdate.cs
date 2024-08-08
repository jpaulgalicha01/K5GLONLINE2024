using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace K5GLONLINE
{
    public partial class frmUpdate : Form
    {

        public frmUpdate()
        {
            InitializeComponent();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            ////bool isFileExists = File.Exists(Environment.CurrentDirectory + "\\K5Installer.exe"); // ga check kon ara sa same folder

            ////if (isFileExists == false)
            ////{
            ////    string sourceFile = @"\\winserver\C\K5GL\SrcFldr\K5Installer.exe";
            ////    string destinationFile = Environment.CurrentDirectory + "\\K5Installer.exe";

            ////    File.Copy(sourceFile, destinationFile, true);

            ////    Process.Start(Environment.CurrentDirectory + "\\K5Installer.exe");
            ////    Application.Exit();
            ////}
            ////else
            ////{
            ////    Process.Start(Environment.CurrentDirectory + "\\K5Installer.exe");
            ////    Application.Exit();
            ////}

            //string strConstant = "https://ourinstaller.blob.core.windows.net/blobinstallerfile/"; // replace with your actual URL
            
            
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strConstant = "https://ourinstaller.blob.core.windows.net/blobinstallerfile/"; // replace with your actual URL
            string strFileName = "CbytesInstaller.exe";
            string strFilePath = Environment.CurrentDirectory + "\\" + strFileName;

            if (!File.Exists(strFilePath))
            {
                System.Diagnostics.Process.Start(strConstant + strFileName);
            }
            else
            {
                System.Diagnostics.Process.Start(strFilePath);
                Application.Exit();
            }
        }
    }
}
