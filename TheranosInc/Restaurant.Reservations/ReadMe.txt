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



Pending Tasks:
==================
1. Error message when all tables are in use.
2. Tooltip for each row.
3. Validation on Settings page.
4. If App Crashes, data should not be lost.