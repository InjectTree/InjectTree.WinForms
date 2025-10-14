using System;
using System.Collections;
using System.Windows.Forms;

namespace InjectTree.WinForms;

public class ToolStripBranchProvider : IBranchProvider
{
    public IEnumerable GetBranches(object node)
    {
        return node is ToolStrip toolStrip ? toolStrip.Items : Array.Empty<object>();
    }
}