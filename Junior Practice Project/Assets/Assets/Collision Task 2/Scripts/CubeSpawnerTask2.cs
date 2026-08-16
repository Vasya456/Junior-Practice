using UnityEngine;

public class CubeSpawnerTask2 : MonoBehaviour
{

    [SerializeField] private CubeTask2[] _cubePrefab;
    [SerializeField] private float _spawnSpread = 1.5f;
    [SerializeField] private int minRandomIndex = 0;
    [SerializeField] private float _scaleMultiplier = 0.5f;

    public void CreateCube(Vector3 position, Quaternion rotation, float nextChance, Vector3 parentScale)  
    {
        int cubeCount = Random.Range(2, 7);

        for (int i = 0; i < cubeCount; i++)
        {
            int randomIndex = Random.Range(0, _cubePrefab.Length);

            Vector3 offset = new Vector3(Random.Range(-_spawnSpread, _spawnSpread), Random.Range(minRandomIndex, _spawnSpread), Random.Range(-_spawnSpread, _spawnSpread));

            CubeTask2 newCube = Instantiate(_cubePrefab[randomIndex], position + offset, rotation);

            newCube.transform.localScale = parentScale * _scaleMultiplier;           

            if (!newCube.TryGetComponent<CubeTask2>(out CubeTask2 cube))
            {
                cube = newCube.gameObject.AddComponent<CubeTask2>();
            }

            cube.SetChance(nextChance);

            ApplyRandomColor(newCube.gameObject);
            ApplyGravity(newCube.gameObject);
        }
    }

    private void ApplyRandomColor(GameObject cube)
    {
        if (!cube.TryGetComponent<Renderer>(out Renderer renderer))
            return;

        renderer.material.color = new Color(Random.value, Random.value, Random.value);

    }

    private void ApplyGravity(GameObject cube)
    {
        if (!cube.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            rigidbody = cube.AddComponent<Rigidbody>();

        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
    }
}
