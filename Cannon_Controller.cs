using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Controller : MonoBehaviour
{
    public bool Load_Bullet = false;
    public bool Load_Fire = false;
    public bool Cannon_Triggering = false;
    public AudioSource audioSource;
    public AudioClip audioClip;
    //private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        //photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Load_Bullet && Load_Fire)
        {
            Cannon_Attack();
        }
        if (Load_Bullet)
        {
            GameObject.Find("Cannon_Barrel").transform.Find("Load_Bullet_Particle").gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("Cannon_Barrel").transform.Find("Load_Bullet_Particle").gameObject.SetActive(false);
        }

        if (Cannon_Triggering)
        {
            Cannon_Rotaion();
        }
    }
    
    public void Cannon_Attack()
    {
        audioSource.PlayOneShot(audioClip);
        Cannon_Fire_Active();
        StartCoroutine(WaitSeconds());
    }
    public void Cannon_Fire_Active()
    {
        GameObject.Find("Cannon_Barrel").transform.Find("Cannon_Fire_Particle").gameObject.SetActive(true);
    }
    public void Cannon_Fire_ActiveFalse()
    {
        GameObject.Find("Cannon_Barrel").transform.Find("Cannon_Fire_Particle").gameObject.SetActive(false);
        Load_Bullet = false;
        Load_Fire = false;
    }

    public void Cannon_Reload_Bulluet()
    {
        Load_Bullet = true;
    }

    public void Cannon_Reload_Fire()
    {
        Load_Fire = true;
    }

    public void Cannon_Rotaion()
    {
        if (!Load_Fire)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)
                && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)
                && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)
                && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                Debug.Log("트리거 4개 눌러짐.");
                if (OVRInput.GetDown(OVRInput.Touch.PrimaryThumbstick) && (-10 < GameObject.Find("Cannon_Barrel").transform.rotation.x && GameObject.Find("Cannon_Barrel").transform.rotation.x < 35)
                    && (60 < GameObject.Find("Cannon").transform.rotation.y && GameObject.Find("Cannon").transform.rotation.y < 120))
                {
                    Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
                    Debug.Log("스틱 움직임 확인");
                    if (thumbstick.x < 0) //조이스틱 왼쪽
                    {
                        GameObject.Find("Cannon").transform.eulerAngles.Set(GameObject.Find("Cannon").transform.eulerAngles.x , GameObject.Find("Cannon").transform.eulerAngles.y + thumbstick.x, GameObject.Find("Cannon").transform.eulerAngles.z);
                    }
                    if (thumbstick.x > 0) //조이스틱 오른쪽
                    {
                        GameObject.Find("Cannon").transform.eulerAngles.Set(GameObject.Find("Cannon").transform.eulerAngles.x, GameObject.Find("Cannon").transform.eulerAngles.y + thumbstick.x, GameObject.Find("Cannon").transform.eulerAngles.z);
                    }
                    if (thumbstick.y < 0) //조이스틱 아래쪽
                    {
                        GameObject.Find("Cannon_Barrel").transform.eulerAngles.Set(GameObject.Find("Cannon_Barrel").transform.eulerAngles.x + thumbstick.y, GameObject.Find("Cannon_Barrel").transform.eulerAngles.y, GameObject.Find("Cannon_Barrel").transform.eulerAngles.z);
                    }
                    if (thumbstick.y > 0) //조이스틱 위쪽
                    {
                        GameObject.Find("Cannon_Barrel").transform.eulerAngles.Set(GameObject.Find("Cannon_Barrel").transform.eulerAngles.x + thumbstick.y, GameObject.Find("Cannon_Barrel").transform.eulerAngles.y, GameObject.Find("Cannon_Barrel").transform.eulerAngles.z);
                    }

                }
                else if (OVRInput.GetDown(OVRInput.Touch.SecondaryThumbstick) && (-10 < GameObject.Find("Cannon_Barrel").transform.rotation.x && GameObject.Find("Cannon_Barrel").transform.rotation.x < 35)
                    && (60 < GameObject.Find("Cannon").transform.rotation.y && GameObject.Find("Cannon").transform.rotation.y < 120))
                {
                    Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

                    if (thumbstick.x < 0) //조이스틱 왼쪽
                    {
                        GameObject.Find("Cannon").transform.eulerAngles.Set(GameObject.Find("Cannon").transform.eulerAngles.x, GameObject.Find("Cannon").transform.eulerAngles.y + thumbstick.x, GameObject.Find("Cannon").transform.eulerAngles.z);
                    }
                    if (thumbstick.x > 0) //조이스틱 오른쪽
                    {
                        GameObject.Find("Cannon").transform.eulerAngles.Set(GameObject.Find("Cannon").transform.eulerAngles.x, GameObject.Find("Cannon").transform.eulerAngles.y + thumbstick.x, GameObject.Find("Cannon").transform.eulerAngles.z);
                    }
                    if (thumbstick.y < 0) //조이스틱 아래쪽
                    {
                        GameObject.Find("Cannon_Barrel").transform.eulerAngles.Set(GameObject.Find("Cannon_Barrel").transform.eulerAngles.x + thumbstick.y, GameObject.Find("Cannon_Barrel").transform.eulerAngles.y, GameObject.Find("Cannon_Barrel").transform.eulerAngles.z);
                    }
                    if (thumbstick.y > 0) //조이스틱 위쪽
                    {
                        GameObject.Find("Cannon_Barrel").transform.eulerAngles.Set(GameObject.Find("Cannon_Barrel").transform.eulerAngles.x + thumbstick.y, GameObject.Find("Cannon_Barrel").transform.eulerAngles.y, GameObject.Find("Cannon_Barrel").transform.eulerAngles.z);
                    }
                }


            }
        }
    }
    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(3.75f);
        Cannon_Fire_ActiveFalse();
    }



    private void OnTriggerStay(Collider other)
    {
        Cannon_Triggering = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        Cannon_Triggering = true;

    }
    private void OnTriggerExit(Collider other)
    {
        Cannon_Triggering = false;
    }
}
