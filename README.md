# CodingTest
This is a sample code exercise completed to showcase some programming techniques that is used to build a good api project. 
The project emphasize on open closed principles as well as uses DI extensively to manage depedencies between participants.

# Unit Tests
A lot of unit tests were created to ensure that the code paths are covered and different variations of inputs are checked. 
NUnit test cases used to pass in different variation of params.
Current code coverage is sitting at ~90%. 
Moq is used to mock some of the depedencies.
To run the unit tests, simply open the project in VS and from test menu run all tests.

# Consumign API endpoint
To consume API endpoint you can either use postman (preferred) or chrome. There is only single REST GET endpoint which accepts a entry time and exit time.
A sample request while running the api locally is :- https://localhost:44331/Calculator?entrytime=7/11/2020 9:33:10 AM&exitTime=7/11/2020 18:33:10 PM

# Improvement
A swagger endpoint could be added to better document the API. If we add more endpoints it'll be feasible to add that.

