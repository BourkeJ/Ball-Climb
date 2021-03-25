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



    // Start is called before the first frame update
	private void Awake() {
		_transform = GetComponent<Transform>();
		_camera = GetComponent<Camera>();
        bottomLeway = 0f;
	}

    // Update is called once per frame
    void Update()
    {
        if(_transform.position.y > maxHeight){
            maxHeight = _transform.position.y;
        }

        if(_transform.position.y > 1){
            bottomLeway = _bottomBound;
        }

        if(_transform.position.y > 1){
            _transform.position = new Vector3(
                _transform.position.x,
                Mathf.Clamp(
                    _target.position.y, 
                    maxHeight - bottomLeway, 
                    _topObject.position.y - _topBound),
                _transform.position.z);
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
