using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool _canControl = true;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _roatationSpeed;
    private Rigidbody _rigidbody;

    private Vector2 _touchStartPosition = new Vector2(Single.PositiveInfinity, Single.PositiveInfinity);

    [SerializeField] private UnityEvent OnControlDisable;

    public bool CanControl
    {
        get => _canControl;
        set
        {
            _canControl = value;
            if(value == false) OnControlDisable.Invoke();
        }
    }

    private void Move()
    {
        if (Input.touchCount < 1) return;

        if (!_canControl) return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began || _touchStartPosition == new Vector2(Single.PositiveInfinity, Single.PositiveInfinity))
        {
            _touchStartPosition = touch.position;
        }

        float angle = Vector3.Angle(touch.position - _touchStartPosition, Vector2.up) *
                      Mathf.Sign((touch.position.x - _touchStartPosition.x));
        Quaternion neededRotation = Quaternion.Euler(0, angle, 0);

        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            neededRotation,
            _roatationSpeed * Time.deltaTime);
        
        if (Mathf.Abs(transform.rotation.y * 180) - Mathf.Abs(neededRotation.y * 180) < 5)
        {
            _rigidbody.velocity = (transform.TransformDirection(Vector3.forward) * _walkSpeed) +
                                  Vector3.up * _rigidbody.velocity.y;
        }
    }
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(GameStateManager.GameState == GameState.Playing)
            Move();
    }
}
