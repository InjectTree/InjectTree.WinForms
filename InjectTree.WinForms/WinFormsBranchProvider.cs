using System.Collections;
using System.Windows.Forms;

namespace InjectTree.WinForms;

internal sealed class WinFormsBranchProvider : IBranchProvider
{
    public IEnumerable GetBranches(object node)
    {
        if (node is Control control)
        {
            var contextMenuStrip = control.ContextMenuStrip;
            if (contextMenuStrip is not null)
                yield return contextMenuStrip;

            foreach (Control child in control.Controls)
            {
                yield return child;
            }
        }

        if (node is ToolStrip toolStrip)
        {
            foreach (ToolStripItem child in toolStrip.Items)
            {
                yield return child;
            }
        }

        if (node is ToolStripDropDownItem toolStripDropDownItem)
        {
            foreach (ToolStripItem child in toolStripDropDownItem.DropDownItems)
            {
                yield return child;
            }
        }
    }
}