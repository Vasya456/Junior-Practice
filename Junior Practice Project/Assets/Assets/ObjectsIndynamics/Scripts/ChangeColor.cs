using Unity.VisualScripting;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public void ApplyRandomColor(GameObject cube)
    {
        if (!cube.TryGetComponent<Renderer>(out Renderer renderer))
            return;

        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
