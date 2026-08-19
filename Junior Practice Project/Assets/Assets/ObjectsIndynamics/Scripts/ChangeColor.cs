using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public void ApplyRandomColor(Renderer renderer)
    {       
        if (renderer == null)
            return;
       
        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}


