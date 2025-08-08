using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Image _lips;
    [SerializeField] private Image _rouge;
    [SerializeField] private Image _acne;

    public void SetLips(Sprite CurentLips)
    {
        _lips.gameObject.SetActive(true);
        _lips.sprite = CurentLips;
    }

    public void SetRouge(Sprite CurentRouge)
    {
        _rouge.gameObject.SetActive(true);
        _rouge.sprite = CurentRouge;
    }

    public void DelayAcne()
    =>  _acne.gameObject.SetActive(false);

    public void Reset()
    {
        _rouge.gameObject.SetActive(false);
        _lips.gameObject.SetActive(false);
        _acne.gameObject.SetActive(true);
    }
}