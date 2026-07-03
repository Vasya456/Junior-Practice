using UnityEngine;

public class Grower : MonoBehaviour
{
    [SerializeField] private float _growSpeed;

    private void Update()
    {
        transform.localScale += Vector3.one * _growSpeed * Time.deltaTime;
    }
}
