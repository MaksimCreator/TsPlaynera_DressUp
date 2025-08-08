using Zenject;

public class PresenterControl
{
    private readonly BookPresenterControl _bookPresenterControl;
    private readonly GameplayPresenterControl _gameplayPresenterControl;

    [Inject]
    public PresenterControl(BookPresenterControl bookPresenterControl, GameplayPresenterControl gameplayPresenterControl)
    {
        _bookPresenterControl = bookPresenterControl;
        _gameplayPresenterControl = gameplayPresenterControl;
    }

    public void DisablePresenters()
    {
        _bookPresenterControl.SetActive(false);
        _gameplayPresenterControl.SetActive(false);
    }

    public void EnablePreseter()
    {
        _bookPresenterControl.SetActive(true);
        _gameplayPresenterControl.SetActive(true);
    }
}