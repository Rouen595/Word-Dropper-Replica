// game manager from word dropper
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;

    public float restartDelay = 0.01f;


    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("YOU DIED");
            //restart game
            Restart();
        }

    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
