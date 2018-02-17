using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    public float Speed = 10;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        _rb.AddForce(movement * Speed);
    }
}
