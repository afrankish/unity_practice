using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _offset;

    public float RotationalSpeed = 90;
    public GameObject Focus;

    private void Start()
    {
        _offset = transform.position - Focus.transform.position;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("CamHorizontal");
        float angle = Time.deltaTime * RotationalSpeed;

        _offset = Quaternion.AngleAxis(angle, transform.up) * _offset;
    }

    private void LateUpdate()
    {
        transform.position = Focus.transform.position + _offset;
        transform.LookAt(Focus.transform);
    }
}
