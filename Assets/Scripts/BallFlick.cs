using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFlick : MonoBehaviour
{
    //mouseTestVars
    [SerializeField] private float _thrust = 20f;
 
    private Transform _transform = null;
    private Vector2 _mousePosition0 = Vector2.zero;
    private Vector2 _mousePosition1 = Vector2.zero;
    private bool _flicked = false;
    private Rigidbody _rigidBody = null;
    private float _timeHeld = 0f;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //touchScreen
        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);
        //     if (touch.phase == TouchPhase.Moved)
        //     {
        //         Vector2 pos = touch.position;
        //         pos.x = (pos.x - width) / width;
        //         pos.y = (pos.y - height) / height;
        //         position = new Vector3(-pos.x, pos.y, 0.0f);
            
        //         transform.position = position;
        //     }
        // }

        //mouse
        if(_flicked == false){
            if (Input.GetMouseButtonDown(0)) {
                _mousePosition0 = Input.mousePosition;
                _transform.GetComponent<Renderer>().material.color = Color.white;
                //print(_mousePosition0);
            } 
            if(Input.GetMouseButton(0)) {
                _timeHeld += Time.deltaTime;
                print(_timeHeld);
            }

            if (Input.GetMouseButtonUp(0)) {
                _mousePosition1 = Input.mousePosition;
                //print(_mousePosition1);
                _transform.GetComponent<Renderer>().material.color = Color.black;
                _flicked = true;
            }
        }else{
            Vector3 direction = new Vector3(_mousePosition1.x - _mousePosition0.x, _mousePosition1.y - _mousePosition0.y, 0);
            print(_timeHeld * _thrust);
            _rigidBody.AddForce(direction * (2 - _timeHeld) * _thrust);
            _timeHeld = 0;
            _flicked = false;
        }
    }
}
