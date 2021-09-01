using System.Windows.Forms;

namespace ModernNotifyIcon.Theme
{
    public class ThemeReferencedContextMenuStrip : ContextMenuStrip
    {
        public ThemeReferencedRenderer ThemeReferencedRenderer { get; }

        public int Spacing 
        { 
            get => ThemeReferencedRenderer.VerticalPadding;
            set => ThemeReferencedRenderer.VerticalPadding = value; 
        }

        public ThemeReferencedContextMenuStrip()
        {
            Renderer = ThemeReferencedRenderer = new ThemeReferencedRenderer();
            ItemAdded += ItemsChanged;
            ItemRemoved += ItemsChanged;
        }

        private void ItemsChanged(object sender, ToolStripItemEventArgs e)
        {
            foreach (var item in Items)
            {
                if (item is not ToolStripItem stripItem)
                    continue;
                stripItem.Padding = new Padding(0, Spacing, 0, Spacing);
            }
        }
    }
}
