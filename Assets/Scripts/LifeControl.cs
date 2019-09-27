using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControl : MonoBehaviour{

    public static int lifeCountLost = 0;
    public static bool isOver = false;

    public GameObject[] lifesBlack;
    public GameObject[] lifesRed;
    
    public void LifeLost(){
        if(lifeCountLost < 4){
            for(int i = 0; i < lifeCountLost; i++){
                lifesBlack[i].SetActive(false);
                lifesRed[i].SetActive(true);
            }
        }
        else{
            isOver = true;
        }
    }

}
