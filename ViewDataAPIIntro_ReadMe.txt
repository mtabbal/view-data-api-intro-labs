=========================================
  View and Data API Intro Training Labs 
=========================================

This folder contains introductory materials for View and Data API.

The labs consist of four modules. Starting from Lab1, it incrementally 
adds code or reuse what you have written, and implement a simple web service application  
 

Lab1: HelloViewDataWorld 
------------------------

The minimum project that demonstrates how to make View and Data REST API call. In this lab, you learn what REST API is, how to make a request and obtain response, and get an access token which will be used in subsequent REST calls. 


Lab2: ViewDataAPIIntro 
----------------------

In this lab, you will learn steps to upload a file to A360 storage and make it ready for viewing. 


Lab3: ViewDataAPIWebIntro
-------------------------

In the previous two labs, we looked at View and Data API as a desktop client application. In this lab, we write a minimum, single page web service in APS.NET. We will reuse most of View and Data API REST calls themselves, and add UI layers as a web page.   


Lab4: ViewDataAPIWebIntroJS
---------------------------

In this lab, we build on top of Lab3 and add JavaScript layer to view an uploaded model. 


* How to run the sample project

In order to use View and Data, you will need consumer API key and secret assigned to you. 
Go to ( https://developer.autodesk.com/ ) to obtain the key and secret. 

Samples are written in C#, using Microsoft Visual Studio 2012. 

Before you build, please set your own key and secret in the code: 


in ViewData.cs >> class ViewData >> 
 - consumerKey
 - consumerSecret


						Written by M. Harada Feburary 28, 2015. 
