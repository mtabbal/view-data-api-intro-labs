<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ViewDataAPIIntro.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View & Data API</title>
    <meta charset="utf-8" />
    <style type="text/css">
        #form1
        {
            height: 171px;
            width: 622px;
        }
        body
        {
            background-color:#d4ebda; 
        }
        h1
        {
            color:#201e58;  
            text-align: center;
        }
        #viewer
        {
            height: 300px;
            width: 300px;
            background-color:#f1f0f0; 
        }
    </style> 

        <!-- Autodesk Viewer --> 
        <link rel="stylesheet" href="https://developer.api.autodesk.com/viewingservice/v1/viewers/style.css" type="text/css"/>
        <script src="https://developer.api.autodesk.com/viewingservice/v1/viewers/viewer3D.min.js"></script>
        <!-- ViewDataAPI Intro Code --> 
        <script src="Scripts/viewer-embed.js"></script>

        <script>
           
            // Initialize the viewer, which includes setting a callback 
            // function to load the model. 
            // Arguments to ViewerEmbed.initialize: 
            // 1) getToken - callback function to get a valid token
            // 2) docUrn - urn of a uploaded model
            // 3) viewerElement - a portion of html document to embed a viewer. 
            function initialize() {
                var docUrn = document.getElementById("TextBoxUrn").value;
                var viewerElement = document.getElementById('viewer');
                ViewerEmbed.initialize(getToken, docUrn, viewerElement); 
            }

            // Returns a valid access token. For our getting started project, 
            // we simply return the value of token text box.
            // This will be called from options in initializer:   
            // Autodesk.Viewing.Initializer() >> 
            // Autodesk.Viewing.Private.initializeAuth() >>
            // accessToken = options.getAccessToken();
            function getToken() {
                var authToken = document.getElementById("TextBoxToken").value; 
                return authToken; 
            }

        </script>

</head>
<!--body onload="initialize()"-->
<body> 
    <form id="form1" runat="server">
        <h1>My First View and Data API JS</h1> 
    <div>
        <!-- Token to urn -->  
        <asp:Label ID="LabelToken" runat="server" Text="Token" Width="60px"></asp:Label>  
         
        <asp:TextBox ID="TextBoxToken" runat="server" ReadOnly="True" Width="400px" BackColor="#E4E4E4"></asp:TextBox>
    &nbsp;
        <asp:Button ID="ButtonToken" runat="server" OnClick="ButtonToken_Click" Text="Get Token" Width="90px" />
        <br />
        <br />
        <asp:Label ID="LabelBucket" runat="server" Text="Bucket" Width="60px"></asp:Label>

        <asp:TextBox ID="TextBoxBucketName" runat="server" Width="400px"></asp:TextBox>
        &nbsp
        <asp:Button ID="ButtonBucket" runat="server" Text="Create" OnClick="ButtonBucket_Click" Width="90px" />
        <br />
        <br />
        <asp:Label ID="LabelFile" runat="server" Text="File" Width="60px"></asp:Label>

        <asp:FileUpload ID="FileUpload1" runat="server" Width="400px"></asp:FileUpload>
        &nbsp;&nbsp;
        <asp:Button ID="ButtonUpload" runat="server" Text="Upload" OnClick="ButtonUpload_Click" Width="90px" />

        <br />
        <br />
        <asp:Label ID="LabelId" runat="server" Text="id" Width="60px"></asp:Label>

        <asp:TextBox ID="TextBoxId" runat="server" ReadOnly="True" Width="400px" BackColor="#E4E4E4"></asp:TextBox>
        &nbsp;
        <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" Width="90px" />
        <br />
        <br />
        <asp:Label ID="LabelUrn" runat="server" Text="urn" Width="60px"></asp:Label>

        <asp:TextBox ID="TextBoxUrn" runat="server" ReadOnly="True" Width="400px" BackColor="#E4E4E4"></asp:TextBox>
        &nbsp;
        <br />
        <br />
        <!-- Request and Response portion --> 
        <asp:Label ID="LabelRequest" runat="server" Text="Request"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxRequest" runat="server" Height="50px" TextMode="MultiLine" Width="580px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LabelResponse" runat="server" Text="Response"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxResponse" runat="server" Height="60px" TextMode="MultiLine" Width="580px"></asp:TextBox>
        <br />
        <br />
        <!-- Viewer portion --> 
        <input id="ButtonView" type="button" value="View" onclick="initialize()" /><br />

    </div>

    <div id="viewer" style="position:absolute; width:97%; height:40%;"></div>
 

    </form>

        
    </body>
</html>
