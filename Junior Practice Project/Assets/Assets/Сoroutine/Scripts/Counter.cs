using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _startCount = 0f;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private float _endCount = 10f;

    private float _sumCount = 0f;
    private Coroutine _countdownCoroutine;
    private bool _isCounting = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!_isCounting)
            {             
                _countdownCoroutine = StartCoroutine(Countdown());
                _isCounting = true;
            }
            else
            {               
                if (_countdownCoroutine != null)
                {
                    StopCoroutine(_countdownCoroutine);
                    _countdownCoroutine = null;
                }
                _isCounting = false;
            }
        }
    }

    private IEnumerator Countdown()
    {
        for (float i = _startCount; i <= _endCount; i += _delay)
        {
            _sumCount += _delay;
            Debug.Log($"счётчик - {_sumCount}");
            yield return new WaitForSeconds(_delay);
        }
        _isCounting = false;
        _countdownCoroutine = null;
    }
}



