using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _topObject = null;
    [SerializeField] private float _topBound = -0.2f;
    [SerializeField] private float _bottomBound = 0f;
    [SerializeField] private Transform _target = null;

    private Transform _transform;
    private Camera _camera;
    
    [HideInInspector] public float bottomLeway = 0f;
    [HideInInspector] public float maxHeight;


	private void Awake() {
		_transform = GetComponent<Transform>();
		_camera = GetComponent<Camera>();
        bottomLeway = 0f;
	}

    void Update()
    {
        //check the highest point the camera has been
        if(_transform.position.y > maxHeight){
            maxHeight = _transform.position.y;
        }

        //check if camera is out of the start area
        if(_transform.position.y > 1){
            bottomLeway = _bottomBound;
        }

        //if the camera is out of the start area, it is clamped so the ball can go no lower than the platform lowest on the screen at the cam's max height
        if(_transform.position.y > 1){
            _transform.position = new Vector3(
                _transform.position.x,
                Mathf.Clamp(
                    _target.position.y, 
                    maxHeight - bottomLeway, 
                    _topObject.position.y - _topBound),
                _transform.position.z);
        //if the camera is in the starting area, it is clamped to a height of 1
        }else{
            _transform.position = new Vector3(
                _transform.position.x,
                Mathf.Clamp(
                    _target.position.y, 
                    1, 
                    _topObject.position.y - _topBound),
                _transform.position.z);
        }
    }
}
