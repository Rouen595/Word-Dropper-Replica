using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{

    public Text livesText;
    public GameManager gameManager;

    void Start()
    {
        
        if (ChooseNumLives.numLives < 1)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("Credits");
        }
        livesText.text = "Lives: " + ChooseNumLives.numLives.ToString(); 

    }

}
