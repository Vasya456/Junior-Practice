using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _key = KeyCode.Mouse0;
  
    public event Action ButtonPressed;
   
    private void Update()
    {
       if(Input.GetKeyDown(_key))
            ButtonPressed?.Invoke(); 
    }
}


