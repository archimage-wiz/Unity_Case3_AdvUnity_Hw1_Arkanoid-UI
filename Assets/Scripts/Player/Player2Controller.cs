using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class Player2Controller : PlayerController
{
    [SerializeField] private TMPro.TextMeshProUGUI _scores_text;
    
    void Start()
    {
        var _game_play_master = FindObjectOfType<SceneGamePlayMaster>();

        
    }

    void Update(){
        xy = _input.ActionMap.Player2Move.ReadValue<Vector2>();
        PlayerMove(xy);
        _scores_text.text = _player_score.ToString();
        
    }

}
