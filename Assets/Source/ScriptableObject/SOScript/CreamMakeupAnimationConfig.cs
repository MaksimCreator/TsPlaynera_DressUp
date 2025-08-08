using UnityEngine;

[CreateAssetMenu(fileName = "CreamMakeupConfig", menuName = "Config/CreamMakeup")]
public class CreamMakeupAnimationConfig : ScriptableObject
{
    [SerializeField] private float _delayStep;
    [SerializeField] private float _durationFirstPoint;
    [SerializeField] private float _durationSecondPoint;
    [SerializeField] private float _durationThirdPoint;
    [SerializeField] private float _durationReturnItem;
    [SerializeField] private float _durationReturnHand;

    public float DurationFirstPoint => _durationFirstPoint;

    public float DurationSecondPoint => _durationSecondPoint;

    public float DurationThirdPoint => _durationThirdPoint;

    public float DurationReturnItem => _durationReturnItem;
    
    public float DurationReturnHand => _durationReturnItem;

    public int DelayStep => (int)(_delayStep * 1000);
}