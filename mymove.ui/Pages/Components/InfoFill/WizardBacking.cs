namespace mymove.ui;

public record struct WizardComponentParameters
(
    IEnumerable<WizardElement> Elements,
    int InitialStartingIndex = 0
);

public record WizardComponentItems
(
    IEnumerable<IWizardElement> WizardElements
)
{
    public void SetWizardIndex(int index) => SetCurrentIndex(index);

    public IWizardElement GetCurrentWizardElement()
    {
        var index = GetCurrentIndex();
        return CurrentWizard.Element!;
    }

    protected WizardOfIndex CurrentWizard { get; set; }

    protected int GetCurrentIndex() => SetCurrentIndex(CurrentWizard.Index);
    protected int SetCurrentIndex(int index)
    {
        if (CurrentWizard is { Element: null }
            || (CurrentWizard is { Index: var a, Element: not null } && a != index)
        ){
            CurrentWizard = WizardElements.ElementAtOrDefault(index) switch
            {
                {} wizard => new (index, wizard),
                _ => CurrentWizard
            };
        }
        
        return CurrentWizard.Index;
    }

    public void NextWizard() => SetCurrentIndex(CurrentWizard.Index+1);
    public void PreviousWizard() => SetCurrentIndex(CurrentWizard.Index-1);
}

public record struct WizardOfIndex(int Index, IWizardElement Element);