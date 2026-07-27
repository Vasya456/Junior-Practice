using TMPro;
using UnityEngine;

public class TextCounter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.onButtonPassed.AddListener(Text);
    }

    private void OnDisable()
    {
        _inputReader.onButtonPassed.RemoveListener(Text);
    }

    public void Text() 
    {
        Debug.Log("Кнопка нажата");
    }
}
