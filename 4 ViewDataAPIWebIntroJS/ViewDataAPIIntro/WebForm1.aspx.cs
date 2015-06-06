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
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Added for RestSharp. 
using RestSharp;
using RestSharp.Deserializers;

namespace ViewDataAPIIntro
{
    /// <summary>
    /// Minimum UI to upload a model to be ready for viewing.  
    /// Get access token >> create a bucket >> upload file
    /// >> register. 
    /// </summary>
    /// 
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // An initial bucket name. 
            // Note: bucket name may overlap with sombody else. 
            // (Shoud have naming rule. under discussion) 
            // Here I'm using registered Developer Symbol (RDS) 
            // and date for a temporary bucket. 
            DateTime today = DateTime.Now;
            string time = today.DayOfYear.ToString() + today.Hour.ToString() + today.Minute.ToString();
            TextBoxBucketName.Text = "adskbucket_" + time; 
        }

        protected void ButtonToken_Click(object sender, EventArgs e)
        {
            // View and Data API call here
            string authToken = ViewData.Authenticate();

            bool authenticated = !string.IsNullOrEmpty(authToken);
            if (authenticated)
            {
                // Save authToken for this session
                Session["authToken"] = authToken;
                TextBoxToken.Text = authToken; 
            }

            // Show the request and response in the form. 
            // This is for learning purpose. 
            ShowRequestResponse(); 
        }

        // Helper function.  
        // Displays request and response in the text boxes.
        // This is for learning purpose. 
        private void ShowRequestResponse()
        {
            // show the request and response in the form. 
            IRestResponse response = ViewData.m_lastResponse;
            TextBoxRequest.Text = response.ResponseUri.AbsoluteUri;
            TextBoxResponse.Text =
                "Status Code: " + response.StatusCode.ToString() + Environment.NewLine
                + response.Content;
        }

        protected void ButtonBucket_Click(object sender, EventArgs e)
        {
            string accessToken = HttpContext.Current.Session["authToken"] as string;
            string bucketname = TextBoxBucketName.Text;
            string policy = "transient"; // transient(24h)/temporary(30days)/persistent 

            // Here is the main part that we call View and Data API bucket creation.
            // return value key is the bucket name.  
            string key = ViewData.CreateBucket(accessToken, bucketname, policy);

            // For our learning, 
            // show the request and response in the form. 
            ShowRequestResponse(); 
        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            string fileName = FileUpload1.FileName; 
            string accessToken = Session["authToken"] as string;
            string bucketName = TextBoxBucketName.Text; 
            byte[] fileData = FileUpload1.FileBytes; 

            // Here is the main part that we call View and Data API upload  
            string id = ViewData.Upload(accessToken, bucketName, fileName, fileData);

            TextBoxId.Text = id; // "urn:xxx"

            // For our learning, 
            // show the request and response in the form. 
            ShowRequestResponse(); 
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            string accessToken = Session["authToken"] as string;
            string id = TextBoxId.Text; 

            // Here is the main part that we call View and Data API register 
            string urn64 = ViewData.Register(accessToken, id);

            TextBoxUrn.Text = "urn:" + urn64; // Modified to make it easier to pass to the viewer. 
            Session["urn"] = urn64; 

            // For our learning, 
            // show the request and response in the form. 
            ShowRequestResponse(); 
        }

    }
}