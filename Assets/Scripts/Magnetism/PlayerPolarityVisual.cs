using UnityEngine;

public class PlayerPolarityVisual : MonoBehaviour
{
    private Renderer playerRenderer;

    private MaterialPropertyBlock propertyBlock;
    private static readonly int ColorId = Shader.PropertyToID("_Color");
    private static readonly int OutlineIntensity = Shader.PropertyToID("_OutlineIntensity");

    [SerializeField]
    private Material positiveMaterial;
    [SerializeField]
    private Material negativeMaterial;

    void Awake()
    {
        playerRenderer = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        SetPolarity(null);
    }
    public void SetPolarity(MagneticPolarity? polarity)
    {
        playerRenderer.GetPropertyBlock(propertyBlock);
        Color color;
        switch (polarity)
        {
            case MagneticPolarity.Positive:
                color = positiveMaterial.color;
                break;
            case MagneticPolarity.Negative:
                color = negativeMaterial.color;
                break;
            default:
                color = Color.white;
                break;
        }
        propertyBlock.SetColor(ColorId, color);
        propertyBlock.SetFloat(OutlineIntensity, polarity == null ? 0f : 30f);

        playerRenderer.SetPropertyBlock(propertyBlock);
    }
}
