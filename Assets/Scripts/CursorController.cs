using UnityEngine;

public class CursorController : MonoBehaviour
{
    private PlayerInputReader playerInput;
    void Awake()
    {
        playerInput = GetComponent<PlayerInputReader>();
    }
    void Start()
    {
        LockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.IsPausePressed)
        {
            UnlockCursor();
        }
        else if (playerInput.IsLeftMouseButtonHeld && Cursor.lockState != CursorLockMode.Locked)
        {
            LockCursor();
        }
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
