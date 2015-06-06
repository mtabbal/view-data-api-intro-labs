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
using System.Text;
using System.Threading.Tasks;
using System.Net; // for HttpStatusCode 
using System.IO; 
// Added for RestSharp 
using RestSharp;
using RestSharp.Deserializers;

///=============================================================
/// Welcome to the View and Data API. 
/// 
/// "ViewData" class in this page defines/construct REST API
/// calls to View and Data web services.
/// 
/// You can find the API documentation at the following site:
/// http://developer.api.autodesk.com/documentation/v1/vs/index.html#vs-api-reference
///
/// We are using a library called RestSharp in this lab for 
/// simplicity and to focus on View and Data specific API. 
///=============================================================
namespace HelloViewDataWorld
{
    class ViewData
    {
        // Set values specific to your environments.
        // Hard coded for simplicity for this exercise. 
        // Replace with your own key and secret.  

        public const string baseApiUrl = @"https://developer.api.autodesk.com/";
        public const string consumerKey = @"<your key comes here>";
        public const string consumerSecret = @"<your secret comes here>";

        // Member variables 
        // Save the last response. This is for learning purposes.
        // Not required to make actual REST call. 
        public static IRestResponse m_lastResponse = null;

        ///=============================================================
        /// Authentication/v1/authenticate 
        /// Obtain an access token. 
        /// URL
        /// https://developer.api.autodesk.com/authentication/v1/authenticate 
        /// Method: POST
        /// Doc: 
        /// http://developer.api.autodesk.com/documentation/v1/auth/authentication.html#create-an-oauth2-token
        /// 
        /// Sample Response (JSON)
        /// {
        ///   "token_type":"Bearer",
        ///   "expires_in":1799,
        ///   "access_token":"aPJ8Ibj34KgDj8tkuWQFjo4hzs5sN"
        /// }
        ///=============================================================
        ///
        public static string Authenticate()
        {
            // (1) Build request 
            var client = new RestClient();
            client.BaseUrl = new System.Uri(baseApiUrl);

            // Set resource/end point
            var request = new RestRequest();
            request.Resource = "authentication/v1/authenticate";
            request.Method = Method.POST;

            // Set required parameters 
            request.AddParameter("client_id", consumerKey);   
            request.AddParameter("client_secret", consumerSecret);  
            request.AddParameter("grant_type", "client_credentials");

            // (2) Execute request and get response
            IRestResponse response = client.Execute(request);

            // Save response. This is to see the response for our learning.
            m_lastResponse = response;

            // Get the access token. 
            string accessToken = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                JsonDeserializer deserial = new JsonDeserializer();
                AuthenticateResponse loginResponse = 
                    deserial.Deserialize<AuthenticateResponse>(response);
                accessToken = loginResponse.access_token;
            }

            return accessToken; 
        }

    }
}
