using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseScript2 : MonoBehaviour
{
    public GameObject pauseCanvas;
    public bool paused = false;
    public Button resumeButton;
    public FirstPersonController fps;

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            togglePause();
        }
    }

    public void togglePause()
    {
        fps.lockcam = !fps.lockcam;
        paused = !paused;
        Time.timeScale = paused ? 0f : 1f;
        pauseCanvas.SetActive(paused);
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = paused;

        Debug.Log(paused ? "Game Paused" : "Game Resumed");
    }

    public void exitToMenu()
    {
        if(paused)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }

  
}
