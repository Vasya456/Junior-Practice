using System.Collections;
using UnityEngine;

public class TextCounter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private float _counter;
    private float step = 0.5f;
    private float _counterInterval = 0.5f;

    private Coroutine _coroutine;

    private bool _isWork = true;

    private void OnEnable()
    {
        _inputReader.ButtonPressed += OnPressed ;
    }

    private void OnDisable()
    {
        _inputReader.ButtonPressed -= OnPressed;
    }

    private void OnPressed()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(IncreaseCounter());
        }
        else 
        {                   
            StopCoroutine(_coroutine);
            _coroutine = null;
            
        }
    }
   
    private IEnumerator IncreaseCounter()
    {
        while (_isWork)
        {
            _counter += step;
            Debug.Log(_counter);
            yield return new WaitForSeconds(_counterInterval);
        }
    }
}
