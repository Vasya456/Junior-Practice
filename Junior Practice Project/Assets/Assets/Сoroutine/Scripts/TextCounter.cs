using TMPro;
using UnityEngine;

public class TextCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _textIncrease = 0.5f;
    private float _currentValue;

    public void Increase()
    {
        _currentValue +=_textIncrease;
        _text.text = _currentValue.ToString();
    }   
}
