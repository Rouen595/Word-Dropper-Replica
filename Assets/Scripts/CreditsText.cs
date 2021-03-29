// credits from word dropper
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsText : MonoBehaviour
{
    public Text creditsName;
    public Text creditsScore;
    public Text creditsLives;

    void Start()
    {
        creditsName.text = "Game over, " + Name.username;
        creditsScore.text = "Score: " + Score.CurrentScore;
        creditsLives.text = "Lives: " + ChooseNumLives.numLives;
    }
}
