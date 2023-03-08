using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGamePlayMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
                
    }

    public void OnClickNewGameButton() {
        FindObjectOfType<GamePlayMaster>().NewGame();
    }

    public void OnClickResumeButton() {
        FindObjectOfType<GamePlayMaster>().ResumeGame();
    }

    public void OnClickExitButton() {
        FindObjectOfType<GamePlayMaster>().ExitGame();
    }

}
