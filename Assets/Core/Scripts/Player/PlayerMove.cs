using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;

    [SerializeField] private WheelJoint2D _leftCircle, _rightCircle;
    [SerializeField] private float _speed;
    [HideInInspector] public float movement;

    private void Start()
    {
        UpdatePlayer();
    }

    public void UpdatePlayer()
    {
        transform.position = _startPosition;
        transform.eulerAngles = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (movement * _speed == 0)
        {
            _leftCircle.useMotor = false;
            _rightCircle.useMotor = false;
        }
        else
        {
            _leftCircle.useMotor = true;
            _rightCircle.useMotor = true;
            _leftCircle.motor = new JointMotor2D {motorSpeed = movement * _speed, maxMotorTorque = 10000};
            _rightCircle.motor = new JointMotor2D {motorSpeed = movement * _speed, maxMotorTorque = 10000};
        }
    }
}