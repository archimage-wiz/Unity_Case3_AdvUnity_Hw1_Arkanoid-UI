using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGamePlayMaster : MonoBehaviour
{
    [SerializeField] int BricksMatrix_x, BricksMatrix_y;
    private GameObject [][] _bricks;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _tunnel;
    [SerializeField] private GameObject _p1_camera;
    [SerializeField] private GameObject _p2_camera;
    private GamePlayMaster _master;
   

    void Start()
    {

        BricksCreator();

        if(_master == null){
            _master = FindObjectOfType<GamePlayMaster>();
        }
        _master.GamePauseAction += OnPause;
        _master.GameUnPauseAction += OnUnPause;

    }

    void ShowHide(bool x){
        _ball.SetActive(x);
        _tunnel.SetActive(x);
        _p1_camera.SetActive(x);
        _p2_camera.SetActive(x);
        for(int y_cnt = 0; y_cnt < _bricks.Length; y_cnt++)
        {
            for(int x_cnt = 0; x_cnt < _bricks[y_cnt].Length; x_cnt++)
            {
                _bricks[y_cnt][x_cnt].SetActive(x);
            }
        }
    }

    void OnPause() {

        ShowHide(false);
        //Time.timeScale = 0f;
    }
    void OnUnPause() {

        ShowHide(true);
        //Time.timeScale = 1f;

    }

    void OnDisable () {
        // _master.GamePauseAction -= OnPause;
        // _master.GameUnPauseAction -= OnUnPause;
    }
    void OnDestroy () {
        _master.GamePauseAction -= OnPause;
        _master.GameUnPauseAction -= OnUnPause;
    }


    void BricksCreator()
    {

        _bricks = new GameObject[BricksMatrix_y][];
        for (int i = 0; i < BricksMatrix_y; i++) {
            _bricks[i] = new GameObject[BricksMatrix_x];
        }

        var _brick = Resources.Load("Brick", typeof(GameObject)) as GameObject;
        //print(_brick);

        for(int y_cnt = 0; y_cnt < _bricks.Length; y_cnt++)
        {
            for(int x_cnt = 0; x_cnt < _bricks[y_cnt].Length; x_cnt++)
            {
                _bricks[y_cnt][x_cnt] = Instantiate(_brick, new Vector3(0, (BricksMatrix_y - y_cnt) * 0.5f, x_cnt - (BricksMatrix_x/2)), Quaternion.identity, this.gameObject.transform);
                _bricks[y_cnt][x_cnt].transform.Rotate(0, yAngle:90, 0);
            }            
        }        
        
    }


}
