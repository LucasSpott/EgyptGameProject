using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [Header("Player Attack")]
    public int damage;
    public GameObject Enemy;

    public Animator anim;

    void Update(){

        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Enemy"){
            Enemy.GetComponent<EnemyLife>().TakeDamage(damage);
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                anim.SetBool("Attack", true);
                anim.SetBool("Idle", false);
            }else{
                anim.SetBool("Attack", false);
                anim.SetBool("Idle", true);
            }
        }
    }
}
