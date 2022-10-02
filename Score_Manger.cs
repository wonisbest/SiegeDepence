using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manger : MonoBehaviour
{
    public int Score;
    public int Enemy_Killed = 0;
    public int Enemy_Remained = 0;
    public int Round = 0;
    public int HealthPoint = 100;
    public bool GameOverBool = false;
    public bool GameStartBool = false;
    public Slider HealthSldier;
    public Text txt_scr;
    public Text txt_rem;
    public Text txt_round;
    public Text txt_health;
    public Text txt_Round_End_Score;
    public Text txt_Game_End_Score;
    public Text txt_Game_Over_Score;
    public Text txt_OVR_Game_Over_Score;
    public Text txt_OVR_Round_End_Score;

    public Text txt_gameinfo_round;
    public Text txt_gameinfo_time;
    public Text txt_gameinfo_health;
    public Text txt_gameinfo_remainenemy;
    public Text txt_gameinfo_score;

    public Text txt_TCBS_time;

    public float Limit_Time ;
    public Text txt_Time;

    GameObject[] killEmAll; //SiegeWeapon Destroy
    // Start is called before the first frame update
    void Start()
    {
        txt_scr = GameObject.Find("Scroe_Var_Text").GetComponent<Text>();
        txt_rem = GameObject.Find("Enemy_Killed_Var_Text").GetComponent<Text>();
        txt_round = GameObject.Find("Round_Var_Text").GetComponent<Text>();
        txt_health = GameObject.Find("HealthVarText").GetComponent<Text>();
    }

    // Update is called once per frame
    
    void Update()
    {
        //Score = GameObject.Find("Game_Manager").GetComponent<Game_Manager>().Score;
        //nemy_Killed = GameObject.Find("Game_Manager").GetComponent<Game_Manager>().Enemy_Killed;
        Round = GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round;
        
        /*if (PhotonNetwork.IsMasterClient)
        {
            //master score, kill 동기화
            if (MasterScore >= GameObject.Find("Game_Manager").GetComponent<Game_Manager>().MasterScore)
            {
                GameObject.Find("Game_Manager").GetComponent<Game_Manager>().MasterScore = MasterScore;
            }

            if (MasterEnemy_Killed >= GameObject.Find("Game_Manager").GetComponent<Game_Manager>().MasterEnemy_Killed)
            {
                GameObject.Find("Game_Manager").GetComponent<Game_Manager>().MasterEnemy_Killed = MasterEnemy_Killed;
            }

            //sub score, kill 동기화
            SubScore = GameObject.Find("Game_Manager").GetComponent<Game_Manager>().SubScore;
            SubEnemy_Killed = GameObject.Find("Game_Manager").GetComponent<Game_Manager>().SubEnemy_Killed;
            

        }
        else
            {
            //master score, kill 동기화
            MasterScore = GameObject.Find("Game_Manager").GetComponent<Game_Manager>().MasterScore;
            MasterEnemy_Killed = GameObject.Find("Game_Manager").GetComponent<Game_Manager>().MasterEnemy_Killed;

            //sub score, kill 동기화
            if (SubScore >= GameObject.Find("Game_Manager").GetComponent<Game_Manager>().SubScore)
            {
                GameObject.Find("Game_Manager").GetComponent<Game_Manager>().SubScore = SubScore;
            }

            if (SubEnemy_Killed >= GameObject.Find("Game_Manager").GetComponent<Game_Manager>().SubEnemy_Killed)
            {
                GameObject.Find("Game_Manager").GetComponent<Game_Manager>().SubEnemy_Killed = SubEnemy_Killed;
            }

            Limit_Time = gameObject.GetComponent<Game_Manager>().Limit_Time;
            HealthPoint = gameObject.GetComponent<Game_Manager>().HealthPoint;
            
            }*/
        Remain_Enemy();

        txt_scr.text = Score.ToString();
        txt_rem.text = Enemy_Remained.ToString();
        txt_round.text = Round.ToString();
        TimeCountBeforeStart();
        GameInfoUI();
        HealthBar();
        Round_End();
        TimeEnd();
        
    }

    void Round_End()
    {
        if(Round == 1)
        {
            if(Enemy_Killed == 10)
            {
                Enemy_Killed = 0;
                GameStartBool = false;
                //GameObject.Find("Game_Manager").transform.Find("MainCanvas").gameObject.SetActive(true);
                Score += (int)(Limit_Time * 100);
                Score += HealthPoint * 10;
                //GameObject.Find("Game_Manager").GetComponent<Game_Manager>().Score = Score;
                txt_Round_End_Score.text = Score.ToString();
                txt_OVR_Round_End_Score.text = Score.ToString();
                GameObject.Find("Game_Manager").transform.Find("PC_Main_GameOVRCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(true);
                GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(true);
                //GameObject.FindGameObjectWithTag("UI_RoundClearPanel").SetActive(true);

            }
        }
        else if (Round == 2)
        {
            if (Enemy_Killed == 18)
            {
                Enemy_Killed = 0; GameStartBool = false;
                Score += (int)(Limit_Time * 100);
                Score += HealthPoint * 10;
                //GameObject.Find("Game_Manager").GetComponent<Game_Manager>().Score = Score;
                txt_Round_End_Score.text = Score.ToString();
                txt_OVR_Round_End_Score.text = Score.ToString();
                GameObject.Find("Game_Manager").transform.Find("PC_Main_GameOVRCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(true);
                GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(true);

                killEmAll = GameObject.FindGameObjectsWithTag("SiegeWeapon");
                for (int i = 0; i < killEmAll.Length; i++)
                {
                    //PhotonNetwork.Destroy(killEmAll[i].gameObject);
                    Destroy(killEmAll[i].gameObject);
                }
            }
        }
        else if (Round == 3)
        {
            if (Enemy_Killed == 28)
            {
                Enemy_Killed = 0; GameStartBool = false;
                Score += (int)(Limit_Time * 100);
                Score += HealthPoint * 10;
                //GameObject.Find("Game_Manager").GetComponent<Game_Manager>().Score = Score;
                txt_Round_End_Score.text = Score.ToString();
                txt_OVR_Round_End_Score.text = Score.ToString();
                GameObject.Find("Game_Manager").transform.Find("PC_Main_GameOVRCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(true);
                GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(true);

                killEmAll = GameObject.FindGameObjectsWithTag("SiegeWeapon");
                for (int i = 0; i < killEmAll.Length; i++)
                {
                    //PhotonNetwork.Destroy(killEmAll[i].gameObject);
                    Destroy(killEmAll[i].gameObject);
                }
            }
        }
        else if (Round == 4)
        {
            if (Enemy_Killed == 36)
            {
                Enemy_Killed = 0; GameStartBool = false;
                Score += (int)(Limit_Time * 100);
                Score += HealthPoint * 10;
                //GameObject.Find("Game_Manager").GetComponent<Game_Manager>().Score = Score;
                txt_Round_End_Score.text = Score.ToString();
                txt_OVR_Round_End_Score.text = Score.ToString();
                txt_OVR_Round_End_Score.text = Score.ToString();
                GameObject.Find("Game_Manager").transform.Find("PC_Main_GameOVRCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(true);
                GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(true);

                killEmAll = GameObject.FindGameObjectsWithTag("SiegeWeapon");
                for (int i = 0; i < killEmAll.Length; i++)
                {
                    //PhotonNetwork.Destroy(killEmAll[i].gameObject);
                    Destroy(killEmAll[i].gameObject);
                }
            }
        }
        else if (Round == 5)
        {
            if (Enemy_Killed == 48)
            {
                Enemy_Killed = 0; GameStartBool = false;
                Score += (int)(Limit_Time * 100);
                Score += HealthPoint * 10;
                //GameObject.Find("Game_Manager").GetComponent<Game_Manager>().Score = Score;
                txt_Game_End_Score.text = Score.ToString();
                //txt_OVR_Game_End_Score.text = Score.ToString();
                GameObject.Find("Game_Manager").transform.Find("PC_Main_GameOVRCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(true);
                GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("RoundClear_Panel").gameObject.SetActive(true);

                killEmAll = GameObject.FindGameObjectsWithTag("SiegeWeapon");
                for (int i = 0; i < killEmAll.Length; i++)
                {
                    //PhotonNetwork.Destroy(killEmAll[i].gameObject);
                    Destroy(killEmAll[i].gameObject);
                }
            }
        }

        if(Limit_Time < 0 || HealthPoint == 0)
        {
            GameOverBool = true; GameStartBool = false;
            txt_Game_Over_Score.text = Score.ToString();
            txt_OVR_Game_Over_Score.text = Score.ToString();
            GameObject.Find("Game_Manager").transform.Find("PC_Main_MainCanvas").transform.Find("GameOver_Panel").gameObject.SetActive(true);
            GameObject.Find("Game_Manager").transform.Find("PC_Main_GameOVRCanvas").transform.Find("GameOver_Panel").gameObject.SetActive(true);

            killEmAll = GameObject.FindGameObjectsWithTag("SiegeWeapon");
            for (int i = 0; i < killEmAll.Length; i++)
            {
                //PhotonNetwork.Destroy(killEmAll[i].gameObject);
                Destroy(killEmAll[i].gameObject);
            }
        }
    }

    void Remain_Enemy()
    {
        if (Round == 1)
        {
            Enemy_Remained = 10 - Enemy_Killed;
        }
        else if (Round == 2)
        {
            Enemy_Remained = 18 - Enemy_Killed;
        }
        else if (Round == 3)
        {
            Enemy_Remained = 28 - Enemy_Killed;
        }
        else if (Round == 4)
        {
            Enemy_Remained = 36 - Enemy_Killed;
        }
        else if (Round == 5)
        {
            Enemy_Remained = 48 - Enemy_Killed;
        }
    }

    public void TimeEnd()
    {
        if (!GameOverBool && GameStartBool) { 
        Limit_Time -= Time.deltaTime;
        txt_Time.text = Mathf.Round(Limit_Time).ToString();
        }
    }

    public void HealthBar()
    {
        HealthSldier.value = HealthPoint;
        txt_health.text = HealthPoint.ToString();
    }

    public void GameInfoUI()
    {
        txt_gameinfo_round.text = Round.ToString();
        txt_gameinfo_time.text = Mathf.Round(Limit_Time).ToString();
        txt_gameinfo_health.text = HealthPoint.ToString();
        txt_gameinfo_remainenemy.text = Enemy_Remained.ToString();
        txt_gameinfo_score.text = Score.ToString();
    }

    public void TimeCountBeforeStart()
    {
        txt_TCBS_time.text = Mathf.Round(Limit_Time - 60).ToString();
        if(Limit_Time < 60)
        {
            GameObject.Find("Game_Manager").transform.Find("PC_Main_GameOVRCanvas").transform.Find("TimeCount_Panel").gameObject.SetActive(false);
        }
    }
}
