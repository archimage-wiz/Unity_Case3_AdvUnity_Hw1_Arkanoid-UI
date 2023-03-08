using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour
{

    [SerializeField] private float _level_bound_p1 = 27;
    [SerializeField] private float _level_bound_p2 = -27;
    [SerializeField] private float _max_ball_speed = 25;
    [SerializeField, Range(1, 25)] private float _ball_speed = 1;
    [SerializeField, Range(0.01f, 1)] private float _ball_acceleration = 0.01f;
    [SerializeField] private float _ball_distraction_factor = 25;
    private Rigidbody _self_rigidbody;
    private Vector3 _last_vector;
    private Vector3 _av_before_collision;
    private PlayerController _last_player;

    void Start() {

        _self_rigidbody = transform.GetComponent<Rigidbody>();

        _last_vector = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)) * _ball_speed;
        //_last_vector = new Vector3(15, 5, 5) * _ball_speed;
        _self_rigidbody.velocity = _last_vector;
        //print(_self_rigidbody.GetInstanceID());

    }

    void OnCollisionEnter(Collision collision){

        _last_vector = Vector3.Reflect(_last_vector.normalized, collision.gameObject.transform.forward);

        var _was_a_payer = false;
        if (collision.gameObject == FindObjectOfType<Player1Bat>().gameObject){
            _last_player = FindObjectOfType<Player1Controller>();
            _was_a_payer = true;
        }
        if (collision.gameObject == FindObjectOfType<Player2Bat>().gameObject){
            _last_player = FindObjectOfType<Player2Controller>();
            _was_a_payer = true;
        }
        if(_was_a_payer) {
            var p_vel = _last_player.GetVector2Velocity();
            _last_vector += new Vector3(0, p_vel.y, p_vel.x) * _ball_distraction_factor;
        }

        if (collision.gameObject.GetComponent<BrickController>() is BrickController && _last_player) {
            int x = collision.gameObject.GetComponent<BrickController>().GetSelfPower();
            _last_player.AddScore(x);
        }

        if (_ball_speed < _max_ball_speed) { _ball_speed += _ball_acceleration; }
        _last_vector = _last_vector * _ball_speed;

    }


    void Update()
    {
        if (_self_rigidbody.velocity.x == 0) { _last_vector += Vector3.one * Time.deltaTime; }
        //print(_self_rigidbody.GetInstanceID());
        
        if (_last_vector.x > 0 && _last_vector.x < 5) { _last_vector += new Vector3(0.1f, 0, 0) * Time.deltaTime; }
        if (_last_vector.x < 0 && _last_vector.x > -5) { _last_vector -= new Vector3(0.1f, 0, 0) * Time.deltaTime; }
        _self_rigidbody.velocity = _last_vector;

        if (transform.position.x > _level_bound_p1 || transform.position.x < _level_bound_p2) {
            if (_last_player) { _last_player.AddScore(0); } // TODO: game scores logic
            transform.position = new Vector3(0, 6, 0);
            _last_vector = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)) * _ball_speed;
            _self_rigidbody.velocity = _last_vector;
        }
        
    }

}
