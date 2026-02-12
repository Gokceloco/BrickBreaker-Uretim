using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;

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
            Destroy(collision.gameObject);
        }

        _direction = Vector3.Reflect(_direction, collision.contacts[0].normal);
    }
}
