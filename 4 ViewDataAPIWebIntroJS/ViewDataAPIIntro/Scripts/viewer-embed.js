//
// Copyright (C) 2015 by Autodesk, Inc.
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
// Written by M.Harada
// Disclaimer: View and Data API is still in beta state and under 
// constant review. Please refer to the official site for
// the latest changes. 

//==============================================================
// Welcome to the View and Data API Intro.
// 
// This is a minimum sample that demonstrates the usage of Viewer API.
// The code is taken from the Quick Start guide, modified and added  
// explanations for the purpose of learning for the first time. 
// Please refer to the following link for additional info about
// Guick Start guide. 
// http://developer.api.autodesk.com/documentation/v1/vs/vs_quick_start.html#vs-api-quick-start
// 
// The documentation about Client side JavaScript viewer API is found here: 
// Doc:
// http://developer.api.autodesk.com/documentation/v1/vs/viewers/Autodesk.Viewing.Document.html
//==============================================================

var ViewerEmbed = {
    
    // Initialize the viewer, which includes setting a callback function
    // to load the model on success. 
    // Arguments: 
    // 1) getToken - callback function to get a valid token
    // 2) docUrn - urn of a uploaded model
    // 3) viewerElement - a portion of html document to embed a viewer. 
    //
    initialize: function (getToken, docUrn, viewerElement) {
        
        // Set options: 
        // env is used in: 
        // Autodesk.Viewing.Initializer() >> 
        // Autodesk.Viewing.Private.initializeEnvironmentVariable() >> 
        // env = options.env; 
        // 
        // getAccessToken and refreshToken are called from:
        // Autodesk.Viewing.Initializer() >> 
        // Autodesk.Viewing.Private.initializeAuth() >>
        // accessToken = options.getAccessToken();
        // 
        // see viewer3D.js. 
        // 
        var options = {  
            'env': 'AutodeskProduction', 
            'getAccessToken': getToken,
            'refreshToken': getToken,
        };

        // Create a viewer 
        // (a) This shows a viewer without UI. This is in Quick Start Guide.  
        //var viewer = new Autodesk.Viewing.Viewer3D(viewerElement, {});
        // (b) This shows a viewer with basic default set of UI.  
        var viewer = new Autodesk.Viewing.Private.GuiViewer3D(viewerElement, {
            extensions: ['BasicExtension']
        });

        // Initialize the viewer with the options.
        // Set the callback to actually load a model for viewing. 
        Autodesk.Viewing.Initializer(options, function () { // onSuccessCallback 
            viewer.initialize();
            ViewerEmbed.loadDocument(viewer, docUrn); // defined below. 
        });
    }, 

    // Load a document with a given id (=urn) in the viewer.
    // Autodesk.viewing.Document.load takes three arguments:
    //   1) documentId - this is the urn
    //   2) a callback function for viewer to load the model   
    //   3) a callback function when something goes wrong. 
    // In this example, we assume for a display of single 3D model.  
    // 
    loadDocument: function (viewer, documentId) {

        // Find the first 3d geometry and load it.
        Autodesk.Viewing.Document.load(documentId, // arg1: urn 
            function (doc) { // arg2: onLoadCallback
                var geometryItems = [];
                geometryItems = Autodesk.Viewing.Document.getSubItemsWithProperties(
                    doc.getRootItem(), // item - document node to begin searching from. 
                    { // properties to search for 
                        'type': 'geometry', // geometry/view/resource/info/design/warning/error/folder/
                        'role': '3d'  // 2d/3d/thumbnail/tileRoot/graphics/conversion/viewable/Autodesk.CloudPlatform.PropertyDatabase (I'm not sure for all of them).  
                    },
                    true); // recursive searcn, true/false 

                if (geometryItems.length > 0) {
                    // Finally, load the model 
                    viewer.load(doc.getViewablePath(geometryItems[0]));
                }
            },
            function (errorMsg) { // arg3: onErrorCallback
                alert("Load Error: " + errorMsg);
            }
        );
    }
}

