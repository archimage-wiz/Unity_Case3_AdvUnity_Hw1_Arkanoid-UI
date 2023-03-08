using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGamePlayMaster : MonoBehaviour
{
    [SerializeField] private GamePlayMaster _master;
    [SerializeField] private GameObject _ball;

    void Start()
    {
        if(_master == null){
            _master = FindObjectOfType<GamePlayMaster>();
        }
        _master.GamePauseAction += OnPause;
        _master.GameUnPauseAction += OnUnPause;
        //print("Scene game play master started");
    }

    void OnPause() {

        _ball.SetActive(false);


    }
    void OnUnPause() {

        _ball.SetActive(true);

    }

    void OnDisable () {
        // _master.GamePauseAction -= OnPause;
        // _master.GameUnPauseAction -= OnUnPause;
    }
    void OnDestroy () {
        _master.GamePauseAction -= OnPause;
        _master.GameUnPauseAction -= OnUnPause;
    }

}
