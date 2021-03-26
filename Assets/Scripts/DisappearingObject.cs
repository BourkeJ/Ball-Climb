using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingObject : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(){
        Destroy(gameObject);
    }
}
