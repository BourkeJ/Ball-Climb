using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    [SerializeField] private Transform _ballTrans = null;
    [SerializeField] private Rigidbody _ballRB = null;
    private Vector3 _startPos = Vector3.zero;

    void Awake()
    {
        _startPos = _ballTrans.position;
    }

    public void BallReset()
    {
        _ballRB.velocity = Vector3.zero;
        _ballRB.angularVelocity = Vector3.zero;
        _ballTrans.position =  _startPos;
    }

    public void OnTriggerEnter(Collider collider){
        BallReset();
    }
}
