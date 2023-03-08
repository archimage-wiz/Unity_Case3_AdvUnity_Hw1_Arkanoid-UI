using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player1Controller : PlayerController
{
    [SerializeField] public TMPro.TextMeshProUGUI _p1_scores_text;

        void Update() {
        xy = _input.ActionMap.Player1Move.ReadValue<Vector2>();
        PlayerMove(xy);
        _p1_scores_text.text = _player_score.ToString();
    }

}
