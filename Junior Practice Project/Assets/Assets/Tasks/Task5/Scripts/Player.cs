using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public readonly string HorizonAxes = "Horizontal";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Move()
    {
        float moveX = Input.GetAxis(HorizonAxes) * _speed;
        _rigidbody.linearVelocity = new Vector2(moveX, _rigidbody.linearVelocity.y);
    }

    private void Jump() 
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}



//Задание
//2D платформер *
//Создать простой 2D платформер, в котором реализовать:

//-Управление персонажем(бег, прыжки); +

//-Анимацию бега(прыжок не обязательно);

//-Простых врагов, который будут патрулировать небольшой участок;

//-Спавн монеток, которые можно собирать.

