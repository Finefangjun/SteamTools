using Avalonia.Automation.Peers;
using Avalonia.Automation;
using Avalonia.Controls;
using Avalonia.Controls.Mixins;

namespace BD.WTTS.UI.Views.Controls;

[PseudoClasses(":pressed", ":selected")]
public class StepperItem : ContentControl, ISelectable
{
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<StepperItem, string>(nameof(Title));

    public static readonly StyledProperty<int> IndexProperty =
        AvaloniaProperty.Register<StepperItem, int>(nameof(Index));

    public static readonly StyledProperty<bool> IsSelectedProperty =
        SelectingItemsControl.IsSelectedProperty.AddOwner<StepperItem>();

    public static readonly StyledProperty<bool> IsSkipProperty =
        AvaloniaProperty.Register<StepperItem, bool>(nameof(IsSkip));

    static StepperItem()
    {
        SelectableMixin.Attach<StepperItem>(IsSelectedProperty);
        PressedMixin.Attach<StepperItem>();
        FocusableProperty.OverrideDefaultValue(typeof(StepperItem), true);
        //DataContextProperty.Changed.AddClassHandler<StepperItem>((x, e) => x.UpdateHeader(e));
        AutomationProperties.ControlTypeOverrideProperty.OverrideDefaultValue<StepperItem>(AutomationControlType.TabItem);
    }

    public bool IsSelected
    {
        get { return GetValue(IsSelectedProperty); }
        set { SetValue(IsSelectedProperty, value); }
    }

    public bool IsSkip
    {
        get { return GetValue(IsSkipProperty); }
        set { SetValue(IsSkipProperty, value); }
    }

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public int Index
    {
        get => GetValue(IndexProperty);
        set => SetValue(IndexProperty, value);
    }

    protected override AutomationPeer OnCreateAutomationPeer() => new ListItemAutomationPeer(this);

}