### Project Description
The intended users of this application include:
- Buyers and tenants, who are looking for properties in Greater Vancouver.
- Property owners, who want to sell or rent out their properties.

The application will feature the following pages:
- Home Page: A welcoming introduction to the platform.
- Registration/Login Page: Allowing users to sign up and log in.
- Property Listings Page: Displaying available properties with search and filtering options.
- Property Details Page: Providing detailed information on each property.
- Information Management Pages: For administrators to manage property and user information.
- AI Customer Service Page: Offering AI-powered assistance based on user inquiries.

The application will provide the following functionalities:
1. User Authentication: Secure login and logout for users.
2. Admin Management: Enabling administrators to maintain property listings and relevant data.
3. Property Listings Display: Presenting properties with advanced search and filtering capabilities.
4. Property Details Page: Showing comprehensive property information, including images and descriptions.
5. AI Customer Service: Utilizing AI to analyze user inquiries and provide personalized assistance and recommendations.

### ER Diagram
![ER Diagram](ERD.drawio.png)



### run app locally
mock secrets need to be set before run the app
```
dotnet user-secrets set "Authentication:Google:ClientId" "ClientId"
dotnet user-secrets set "Authentication:Google:ClientSecret" "client-secret"

dotnet user-secrets set "Authentication:Facebook:AppId" "AppId"
dotnet user-secrets set "Authentication:Facebook:AppSecret" "client-secret"

dotnet user-secrets set "Authentication:Microsoft:ClientId" "ClientId"
dotnet user-secrets set "Authentication:Microsoft:ClientSecret" "client-secret"
```
to run the app
```
dotnet run
```


# Kanban

### todo
new feature:

enhancement:

optimization:
- figure out a bettter way to solve SQLite decimal ordering error

### finished
- show image on frontend
- Implement database paging on backend
- merge customer table and AspNetUser table
- support adding, editing, and deleting properties
- manage properties on the user page
- support register user
- support role controll
- support search properties
- fetch ImageId but not image object in Property Detail action

chanllenge record:

Failed executing DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
DROP TABLE "Customers";
SQLite Error 19: 'FOREIGN KEY constraint failed'.
