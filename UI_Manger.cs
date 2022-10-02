using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UI_Manger : MonoBehaviourPun
{
    GameObject[] killEmAll;
    
    
    // Start is called before the first frame update
    
    void Start()
    {
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            killEmAll = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < killEmAll.Length; i++)
            {
                
                Destroy(killEmAll[i].gameObject);
            }
            killEmAll = GameObject.FindGameObjectsWithTag("Enemy_Siege");
            for (int i = 0; i < killEmAll.Length; i++)
            {
                
                Destroy(killEmAll[i].gameObject);
            }
            killEmAll = GameObject.FindGameObjectsWithTag("SiegeWeapon");
            for (int i = 0; i < killEmAll.Length; i++)
            {
                
                Destroy(killEmAll[i].gameObject);
            }

        }


        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            Time.timeScale = 0;
            GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("Pause_Panel").gameObject.SetActive(true);
            GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("First_Panel").gameObject.SetActive(false);
            GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("Setting_Panel").gameObject.SetActive(false);
            GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("GameOver_Panel").gameObject.SetActive(false);
            GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale = 0;
            GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("Pause_Panel").gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("First_Panel").gameObject.activeSelf)
            {
                
                StartButton();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("Pause_Panel").gameObject.activeSelf)
            {
                ResumeButton();
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("RoundClear_Panel").gameObject.activeSelf)
            {
                //gameObject.GetComponent<Game_Manager>().PhotonNextRoundBool = true;
                NextRoundButton();
            } 
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("GameOver_Panel").gameObject.activeSelf)
            {
                //gameObject.GetComponent<Game_Manager>().PhotonRestartBool = true;
                RestartButton();
            }
        }
    }
    
    public void StartButton() 
    {
        //혹시 적 있으면 다 없애고
        killEmAll = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < killEmAll.Length; i++)
        {
            
            Destroy(killEmAll[i].gameObject);
        }
        killEmAll = GameObject.FindGameObjectsWithTag("Enemy_Siege");
        for (int i = 0; i < killEmAll.Length; i++)
        {
            
            Destroy(killEmAll[i].gameObject);
        }
        killEmAll = GameObject.FindGameObjectsWithTag("SiegeWeapon");
        for (int i = 0; i < killEmAll.Length; i++)
        {
            
            Destroy(killEmAll[i].gameObject);
        }


        //gameObject.GetComponent<Game_Manager>().PhotonStartBool += 1 ;
        GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round += 1;
        GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Enemy_Create_Start();
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().HealthPoint = 100;
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().Limit_Time = 65;
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().TimeEnd();
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().GameStartBool = true;
        GameObject.Find("Game_Manager").transform.Find("PC_Main_GameOVRCanvas").transform.Find("TimeCount_Panel").gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("UI_FirstPanel").SetActive(false);
        //GameObject.FindGameObjectWithTag("UI_Canvas").SetActive(false);
        //GameObject.Find("Game_Manager").transform.Find("Canvas").gameObject.SetActive(false);


    }
    
    public void ResumeButton()
    {
        GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("Pause_Panel").gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void SettingButton()
    {
        GameObject.FindGameObjectWithTag("UI_FirstPanel").SetActive(false);
        //GameObject.FindGameObjectWithTag("UI_PausePanel").SetActive(false);
        GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("Setting_Panel").gameObject.SetActive(true);
    }
    
    public void BackButton_SettingPanel()
    {
        GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("Setting_Panel").gameObject.SetActive(false);
        GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("First_Panel").gameObject.SetActive(true);
    }
    
    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
    
    public void RestartButton()
    {
        GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round = 0;
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().GameStartBool = false;
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().GameOverBool = false;
        GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("GameOver_Panel").gameObject.SetActive(false);
        GameObject.Find("Game_Manager").transform.Find("PC_Main_GameOVRCanvas").transform.Find("GameOver_Panel").gameObject.SetActive(false);
        GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("First_Panel").gameObject.SetActive(true);
        //GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Enemy_Create_Start();
        killEmAll = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < killEmAll.Length; i++)
        {
            
            Destroy(killEmAll[i].gameObject);
        }
        killEmAll = GameObject.FindGameObjectsWithTag("Enemy_Siege");
        for (int i = 0; i < killEmAll.Length; i++)
        {
            
            Destroy(killEmAll[i].gameObject);
        }
        killEmAll = GameObject.FindGameObjectsWithTag("SiegeWeapon");
        for (int i = 0; i < killEmAll.Length; i++)
        {
            
            Destroy(killEmAll[i].gameObject);
        }
    }
    
    public void NextRoundButton()
    {
        //gameObject.GetComponent<Game_Manager>().PhotonRoundClearBool += 1;
        //GameObject.Find("Game_Manager").GetComponent<Game_Manager>().Enemy_Killed = 0;
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().Enemy_Killed = 0;
        //GameObject.Find("Game_Manager").GetComponent<Game_Manager>().MasterEnemy_Killed = 0;
        //GameObject.Find("Game_Manager").GetComponent<Score_Manger>().MasterEnemy_Killed = 0;
        //GameObject.Find("Game_Manager").GetComponent<Game_Manager>().SubEnemy_Killed = 0;
        //GameObject.Find("Game_Manager").GetComponent<Score_Manger>().Enemy_Killed = 0;
        GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round += 1;
        GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Enemy_Create_Start();
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().Limit_Time = 65;
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().GameStartBool = true;
        //GameObject.FindGameObjectWithTag("UI_RoundClearPanel").SetActive(false);
        GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(false);
        GameObject.Find("Game_Manager").transform.Find("PC_Main_GameOVRCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(false);
        GameObject.Find("Game_Manager").transform.Find("PC_Main_GameOVRCanvas").transform.Find("TimeCount_Panel").gameObject.SetActive(true);
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().TimeEnd();
        //GameObject.FindGameObjectWithTag("UI_Canvas").SetActive(false);
        //GameObject.Find("Game_Manager").transform.Find("Canvas").gameObject.SetActive(false);

    }
    

}
