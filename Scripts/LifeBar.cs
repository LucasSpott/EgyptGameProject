using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour{
    
    private static Image lifeBarImage;

    public static void LifeHeathBar(float life){
        lifeBarImage.fillAmount = life;
    if(lifeBarImage.fillAmount < 0.2f){
        LifeHeathBarColor(Color.red);
    }else if(lifeBarImage.fillAmount < 0.5f){
        LifeHeathBarColor(Color.yellow);
    }else{
        LifeHeathBarColor(Color.green);
    }
}

    public static float LifeBarValue(){
        return lifeBarImage.fillAmount;
    }

    public static void LifeHeathBarColor(Color color){
        lifeBarImage.color = color;
    }

    void Start(){
        lifeBarImage = GetComponent<Image>();
    }
}

