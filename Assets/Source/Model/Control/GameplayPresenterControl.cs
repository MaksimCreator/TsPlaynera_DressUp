public class GameplayPresenterControl
{
    public bool IsActive { get; private set; } = true;

    public void SetActive(bool value)
    => IsActive = value;
}