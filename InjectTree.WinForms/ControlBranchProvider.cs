using System;
using System.Collections;
using System.Windows.Forms;

namespace InjectTree.WinForms;

public class ControlBranchProvider : IBranchProvider
{
    public IEnumerable GetBranches(object node)
    {
        return node is Control control ? control.Controls : Array.Empty<object>();
    }
}