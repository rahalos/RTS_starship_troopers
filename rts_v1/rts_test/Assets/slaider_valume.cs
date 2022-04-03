using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slaider_valume : MonoBehaviour
{
    public Text sliderText;
    public Slider slider;
    public string prefix;

    // Update is called once per frame
    void Update()
    {
        sliderText.text = prefix + slider.value.ToString() + "/" + slider.maxValue;
    }
}
