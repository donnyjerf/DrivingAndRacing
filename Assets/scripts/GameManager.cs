using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public controller RR;
    public GameObject needle;
    private float startPosition = 225f, endPosition = -45;
    private float desiredPosition;

    public float vehicleSpeed;

    void Start()
    {

    }

    void FixedUpdate()
    {
        vehicleSpeed = RR.KPH;
        updateNeedle();

    }

    public void updateNeedle()
    {
        desiredPosition = startPosition - endPosition;
        float temp = RR.engineRPM / 10000;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * desiredPosition));


    }
}
