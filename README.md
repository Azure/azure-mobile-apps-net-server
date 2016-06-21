# Azure Mobile Apps .NET Server SDK

This repo contains the .NET backend for **Azure Mobile Apps**. The Mobile Apps .NET backend is a peer to the [Node.js backend](https://github.com/Azure/azure-mobile-apps-node), giving users a choice in backend platform.

## Download Source Code

To get the source code and a sample backend via **git** just type:

    git clone https://github.com/Azure/azure-mobile-apps-net-server.git
    cd ./azure-mobile-apps-net-server/

## Building and Running Tests

The solution must be built in Visual Studio 2013 or 2015.

1. Open the ```ServerSDK.sln``` solution file in Visual Studio.
2. Press ```F7``` or ```Ctrl```+```Shift```+```B``` to build the solution.

### Running the Tests

After you've built the SDK, open the Test Explorer in Visual Studio (Test->Windows->Test Explorer) or search "Test Explorer" in the Quick Launch bar (```Ctrl```+```Q```) in VS 2015.  In the window, press "Run all" or use the dropdown to run a subset of tests.

## Running the Sample App

There is a sample web project in the 'sample' folder in the solution.  It contains controllers which excercise several features of the SDK.

To run the sample project:

* Right click on the 'SampleApp' project and select 'Set as startup project'.
* Hit ```F5``` to run the project in the browser of your choice (or ```Ctrl```+```F5``` to start without debugging).
* A welcome page should be displayed, indicating the service is running.
* You can now issue requests (such as GET or POST) to the backend from your browser.

## Useful Resources

* Tutorials and product overview are available at [Microsoft Azure Mobile Services Developer Center](https://azure.microsoft.com/en-us/documentation/learning-paths/appservice-mobileapps/).
* See the [Mobile Apps .NET server SDK topic](https://azure.microsoft.com/documentation/articles/app-service-mobile-dotnet-backend-how-to-use-server-sdk/) for details on how to work with this SDK.
* The [wiki for this repo](./wiki) is where we document issues and other interesting behaviors of the Mobile Apps .NET server SDK. 
* Our product team actively monitors the [Mobile Services Developer Forum](https://social.msdn.microsoft.com/forums/azure/en-US/home?forum=azuremobile) and [Stackoverflow](http://stackoverflow.com/questions/tagged/azure-mobile-app) to assist you with any troubles.

## Contribute Code or Provide Feedback

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

If you would like to become an active contributor to this project please follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines](http://azure.github.com/guidelines.html).

If you encounter any bugs with the library please file an issue in the [Issues](https://github.com/Azure/azure-mobile-apps-net-server/issues) section of the project.

## License

[Apache (2.0)](./LICENSE)