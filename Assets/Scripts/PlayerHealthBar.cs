using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    Vector3 scale;


    [SerializeField] Slider slider;
    [SerializeField] GameObject targetObject;
    //[SerializeField] Vector3 offset;

    private void Awake()
    {
        scale = transform.localScale;
    }
    private void Update()
    {
        transform.localScale = scale;

        float sliderValue = targetObject.GetComponent<PlayerHealth>().GetHealthPercentage();
        slider.value = sliderValue; 
    }

}
