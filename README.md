# ModernNotifyIcon

## What is this?

ModernNotifyIcon is library that make you to can use windows 10 style menu for notify icon.

## How to use?

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
            .AddHandler(toggled => { /* Another handler */ })))
    .Build(Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location)); // Get icon of assembly
    
notification.Visible = true;
```