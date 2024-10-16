using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Player_pos : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -3)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                gameObject.transform.position = GameObject.Find("Player_1_Position").transform.position;
            }
            else
            {
                gameObject.transform.position = GameObject.Find("Player_2_Position").transform.position;
            }
        }
    }
}
