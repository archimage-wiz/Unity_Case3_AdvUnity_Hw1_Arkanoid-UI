using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.EventSystems;
using System;

public class GamePlayMaster : MonoBehaviour
{
    private PlayerInputMap _input;
    public event Action GamePauseAction;
    public event Action GameUnPauseAction;
    public bool _is_paused = true;


    void Start()
    {
        if (_input != null) { _input = new PlayerInputMap(); }
        if(SceneManager.GetActiveScene().buildIndex == 0) {
            SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
        }

        _input = new PlayerInputMap();
        _input.ActionMap.Enable();
        _input.ActionMap.MainMenu.performed += MainMenuAsk;

    }

    public void NewGame(){

        if (SceneManager.GetSceneByName("GameScene").isLoaded == true) { 
            SceneManager.UnloadSceneAsync("GameScene");
        }
        SceneManager.UnloadSceneAsync("PauseMenu");

        SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
        _is_paused = false;

    }
    public void ResumeGame(){
        SceneManager.UnloadSceneAsync("PauseMenu");
        _is_paused = false;
        GameUnPauseAction?.Invoke();
    }
    public void ExitGame(){
        SceneManager.UnloadSceneAsync("PauseMenu");
        SceneManager.UnloadSceneAsync("GameScene");
        print("Exit game");
        Debug.Break();
    }

    void MainMenuAsk(CallbackContext context){

        if(_is_paused != true) {
            _is_paused = true;
            print(Time.timeScale);
            //Time.timeScale = 0f;
            GamePauseAction?.Invoke();
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        }
        
    }


}
