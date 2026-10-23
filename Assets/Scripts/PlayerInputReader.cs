using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction leftMouseButtonAction;
    private InputAction rightMouseButtonAction;

    public Vector2 MoveInput { get; private set; }
    public bool IsJumpPressed { get; private set; }
    public bool IsLeftMouseButtonHeld { get; private set; }
    public bool IsRightMouseButtonHeld { get; private set; }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        leftMouseButtonAction = InputSystem.actions.FindAction("Attack");
        rightMouseButtonAction = InputSystem.actions.FindAction("Aim");
    }

    void Update()
    {
        MoveInput = moveAction.ReadValue<Vector2>();
        IsJumpPressed = jumpAction.WasPressedThisFrame();
        IsLeftMouseButtonHeld = leftMouseButtonAction.IsPressed();
        IsRightMouseButtonHeld = rightMouseButtonAction.IsPressed();
    }
}
