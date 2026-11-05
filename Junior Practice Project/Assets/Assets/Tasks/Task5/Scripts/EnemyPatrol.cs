using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private bool _isFacingRight;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody;


}
