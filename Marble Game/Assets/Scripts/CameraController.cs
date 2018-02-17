using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _offset;

    public float MinPitch = 0;
    public float MaxPitch = -85;
    public float RotationalSpeed = 90;
    public GameObject Focus;

    private void Start()
    {
        _offset = transform.position - Focus.transform.position;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("CamHorizontal");
        float angle = Time.deltaTime * RotationalSpeed * moveHorizontal;

        _offset = Quaternion.AngleAxis(angle, transform.up) * _offset;

        float moveVertical = Input.GetAxis("CamVertical");
        angle = Time.deltaTime * RotationalSpeed * moveVertical;

        _offset = Quaternion.AngleAxis(angle, transform.right) * _offset;
    }

    private void LateUpdate()
    {
        float pitch = Vector3.Angle(Vector3.down, _offset) - 90;
        float targetPitch = Mathf.Clamp(pitch, MinPitch, MaxPitch);
        float pitchDiff = targetPitch - pitch;
        _offset = Quaternion.AngleAxis(pitchDiff, transform.right) * _offset;

        transform.position = Focus.transform.position + _offset;
        transform.LookAt(Focus.transform);
    }
}
