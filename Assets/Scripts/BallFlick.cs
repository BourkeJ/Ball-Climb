using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFlick : MonoBehaviour
{
    [SerializeField] private float _thrust = 20f;
    
    private Transform _transform = null;
    private Vector2 _mousePosition0 = Vector2.zero;
    private Vector2 _mousePosition1 = Vector2.zero;
    private bool _flicked = false;
    private Rigidbody _rigidBody = null;
    private float _timeHeld = 0f;
    private bool _flickable = true;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        //Check if the ball is touching a platform/wall
        if(_flickable == true){
            if(_flicked == false){
                //get position of flick start and change ball color when touched
                if (Input.GetMouseButtonDown(0)) {
                    _mousePosition0 = Input.mousePosition;
                    _transform.GetComponent<Renderer>().material.color = Color.white;
                } 

                //see how long player is holding down their tap
                if(Input.GetMouseButton(0)) {
                    _timeHeld += Time.deltaTime;
                }

                //get position of flick release and change color back to black
                if (Input.GetMouseButtonUp(0)) {
                    _mousePosition1 = Input.mousePosition;
                    _transform.GetComponent<Renderer>().material.color = Color.black;
                    _flicked = true;
                }

            //once flicked, the ball uses the flick positions as a vector and adds force in that direction
            //once force has been added, flick vars are reset
            }else{
                Vector3 direction = new Vector3(
                    _mousePosition1.x - _mousePosition0.x, 
                    _mousePosition1.y - _mousePosition0.y, 
                    0);
                _rigidBody.AddForce(direction * (2 - _timeHeld) * _thrust);
                _timeHeld = 0;
                _mousePosition0 = Vector2.zero;
                _mousePosition1 = Vector2.zero;
                _flicked = false;
            }
        }
    }

    //if the ball is touching a wall or platform, the player can flick
    private void OnTriggerEnter(Collider collision){
        _flickable = true;
    }

    //if the ball is not touching a wall or platform (i.e. in the air) the player cannot flick
    private void OnTriggerExit(Collider collision){
        _flickable = false;
        //if the player starts flicking but the ball rolls out of the trigger zone, the flick vars are reset
        if(_mousePosition1 == Vector2.zero && _mousePosition0 != Vector2.zero){
            _transform.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
