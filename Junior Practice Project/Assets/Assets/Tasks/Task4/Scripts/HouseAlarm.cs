using UnityEngine;

public class HouseAlarm : MonoBehaviour
{
    [SerializeField] private Thief _thief;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _speed;

    private float _currentVolume;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float targetVolume = 0f;

        if (_thief.gameObject.activeSelf)
        {
            float distance = Vector2.Distance(transform.position, _thief.transform.position);
            targetVolume = Mathf.InverseLerp(_maxDistance, _minDistance, distance);
        }

        _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, _speed * Time.deltaTime);

        _audioSource.volume = _currentVolume;
        _audioSource.pitch = 1f + _currentVolume * 0.5f;
    }


}
