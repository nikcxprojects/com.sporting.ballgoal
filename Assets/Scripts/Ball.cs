using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody.isKinematic = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !GameManager.instance.isPaused)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = Vector2.zero;

            Vector2 screenPoint = (Vector2)Camera.main.WorldToScreenPoint(transform.position);
            Vector2 direction = (Vector2)Input.mousePosition - screenPoint;
            direction.Normalize();

            _rigidbody.AddForce(direction * 10 + Vector2.up, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _rigidbody.isKinematic = true;
        _rigidbody.angularVelocity = 0;
        _rigidbody.velocity = Vector2.zero;
    }
}
