using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour{
   [Header("Enemy Life")]
    public int LifeEnemy;

    public void TakeDamage(int damage){
        LifeEnemy -= damage;
        LifeSystem();
    }

    void LifeSystem(){
        if(LifeEnemy <= 0){
            Destroy(gameObject);
        }
    }

}
