// pause menu from word dropper
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public int score = 0;
    public int lives = 0;
    public float Speed = 0f;
    public string name = "";

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text livesText;
    [SerializeField]
    private Text nameText;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void NewGame()
    {
        Name.username = "Player";
        Score.CurrentScore = 0;
        ChooseNumLives.numLives = 5;
        ChangeSpeed.gameSpeed = 2f;

        nameText.text = Name.username;
        scoreText.text = "Score: " + Score.CurrentScore;
        livesText.text = "Lives: " + ChooseNumLives.numLives;
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        Time.timeScale = 1f;
        Score.CurrentScore = 0;
        ChooseNumLives.numLives = 5;
        ChangeSpeed.gameSpeed = 2f;

        Name.username = "Traveller";
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
        Application.Quit();
       

    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        /*
        Name.username = "Traveller";
        Score.CurrentScore = 0;
        ChooseNumLives.numLives = 5;
        ChangeSpeed.minSpd = 8f;
        ChangeSpeed.maxSpd = 12f;
        ChangeSpeed.gameSpeed = 2f;
        */

        nameText.text = Name.username;
        scoreText.text = "Score: " + Score.CurrentScore;
        livesText.text = "Lives: " + ChooseNumLives.numLives;

        Debug.Log("Game Saved");

    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            Score.CurrentScore = 0;
            ChooseNumLives.numLives = 1;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            nameText.text = save.name;
            scoreText.text = "Score: " + save.score;
            livesText.text = "Lives: " + save.lives;

            Name.username = save.name;
            Score.CurrentScore = save.score;
            ChooseNumLives.numLives = save.lives;
            ChangeSpeed.gameSpeed = save.gameSpeed;

            Debug.Log("Game Loaded");

            Resume();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.score = Score.CurrentScore;
        save.lives = ChooseNumLives.numLives;
        save.gameSpeed = ChangeSpeed.gameSpeed;
        save.name = Name.username;

        return save;

    }

}
