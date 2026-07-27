using UnityEngine;
using UnityEngine.Events;

public class InputReaderTest : MonoBehaviour
{
    [SerializeField] private KeyCode _key = KeyCode.Space;

    public UnityEvent OnButtonPressedTesting;


    private void Update()
    {
        if(Input.GetKeyDown(_key))
            OnButtonPressedTesting?.Invoke();
    }

}


