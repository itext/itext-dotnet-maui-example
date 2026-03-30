# iText .NET MAUI example

## Description
A sample .NET MAUI project which uses iText to test how it works on iOS platform.

## Software Requirements
1. .NET 10+
   1. Installation can be checked by running `dotnet --info`.
2. Installed .NET MAUI
   1. Run `dotnet workload install maui` to install MAUI.
   2. Verify that MAUI was installed by running `dotnet workload list`.
3. Rider or VisualStudio 2022+.
4. (Mac only) Xcode 26.2+

This README was written based on workflow on macOS 26 using Rider.

## Instructions
### iOS simulator
To build App for iOS simulator
```bash
dotnet build ./itext-dotnet-maui-example.sln /property:GenerateFullPaths=true /p:Configuration=Release -f net10.0-ios
dotnet build ./itext-dotnet-maui-example.sln /property:GenerateFullPaths=true /p:Configuration=Release -f net10.0-ios -t:Run -p:_DeviceName=:v2:udid=<DEVICE_ID>
```
where <DEVICE_ID>> is the device ID to run the App on. Put your device ID here instead.

To create a iOS App one needs
1. Enroll to Apple developer program.
1. Follow instructions on how to create development certificate, add devices, create provisioning profile.
1. If App is not installed on your test device: update tools/SDKs to the latest versions if your Mac allows, google, build, restart, repeat until solved.
