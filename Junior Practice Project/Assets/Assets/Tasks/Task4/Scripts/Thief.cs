using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_target == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<House>(out House house))
        {
            gameObject.SetActive(false);
        }
    }

}


//У вас есть некий дом (2d или 3d, это не важно), в который сможет зайти наш жулик. +

//Давайте поможем Лёше поймать жулика, для этого в доме следует установить сигнализацию. 

//Сигнализацию лучше установить на двери, либо во внутреннем пространстве дома, чтобы мы знали, что жулик зашел.

//Когда жулик зашел в дом, громкость сигнализации должна начать плавно увеличиваться до максимальной. Когда жулик вышел, громкость должна плавно снизиться до нуля.

//Учитывайте кол-во зашедших жуликов в зону сигнализации.

//Перед выполнением изучите Mathf.MoveTowards

//Сдача как проект на Git + видео демонстрация.