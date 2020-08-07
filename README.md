# BPDTS.AutomationTests
A suite of automated tests to get user details details

Repo to clone :  https://github.com/degala123/BPDTS.AutomationTests.git

# Project Structure

   Client Folder,
   Contexts Folder,
   Features Folder,
   Helpers Folder,
   Services Folder,
   Steps Folder 
    
     
## Client Folder: 

  This folder has userclinet which conatins the endpoints created using Refit.
  
## Contexts Folder: 

  This folder has propertiesfor the reusablity purpose to get or set the values.
 
## Features Folder: 

  This folder has Specflow feature files conatins the test scenarios for the get user details page.
				
## Helpers Folder:
  This folder contains the Json property responses.
	
## Services Folder:
  This folder contains the services for the get users end points.
		
## Steps Folder:
This folder contains the step definitions class where the specflow steps are implemented.
	
## Application Url:

Added the get user details details base url to 'App.config' in the app settings.

```<add key="BaseUrl" value="http://bpdts-test-app-v2.herokuapp.com" />```



