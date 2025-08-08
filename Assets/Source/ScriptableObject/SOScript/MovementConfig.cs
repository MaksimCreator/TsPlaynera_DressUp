using UnityEngine;

[CreateAssetMenu(fileName = "MovementConfig", menuName = "Config/Movement")]
public class MovementConfig : ScriptableObject
{
    [SerializeField] private float _durationMove;

    public float DurationMove => _durationMove;
}
