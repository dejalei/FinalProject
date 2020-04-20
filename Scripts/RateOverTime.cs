using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateOverTime : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 5.0f;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var emission = ps.emission;
        emission.rateOverTime = hSliderValue;
    }
    private void OnGUI()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(25, 45, 100, 30), hSliderValue, 5.0f, 200.0f);
    }
}