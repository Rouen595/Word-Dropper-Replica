using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{

    public Text livesText;
    public GameManager gameManager;

    void Start()
    {
        
        
        livesText.text = "Lives: " + ChooseNumLives.numLives.ToString(); 

    }

    void Update()
    {
        livesText.text = "Lives: " + ChooseNumLives.numLives.ToString();
        if (ChooseNumLives.numLives < 1)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("Credits");
        }
    }

}
