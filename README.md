# ModernNotifyIcon

![](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
[![](https://img.shields.io/badge/NuGet-004880?style=for-the-badge&logo=nuget&logoColor=white)](https://www.nuget.org/packages/ModernNotifyIcon/)

## What is this?

ModernNotifyIcon is library that make you to can use windows 10 style menu for notify icon.

## How to install?

In your csproj :
```xml
<PackageReference Include="ModernNotifyIcon" Version="1.1.0" />
```

Or, if you using .net cli :
```powershell
dotnet add package ModernNotifyIcon --version 1.1.0
```

## How to use?

In your csproj :
```xml
<PropertyGroup>
    <!-- net5.0-windows10.0.19041.0 or above -->
    <TargetFramework>net5.0-windows10.0.19041.0</TargetFramework>
</PropertyGroup>
```

In your source code :
```c#
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

using ModernNotifyIcon;

var notification = NotifyIconBuilder
	.Create()
	.Configure(builder => builder
		.AddText("Sample text")
		.AddSeparator()
		.AddButton(option => option
			.SetText("Sample button")
			.AddHandler(() => { /* On state changed */ }))
		.AddToggle(option => option
			.SetText("Sample toggle")
			.AddHandler(toggled => { /* One handler */ })
			.AddHandler(toggled => { /* Another handler */ }))
		.AddSubmenu("Sample submenu", sub => sub
			.AddText("Sample text")
			.AddSeparator()
			.AddButton(option => option
				.SetText("Sample button")
				.AddHandler(() => { /* On state changed */ }))
			.AddToggle(option => option
				.SetText("Sample toggle")
				.AddHandler(toggled => { /* One handler */ })
				.AddHandler(toggled => { /* Another handler */ }))))
	.Build(Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location)!);
    
notification.Visible = true;
```