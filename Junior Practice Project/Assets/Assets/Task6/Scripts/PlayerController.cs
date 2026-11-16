using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : Characters
{

    private static readonly int IsAttackingHash = Animator.StringToHash("IsAttacking");
    public readonly string HorizonAxes = "Horizontal";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxhealth;
    [SerializeField] private Transform _target;
    [SerializeField] private float _attackRange;

    private float _currentHealth;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _currentHealth = _maxhealth;
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        Attack();
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

    private void Attack()
    {
        if (_target == null || _animator == null)
            return;

        float distance = Vector2.Distance(transform.position, _target.position);
        bool inRange = distance <= _attackRange;

        _animator.SetBool(IsAttackingHash, inRange);       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
//Битва за платформер - Начало
//Продолжаем работать над платформером, реализуем работу со здоровьем персонажа. 

//Теперь враги и игрок могут атаковать друг друга, когда подходят близко. 

//Враги должны начать преследовать игрока, когда увидят его, в обратном случае они должны патрулировать территорию. А игрок может лечиться, подбирая аптечки, которые случайным образом разбросаны по уровню.

//Отображать здоровье в этой задаче не требуется, это мы сделаем в следующей задаче.

//Задача со звездочкой: Добавить анимацию атаки врагу

//Сдавать через Git + видео демонстрация.