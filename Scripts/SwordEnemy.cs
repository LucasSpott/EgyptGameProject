using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy : MonoBehaviour
{
    [Header("Enemy Damage")]
    public int damageEnemy;
    public GameObject Player;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            Player.GetComponent<playerLife>().life -= damageEnemy;
        }
    }

}
