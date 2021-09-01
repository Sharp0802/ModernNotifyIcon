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
	.Build(Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location)!);

notification.Visible = true;

Application.Run();