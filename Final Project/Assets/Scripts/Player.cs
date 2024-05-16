using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float playerSpeed = 1f;
    
    private bool canTurn;
    private bool ignoreCollision;
    private Rigidbody rigidB;
    private GameObject lastDetector;

    void Start(){
        canTurn = false;
        ignoreCollision = false;
        rigidB = this.GetComponent<Rigidbody>();
    }

    void Update(){
        print(rigidB.velocity);
        if(Input.GetKeyDown(KeyCode.W) && !canTurn){
            rigidB.velocity = transform.forward * playerSpeed;
            ignoreCollision = false;
        }else if(Input.GetKeyDown(KeyCode.S) && !canTurn){
            rigidB.velocity = transform.forward * -playerSpeed;
            ignoreCollision = false;
        }else if(Input.GetKeyDown(KeyCode.A) && canTurn){
            this.transform.Rotate(0, -90, 0, Space.World);
            Vector3 pos = transform.position;
            pos.x = lastDetector.transform.position.x;
            pos.z = lastDetector.transform.position.z;
            transform.position = pos;
            canTurn = false;
        }else if(Input.GetKeyDown(KeyCode.D) && canTurn){
            this.transform.Rotate(0, 90, 0, Space.World);
            Vector3 pos = transform.position;
            pos.x = lastDetector.transform.position.x;
            pos.z = lastDetector.transform.position.z;
            transform.position = pos;
            canTurn = false;
        }
    }

    void OnCollisionEnter(Collision coll){
        if(!ignoreCollision){
            GameObject collGO = coll.gameObject;
            if(collGO.tag == "Detector"){
                rigidB.velocity = Vector3.zero;
                ignoreCollision = true;
                Vector3 pos = transform.position;
                pos.x = collGO.transform.position.x;
                pos.z = collGO.transform.position.z;
                transform.position = pos;
                canTurn = true;
                lastDetector = collGO;
            }
        }
    }
}
