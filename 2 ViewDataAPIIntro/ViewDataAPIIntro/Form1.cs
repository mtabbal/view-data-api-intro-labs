#region Copyright
//
// Copyright (C) 2015 by Autodesk, Inc.
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
//
// Written by M.Harada.  
// 
#endregion // Copyright

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; // for debugging. 
using System.IO; 
// Added for RestSharp. 
using RestSharp;

namespace ViewDataAPIIntro
{
    /// <summary>
    /// Minimum UI to upload a model for viewing. 
    /// getToken >> create a bucket >> 
    /// upload a file >> register 
    /// </summary>
    public partial class Form1 : Form
    {
        // Save access token and other data. 
        private static string m_accessToken = "";
        private static string m_fileName = "";
        private static string m_id = "urn:xxx";
        private static string m_urn64 = ""; 

        public Form1()
        {
            InitializeComponent();

            // An initial bucket name. 
            // Note: bucket name may overlap with sombody else. 
            // (Shoud have naming rule)
            // Here I'm using RDS + bucket_ + current time. 
            // RDS = Registered Developer Symbol 
            DateTime today = DateTime.Now;
            string time = today.DayOfYear.ToString() + today.Hour.ToString() + today.Minute.ToString(); 
            textBoxBucketName.Text = "adskbucket_" + time; 
        }

        private void buttonToken_Click(object sender, EventArgs e)
        {
            textBoxRequest.Text = "Request comes here";
            textBoxResponse.Text = "Response comes here. This may take secones. Please wait...";
            this.Update();

            // Here is the main part that we call ViewData authenticate 
            m_accessToken = ViewData.Authenticate();

            // Show the obtained token in the form 
            textBoxToken.Text = m_accessToken; 

            // For our learning, 
            // show the request and response in the form. 
            ShowRequestResponse(); 
        }

        private void buttonBucket_Click(object sender, EventArgs e)
        {
            textBoxRequest.Text = "Request comes here";
            textBoxResponse.Text = "Response comes here. This may take secones. Please wait...";
            this.Update();

            string bucketname = textBoxBucketName.Text;
            string policy = "transient"; // transient(24h)/temporary(30days)/persistent 

            // Here is the main part that we call View and Data API bucket creation.
            // return value key is the bucket name.  
            string key = ViewData.CreateBucket(m_accessToken, bucketname, policy);

            // For our learning, 
            // show the request and response in the form. 
            ShowRequestResponse(); 
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            textBoxRequest.Text = "Request comes here";
            textBoxResponse.Text = "Response comes here. This may take secones. Please wait...";
            this.Update();

            // Set the data needed to upload. 
            string bucketName = textBoxBucketName.Text;
            string path = textBoxFile.Text;
            string fileName = m_fileName;
            byte[] fileData = File.ReadAllBytes(path);

            // Here is the main part that we call View and Data API upload  
            m_id = ViewData.Upload(m_accessToken, bucketName, fileName, fileData);

            // show the id = urn:xxx on the form. 
            textBoxId.Text = m_id; // "urn:xxx"

            // For our learning, 
            // show the request and response in the form. 
            ShowRequestResponse(); 
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            textBoxRequest.Text = "Request comes here";
            textBoxResponse.Text = "Response comes here. This may take secones. Please wait...";
            this.Update();

            // Here is the main part that we call View and Data API to register the file for viewing.  
            string m_urn64 = ViewData.Register(m_accessToken, m_id);

            // show the urn64 to the form. 
            textBoxUrn.Text = m_urn64; 

            // For our learning, 
            // show the request and response in the form. 
            ShowRequestResponse(); 

        }

        // Choose a file to upload. No REST call with this button. 
        //
        private void buttonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = fileDialog.FileName;  // full path 
                m_fileName = fileDialog.SafeFileName;    // file name only   
            }
        }

        // Displays request and response in the text boxes.
        // This is for learning purposes. 
        private void ShowRequestResponse()
        {
            // show the request and response in the form. 
            IRestResponse response = ViewData.m_lastResponse;
            textBoxRequest.Text = response.ResponseUri.AbsoluteUri;
            textBoxResponse.Text =
                "Status Code: " + response.StatusCode.ToString() 
                + Environment.NewLine + response.Content;
        }

    }
}
