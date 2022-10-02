using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Creat : MonoBehaviour
{ 
    // Start is called before the first frame update
    public GameObject Enemy_FootSoldier;
    public GameObject Enemy_FootSolider_target;
    public GameObject Enemy_SiegeSoldier;
    public GameObject Enemy_SiegeSoldier_target;
    public GameObject SiegeWeapon_1;
    public GameObject SiegeWeapon_2;
    public GameObject SiegeWeapon_3;
    Vector3 Position;
    Vector3 Second_Position;

    Vector3 SiegeWeapon_Position_1;
    Vector3 SiegeWeapon_Position_2;
    Vector3 SiegeWeapon_Position_3;
    public int Round = 0;
    
    public float SiegeSoldier_Speed = 1f;
    public float FootSoldier_Speed = 1f;

    public float SiegeSoldier_AD;
    public float FootSoldier_AD;
    
    void Start()
    {
        Position = GameObject.FindGameObjectWithTag("Game_Manger").transform.position;
        Second_Position = GameObject.Find("Second_Respawn_Place").transform.position;
        SiegeWeapon_Position_1 = GameObject.Find("SiegeWeapon_Position_1").transform.position;
        SiegeWeapon_Position_2 = GameObject.Find("SiegeWeapon_Position_2").transform.position;
        SiegeWeapon_Position_3  = GameObject.Find("SiegeWeapon_Position_3").transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enemy_Create_Start()
    {
        StartCoroutine(Enemy_Create());
    }
    public IEnumerator Enemy_Create()
    {
            if (Round == 1) // 10 다 나오는데 2마리에 5초 -> 5 * 5 = 25
            {
                FootSoldier_Speed = 2f;
                for (int i = 0; i < Round * 10; i++)
                {
                    Enemy_FootSolider_target = Instantiate( Enemy_FootSoldier, Position, Quaternion.identity);
                    
                    //Enemy_FootSolider_target = (GameObject)Instantiate(Enemy_FootSoldier, new Vector3(190,-24,-37), Quaternion.identity);
                    if(i % 2 == 0){ yield return new WaitForSeconds(5f); }
                }
            }
            else if (Round == 2) // 12 + 6 = 18 다 나오는데 3마리에 4초 -> 4 * 6 =  24
            {
                FootSoldier_Speed = 2f;
                SiegeSoldier_Speed = 1.5f;
                GameObject SiegeWeapon_1_target = Instantiate(SiegeWeapon_1, SiegeWeapon_Position_1, Quaternion.Euler(0, -90, 0));
                //PhotonNetwork.Instantiate(SiegeWeapon_1.name, SiegeWeapon_Position_1, Quaternion.Euler(0, -90, 0));
            for (int i = 0; i < Round * 6; i++)
                {
                    if(i % 2 == 0)
                    {
                        Enemy_FootSolider_target = Instantiate(Enemy_FootSoldier, Position, Quaternion.identity);
                        //PhotonNetwork.Instantiate(Enemy_FootSoldier.name, Position, Quaternion.identity);
                    }
                    else
                    {
                        Enemy_FootSolider_target = Instantiate(Enemy_FootSoldier, Second_Position, Quaternion.identity);
                        //PhotonNetwork.Instantiate(Enemy_FootSoldier.name, Second_Position, Quaternion.identity);
                    }
                    if (i % 2 == 0)
                    {
                        Enemy_SiegeSoldier_target = Instantiate(Enemy_SiegeSoldier, Position, Quaternion.identity);
                        //PhotonNetwork.Instantiate(Enemy_SiegeSoldier.name, Position, Quaternion.identity);
                    }
                    if (i % 2 == 0) { yield return new WaitForSeconds(4f); }

                }
            }
            else if (Round == 3) //18 + 9 + 1 = 28 다 나오는데 3마리에 3초 -> 3 * 9 =  27초
            {
                FootSoldier_Speed = 2.5f;
                SiegeSoldier_Speed = 1.5f;
                GameObject SiegeWeapon_1_target = Instantiate(SiegeWeapon_1, SiegeWeapon_Position_1, Quaternion.Euler(0, -90, 0));
                GameObject SiegeWeapon_2_target = Instantiate(SiegeWeapon_2, SiegeWeapon_Position_2, Quaternion.Euler(0, -135, 0));
                //PhotonNetwork.Instantiate(SiegeWeapon_1.name, SiegeWeapon_Position_1, Quaternion.Euler(0, -90, 0));
                //PhotonNetwork.Instantiate(SiegeWeapon_2.name, SiegeWeapon_Position_2, Quaternion.Euler(0, -135, 0));
                for (int i = 0; i < Round * 6; i++)
                {
                    if (i % 2 == 0)
                    {
                        Enemy_FootSolider_target = Instantiate(Enemy_FootSoldier, Position, Quaternion.identity);
                        //PhotonNetwork.Instantiate(Enemy_FootSoldier.name, Position, Quaternion.identity);
                    }
                    else
                    {
                        Enemy_FootSolider_target = Instantiate(Enemy_FootSoldier, Second_Position, Quaternion.identity);
                        //PhotonNetwork.Instantiate(Enemy_FootSoldier.name, Second_Position, Quaternion.identity);
                    }
                    if (i % 2 == 0)
                    {
                        Enemy_SiegeSoldier_target = Instantiate(Enemy_SiegeSoldier, Position, Quaternion.identity);
                        //PhotonNetwork.Instantiate(Enemy_SiegeSoldier.name, Position, Quaternion.identity);
                    }
                    if(i == 10)
                    {
                        Enemy_SiegeSoldier_target = Instantiate(Enemy_SiegeSoldier, Position, Quaternion.identity);
                    }
                    if (i % 2 == 0) { yield return new WaitForSeconds(3f); }

                }
            }
            else if (Round == 4) // 24 + 12  = 36  다 나오는데 3마리에 2초 -> 2 * 12 =  24초
            {
                GameObject SiegeWeapon_1_target = Instantiate(SiegeWeapon_1, SiegeWeapon_Position_1, Quaternion.Euler(0, -90, 0));
                GameObject SiegeWeapon_2_target = Instantiate(SiegeWeapon_2, SiegeWeapon_Position_2, Quaternion.Euler(0, -135, 0));
                //PhotonNetwork.Instantiate(SiegeWeapon_1.name, SiegeWeapon_Position_1, Quaternion.Euler(0, -90, 0));
                //PhotonNetwork.Instantiate(SiegeWeapon_2.name, SiegeWeapon_Position_2, Quaternion.Euler(0, -135, 0));
                FootSoldier_Speed = 3f;
                SiegeSoldier_Speed = 2.5f;
                for (int i = 0; i < Round * 6; i++)
                {
                    if (i % 2 == 0)
                    {
                        Enemy_FootSolider_target = Instantiate(Enemy_FootSoldier, Position, Quaternion.identity);

                        //PhotonNetwork.Instantiate(Enemy_FootSoldier.name, Position, Quaternion.identity);
                    }
                    else
                    {
                        Enemy_FootSolider_target = Instantiate(Enemy_FootSoldier, Second_Position, Quaternion.identity);
                        //PhotonNetwork.Instantiate(Enemy_FootSoldier.name, Second_Position, Quaternion.identity);
                    }
                    if (i % 2 == 0)
                    {
                        Enemy_SiegeSoldier_target = Instantiate(Enemy_SiegeSoldier, Position, Quaternion.identity);
                        //PhotonNetwork.Instantiate(Enemy_SiegeSoldier.name, Position, Quaternion.identity);
                    }
                    if (i % 2 == 0) { yield return new WaitForSeconds(2f); }

                }
            }
            else if (Round == 5)  // 30 + 15 + 3 = 48 다 나오는데 3마리에 1초 -> 1 * 15 =  15초
            {
                GameObject SiegeWeapon_1_target = Instantiate(SiegeWeapon_1, SiegeWeapon_Position_1, Quaternion.Euler(0, -90, 0));
                GameObject SiegeWeapon_2_target = Instantiate(SiegeWeapon_2, SiegeWeapon_Position_2, Quaternion.Euler(0, -135, 0));
                GameObject SiegeWeapon_3_target = Instantiate(SiegeWeapon_3, SiegeWeapon_Position_3, Quaternion.Euler(0, -75, 0));
                //PhotonNetwork.Instantiate(SiegeWeapon_1.name, SiegeWeapon_Position_1, Quaternion.Euler(0, -90, 0));
                //PhotonNetwork.Instantiate(SiegeWeapon_2.name, SiegeWeapon_Position_2, Quaternion.Euler(0, -135, 0));
                //PhotonNetwork.Instantiate(SiegeWeapon_3.name, SiegeWeapon_Position_3, Quaternion.Euler(0, -75, 0)); //-75
            FootSoldier_Speed = 4f;
                SiegeSoldier_Speed = 3f;
                for (int i = 0; i < Round * 6; i++)
                {
                    if (i % 2 == 0)
                    {
                        Enemy_FootSolider_target = Instantiate(Enemy_FootSoldier, Position, Quaternion.identity);
                        //PhotonNetwork.Instantiate(Enemy_FootSoldier.name, Position, Quaternion.identity);
                    }
                    else
                    {
                        Enemy_FootSolider_target = Instantiate(Enemy_FootSoldier, Second_Position, Quaternion.identity);
                        //PhotonNetwork.Instantiate(Enemy_FootSoldier.name, Second_Position, Quaternion.identity);
                    }
                    if (i % 2 == 0)
                    {
                        Enemy_SiegeSoldier_target = Instantiate(Enemy_SiegeSoldier, Position, Quaternion.identity);
                        //PhotonNetwork.Instantiate(Enemy_SiegeSoldier.name, Position, Quaternion.identity);
                    }
                    if(i == 10)
                    {
                        Enemy_SiegeSoldier_target = Instantiate(Enemy_SiegeSoldier, Position, Quaternion.identity);
                    }
                    if (i % 2 == 0) { yield return new WaitForSeconds(1f); }
                
                }
            }
    }
    

}
