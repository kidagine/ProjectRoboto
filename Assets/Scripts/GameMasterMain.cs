    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterMain : MonoBehaviour
{

    private static GameMasterMain instanceMain;
    public Vector2 lastCheckPointPosMain;
    void Awake(){

        if (instanceMain == null){
            instanceMain = this;
            DontDestroyOnLoad(instanceMain);
        } else {
            Destroy(gameObject);
        }
    }
}