using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private ClickDetector _clickDetector;
    [SerializeField] private CubeSpawner _cubeSpawner;

    [SerializeField] private float _divider = 2;
    [SerializeField] private float _minChanceRoll = 0f;
    [SerializeField] private float _maxChanceRoll = 100f;

    private void OnEnable()
    {
        Debug.Log("CubeClickHandler.OnEnable, clickDetector = " + _clickDetector);
        _clickDetector.CubeClicked += HandleCubeClicked;
    }

    private void OnDisable()
    {
        _clickDetector.CubeClicked -= HandleCubeClicked;
    }

    private void HandleCubeClicked(CubeInfo info)
    {
        Debug.Log("HandleCubeClicked вызван для " + info.name);

        Vector3 spawnPosition = info.transform.position;
        Quaternion spawnRotation = info.transform.rotation;
        float currentChance = info.Chance;

        Destroy(info.gameObject);

        float roll = Random.Range(_minChanceRoll, _maxChanceRoll);

        Vector3 spawnScale = info.transform.localScale;

        if (roll < currentChance)
            _cubeSpawner.CreateCube(spawnPosition, spawnRotation, currentChance / _divider, spawnScale);
    }
}
