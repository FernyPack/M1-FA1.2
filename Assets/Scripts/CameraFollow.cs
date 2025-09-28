using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -7);
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target == null) return;
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
