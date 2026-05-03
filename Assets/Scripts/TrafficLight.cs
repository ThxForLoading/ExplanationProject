using System;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [Header("Lights")]
    [SerializeField] GameObject topLight;
    [SerializeField] GameObject middleLight;
    [SerializeField] GameObject bottomLight;

    [Header("Materials")]
    [SerializeField] Material[] mats; //Assigned in Inspector, black = 0, red = 1, yellow = 2, green = 3

    private MeshRenderer meshTop;
    private MeshRenderer meshBottom;
    private MeshRenderer meshMiddle;

    [Header("Toggle State")]
    public TrafficLightStates currentState;

    void Start()
    {
        meshTop = topLight.GetComponent<MeshRenderer>();
        meshMiddle = middleLight.GetComponent<MeshRenderer>();
        meshBottom = bottomLight.GetComponent<MeshRenderer>();

        meshTop.material = mats[0];     //Set all 3 to black
        meshMiddle.material = mats[0];
        meshBottom.material = mats[0];
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case TrafficLightStates.Red:
                meshTop.material = mats[1];     //Top to red
                meshMiddle.material = mats[0];
                meshBottom.material = mats[0];
                break;
            case TrafficLightStates.Yellow:
                meshTop.material = mats[0];     //Mid to yellow
                meshMiddle.material = mats[2];
                meshBottom.material = mats[0];
                break;
            case TrafficLightStates.Green:
                meshTop.material = mats[0];     //Bot to green
                meshMiddle.material = mats[0];
                meshBottom.material = mats[3];
                break;
            case TrafficLightStates.AllBlack:
                meshTop.material = mats[0];     //Set all 3 to black
                meshMiddle.material = mats[0];
                meshBottom.material = mats[0];
                break;
            default:
                break;
        }
    }
}


public enum TrafficLightStates{
    Red,
    Yellow,
    Green,
    AllBlack
}