using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube[] _cubePrefab;
    [SerializeField] private float _spawnSpread = 1.5f;
    [SerializeField] private float _scaleMultiplier = 0.5f;

    [SerializeField] private float _explosionForce = 300f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _upwardModifier = 1f;

    [SerializeField] private int minCubeCount = 2;
    [SerializeField] private int maxCubeCount = 7;
    [SerializeField] private int minRandomIndex = 0;

    public void CreateCube(Vector3 position, Quaternion rotation, float nextChance, Vector3 parentScale)
    {
        int cubeCount = Random.Range(minCubeCount, maxCubeCount);


        for (int i = 0; i < cubeCount; i++)
        {
            int randomIndex = Random.Range(minRandomIndex, _cubePrefab.Length);

            Vector3 offset = new Vector3(Random.Range(-_spawnSpread, _spawnSpread), Random.Range(minRandomIndex, _spawnSpread), Random.Range(-_spawnSpread, _spawnSpread));

            Cube newCube = Instantiate(_cubePrefab[randomIndex], position + offset, rotation);
            newCube.transform.localScale = parentScale * _scaleMultiplier;

            CubeInfo info = newCube.gameObject.AddComponent<CubeInfo>();
            info.SetChance(nextChance);


            ApplyRandomColor(newCube.gameObject);
            ApplyGravity(newCube.gameObject);
            ApplyExplisionForce(newCube.GetComponent<Rigidbody>(), position);
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
    }

    private void ApplyExplisionForce(Rigidbody rigidbody, Vector3 explosionCenter) 
    {
        if (rigidbody == null)
            return;

        rigidbody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius, _upwardModifier, ForceMode.Impulse);
    }

}
