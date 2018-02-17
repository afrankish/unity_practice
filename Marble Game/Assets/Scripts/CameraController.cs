using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _offset;

    public GameObject Focus;

    private void Start()
    {
        _offset = transform.position - Focus.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Focus.transform.position + _offset;
    }
}
