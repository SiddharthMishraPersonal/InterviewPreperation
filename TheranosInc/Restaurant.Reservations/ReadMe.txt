Problem Statement:
==================

[WPF Applicants] Design a WPF application for handling restaurant reservations. 
The input for the application is an XML file containing information about the tables in the restaurant and the maximum occupancy per table. (please see the attached tables.xml file)
The application should handle the following functionality for a single day. Assume that the restaurant operates from 10am to 10pm.

                a. Add reservation
                b. Delete reservation
                c. Edit reservation.

    While designing your application make the following considerations-

                a. Recovery if the app crashes. (Reservations should not be lost)
               b. Please make sure that the UI is always responsive.

Assumptions & 

Issues:
=========
The input file Tables.xml was not in correct format:
1. Root 'Tables' element didn't have correct closing tag.
2. All 'Table' elements didn't have closing tags.

I fixed it to read properly through XmlSerializer class.

Prerequisites:
===============

1. Make sure you are connected to internet.
2. Build the code first which will download all nuget packages required for this application.
3. I have used Nlog for logging.
4. MahApp.Metro has been used for beautiful UI which matches the Window 8 themes.


Features:
============
1.  Application mutex bound so only one instance can be used at a time.
2.  NLog configured to store logs on exception.
3.  MahApp dll is used to make application's look and feel like Metro theme based application.
4.  AutoFac used for Dependency Injections and IoC.
5.  XMLOperations are done to Serialize and Deserialize objects like, Tables, Reservations and Settings.
6.  Settings window implemented to store default file and folder path for the application. By default all data will be stored under C:/ProgramData/Reservations folder.
7.  Custom ToolTips are available on controls.
8.  XAML based validation has been implemented.
9.  Custom XAML components like styles, tooltips, imagesources, converters, validations are stored into Resource Dictionary which we have merged into main dictionary.
10. 


Pending Tasks:
==================
1. Tooltip for each row.
2. Validation on Settings page.

