using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Transform target;
    private Vector3 initialOffset;
    private Vector3 cameraPosition;
    private Transform pastTarget;

    void Start(){
        initialOffset = this.transform.position - target.position;
        pastTarget = target;
    }

    void Update(){
        cameraPosition = target.position + initialOffset;
        transform.position = cameraPosition;
        if(pastTarget.transform.rotation != target.rotation){
            transform.Rotate(0, target.rotation.y, 0, Space.World);
        }
        pastTarget = target;
    }
}
