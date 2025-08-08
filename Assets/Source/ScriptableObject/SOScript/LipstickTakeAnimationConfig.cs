using UnityEngine;

[CreateAssetMenu(fileName = "LipstickTakeAnimationConfig", menuName = "Config/LipstickTake")]
public class LipstickTakeAnimationConfig : ScriptableObject
{
    [SerializeField] private float _delayStep;
    [SerializeField] private float _durationTakeLipstick;
    [SerializeField] private float _durationLipstickMoveCenter;

    public float DurationTakeLipstick => _durationTakeLipstick;

    public float DurationLipstickMoveCenter => _durationLipstickMoveCenter;

    public int DelayStep => (int)(_delayStep * 1000);
}
