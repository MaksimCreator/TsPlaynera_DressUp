using UnityEngine;

[CreateAssetMenu(fileName = "LipstickMakeupAnimationConfig", menuName = "Config/LipstickMakeup")]
public class LipstickMakeupAnimationConfig : ScriptableObject
{
    [SerializeField] private float _delayStep;
    [SerializeField] private float _durationLeftPoint;
    [SerializeField] private float _durationRightPoint;
    [SerializeField] private float _durationReturnItem;
    [SerializeField] private float _durationReturnHand;
    [SerializeField] private int _numberOfRepetitions;

    public float DurationReturnItem => _durationReturnItem;

    public float DurationReturnHand => _durationReturnHand;

    public float DurationLeftPoint => _durationLeftPoint;

    public float DurationRightPoint => _durationRightPoint;

    public int NumberOfRepetitions => _numberOfRepetitions;

    public int DelayStep => (int)(_delayStep * 1000);
}