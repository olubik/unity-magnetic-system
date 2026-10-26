using UnityEngine;

public class MagneticPolaritySwitcher : MonoBehaviour
{
    private MagneticObject magneticObj;

    private float timer;
    [SerializeField]
    private float switchInterval = 5f;

    void Awake()
    {
        magneticObj = GetComponent<MagneticObject>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            SwitchPolarity();
            timer = 0f;
        }
    }

    private void SwitchPolarity()
    {
        magneticObj.SetPolarity(magneticObj.Polarity == MagneticPolarity.Positive ? MagneticPolarity.Negative : MagneticPolarity.Positive);
    }
}
