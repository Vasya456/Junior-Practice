using System.Collections;
using UnityEngine;

public class EnemySpawnersTask2 : MonoBehaviour
{
    [SerializeField] private EnemyTask2 _enemyPrefabTask2;
    [SerializeField] private Transform _target;
    [SerializeField] private float _counterInterval = 2;
    private bool _isWork = true;

    private void Start()
    {
        StartCoroutine(Cooldown());
    }

    private void CreateEnemy() 
    {   
      EnemyTask2 enemy = Instantiate(_enemyPrefabTask2, transform.position, transform.rotation);
      enemy.SetTarget(_target);
    }
   
    private IEnumerator Cooldown()
    {
        while (_isWork)
        {
            yield return new WaitForSeconds(_counterInterval);
            CreateEnemy();
        }
    }
}





//Задание
//Продвинутая генерация врагов
//Продолжаем работать над проектом с генерацией врагов. 

//Теперь каждая точка спауна создает свой тип врагов и имеет цель, то есть объект, к которому идут враги.++

//В момент создания точка спауна передает врагу свою цель, чтобы тот направился к ней. Таких целей должно быть несколько, у каждого спавнера своя цель.

//Сами цели движутся по заранее определенному маршруту, от одной точки к другой.

//Сдавать как проект на Git и видео демонстрацию



//На уровне присутствует несколько точек спавна (создания врагов).

//Каждые две секунды в случайной точке спавна должен появляться новый враг. После этого он должен начать двигаться по прямой в том направлении, которое ему укажет спавнер.

//Сдавать как проект на Git и видео демонстрацию