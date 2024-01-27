using System.Diagnostics;

public class ShellViewModel : BindableBase, IActiveAware
{
    private readonly IRegionManager _regionManager;
    private bool _isInitialized;

    public ShellViewModel(
        IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }
    private bool _isActive;
    public event EventHandler IsActiveChanged;
    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            if (!_isInitialized) Initialize();
        }
    }
    private void Initialize()
    {
        _isInitialized = true;
        try
        {
            _regionManager.RequestNavigate("HeaderRegion", "HeaderView");
            _regionManager.RequestNavigate("BodyRegion", "BodyView");
        }
        catch (Exception ex)
        {

        }
    }
}
