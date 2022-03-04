using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sandClock : MonoBehaviour
{
    public GameObject SandClockNumber;
    public static int scNumber;
    
    void Update()
    {
        SandClockNumber.GetComponent<Text>().text ="" + scNumber;
    }
}
