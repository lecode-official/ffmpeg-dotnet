# FFmpeg.NET

FFmpeg.NET is a .NET Core wrapper around the native FFmpeg libraries. It is currently in a very ***early*** stage of development and is definitely ***not***
production ready. This project aims to be cross platform, but currently it has only been tested under Ubuntu 14.04 and Ubuntu 16.04. If you have managed to
get FFmpeg.NET running under Windows or MacOS, I would greatly appreciate if you would share your experiences.

## Using the Project

If you want to you can download and manually build the solution. The project was built using Visual Studio Code under Ubuntu. Just clone the Git repository:

```batch
git clone https://github.com/lecode-official/ffmpeg-dotnet.git
```

Before using FFmpeg.NET, you need to install the latest version of FFmpeg. The source includes an installation script, which downloads, builds, and installs
everything for you:

```batch
cd ffmpeg-dotnet/Installation
sudo bash InstallFFmpeg.sh
```

Also, if you haven't installed the latest version of .NET Core, you can install it using the provided installation script:

```batch
cd ffmpeg-dotnet/Installation
sudo bash InstallDotNetCore.sh
```

After that, you can just `dotnet restore` and `dotnet build` the projects. A basic sample is provided with the source code:

```batch
cd ffmpeg-dotnet/Source/FFmpegDotNet.Interop
dotnet restore
dotnet build
cd ../FFmpegDotNet.Samples.FrameExtraction
dotnet restore
dotnet build
dotnet run
```

## Contributions

Currently I am not accepting any contributors, but if you want to help, I would greatly appreciate feedback and bug reports. To file a bug, please use GitHub's
issue system. Alternatively, you can clone the repository and send me a pull request.