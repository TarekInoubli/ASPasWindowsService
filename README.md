# ASPasWindowsService
*** How to run an ASP.NET Core application as a windows service ***

In this short example we will see how an ASP.NET Core app can be hosted as a Windows Service without using IIS.
After hosting as a Windows Service, the app will be automatically started after server reboots.

## Create the app step by step
### Step1: Create an empty ASP.Core app

![image](https://user-images.githubusercontent.com/5670324/158612625-31f81bf8-c855-4db1-9da6-78b1ab451e00.png)

### Step2: Add package reference
The app requires a package reference for "Microsoft.Extensions.Hosting.WindowsServices"

### Step3: Set output type to Exe

Edit the csproj and add the OutputType of exe. 

![image](https://user-images.githubusercontent.com/5670324/158616168-94557548-1e5f-46ca-9f21-5af134d0fc3b.png)

### Step4: Add a simple api controller

![image](https://user-images.githubusercontent.com/5670324/158613492-bc87aa12-e1b0-4dd4-b5c2-03ca39d50606.png)

![image](https://user-images.githubusercontent.com/5670324/158613626-3a556f39-44bf-4fe9-92c6-e65271e775d9.png)

### Step5: Tack the "UseWindowsService()"

Inside program.cs:

![image](https://user-images.githubusercontent.com/5670324/158614631-81bcd752-c1db-4eb4-8ed1-04602d638d8c.png)

IHostBuilder.UseWindowsService is called when building the host.
If the app is running as a Windows Service, the method:
* Sets the host lifetime to WindowsServiceLifetime.
* Sets the content root to AppContext.BaseDirectory.
* Enables logging to the event log:
  - The application name is used as the default source name.
  - The default log level is Warning or higher for an app based on an ASP.NET Core template that calls CreateDefaultBuilder to build the host.
  - Override the default log level with the Logging:EventLog:LogLevel:Default key in appsettings.json/appsettings.{Environment}.json or other configuration provider.
  - Only administrators can create new event sources. When an event source can't be created using the application name, a warning is logged to the Application source and event logs are disabled.

### Step6: Publish the app as self-contained

![image](https://user-images.githubusercontent.com/5670324/158616805-8ed8337c-4a62-4aeb-9f29-66ef2e4b7270.png)

### Step7: Start the exe file and test the service
