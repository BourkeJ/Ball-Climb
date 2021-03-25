using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFlick : MonoBehaviour
{
    //mouseTestVars
    [SerializeField] private Camera _camera = null;
    private Vector2 _mousePosition0 = Vector2.zero;
    private Vector2 _mousePosition1 = Vector2.zero;
    private bool _flicked = false;
    private Rigidbody _rigidBody = null;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
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
                print(_mousePosition0);
            } 
            if (Input.GetMouseButtonUp(0)) {
                _mousePosition1 = Input.mousePosition;
                print(_mousePosition1);
                _flicked = true;
            }
        }else{
            Vector3 direction = new Vector3(_mousePosition1.x - _mousePosition0.x, _mousePosition1.y - _mousePosition0.y, 0);
            print(_mousePosition1.x - _mousePosition0.x);
            _rigidBody.AddForce(direction * 0.5f);
            _flicked = false;
        }
    }
}
