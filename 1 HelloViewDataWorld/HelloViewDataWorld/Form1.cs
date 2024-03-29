﻿#region Copyright
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
// Added for RestSharp. 
using RestSharp;

namespace HelloViewDataWorld
{
    /// <summary>
    /// Minimum UI to call ViewData.Authenticate().  
    /// Display an access token, request and response. 
    /// </summary>
    public partial class Form1 : Form
    {
        // Save access token. 
        private static string m_accessToken = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonToken_Click(object sender, EventArgs e)
        {
            textBoxRequest.Text = "Request comes here";
            textBoxResponse.Text = "Response comes here. This may take secones. Please wait...";
            this.Update();

            // Here is the main part that we call ViewData authenticate 
            m_accessToken = ViewData.Authenticate();

            // Show it in the form 
            textBoxToken.Text = m_accessToken;

            // For our learning, 
            // show the request and response in the form. 
            ShowRequestResponse(); 
        }

        // Helper function. 
        // Displays request and response in the text boxes.
        // This is for learning purpose. 
        private void ShowRequestResponse()
        {
            // show the request and response in the form. 
            IRestResponse response = ViewData.m_lastResponse;
            textBoxRequest.Text = response.ResponseUri.AbsoluteUri;
            textBoxResponse.Text =
                "Status Code: " + response.StatusCode.ToString() + Environment.NewLine 
                + response.Content;
        }

    }
}
