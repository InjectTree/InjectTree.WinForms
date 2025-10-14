using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace InjectTree.WinForms.Tests;

[TestFixture]
public class InjectTreeWinFormsTests
{
    private IServiceProvider? _serviceProvider;
    private ITreeTraversalStrategy? _treeTraversalStrategy;

    [SetUp]
    public void SetUp()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddInjectTree();
        serviceCollection.AddInjectTreeWinForms();

        _serviceProvider = serviceCollection.BuildServiceProvider();
        _treeTraversalStrategy = _serviceProvider.GetRequiredService<ITreeTraversalStrategy>();
    }

    [Test]
    public void Default_EnumerateMenuStrip_Tests()
    {
        Debug.Assert(_serviceProvider != null, nameof(_serviceProvider) + " != null");
        Debug.Assert(_treeTraversalStrategy != null, nameof(_treeTraversalStrategy) + " != null");

        // Arrange
        var menuStrip = new MenuStrip();
        var item1 = new ToolStripMenuItem("Item1");
        var item2 = new ToolStripMenuItem("Item2");

        menuStrip.Items.Add(item1);
        menuStrip.Items.Add(item2);

        // Act
        var allControls = _treeTraversalStrategy.EnumerateNodes(menuStrip, _serviceProvider).OfType<object>().ToArray();

        // Assert
        Assert.That(allControls, Contains.Item(item1));
        Assert.That(allControls, Contains.Item(item2));
    }


    [Test]
    public void Default_EnumerateSplitContainer_Tests()
    {
        Debug.Assert(_serviceProvider != null, nameof(_serviceProvider) + " != null");
        Debug.Assert(_treeTraversalStrategy != null, nameof(_treeTraversalStrategy) + " != null");

        // Arrange
        var split = new SplitContainer();
        var button1 = new Button { Name = "Button1" };
        var button2 = new Button { Name = "Button2" };

        split.Panel1.Controls.Add(button1);
        split.Panel2.Controls.Add(button2);

        // Act
        var allControls = _treeTraversalStrategy.EnumerateNodes(split, _serviceProvider).OfType<object>().ToArray();

        // Assert
        Assert.That(allControls, Contains.Item(button1));
        Assert.That(allControls, Contains.Item(button2));
    }


    [Test]
    public void Default_EnumerateTabControl_Tests()
    {
        Debug.Assert(_serviceProvider != null, nameof(_serviceProvider) + " != null");
        Debug.Assert(_treeTraversalStrategy != null, nameof(_treeTraversalStrategy) + " != null");

        // Arrange
        var tabControl = new TabControl();
        var page1 = new TabPage();
        var button1 = new Button { Name = "Button1" };
        var page2 = new TabPage();
        var button2 = new Button { Name = "Button2" };

        page1.Controls.Add(button1);
        page2.Controls.Add(button2);

        tabControl.TabPages.Add(page1);
        tabControl.TabPages.Add(page2);

        // Act
        var allControls = _treeTraversalStrategy.EnumerateNodes(tabControl, _serviceProvider).OfType<object>().ToArray();

        // Assert
        Assert.That(allControls, Contains.Item(button1));
        Assert.That(allControls, Contains.Item(button2));
    }

    [Test]
    public void Default_EnumerateToolStrip_Tests()
    {
        Debug.Assert(_serviceProvider != null, nameof(_serviceProvider) + " != null");
        Debug.Assert(_treeTraversalStrategy != null, nameof(_treeTraversalStrategy) + " != null");

        // Arrange
        var toolStrip = new ToolStrip();
        var item1 = new ToolStripMenuItem("Item1");
        var item2 = new ToolStripMenuItem("Item2");

        toolStrip.Items.Add(item1);
        toolStrip.Items.Add(item2);

        // Act
        var allControls = _treeTraversalStrategy.EnumerateNodes(toolStrip, _serviceProvider).OfType<object>().ToArray();

        // Assert
        Assert.That(allControls, Contains.Item(item1));
        Assert.That(allControls, Contains.Item(item2));
    }
}