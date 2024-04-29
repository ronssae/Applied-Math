using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMath : MonoBehaviour
{
    public Slider LerpSlider;
    public Slider MoveTowards;
    public Slider PingPong;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LerpSlider.value = Mathf.Lerp
            (LerpSlider.value, LerpSlider.maxValue, Speed * Time.deltaTime);
        MoveTowards.value = Mathf.MoveTowards
            (MoveTowards.value, MoveTowards.maxValue, Speed * Time.deltaTime);
        PingPong.value = Mathf.PingPong
            (Speed * Time.time, PingPong.maxValue);
    }
}
