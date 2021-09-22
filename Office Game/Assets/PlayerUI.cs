using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class PlayerUI : MonoBehaviour
{
    public GameObject winPanel, deathPanel, pausePanel;

    public ScenesManager scenes;

    private string gameID = "4356945";
    public static int addCnt = 1;

    void Start(){
        Advertisement.Initialize(gameID, false);
    }

    public void pause(){
        pausePanel.SetActive(true);
        Time.timeScale = 0;      

        if(addCnt % 3 == 0){
            if(Advertisement.IsReady("Interstitial_Android")){
                Advertisement.Show("Interstitial_Android");
            }
        }

        addCnt++;
    }

    public void resume(){
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void openScene(int id){
        Time.timeScale = 1;
        scenes.openScene(id);
        //Application.LoadLevel(id);
    }

    public void restart(){
        openScene(Application.loadedLevel);
    }

    public void next(){
        openScene(Application.loadedLevel+1);
    }

    public void setDeathPanelVisible(bool visible){
        deathPanel.SetActive(visible);

        if(visible){
            if(addCnt % 3 == 0){
                if(Advertisement.IsReady("Interstitial_Android")){
                    Advertisement.Show("Interstitial_Android");
                }
            }

            addCnt++;   
        }
    }

    public void setWinPanelVisible(bool visible){
        winPanel.SetActive(visible);
    }
}
