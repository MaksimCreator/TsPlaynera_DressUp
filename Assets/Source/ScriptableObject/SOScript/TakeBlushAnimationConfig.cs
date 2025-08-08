using UnityEngine;

[CreateAssetMenu(fileName = "TakeBlushConfig", menuName = "Config/TakeBlush")]
public class TakeBlushAnimationConfig : ScriptableObject
{
    [SerializeField] private float _delayStep;
    [SerializeField] private float _durationMoveTon;
    [SerializeField] private float _durationMoveBlush;
    [SerializeField] private float _durationEdgeToCenterTon;
    [SerializeField] private float _durationMoveLeftPositionTon;
    [SerializeField] private float _durationMoveRightPositionTon;
    [SerializeField] private float _durationCenterScreen;
    [SerializeField] private int _numberOfRepetitions;

    public int NumberOfRepetitions => _numberOfRepetitions;

    public float DurationMoveBlush => _durationMoveBlush;

    public float DurationBlushToTon => _durationMoveTon;

    public float DurationMoveLeftPositionTon => _durationMoveLeftPositionTon;

    public float DurationMoveRightPositionTon => _durationMoveRightPositionTon;

    public float DurationEdgeToCenterTon => _durationEdgeToCenterTon;

    public float DurationCenterScrean => _durationCenterScreen;

    public int DelayStep => (int)(_delayStep * 1000);
}