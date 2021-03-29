// change speed from word dropper
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpeed : MonoBehaviour
{
    public static float gameSpeed = 1f;

    /*
    public void Start()
    {
        gameSpeed = 1f;
    }
    */

    public void Change(float f)
    {
        GetComponent<Text>().text = f.ToString();
        gameSpeed = f;
    }
}
