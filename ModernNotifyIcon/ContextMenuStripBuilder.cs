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

        public ContextMenuStripBuilder AddSeparator() => AddItem(new ToolStripSeparator());

        public ContextMenuStripBuilder AddToggle(Action<ToggleGenerateOption> option)
        {
            var optionRef = new ToggleGenerateOption();
            option.Invoke(optionRef);
            var toggle = new ToolStripButton(optionRef.Text);
            toggle.Click += (_, _) => optionRef.InvokeHandlers(toggle.Checked = !toggle.Checked);
            return this;
        }

        public ContextMenuStripBuilder AddButton(Action<ButtonGenerateOption> option)
        {
            var optionRef = new ButtonGenerateOption();
            option.Invoke(optionRef);
            var button = new ToolStripButton(optionRef.Text);
            button.Click += (_, _) => optionRef.InvokeHandlers();
            return this;
        }

        public ThemeReferencedContextMenuStrip Build()
        {
            var strip = new ThemeReferencedContextMenuStrip();
            var array = Items.ToArray();
            for (var i = 0; i < array.Length; ++i)
            {
                array[i].Padding = new Padding(0, 5, 0, 5);
                array[i].Margin += new Padding(0, i == 0 ? 5 : 0, 0, i == array.Length - 1 ? 5 : 0);
            }
            strip.Items.AddRange(array);
            return strip;
        }
    }
}
