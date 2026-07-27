using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _key = KeyCode.Mouse0;

    public UnityEvent onButtonPassed;


    private void Update()
    {
       if(Input.GetKeyDown(_key))
            onButtonPassed?.Invoke();
    }
}


//Привет! Класс Counter  не должен заниматься получением ввода. Сделай отдельный класс InputReader, который будет через событие сообщать о нажатии на кнопку. 
//Работа счетчика переключается только по нажатию лкм! for (float i = _startCount; i <= _endCount; i += _delay) -ограничений на количество делать не нужно. 
//Сейчас количество набранного счета хранится И в счетчике И в компоненте отображения.
//Если сбросить одно значение, текст будет показывать одно, а в счетчике - совсем другое! В TextCounter  не должно быть своего хранилища данных. 
//Свяжи компоненты через событие (TextCounter  знает о счетчике и подписывается на него). Текущее значение можно передавать через событие. 