Assumptions & 

Issues:
=========
The input file Tables.xml was not in correct format:
1. Root 'Tables' element didn't have correct closing tag.
2. All 'Table' elements didn't have closing tags.

I fixed it to read properly through XmlSerializer class.