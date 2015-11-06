#Attask-Helper

Generates AtTask changeset information for Caselle 

##What it Looks Like

When you select a changeset it builds something you can paste for an update for the defect like so:

```
Build Development.1337 revision 55420 (d1fa25bef1a3)

MasterSln/Caselle.Um0/Caselle.Um0.WrsObserver/Actions/LocationInformationAction.cs
MasterSln/Caselle.Um0/Caselle.Um0.WrsObserver/Caselle.Um0.WrsObserver.csproj
MasterSln/Caselle.Um0/Caselle.Um0.WrsObserver/DTO/ThinLocation.cs
MasterSln/Caselle.Um0/Caselle.Um0.WrsObserver/Messages/LocationInformationMessgae.cs
```

It even works for if you did a defect in 147 or in Prerelease

```
Build 4.2.147.1337 revision 48156 (f62c0756f556)
Build 2016.02.1337
Build Development.1337

MasterSln/Caselle.Cd0/Caselle.Cd0.DAL.Interfaces/ICd0Data.Transaction.cs
MasterSln/Caselle.Cd0/Caselle.Cd0.DAL/Cd0DataAccess.Transaction.cs
MasterSln/Caselle.Cd0/Caselle.Cd0.DTO/TrustDisposition.cs
MasterSln/Caselle.Cd0/Caselle.Cd0.MVC/Miscellaneous/UpdateGL/GLTransactionSummary.cs
MasterSln/Caselle.Cd0/Caselle.Cd0.MVC/Miscellaneous/UpdateGL/UpdateGLPhase.cs
MasterSln/Caselle.Cd0/Caselle.Cd0.MVC/Miscellaneous/UpdateGL/UpdateGLProcess.cs
MasterSln/Caselle.Cd0/Caselle.Cd0.MVC/Miscellaneous/UpdateGL/UpdateGLView.cs
MasterSln/Caselle.Cd0/Caselle.Cd0.Utility/GeneralLedgerUtility.cs
MasterSln/Caselle.Constants/Views.cs
```

##How to use it

AtTask Helper makes a couple of assumptions about how you manage your workflow that are pretty safe for Caselle employees  
1. Your computer username is the same as your Degobah login (eg. ATH for me)  
2. Deathstar is currently running (Not grey in CCTray)  

The first time that AtTask-Helper runs per release it attempts to find all of your hg repositories to build up profiles for processing.  After that it will run an options dialog that allows you to select the directories that all of your code is in.

After running there is a profile dropdown, this allows you to select which repository you're wanting to build a comment for
If you want to select one automatically on run you can just create a shortcut that has the profile name after the target (eg. Target: `"D:\AllanIsTheBestCoderEver\AtTask-Helper\AtTask-Helper.exe" Development`

Now that it's running you can simply click in the big box to copy the Changeset information, or click "Copy" to copy any build information.


##How it Works

AtTask-Helper pulls information from two places  
1. From the HG repository on your machine  
2. And from `http://deathstar/ccnet`

The HG repo contains the majority of the information that is being used to generate the main message.  All of the build information, on the other hand, is pulled directly from Deathstar.

To get the build number that will contain your changeset it assumes you just barely pushed and then looks at the status of the server.  If the server is already building it means that your changeset won't be in this *next* completed build and will have to wait one more build, so it just adds two to the previous build number.  If the server is not building, it just adds one.
`
