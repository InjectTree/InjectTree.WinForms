using System.Windows.Forms;

namespace InjectTree.WinForms.Tests;

public class MyToolStripControlHost : ToolStripControlHost
{
    public MyToolStripControlHost() : base(new Button(), "innerButton")
    {
    }
}