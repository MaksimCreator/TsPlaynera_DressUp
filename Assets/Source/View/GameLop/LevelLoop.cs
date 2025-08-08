using UnityEngine;
using Zenject;

public class LevelLoop : GameLoop
{
    private IControl[] _controls;
    private IUpdateble[] _updatebles;

    [Inject]
    private void Construct(HandAnimation handAnimation,
        HandMovement handMovement,
        GameplayController gameplayController,
        InputRouter dragAndDropSystem)
    {
        _controls = new IControl[]
        {
            handAnimation,
            handMovement,
            gameplayController,
            dragAndDropSystem
        };

        _updatebles = new IUpdateble[0];
    }

    protected override IControl[] GetControls()
    => _controls;

    protected override IUpdateble[] GetUpdatebles()
    => _updatebles;
}