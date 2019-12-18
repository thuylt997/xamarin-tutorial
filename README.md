# Building your mobile app using Xamarin.
<p align="center">
    <img src="https://docs.microsoft.com/en-us/xamarin/get-started/what-is-xamarin-images/xamarin-app-cropped.png" />
</p>

Xamarin.Forms is a cross-platform UI toolkit that allows developers to efficiently create native user interface layouts that can be shared across iOS, Android, and Universal Windows Platform apps. For the full Xamarin.Forms documentation, see Xamarin.Forms Documentation.

## Getting Started

### What is Xamarin?
Xamarin is an open-source platform for building modern and performant applications for iOS, Android, and Windows with .NET. Xamarin is an abstraction layer that manages communication of shared code with underlying platform code. Xamarin runs in a managed environment that provides conveniences such as memory allocation and garbage collection.

Xamarin enables developers to share an average of 90% of their application across platforms. This pattern allows developers to write all of their business logic in a single language (or reuse existing application code) but achieve native performance, look, and feel on each platform.

Xamarin applications can be written on PC or Mac and compile into native application packages, such as an .apk file on Android, or an .ipa file on iOS.

### Who Xamarin is for
Xamarin is for developers with the following goals:
- Share code, test and business logic across platforms.
- Write cross-platform applications in C# with Visual Studio.

## Requirements
* **Development Environment**
    - macOS: Visual Studio for Mac
    - Android: Visual Studio
* **Xamarin.iOS**
    - macOS: Yes
    - Android: Yes (with Mac computer)
* **Xamarin.Android**
    - macOS: Yes
    - Android: Yes
* **Xamarin.Forms ^**
    - macOS: iOS & Android
    - Android: Android, Windows/UWP (iOS with Mac computer)
* **Xamarin.Mac**
    - macOS: Yes
    - Android: Open project & compile only

## Installation
1. Clone the repository
```sh
git clone https://github.com/thuyducati/xamarin-tutorial
```
2. Rebuild the project
- This repo includes 2 projects, choose one of these projects and open it using Visual Studio.
- Build the project to get all neccesary NuGet Packages.
3. In the Visual Studio toolbar, press the Start button (the triangular button that resembles a Play button) to launch the application inside your chosen remote iOS simulator or Android emulator.