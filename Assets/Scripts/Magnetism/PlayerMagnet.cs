using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    private PlayerInputReader playerInput;
    private MagneticPolarity? activePolarity;


    void Awake()
    {
        playerInput = GetComponent<PlayerInputReader>();
    }

    void Update()
    {
        UpdateActivePolarity();
    }

    void UpdateActivePolarity()
    {
        if (playerInput.IsLeftMouseButtonHeld == playerInput.IsRightMouseButtonHeld)
        {
            activePolarity = null;
            return;
        }

        activePolarity = playerInput.IsLeftMouseButtonHeld ? MagneticPolarity.Positive : MagneticPolarity.Negative;
    }
}
