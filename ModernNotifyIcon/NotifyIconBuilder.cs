using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModernNotifyIcon
{
	public class NotifyIconBuilder
	{
		private ContextMenuStripBuilder StripBuilder { get; } = new();

		protected NotifyIconBuilder()
		{
		}

		public static NotifyIconBuilder Create()
		{
			return new NotifyIconBuilder();
		}

		public NotifyIconBuilder Configure(Action<ContextMenuStripBuilder> builder)
		{
			builder(StripBuilder);
			return this;
		}

		public NotifyIcon Build(Icon icon)
		{
			return new NotifyIcon
			{
				Icon = icon,
				ContextMenuStrip = StripBuilder.Build()
			};
		}
	}
}