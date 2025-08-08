using UnityEngine;
using UnityEngine.UI;

public class MakeupComponent : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Sprite _spriteMakeup;

    public Button Button => _button;

    public Sprite SpriteMakeup => _spriteMakeup;
}
