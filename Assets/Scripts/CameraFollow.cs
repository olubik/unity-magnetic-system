using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float yaw;
    private float pitch;

    [SerializeField]
    private PlayerInputReader playerInput;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float sensitivity = 40f;
    private float distance = 5f;
    [SerializeField]
    private float minPitch = -10f;
    private float maxPitch = 85f;
    private float shoulderOffset = 1.5f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        yaw += playerInput.LookInput.x * sensitivity * Time.deltaTime;
        pitch -= playerInput.LookInput.y * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        Vector3 offset = rotation * new Vector3(shoulderOffset, 0f, -distance);

        transform.position = target.position + offset;
        transform.rotation = rotation;
    }
}
