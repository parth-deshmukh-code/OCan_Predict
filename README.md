# Motivations
This project was developed under BIRAC Amrit Grand Challenege JanCare in G H Raisoni College of Engineering,Nagpur in 2023-24

OcanPredict is an AI-powered web application designed for the early screening of Oral Submucous Fibrosis (OSMF).
It leverages advance machine learning models deployed on the Intel platform using Hugging Face's framework to provide accurate predictions.
The application offers a user-friendly interface for seamless interaction with the AI model, 
making cutting-edge technology accessible to end users.

> The maintainer of this repository is [Dave Roman](https://github.com/MrDave1999).
>
> This project has been improved too much since its [first alpha version](https://github.com/DentallApp/back-end/tree/v0.1.0). 

## Index

- [Motivations](#motivations)
- [Rationale Behind](#rationale-behind)
- [Technologies used](#technologies-used)
- [Intel Hardware and Software Utilized](Intel-Hardware-and-Software-Utilized)
  - [Softwares Links](#Softwares-Links)
  - [Frameworks and libraries](#frameworks-and-libraries)
  - [Procedure/ Steps](#Procedure/-Steps)
  - [Own libraries](#own-libraries)
- [Diagrams](#diagrams)
  - [Mouth opining using intel real sense camera](#Mouth-opining-using-intel-real-sense-camera)
  - [OAMF lesion classification](OAMF-lesion-classification)
- [Contributors](#Contributors)

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
- [ultralytics.yolov8](https://github.com/ultralytics/ultralytics/blob/main/docs/en/models/yolov8.md)
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

**Additional references:**
- [Software principles and design](https://deviq.com)
- [Plugin Architecture Pattern in C# by Alvaro Montoya](https://code-maze.com/csharp-plugin-architecture-pattern)
- [Plugin Architecture Design Pattern by Nick Cosentino](https://www.devleader.ca/2023/09/07/plugin-architecture-design-pattern-a-beginners-guide-to-modularity)
- [Plugin Architecture In C# For Improved Software Design by Nick Cosentino](https://www.devleader.ca/2024/03/12/plugin-architecture-in-c-for-improved-software-design)
- [Vertical Slice Architecture in ASP.NET Core by Swapnil Meshram](https://www.linkedin.com/pulse/vertical-slice-architecture-aspnet-core-swapnil-meshram-sitsf)
- [Vertical Slice Architecture in ASP.NET Core by Code Maze](https://code-maze.com/vertical-slice-architecture-aspnet-core)

## Diagrams

### General architecture

<details>
<summary><b>Show diagram</b></summary>

![Mouth opining using intel real sense camera](https://github.com/parth-deshmukh-code/OCan_Predict/blob/dev/diagrams/Mouth%20opening%20uing%20Intel%20REALSENSE%20camera.png)

</details>
<details>
<summary><b>Show diagram</b></summary>

![OAMF lesion classification](https://github.com/parth-deshmukh-code/OCan_Predict/blob/dev/diagrams/OSMF%20lesion%20classification.png)

</details>

## Procedure/ Steps

### OSMF Mouth Opening Staging Using Intel RealSense Camera
- Start the Intel RealSense D405 Depth Camera.
- Ask the patient to seat in fron of camera 
- Capture snapshot and depth data.
- Detect upper and lower lip landmarks.
- Identify Region of Interest (ROI), apply histogram equalization, and thresholding.
- Calculate vertical distances in ROI and find the median vertical distance in pixels.
- Convert distance to real-world units using a calibration factor.
- Determine OSMF stages based on mouth opening distance.

### OSMF Lesion Classification Using Deep Learning and Intel Hugging Face 
- Collect OSMF image database.
- Annotate images using Roboflow.
- Apply data augmentation.
- Train the YOLOv8 deep learning model.
- Deploy the trained model on Intel Hugging Face.
- Test images using an intra-oral camera.
- Perform OSMF classification:
  - OSMF Detected (if lesions are found).
  - No OSMF (if lesions are not found).


## Contributors 

- Dr.Vibha Bora,Principal Investigator
- Mr.Chaitanya Wankhede,Junior Research Fellow
- Mr.Bhanu Nagpure, VIII Sem CSE Student
- Mr.Parth Deshmukh,VI Sem ETRX Student
- Mr.Piyush Choudhari,VI Sem ETRX Student
- Mr.Ashwin Khapre,VI Sem ETRX Student
- Ms.Sakshi Dhore,VI Sem ETRX Student


