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

    private static readonly int OutlineIntensity = Shader.PropertyToID("_OutlineIntensity");
    private MaterialPropertyBlock propertyBlock;


    public MagneticPolarity Polarity => polarity;


    void Awake()
    {
        objRenderer = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
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


    public void SetOutline(bool enabled)
    {
        objRenderer.GetPropertyBlock(propertyBlock);

        propertyBlock.SetFloat(OutlineIntensity, enabled ? 50f : 0f);
        objRenderer.SetPropertyBlock(propertyBlock);
    }
}
