using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    private PlayerInputReader playerInput;
    private PlayerPolarityVisual playerPolarityVisual;
    private MagneticPolarity? activePolarity;

    private List<MagneticObject> targetObjs = new List<MagneticObject>();

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float magnetRadius = 2f;
    [SerializeField]
    private float magnetDistance = 30f;
    [SerializeField]
    private LayerMask magneticLayer;


    void Awake()
    {
        playerInput = GetComponent<PlayerInputReader>();
        playerPolarityVisual = GetComponentInChildren<PlayerPolarityVisual>();
    }

    void Update()
    {
        UpdateActivePolarity();
    }

    void FixedUpdate()
    {
        if (activePolarity == null)
        {
            UpdateTargetOutlines(new List<MagneticObject>());
            return;
        }

        DetectMagneticObjects();
    }

    private void UpdateActivePolarity()
    {
        if (playerInput.IsLeftMouseButtonHeld == playerInput.IsRightMouseButtonHeld)
        {
            activePolarity = null;
            playerPolarityVisual.SetPolarity(activePolarity);
            return;
        }

        activePolarity = playerInput.IsLeftMouseButtonHeld ? MagneticPolarity.Positive : MagneticPolarity.Negative;
        playerPolarityVisual.SetPolarity(activePolarity);
    }

    private void DetectMagneticObjects()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        Vector3 origin = transform.position + Vector3.up;
        Vector3 aimPoint = ray.GetPoint(magnetDistance);
        Vector3 direction = (aimPoint - origin).normalized;

        List<MagneticObject> newTargets = new List<MagneticObject>();

        RaycastHit[] hits = Physics.SphereCastAll(origin, magnetRadius, direction, magnetDistance, magneticLayer);
        foreach (RaycastHit hit in hits)
        {
            MagneticObject newTarget = hit.collider.GetComponent<MagneticObject>();

            if (newTarget == null)
            {
                continue;
            }
            if (!newTargets.Contains(newTarget))
            {
                newTargets.Add(newTarget);
            }
            Rigidbody rb = newTarget.GetComponent<Rigidbody>();
            if (rb == null) continue;

            Vector3 forceDir = (transform.position - rb.position).normalized;

            if (activePolarity == newTarget.Polarity)
            {
                forceDir = -forceDir;
            }
            rb.AddForce(forceDir * 20f, ForceMode.Force);
        }
        UpdateTargetOutlines(newTargets);

    }

    private void UpdateTargetOutlines(List<MagneticObject> newTargets)
    {
        foreach (MagneticObject target in targetObjs)
        {
            if (!newTargets.Contains(target))
            {
                target.SetOutline(false);
            }
        }
        foreach (MagneticObject target in newTargets)
        {
            if (!targetObjs.Contains(target))
            {
                target.SetOutline(true);
            }
        }

        targetObjs = newTargets;
    }
}
