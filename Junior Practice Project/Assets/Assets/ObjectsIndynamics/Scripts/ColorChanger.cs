using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private Renderer _renederer;
    private Color _defaultColor;

    private void Awake()
    {
        _renederer = GetComponent<Renderer>();
        _defaultColor = _renederer.material.color;
    }

    public void ApplyRandomColor(Renderer renderer)
    {       
        if (renderer == null)
            return;
       
        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    public void ResetColor()
    {
        _renederer.material.color = _defaultColor;
    }

}


