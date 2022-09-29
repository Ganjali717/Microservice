# Microservice Architecture with API gateway

![Microservice Using ASP NET Core02](https://user-images.githubusercontent.com/34399229/192992325-c32094a4-aa36-4eb4-b265-df7176e70894.png)


We will have to build a simple Microservice Architecture in ASP.NET Core with API Gateways. <br/> 
This simple project consist from two simple assemblies, that performs simple CRUD operations <br/>
For API Gateway we are using Ocelot
1. Customer <br/>
2. Product <br/>
3. Ocelot <br/>

Ocelot is an Open Source API Gateway for the .NET/Core Platform. What is does is simple. It cunifies multiple microservices so that the client does not have to worry about the location of each and every Microservice. Ocelot API Gateway transforms the Incoming HTTP Request from the client and forward it to an appropriate Microservice.
<br/>
<br/>
Ocelot is widely used by Microsft and other tech-giants as well for Microservice Management. The latest version of Ocelot targets ASP.NET Core 3.1 and is not suitable for .NET Framework Applications. It will be as easy and installing the Ocelot package to your API Gateway project and setting up a JSON Configuration file that states the upstream and downstream routes.


For using Ocelot from 17.0.1 version write in appsettings.json file.

appsettings.json
![Снимок экрана 2022-09-29 131906](https://user-images.githubusercontent.com/34399229/192993205-71c41705-4970-45c8-a31e-0931a6760ebd.png)

Product.cs 
![Снимок экрана 2022-09-29 132127](https://user-images.githubusercontent.com/34399229/192993680-6abd75e3-30ec-4fa1-b443-3daf9be956cd.png)
