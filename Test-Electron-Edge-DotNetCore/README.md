# Sample Electron application using .Net Core via Edge

This illustrates the basic functionality of using Edge to tie an Electron Javascript application to .Net Core c# code.

It also illustrate the bare-bones of packaging up the Electron application.


## Installs
 1. Install Node 7.4.0
 2. Use npm 4.0.5 or newer
 3. Install .Net Core 1.0.0-preview2-1-003177
 4. [OSX specific] Install Mono 4.6

## Builds

The whole application can be built using the electron packager. This will build all the dependencies and put all the files in the correct places etc for a valid runnable application - either for running locally or as a packaged app.

### Build script setup

To faciliate building on different platforms (currently Win and OSX), the `package.json` needs to update to call the correct scripts for doing the specific building and packaging. Change the appropriate scripts to use the `-win` or `-osx` postfixes depending on your platform:

```
"app-install": "npm run app-install-osx",
"app-clean": "npm run app-clean-osx",
"bridge-build-dotnetcore-clean": "npm run bridge-build-dotnetcore-clean-osx",
"bridge-copy-dotnetcore": "npm run bridge-copy-dotnetcore-osx",
```

### The whole app in one process

 1. Update `package.json` for the platform-specific build scripts as mentioned above
 
 2. Install the Electron project dependencies.
 
  	 In this folder, call the following:
    
  	 - [Windows] `npm install`
	 - [OSX] `PKG_CONFIG_PATH=/Library/Frameworks/Mono.framework/Versions/Current/lib/pkgconfig npm install`

 3. Build the project.
 
	In this folder, call the following:
 
	`npm run rebuild`

## Running

The project will have to be built first (see above) to be able to run the app.
In this folder, call the following:

`npm start`

## Cleaning

To clean the build project.
In this folder, call the following:

`npm run clean`

## Packaging

### Packing to a Local Folder
If you have already build the whole project (e.g. through `npm run rebuild`), then you can package the current state of it.
In this folder, call the following:

`npm run pack`

This will make a folder `dist/win-unpacked` where the whole project has been packed to.

### Packing to an Installer
Making an installer will *always* rebuild the whole project to make sure of a clean build that is made for the installer for distribution
In this folder, call the following:

`npm run dist`

This will make an installer executable in the folder `dist/`.
Running this installer will install the app for the current user and launch it. Subsequent launching of the app can be done through the platform's typical means.

It will also make the unpacked version of the project in `dist/win-unpacked` as a first step before making the installer similar to running `npm run pack` as above.
