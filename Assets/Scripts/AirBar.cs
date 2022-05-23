using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AirBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAir(float air)
    {
        slider.value = air;
    }

    public void setMaxAir(float maxAir)
    {
        slider.maxValue = maxAir;
        SetAir(maxAir);
    }
}
