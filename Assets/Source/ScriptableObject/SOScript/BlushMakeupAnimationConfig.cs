using UnityEngine;

[CreateAssetMenu(fileName = "BlushAnimationConfig", menuName = "Config/BlushMakeup")]
public class BlushMakeupAnimationConfig : ScriptableObject
{
    [SerializeField] private float _delayStep;
    [SerializeField] private float _durationMoveFace;
    [SerializeField] private float _durationMoveLeftPoint;
    [SerializeField] private float _durationMoveRightPoint;
    [SerializeField] private float _durationReturnPositionBlush;
    [SerializeField] private float _durationReturnPositionHand;
    [SerializeField] private int _numberOfRepetitions;

    public int NumberOfRepetitions => _numberOfRepetitions;

    public float DurationMoveFace => _durationMoveFace;

    public float DurationMoveLeftPoint => _durationMoveLeftPoint;

    public float DurationMoveRightPoint => _durationMoveRightPoint;

    public float DurationReturnPositionBlush => _durationReturnPositionBlush;

    public float DurationReturnPositionHand => _durationReturnPositionHand;

    public int DelayStep => (int)(_delayStep * 1000);
}
