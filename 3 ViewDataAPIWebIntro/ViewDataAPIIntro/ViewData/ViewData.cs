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

namespace ViewDataAPIIntro
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
                AuthenticateResponse loginResponse = deserial.Deserialize<AuthenticateResponse>(response);
                accessToken = loginResponse.access_token;
            }

            return accessToken; 
        }

        ///==============================================================
        /// Create a bucket. 
        /// A "bucket" is a container that folds a data. 
        /// URL
        /// https://developer.api.autodesk.com/oss/v1/buckets
        /// Methods: POST 
        /// Doc
        /// http://developer.api.autodesk.com/documentation/v1/vs/oss.html#oss-buckets-api
        ///==============================================================

        public static string CreateBucket(string accessToken, string bucketKey, string policy)
        {
            // (1) Build request 
            var client = new RestClient();
            client.BaseUrl = new System.Uri(baseApiUrl);

            // Set resource/end point
            var request = new RestRequest();
            request.Resource = "oss/v1/buckets";
            request.Method = Method.POST;

            // Add headers 
            request.AddHeader("Authorization", "Bearer " + accessToken);
            request.AddHeader("Content-Type", "application/json"); 

            // Add JSON body. In a simplest form. 
            request.AddJsonBody(new { bucketKey = bucketKey, policy = policy });

            // (2) Execute request and get response
            IRestResponse response = client.Execute(request);

            // Save response. This is to see the response for our learning.
            m_lastResponse = response;

            // Get the key = bucket name. 
            string key = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                JsonDeserializer deserial = new JsonDeserializer();
                OssBucketsResponse bucketsResponse = deserial.Deserialize<OssBucketsResponse>(response);
                key = bucketsResponse.key; 
            }

            return key; // the bucket name 
        }

        ///==============================================================
        /// Upload a file  
        /// URL
        /// https://developer.api.autodesk.com/oss/{version}/buckets/{bucketname}/objects/{filename}
        /// Methods: PUT 
        /// Doc
        /// http://developer.api.autodesk.com/documentation/v1/vs/oss.html#oss-upload-api
        /// 
        /// Jim.A's note: 
        /// http://forums.autodesk.com/t5/view-and-data-api/cannot-figure-out-what-s-going-on-with-uploading-registering-and/m-p/5147606/highlight/true#M38
        ///
        /// curl -k -i -X PUT 'https://developer.api.autodesk.com/oss/v1/buckets/jmabucket/objects/ChurchRenovation2.rvt' -H 'Content-Type: application/rvt' -H 'Authorization: Bearer lrdWEGN6aV06NFrsRSpXjNPFjUZJ' --data-binary @ChurchRenovation2.rvt
        /// ==============================================================
        /// Note: doc is inconsistent. e.g., filename vs. object key. 
        /// 
                
        public static string Upload(string accessToken, string bucketName, string fileName, byte[] fileData)
        {
            // (1) Build request 
            var client = new RestClient();
            client.BaseUrl = new System.Uri(baseApiUrl);

            // Set resource/end point
            var request = new RestRequest();
            request.Resource = "oss/{version}/buckets/{bucketname}/objects/{filename}";
            request.Method = Method.PUT;
              
            // Set UrlSegment 
            request.AddUrlSegment("version", "v1");
            request.AddUrlSegment("bucketname", bucketName);
            request.AddUrlSegment("filename", fileName); 

            // Add headers  
            request.AddHeader("Authorization", "Bearer " + accessToken);
            request.AddHeader("Content-Type", "application/octet-stream"); 

            // Add parameter 
            request.AddParameter("requestBody", fileData, ParameterType.RequestBody);

            // (2) Execute request and get response
            IRestResponse response = client.Execute(request);

            // Save response. This is to see the response for our learning.
            m_lastResponse = response;

            // Get the id = "urn:xxx"  
            string id = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                JsonDeserializer deserial = new JsonDeserializer();
                OssBucketsObjectsResponse bucketsResponse = deserial.Deserialize<OssBucketsObjectsResponse>(response);
                id = bucketsResponse.objects[0].id;
            }

            return id; // "urn:xxx" 
        }

        ///==============================================================
        /// Register your data 
        /// URL
        /// https://developer.api.autodesk.com/viewingservice/v1/register
        /// Methods: PUT 
        /// Doc
        /// http://developer.api.autodesk.com/documentation/v1/vs/viewing_service.html#viewing-service-create-bubbles-api
        /// 
        /// curl -k -H "Content-Type: application/json" -H "Authorization:Bearer GX6OONHlQ9qoVaCSmBqJvqPFUT5i" \
        /// -i -d "{\"urn\":\"dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6bXlidWNrZXQvc2t5c2NwcjEuM2Rz\"}" \
        /// https://developer.api.autodesk.com/viewingservice/v1/register
        /// 
        /// Tools to encode to base 64. 
        /// http://www.base64encode.org/
        /// ==============================================================
        /// Note: this one looks like always v1.
        /// Note: access token missing in the ref doc. 
        /// 
        public static string Register(string accessToken, string id)
        {
            // (1) Build request 
            var client = new RestClient();
            client.BaseUrl = new System.Uri(baseApiUrl);

            // Set resource/end point
            var request = new RestRequest();
            request.Resource = "viewingservice/v1/register";
            request.Method = Method.POST;

            // Add headers  
            request.AddHeader("Authorization", "Bearer " + accessToken);
            request.AddHeader("Content-Type", "application/json");

            // Convert urn to urn64. 
            // urn = "urn:xxxxx"
            byte[] bytes = Encoding.UTF8.GetBytes(id);
            string urn64 = Convert.ToBase64String(bytes);

            // Add parameter 
            request.AddJsonBody(new { urn = urn64 } ); 

            // (2) Execute request and get response
            IRestResponse response = client.Execute(request);

            // Save response. This is to see the response for our learning.
            m_lastResponse = response;

            return urn64;
        }

    }
}
