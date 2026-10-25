using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputReader playerInput;

    private CharacterController controller;
    [SerializeField]
    private int speed = 5;
    [SerializeField]
    private float jumpForce = 5f;

    private float gravity = -9.81f;
    private float verticalVel;

    void Awake()
    {
        playerInput = GetComponent<PlayerInputReader>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDir = (cameraRight * playerInput.MoveInput.x + cameraForward * playerInput.MoveInput.y).normalized;

        if (moveDir.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
        }

        if (controller.isGrounded && verticalVel < 0f)
        {
            verticalVel = -2f;
        }

        if (controller.isGrounded && playerInput.IsJumpPressed)
        {
            verticalVel = jumpForce;
        }

        verticalVel += gravity * Time.deltaTime;

        moveDir *= speed;
        moveDir.y = verticalVel;

        controller.Move(moveDir * Time.deltaTime);
    }
}
