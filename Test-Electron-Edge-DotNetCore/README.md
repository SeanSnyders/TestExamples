
## Installs
 1. Install Node 6.9.2
 2. Use npm 4.0.3 or newer
 3. Install .Net Core 1.0.0-preview2-1-003177

## Builds

The whole application can be built using the electron packager. This will build all the dependencies and put all the files in the correct places etc for a valid runnable application - either for running locally or as a packaged app.

### The whole app in one step

 1. Install the Electron project dependencies.
 
  	 In this folder, call the following:
    
  	 `npm install`

 2. Build the project.
 
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
