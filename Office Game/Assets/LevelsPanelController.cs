using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelsPanelController : MonoBehaviour
{
    public Image[] levels;

    public Color32 activeItem;
    public Color32 unavailableItem;

    public ScenesManager scenes;

    void Start(){
        //PlayerPrefs.SetInt("currentLevel", 1);
        for(int i=0;i<levels.Length;i++){
            if(i<=PlayerPrefs.GetInt("currentLevel")){
                levels[i].GetComponent<Image>().color = activeItem;
            }
            else{
                levels[i].GetComponent<Image>().color = unavailableItem;
            }
        }
    }

    public void openLevel(int level){
        if(PlayerPrefs.GetInt("currentLevel",0) >= level-1){
            scenes.openScene(level+1);
        }
    }
}
