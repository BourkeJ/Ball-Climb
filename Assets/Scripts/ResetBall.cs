using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    [SerializeField] private Transform _ballTrans = null;
    [SerializeField] private Rigidbody _ballRB = null;
    [SerializeField] private Transform _camTrans = null;
    [SerializeField] private CameraMovement _camMovement = null;
    [SerializeField] private float _maxDrop = -1f;

    private Vector3 _startPos = Vector3.zero;
    private Vector3 _startPosCam = Vector3.zero;

    void Awake()
    {
        _startPos = _ballTrans.position;
        _startPosCam = _camTrans.position;
    }

    public void BallReset()
    {
        //reset variables if this function is called
        _ballRB.velocity = Vector3.zero;
        _ballRB.angularVelocity = Vector3.zero;
        _ballTrans.position =  _startPos;
        _camMovement.maxHeight = 0;
        _camMovement.bottomLeway = 0f;
        _camTrans.position = _startPosCam;
    }

    void Update(){
        //call ball reset if the ball falls out of bounds
        if(_ballTrans.position.y -_camTrans.position.y  < _maxDrop){
            BallReset();
        }
    }
}
