# README
This project was developed under BIRAC Amrit Grand Challenege JanCare in G H Raisoni College of Engineering,Nagpur in 2023-24

OcanPredict is an AI-powered web application designed for the early screening of Oral Submucous Fibrosis (OSMF).
It leverages advance machine learning models deployed on the Intel platform using Hugging Face's framework to provide accurate predictions.
The application offers a user-friendly interface for seamless interaction with the AI model, 
making cutting-edge technology accessible to end users.

> The maintainer of this repository is [Dave Roman](https://github.com/MrDave1999).
>
> This project has been improved too much since its [first alpha version](https://github.com/DentallApp/back-end/tree/v0.1.0). 

## Index

- [Motivation](#motivations)
- [Rationale Behind](#rationale-behind)
- [Technologies used](#technologies-used)
- [Intel Hardware and Software Utilized](Intel-Hardware-and-Software-Utilized)
  - [Softwares Links](#softwareslinks)
  - [Frameworks and libraries](#frameworks-and-libraries)
  - [Testing](#testing)
  - [Own libraries](#own-libraries)
- [Software Engineering](#software-engineering)
- [Installation](#installation)
- [Plugin configuration](#plugin-configuration)
- [Credentials](#credentials)
- [Validate identity documents](#validate-identity-documents)
- [Configure languages](#configure-languages)
- [Diagrams](#diagrams)
  - [General architecture](#general-architecture)
  - [Core layer](#core-layer)
  - [Relational model](#relational-model)
- [Direct Line API](#direct-line-api)
- [EF Core Migrations](#ef-core-migrations)
- [Running tests](#running-tests)

- [Contribution](#contribution)

## Motivation

Oral Submucous Fibrosis (OSMF) is a well-known premalignant condition and prevalent in Central India. 
Normally in rural areas, youths are addicted to habits of Kharra or gutkha that contains tobacco and 
betel nut as a main ingredients. These habits can develop OSMF and transform into Oral Cancer if not 
detected in time. 

Also there are fewer dental health professionals in rural areas resulting in people having to travel 
to an urban city to obtain oral healthcare. Rural populations living in poverty often cannot afford 
dental healthcare. To solve this problem, the project aims to develop a portable device for early 
screening of oral cancer using Artificial Intelligence that will provide patients, especially rural 
areas, with access to personalized health information and support to improve dental care.

In the current procedure for detecting OSMF, doctors typically measure the interincisal distance using 
a ruler or vernier, which may result in inaccurate measurements. Additionally, histopathology, 
considered the standard examination method for analyzing tissue cells, poses the risk of aggravating 
the condition. Due to these limitations, doctors often adopt a conservative approach to proceed with 
the diagnosis.

## Rationale Behind
Artificial Intelligence offers a promising alternative by enabling early and non-invasive detection 
of OSMF, improving patient outcomes while minimizing discomfort and risks associated with traditional 
methods. 


## Technologies used
Intel RealSense depth camera 405
Quad-core ARM Cortex-A72 processor(Rasberry pi 4B)
Slim oral andonstar camera for intra oral images 
AI model to detect oral submucous fibrosis(OSMF) lesions on Intel Hugging faces
Roboflow

## Intel Hardware and Software Utilized

   **Intel RealSense Depth Camera D405**:Intel RealSense Depth Camera D405 is an advanced depth-sensing 
   camera specifically designed for capturing high-precision depth information at close ranges. Its features and specifications make it particularly valuable for projects requiring fine-grained 3D imaging and detailed object measurements.
   High precision: Enables accurate depth measurement, crucial for applications that demand detailed surface analysis or dimensional accuracy.
   In this project, the Intel RealSense Depth Camera D405 was utilized to calculate the *interincisal
   distance (mouth opening)*. By capturing detailed depth data of the oral region, the camera ensured precise measurements critical for the project's success.

  ### pyrealsense2 Library for RealSense Camera Integration

The **pyrealsense2** library is a Python wrapper for the Intel RealSense SDK, enabling easy integration of RealSense cameras into Python projects. The library facilitates the capture and processing of high-definition video, depth, and infrared data from Intel RealSense devices. By using this library, you can interface with the camera to retrieve real-time data, such as 3D depth information, which can be essential for a variety of applications like object detection, spatial analysis, and robotics.
users can access real-time data streams from the RealSense camera, including depth and color frames. This capability is particularly useful in applications that require precise spatial information.


  ### AI Model on Intel Hugging Face for OSMF Classification on APP
**Training the Model**: The model was trained using standard deep learning libraries and datasets relevant to OSMF image classification.
In our project, this free cloud-based solution allowed us to train our YOLO-based model, and optimize the model for real-time inferencing—all within a single, seamless environment.

**Optimizing the Model**: 
   - The **Intel® Neural Compressor** was used to apply quantization techniques to optimize the model for deployment.
   
  ### Benefits:
- **Efficient Model Deployment**: Intel® Hugging Faces ** made it possible to deploy a highly optimized model on Intel resources, ensuring fast and accurate predictions.
- **Scalability**: This approach allows for deployment both in edge devices and cloud environments, providing scalability for real-time image classification in medical diagnostics.


### Softwares Links
- [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools)
- [Visual Studio 2022](https://visualstudio.microsoft.com)
- [vscode](https://github.com/microsoft/vscode)
- [Docker](https://github.com/docker)
- [Postman](https://www.postman.com)
- [InDirectLine](https://github.com/newbienewbie/InDirectLine)
- [MariaDB](https://github.com/mariadb)
- [HeidiSQL](https://github.com/HeidiSQL)
- [BotFramework-Emulator](https://github.com/microsoft/BotFramework-Emulator)
- [GitHub Actions](https://github.com/actions)
- [Git](https://git-scm.com)
- [draw.io](https://app.diagrams.net)
- [Intel Hugging Face](https://huggingface.co/spaces/piyush3/OcanPredict)

### Frameworks and libraries
- [ASP.NET Core](https://github.com/dotnet/aspnetcore)
- [Microsoft Bot Framework](https://github.com/microsoft/botframework-sdk)
- [AdaptiveCards](https://github.com/microsoft/AdaptiveCards)
- [SendGrid](https://github.com/sendgrid/sendgrid-csharp)
- [SendGrid.Extensions.DependencyInjection](https://www.nuget.org/packages/SendGrid.Extensions.DependencyInjection)
- [libphonenumber-csharp](https://github.com/twcclegg/libphonenumber-csharp)
- [Quartz.Net](https://github.com/quartznet/quartznet)
- [Quartz.Extensions.Hosting](https://www.nuget.org/packages/Quartz.Extensions.Hosting)
- [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Scrutor](https://github.com/khellang/Scrutor)
- [efcore](https://github.com/dotnet/efcore)
- [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)
- [EFCore.NamingConventions](https://github.com/efcore/EFCore.NamingConventions)
- [linq2db.EntityFrameworkCore](https://github.com/linq2db/linq2db.EntityFrameworkCore)
- [EntityFramework.Exceptions](https://github.com/Giorgi/EntityFramework.Exceptions)
- [EFCore.CustomQueryPreprocessor](https://github.com/MrDave1999/EFCore.CustomQueryPreprocessor)
- [DelegateDecompiler](https://github.com/hazzik/DelegateDecompiler)
- [Dapper](https://github.com/DapperLib/Dapper)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/microsoft/vs-threading)
- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
- [Microsoft.IdentityModel.Tokens](https://www.nuget.org/packages/Microsoft.IdentityModel.Tokens)
- [System.IdentityModel.Tokens.Jwt](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt)
- [BCrypt.Net-Next](https://github.com/BcryptNet/bcrypt.net)
- [Scriban](https://github.com/scriban/scriban)
- [itext7.pdfhtml](https://github.com/itext/i7n-pdfhtml)
- [File.TypeChecker](https://github.com/AJMitev/FileTypeChecker)
- [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- [FluentValidation.DependencyInjectionExtensions](https://www.nuget.org/packages/FluentValidation.DependencyInjectionExtensions)

### Own libraries
- [DotEnv.Core](https://github.com/MrDave1999/dotenv.core)
- [YeSql.Net](https://github.com/ose-net/yesql.net)
- [SimpleResults](https://github.com/MrDave1999/SimpleResults)
- [CPlugin.Net](https://github.com/MrDave1999/CPlugin.Net)
- [CPlugin.Net.Attributes](https://www.nuget.org/packages/CPlugin.Net.Attributes)
- [CopySqlFilesToOutputDirectory](https://www.nuget.org/packages/CopySqlFilesToOutputDirectory)
- [CopyPluginsToPublishDirectory](https://www.nuget.org/packages/CopyPluginsToPublishDirectory)

## Software Engineering

Software engineering concepts have been applied in this project:
- [Vertical Slice Architecture](https://garywoodfine.com/implementing-vertical-slice-architecture)
- [CQRS](https://en.wikipedia.org/wiki/Command_Query_Responsibility_Segregation)
- [Plugin-based architecture](https://www.linkedin.com/pulse/plugin-architecture-design-pattern-beginners-guide-nick-cosentino)
- [Interface-based programming](https://en.wikipedia.org/wiki/Interface-based_programming)
- [Modular programming](https://en.wikipedia.org/wiki/Modular_programming)
- [Dependency injection](https://en.wikipedia.org/wiki/Dependency_injection)
- [Operation Result Pattern](https://medium.com/@wgyxxbf/result-pattern-a01729f42f8c)
- [Guard Clause](https://deviq.com/design-patterns/guard-clause)
- [Fail Fast](https://deviq.com/principles/fail-fast)
- [Open-closed principle](https://en.wikipedia.org/wiki/Open%E2%80%93closed_principle)
- [Acyclic dependencies principle](https://en.wikipedia.org/wiki/Acyclic_dependencies_principle)
- [Explicit dependencies](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#explicit-dependencies)
- [Separation of concerns](https://en.wikipedia.org/wiki/Separation_of_concerns)

**Additional references:**
- [Software principles and design](https://deviq.com)
- [Plugin Architecture Pattern in C# by Alvaro Montoya](https://code-maze.com/csharp-plugin-architecture-pattern)
- [Plugin Architecture Design Pattern by Nick Cosentino](https://www.devleader.ca/2023/09/07/plugin-architecture-design-pattern-a-beginners-guide-to-modularity)
- [Plugin Architecture In C# For Improved Software Design by Nick Cosentino](https://www.devleader.ca/2024/03/12/plugin-architecture-in-c-for-improved-software-design)
- [Vertical Slice Architecture in ASP.NET Core by Swapnil Meshram](https://www.linkedin.com/pulse/vertical-slice-architecture-aspnet-core-swapnil-meshram-sitsf)
- [Vertical Slice Architecture in ASP.NET Core by Code Maze](https://code-maze.com/vertical-slice-architecture-aspnet-core)


## Credentials

The following table shows the default credentials for authentication from the application.

| Username                | Password                    |
|-------------------------|-----------------------------|
| basic_user@hotmail.com  | 123456                      |
| secretary@hotmail.com   | 123456                      |
| dentist@hotmail.com     | 123456                      |
| admin@hotmail.com       | 123456                      |
| superadmin@hotmail.com  | 123456                      |

Use this route for authentication:
```
POST - /api/user/login
```
Request body:
```json
{
  "userName": "basic_user@hotmail.com",
  "password": "123456"
}
```

## Validate identity documents

To validate identity documents, it depends largely on the country where the dental office is located. At the moment, we can only validate identity documents registered in Ecuador.

You can enable it from the configuration file, e.g.
```.env
PLUGINS="
Plugin.IdentityDocument.Ecuador.dll
"
```
In case there is no plugin loaded to validate the identity document, the host application will use a fake provider called [FakeIdentityDocument](https://github.com/DentallApp/back-end/blob/dev/src/Infrastructure/Services/FakeIdentityDocument.cs).

It was decided to implement the logic to validate identity documents from a plugin, because it is flexible, since it allows to change the implementation without having to modify the source code of the host application.

## Configure languages

This project uses [resource files](https://github.com/DentallApp/back-end/tree/dev/src/Shared/Resources) to store response messages in different languages. If you want to add a new language, you must modify the [Languages section](https://github.com/DentallApp/back-end/blob/52a0f58f8a721d731b0c21da75bb648eedb40d33/src/HostApplication/appsettings.json#L7-L10) of `appsettings.json`.
```json
"Languages": [
  "es",
  "en",
  "fr"
]
```

## Diagrams

### General architecture

<details>
<summary><b>Show diagram</b></summary>

![Mouth opining using intel real sense camera](https://github.com/parth-deshmukh-code/OCan_Predict/blob/dev/diagrams/Mouth%20opening%20uing%20Intel%20REALSENSE%20camera.png)

</details>

<details>
<summary><b>More details</b></summary>
<br/>


## Direct Line API

[Direct Line API](https://learn.microsoft.com/en-us/azure/bot-service/rest-api/bot-framework-rest-direct-line-3-0-api-reference) allows your client application to communicate with the bot. It acts as a bridge between the client and the bot.

For development and test environments you can use [InDirectLine](https://github.com/newbienewbie/InDirectLine) to avoid having to use Azure. [InDirectLine](https://github.com/newbienewbie/InDirectLine) is a bridge that implements the Direct Line API, but should not be used for production.

By default, the configuration file (.env) contains a key called `DIRECT_LINE_BASE_URL`.
```.env
DIRECT_LINE_BASE_URL=http://indirectline:3000/
```
The provider called [InDirectLine](https://github.com/newbienewbie/InDirectLine) is used by default.

In production, the value of this key must be changed to:
```.env
DIRECT_LINE_BASE_URL=https://directline.botframework.com/
```
In that case the provider to use will be the Direct Line channel of Azure Bot. The backend application is able to switch providers just by reading the URL.

## EF Core Migrations

You can use EF Core migrations to create the database from the entities.

- You must install [dotnet ef](https://learn.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools) as a global tool using the following command:
```sh
dotnet tool install --global dotnet-ef
```

- Change directory.
```sh
cd src/HostApplication
```

- Run this command to create the migration files.
```sh
dotnet ef migrations add InitialCreate
```

- At this point you can have EF create your database and create your schema from the migration.
```sh
dotnet ef database update
```

> That's all there is to it - your application is ready to run on your new database, and you didn't need to write a single line of SQL. Note that this way of applying migrations is ideal for local development, but is less suitable for production environments - see the [Applying Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying) page for more info.

## Running tests

To run the unit tests on your local machine, run this command:
```sh
dotnet test ./tests/UnitTests/DentallApp.UnitTests.csproj -c Release
```

You can also run the chatbot tests on their local machine:
```sh
dotnet test ./tests/ChatBot/Plugin.ChatBot.IntegrationTests.csproj -c Release
```

You can run the integration tests that depend on a database but first you need to follow the following steps:
- Install [MariaDb Server](https://mariadb.com/downloads) and set up your username and password.
- Create a file called `.env` in the root directory with the command:
```sh
cp .env.example .env
# On Windows use the "xcopy" command.
```
- Create a file called `.env.test` in the test directory with the command:
```sh
cp ./tests/IntegrationTests/.env.test.example ./tests/IntegrationTests/.env.test
# On Windows use the "xcopy" command.
```
- Specify your database credentials in the `.env.test` file.
- Execute the dotnet test command to run the tests.
```sh
dotnet test ./tests/IntegrationTests/DentallApp.IntegrationTests.csproj -c Release
```

> The database credentials you have in the ".env" file may not necessarily be the same as those in the ".env.test" file. For example, the ".env" file may have credentials from a remote AWS database and run the application on your local machine with that connection string.

## Contribution

- Dr.Vibha Bora,Principal Investigator
- Mr.Chaitanya Wankhede,Junior Research Fellow
- Mr.Bhanu Nagpure, VIII Sem CSE Student
- Mr.Parth Deshmukh,VI Sem ETRX Student
- Mr.Piyush Choudhari,VI Sem ETRX Student
- Mr.Ashwin Khapre,VI Sem ETRX Student
- Ms.Sakshi Dhore,VI Sem ETRX Student


