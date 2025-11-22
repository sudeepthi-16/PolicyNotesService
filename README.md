# PolicyNotesService

PolicyNotesService is a lightweight microservice built for an insurance company to manage internal notes associated with customer policies.
The service provides functionality to:
1. Create policy notes
2.Retrieve all notes
3.Retrieve a specific note by ID
4.Delete a note

It is implemented using:
.NET 8 Minimal APIs
Entity Framework Core (InMemory DB)
Repository Pattern + Service Layer
Unit Tests & Integration Tests using xUnit + WebApplicationFactory


**📂 Project Structure**
<img width="314" height="691" alt="image" src="https://github.com/user-attachments/assets/4b6060fe-3fc5-4ccc-875c-3e772cc7dd2a" />


**📸 Swagger API Screenshots**

POST /notes – 201 Created

<img width="1900" height="1072" alt="W-2 POST API Swagger Output" src="https://github.com/user-attachments/assets/90af3b5c-b020-4c45-ba93-e363ec59d2f2" />

GET /notes – 200 OK

<img width="1885" height="1043" alt="W-2 Get API Swagger Output" src="https://github.com/user-attachments/assets/bca7deed-2048-4fb6-b46a-a57418262640" />

GET /notes/{id} – 200 OK

<img width="1834" height="998" alt="W-2 GetById API Swagger Output" src="https://github.com/user-attachments/assets/577bfe88-79ec-41a3-92cc-fd7b3603277d" />


DELETE /notes/{id}

<img width="1827" height="795" alt="W-2 Delete API Swagger Output" src="https://github.com/user-attachments/assets/9a3a0adf-4fb5-4a41-8aa3-980ce2e93a16" />

Unit Testing [2 cases - GET,POST]

<img width="1919" height="1129" alt="W-2Unit testing output" src="https://github.com/user-attachments/assets/d1063d81-60cf-4f81-acac-c732224febcf" />

Integration Testing [4 cases- POST -201,GET-200,GET[Id]-200,GET[Id]-404]

<img width="1903" height="1005" alt="Integration Testing Output" src="https://github.com/user-attachments/assets/d34716df-ff28-4ac2-830f-019389037639" />
