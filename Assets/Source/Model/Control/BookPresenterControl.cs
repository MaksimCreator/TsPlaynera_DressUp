public class BookPresenterControl
{
    public bool IsActive { get; private set; } = true;

    public bool CanActiveLipstickPanel { get; private set; }

    public bool CanActiveBlushPanel { get; private set; }

    public void SetActive(bool value)
    => IsActive = value;

    public void EnterLipstickPanel()
    {
        CanActiveLipstickPanel = true;
        CanActiveBlushPanel = false;
    }

    public void EnterBlushPanel()
    {
        CanActiveBlushPanel = true;
        CanActiveLipstickPanel = false;
    }
}
