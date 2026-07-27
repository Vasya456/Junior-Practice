using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private InputReaderTest _inputReader;

    private void OnEnable()
    {
        _inputReader.OnButtonPressedTesting.AddListener(Jump);
    }

    private void OnDisable()
    {
        _inputReader.OnButtonPressedTesting.RemoveListener(Jump);
    }

    public void Jump() 
    {
        Debug.Log("Прыжок");
    }

   
}
