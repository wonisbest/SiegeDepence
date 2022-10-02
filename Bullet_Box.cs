using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet_Box : MonoBehaviourPun
{
    public GameObject Cannon_Bullet;
    public GameObject Cannon_Bullet_target;
    Vector3 hand_position;

    public bool Triggering = false;
    public bool Grabbed_Bullet_bool = false;
    public bool isBullet = false;
    public bool Hand; // Left = true , Right = false
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Grabbed_Bullet();

        
    }

    public void Grabbed_Bullet() { 
        // triggering�� ���¿��� grab�ϸ� �տ� Bullet_prefab ����
        if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) || 
            OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            if (Triggering && !Grabbed_Bullet_bool)
            {
                Triggering = false;
                if(Hand)
                {
                    hand_position = new Vector3(GameObject.FindGameObjectWithTag("Left_Hand").transform.position.x , GameObject.FindGameObjectWithTag("Left_Hand").transform.position.y, GameObject.FindGameObjectWithTag("Left_Hand").transform.position.z);
                }
                else
                {
                    hand_position = new Vector3(GameObject.FindGameObjectWithTag("Right_Hand").transform.position.x, GameObject.FindGameObjectWithTag("Right_Hand").transform.position.y, GameObject.FindGameObjectWithTag("Right_Hand").transform.position.z);
                }
                if (!isBullet) {
                    //����
                    Cannon_Bullet_target = Instantiate(Cannon_Bullet, hand_position, Quaternion.identity);
                    GameObject.Find("Game_Manager").GetComponent<Game_Manager>().isBullet = true; //���� �ҷ� ����
                    isBullet = true;
                    Debug.Log("������ ����, isBullet True");
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag.ToString());
        if (other.tag == "Left_Hand")
        {
            Triggering = true;
            Debug.Log("Ʈ���� ���� �޼�, Hand True, Triggering true");
            Hand = true;
        }
        else if (other.tag == "Right_Hand")
        {
            Triggering = true;
            Debug.Log("Ʈ���� ���� ������, Hand False, Triggering true");
            Hand = false;
        }


    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag.ToString());
        if (other.tag == "Left_Hand")
        {
            Triggering = true;
            Debug.Log("Ʈ���� �� �޼�, Hand True, Triggering true");
            Hand = true;
        }
        else if (other.tag == "Right_Hand")
        {
            Triggering = true;
            Debug.Log("Ʈ���� �� ������, Hand False, Triggering true");
            Hand = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag.ToString());
        Triggering = false;
        if (other.tag == "Left_Hand")
        {
            Triggering = false;
            Debug.Log("Ʈ���� ���� �޼�, Hand True, Triggering true");
            Hand = true;
        }
        else if (other.tag == "Right_Hand")
        {
            Triggering = false;
            Debug.Log("Ʈ���� ���� ������, Hand False, Triggering true");
            Hand = false;
        }
    }

}
