using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLife : MonoBehaviour{

    [Header("Player Life")]
    public int life;
    public Slider lifeBar;

    private void Update(){

        lifeBar.GetComponent<Slider>().value = life;

        if(life <= 0){
            
        }
    }
}