using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace InjectTree.WinForms.Tests;

[TestFixture]
public class TestFormTests
{
    private ServiceProvider _serviceProvider;

    [SetUp]
    public void SetUp()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<ITreeTraversalStrategy, DefaultTreeTraversalStrategy>();
        serviceCollection.AddSingleton<ILeafPropertyInjectionStrategy, TagPropertyInjectionStrategy>();
        serviceCollection.AddInjectTreeWinForms();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    [Test]
    public void TestFormInjectionTest()
    {
        var sut = InjectTreeUtilities.CreateInstance<TestForm>(_serviceProvider);

        Assert.That(sut.button1.Tag, Is.EqualTo("injected"));
        Assert.That(sut.menuStrip1.Tag, Is.EqualTo("injected"));
        Assert.That(sut.contextMenuStrip1.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripContainer1.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripMenuItem1.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripComboBox1.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripTextBox1.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripMenuItem2.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripComboBox2.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripSeparator1.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripTextBox2.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripMenuItem3.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripComboBox3.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripSeparator2.Tag, Is.EqualTo("injected"));
        Assert.That(sut.toolStripTextBox3.Tag, Is.EqualTo("injected"));
        Assert.That(sut.panel1.Tag, Is.EqualTo("injected"));
        Assert.That(sut.myToolStripControlHost.Tag, Is.EqualTo("injected"));
        Assert.That(sut.myToolStripControlHost.Control.Tag, Is.EqualTo("injected"));
    }

    private class TagPropertyInjectionStrategy : ILeafPropertyInjectionStrategy
    {
        public void Inject(object instance, IServiceProvider serviceProvider, params object[] parameters)
        {
            instance
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(p => p is { CanWrite: true, Name: "Tag" })
                ?.SetValue(instance, "injected");
        }
    }
}