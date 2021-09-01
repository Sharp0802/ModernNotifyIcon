using ModernNotifyIcon.Theme;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ModernNotifyIcon
{
    public class ContextMenuStripBuilder
    {
        protected List<ToolStripItem> Items { get; } = new(); 

        public ContextMenuStripBuilder AddItem(ToolStripItem item)
        {
            Items.Add(item);
            return this;
        }

        public ContextMenuStripBuilder AddText(string text) => AddItem(new ToolStripMenuItem(text));

        public ContextMenuStripBuilder AddSeperator() => AddItem(new ToolStripSeparator());

        public sealed class ToggleGenerateOption
        {
            public delegate void ToggleEventHandler(bool toggled);

            public string? Text { get; private set; }

            public event ToggleEventHandler? Toggled;

            public ToggleGenerateOption SetText(string text)
            {
                Text = text;
                return this;
            }

            public ToggleGenerateOption AddHandler(ToggleEventHandler handler)
            {
                Toggled += handler;
                return this;
            }

            internal void InvokeHandlers(bool check)
            {
                Toggled?.Invoke(check);
            }
        }

        public ContextMenuStripBuilder AddToggle(Action<ToggleGenerateOption> option)
        {
            var optionRef = new ToggleGenerateOption();
            option.Invoke(optionRef);
            var toggle = new ToolStripButton(optionRef.Text);
            toggle.Click += (_, _) => {
                optionRef.InvokeHandlers(toggle.Checked = !toggle.Checked);
            };
            return this;
        }

        public ThemeReferencedContextMenuStrip Build()
        {
            var strip = new ThemeReferencedContextMenuStrip();
            strip.Items.AddRange(Items.ToArray());
            return strip;
        }
    }
}
