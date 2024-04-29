using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MathTest : MonoBehaviour
{
    public float Magnitude, Speed;
    public Vector3 StartPos;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, PingPongAmount(), 0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(StartPos, 0.25f);
    }
    public float PingPongAmount()
    {
        return Mathf.PingPong(Time.time * Speed, Magnitude);
    }
    public float SineAmount()
    {
        return Mathf.Sin(Time.time * Speed);
    }
}
