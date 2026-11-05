using System.Collections.Generic;
using UnityEngine;

public class SpawnerTask5 : MonoBehaviour
{
    [SerializeField] private Apples _apples;

    [SerializeField] private Transform[] _spawners;


    private bool isWork = true;

    private float _counterInterval = 2;
    private int spawnerMinIndex = 0;

    private readonly Queue<Apples> _applesPool = new Queue<Apples>();


    private void CreateApple() 
    {
    

    }

}
