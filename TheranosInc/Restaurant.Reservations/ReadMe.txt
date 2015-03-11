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