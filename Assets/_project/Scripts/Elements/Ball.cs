using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;

    [Header("Bounce Properties")]
    [SerializeField] private BallBounceType bounceType;
    [SerializeField] private float playerBounceXMultiplier;
    [SerializeField] private float absoluteBounceBoundry;

    private bool _isMoving;
    private Vector3 _direction;
    private Rigidbody2D _rb;
    public void StartBall()
    {
        _rb = GetComponent<Rigidbody2D>();
        _direction = new Vector3(Random.Range(-1f,1f), 1, 0);
        _isMoving = true;
    }

    private void Update()
    {
        if (_isMoving)
        {
            _rb.linearVelocity = _direction.normalized * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var color = Color.white;
        var pitch = .8f;

        if (collision.gameObject.CompareTag("BottomWall"))
        {
            Destroy(gameObject);
            color = Color.red;
        }

        if (collision.gameObject.CompareTag("Brick"))
        {
            pitch = 1;
            collision.gameObject.GetComponent<Brick>().GetHit(1);
            color = Color.yellow;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            var distance = (transform.position - collision.transform.position).x;

            if (bounceType == BallBounceType.Relative)
            {
                _direction.x += distance * playerBounceXMultiplier;
                if (distance < -absoluteBounceBoundry)
                {
                    color = Color.white;
                }
                else if (distance > absoluteBounceBoundry)
                {
                    color = Color.white;
                }
                else
                {
                    color = new Color(0,.5f,1f);
                }
            }
            else if (bounceType == BallBounceType.Absolute)
            {
                if (distance < -absoluteBounceBoundry)
                {
                    _direction.x = -1;
                }
                else if (distance > absoluteBounceBoundry)
                {
                    _direction.x = 1;
                }
            }            
        }

        _direction = Vector3.Reflect(_direction, collision.contacts[0].normal);

        GetComponentInParent<BallManager>().fXManager
            .PlayImpactPS(collision.contacts[0].point, collision.contacts[0].normal, color);

        GetComponentInParent<BallManager>().fXManager.audioManager.PlayImpactAS(pitch);
    }
}

public enum BallBounceType
{
    Relative,
    Absolute,
}