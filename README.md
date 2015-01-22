Blackbaud-CRM-Manipulate-Batch-With-AppFxWebService
===================================================

## What You Will Build ##

This customization demonstrates how to use an Infinity Web API to create a batch from an existing batch template and then add rows to the new batch. 

##Resources##
* See the [Blackbaud CRM Read Me](https://github.com/blackbaud-community/Blackbaud-CRM/blob/master/README.md). 
* [Step by Step Instructions](https://www.blackbaud.com/files/support/guides/infinitydevguide/Subsystems/inwebapi-developer-help/Content/InfinityBatch/coManipulatingBatchWithThe.htm) for manipulating a batch with the AppFxWebService
* [Infinity Web API](https://www.blackbaud.com/files/support/guides/infinitydevguide/infsdk-developer-help.htm#../Subsystems/inwebapi-developer-help/Content/InfinityWebAPI/WelcomeInfinityWebAPI.htm) Chapter within Developer Guides

##Prerequisites##

Within /BatchWebAPISample/BatchWebAPISample/Form1.vb provide the values for the following contants:
- Const serviceUrlBasePath As String = "http://localhost/bbappfx/" ' the base url for the app fx web service.
- Const databaseName As String = "BBInfinity" ' the name of the database key.  See key named REDBList within web.config on your IIS server for a listing correct database key names.  
- Const applicationTitle As String = "BatchWebAPISample" ' the name of your app used for auditing purposes

##Contributing##

Third-party contributions are how we keep the code samples great. We want to keep it as easy as possible to contribute changes that show others how to do cool things with Blackbaud SDKs and APIs. There are a few guidelines that we need contributors to follow.

For more information, see our [canonical contributing guide](https://github.com/blackbaud-community/Blackbaud-CRM/blob/master/CONTRIBUTING.md) in the Blackbaud CRM repo which provides detailed instructions, including signing the [Contributor License Agreement](http://developer.blackbaud.com/cla).
