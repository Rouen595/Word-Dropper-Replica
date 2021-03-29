// word dropper
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public InputField usernameInput;
    public static string username = "Wordman";

    void Start()
    {
        if (username != null)
            usernameInput.text = username;
    }

    public void SaveUsername(string newName)
    {
        username = newName;
    }
}
