using ModernNotifyIcon.Theme;

using System.Collections.Generic;
using System.Windows.Forms;

namespace ModernNotifyIcon
{
    public class ContextMenuStripBuilder
    {
        protected List<ToolStripMenuItem> Items { get; } = new(); 

        public ContextMenuStripBuilder AddItem(ToolStripMenuItem item)
        {
            Items.Add(item);
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
