using ModernNotifyIcon.Theme;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ModernNotifyIcon
{
	public class ContextMenuStripBuilder
	{
		private List<ToolStripItem> Items { get; } = new();

		private ContextMenuStripBuilder AddItem(ToolStripItem item)
		{
			Items.Add(item);
			return this;
		}

		public ContextMenuStripBuilder AddText(string text) => AddItem(new ToolStripMenuItem(text));

		public ContextMenuStripBuilder AddSeparator() => AddItem(new ToolStripSeparator {Margin = new Padding(0, 2, 0, 2)});

		public ContextMenuStripBuilder AddToggle(Action<ToggleGenerateOption> option)
		{
			var optionRef = new ToggleGenerateOption();
			option.Invoke(optionRef);
			var toggle = new ToolStripMenuItem(optionRef.Text);
			toggle.Click += (_, _) => optionRef.InvokeHandlers(toggle.Checked = !toggle.Checked);
			return AddItem(toggle);
		}

		public ContextMenuStripBuilder AddButton(Action<ButtonGenerateOption> option)
		{
			var optionRef = new ButtonGenerateOption();
			option.Invoke(optionRef);
			var button = new ToolStripMenuItem(optionRef.Text);
			button.Click += (_, _) => optionRef.InvokeHandlers();
			return AddItem(button);
		}

		public ThemeReferencedContextMenuStrip Build()
		{
			const int padding = 5;

			var strip = new ThemeReferencedContextMenuStrip {Spacing = padding};
			var array = Items.ToArray();
			for (var i = 0; i < array.Length; ++i)
			{
				array[i].Padding = new Padding(0, padding, 0, padding);
				array[i].Margin += new Padding(0, i == 0 ? padding : 0, 0, i == array.Length - 1 ? padding : 0);
			}

			strip.Items.AddRange(array);
			return strip;
		}
	}
}