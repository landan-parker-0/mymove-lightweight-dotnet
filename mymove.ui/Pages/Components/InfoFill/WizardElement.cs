using Microsoft.AspNetCore.Components;

namespace mymove.ui;

public interface IWizardItemBase
{
    public RenderFragment WizardItemComponent { get; }
}

public record WizardItemBase<T>(Func<T?, RenderFragment> Fragment) : IWizardItemBase<T>
{
    public ModelSource<T?> ModelSource { get; set; } = new(default!);
    public RenderFragment WizardItemComponent => Fragment(ModelSource.Model);
}

public static class WizardItemBaseExt
{
    public static WizardItemBase<T> AsWizardItemBase<T>(this T? instance, Func<T?, RenderFragment> Fragment)
        => new (Fragment){ ModelSource = new (instance) };
}

public record ModelSource<T>(T Model){}

public interface IWizardItemBase<T> : IWizardItemBase
{
    public ModelSource<T?> ModelSource { get; set; }
}

public interface Render
{
    public RenderFragment Render { get; }
}

public interface IWizardElement: Render
{
    public IEnumerable<IWizardItemBase> WizardItems { get; init; }
}

public record WizardElement
(
    IEnumerable<IWizardItemBase> WizardItems
) : IWizardElement
{
    public RenderFragment Render => WizardItems.Aggregate
    (
        (RenderFragment)(b=>{}),
        (fragment, wizard) => fragment += wizard.WizardItemComponent
    );
}