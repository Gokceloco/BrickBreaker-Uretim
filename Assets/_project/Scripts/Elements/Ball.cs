using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;

    [Header("Bounce Properties")]
    [SerializeField] private bool isBounceRelative;
    [SerializeField] private float playerBounceXMultiplier;
    [SerializeField] private float absoluteBounceBoundry;

    private bool _isMoving;
    private Vector3 _direction;
    public void StartBall()
    {
        _direction = new Vector3(Random.Range(-1f,1f), 1, 0);
        _isMoving = true;
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position += _direction.normalized * Time.deltaTime * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("BottomWall"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Brick"))
        {
            collision.gameObject.GetComponent<Brick>().GetHit(1);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            var distance = (transform.position - collision.transform.position).x;

            if (isBounceRelative)
            {
                _direction.x += distance * playerBounceXMultiplier;
            }
            else
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
    }
}
