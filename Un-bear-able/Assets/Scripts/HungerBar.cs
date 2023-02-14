using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider HungerSlider;
    public static float Hunger;
    float maxHunger = 100f;
    // Start is called before the first frame update
    void Start()
    {
        Hunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        HungerSlider.value = Hunger;

        Hunger -= 0.1f * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            Hunger -= 0.2f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Hunger -= 0.2f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Hunger -= 0.2f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Hunger -= 0.2f * Time.deltaTime;
        }
    }
}