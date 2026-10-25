using UnityEngine;

public class MagneticObject : MonoBehaviour
{
    [SerializeField]
    private MagneticPolarity polarity;


    [SerializeField]
    private Material positiveMaterial;
    [SerializeField]
    private Material negativeMaterial;
    private Renderer objRenderer;


    public MagneticPolarity Polarity => polarity;


    void Awake()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void OnValidate()
    {
        if (objRenderer == null)
        {
            objRenderer = GetComponent<Renderer>();
            if (objRenderer == null) return;
        }

        objRenderer.sharedMaterial = polarity == MagneticPolarity.Positive ? positiveMaterial : negativeMaterial;
    }

}
