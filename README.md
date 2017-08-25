#NLog Based Singleton Logger
Used for logging to local machine.

##Setting Up
###In Explorer
Create "Resources" folder in solution, add "NLogger.dll" and "NLog.config" to this folder.
###In Visual Studio
- Add NLogger.dll as reference to project you want to log
- Add NLog.config to project, so it appears with normal app.config file
- Set NLog.config to always copy to output directory
