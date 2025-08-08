using UnityEngine;

[CreateAssetMenu(fileName = "CreamTakeConfig", menuName = "Config/CreamTake")]
public class CreamTakeAnimationConfig : ScriptableObject
{
    [SerializeField] private float _delayStep = 0.4f;
    [SerializeField] private float _durationMoveHandToCream;
    [SerializeField] private float _durationMoveHandToCenter;

    public int DelayStep => (int)(_delayStep * 1000);

    public float DurationMoveHandToCream => _durationMoveHandToCream;

    public float DurationMoveHandToCenter => _durationMoveHandToCenter;
}