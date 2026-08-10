using UnityEngine;
using System;

public class ClickDetector : MonoBehaviour
{
    public event Action<CubeInfo> CubeClicked;

    private Camera _camera;
    private void Awake()

    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Detector();
    }

    private void Detector()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Вы не попали по обьекту");
            return;
        }

        GameObject clickedObject = hit.collider.gameObject;

        if (!clickedObject.TryGetComponent<CubeInfo>(out CubeInfo info))
        {
            Debug.Log("Вы не попали по обьекту " + clickedObject.name);
            return;
        }

        Debug.Log("Вы кликнули по обьекту " + clickedObject.name);

        CubeClicked?.Invoke(info);
    }
}