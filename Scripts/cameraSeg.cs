using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSeg : MonoBehaviour{
    
    public Vector3 pos, segPos;
    public Transform player;
    public Vector3 offset;
    public float seg;

    void Start(){
        offset = player.position - transform.position;
    }

    void LateUpdate(){
     Perseg();
}
       void Perseg(){
            pos = transform.position;
            segPos = player.position - offset;
            pos = Vector3.Lerp(pos, segPos, seg * Time.deltaTime);
            transform.position = pos;
    }
}
