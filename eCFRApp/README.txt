


The project is built using VS Studio 2017 and can opened and run from VS Studio or VS Code, however VS Studio is recommended.

The solution consists of dotnet core 2.2 backend and Angualar 6 as UI and C# as the backend lang.
Bootstrap 4 has been used for style.

The solution provides a few APIs that draw the data from services. Data has been stored in files as JSON.

Notes:
- Solution is an N-tier monolithic project. I have tried to create various APIs derving data from services and showing it in Swagger UI.
- Logging could not be done due to time constrainsts.
- Angular UI is provided for only word count and Swagger UI is provided for the rest of the APIs. Once you run the solution the output console in VS will provide a url for Angular UI. I am unable to provide it asthe port will be different on another machine.
- Swagger Ui is listed below. Possibility that the port could be different on another machine. When you run the project take the browser url + /swagger/index.html to access swagger UI.
- Users can use the Swagger UI to play with APIs and review the results.
- No db files have been used. Data is stored in Json files for the API usage.
 
 Swagger UI
https://localhost:44366/swagger/index.html

 Run
 To run the solution simply open it in VS 2017 and hit play on top. it will open a browser and show the Angular UI.
 For swagger UI simply copy the browser url + /swagger/index.html and open in another browser. 

 