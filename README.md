# InjectTree.WinForms

WinForms extension for [InjectTree](https://github.com/InjectTree/InjectTree) — no `IInjectedTreeNode` implementation required.

## What it does

Adds an `IBranchProvider` that knows how to walk a native WinForms tree, so `InjectTreeUtilities` can traverse and inject any `Form`/`UserControl` out of the box. It discovers:

- child `Control`s (`Control.Controls`)
- a control's `ContextMenuStrip`, if set
- `ToolStripItem`s of a `ToolStrip`
- nested items of a `ToolStripDropDownItem`

## Install

```bash
dotnet add package InjectTree
dotnet add package InjectTree.WinForms
```

Targets `net48` and `net8.0-windows`.

## Setup

```csharp
var services = new ServiceCollection();

services.AddInjectTree();          // core InjectTree services
services.AddInjectTreeWinForms();  // + WinForms tree walking

services.AddSingleton<ILogger, ConsoleLogger>();
services.AddTreeSingleton<MainForm>();
```

That's it — every `Control`, `ContextMenuStrip` and `ToolStrip` item in the form's tree is now visited automatically, and any `[InjectedLeafProperty]` on them gets resolved.

## License

[BSD-3-Clause](LICENSE)
