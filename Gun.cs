using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Gun : MonoBehaviourPun
{

    // Start is called before the first frame update
    public bool Gun_Bool = false;
    public bool RightHand_Bool;
    public bool LefttHand_Bool;
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (Gun_Bool && LefttHand_Bool) { 
                Gun_Fire();
                //StartCoroutine(WaitSeconds());
            }
        }
        else if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (Gun_Bool && RightHand_Bool)
            {
                Gun_Fire();
                //StartCoroutine(WaitSeconds());
            }
        }
        
        if (gameObject.CompareTag("Gun_1")) { 
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("P");
                gameObject.transform.position = new Vector3((float)123.288, (float)-1.53, (float)-20.33264);
                
            }
        }
    }
    public void Gun_Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        audioSource.PlayOneShot(audioClip);
        //StartCoroutine(WaitSeconds());
        Destroy(spawnedBullet, 2);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.Equals(GameObject.FindGameObjectWithTag("Right_Hand")))
        {
            RightHand_Bool = true;
            Gun_Bool = true;
        }
        else if (collision.Equals(GameObject.FindGameObjectWithTag("Left_Hand")))
        {
            LefttHand_Bool = true;
            Gun_Bool = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.Equals(GameObject.FindGameObjectWithTag("Right_Hand")))
        {
            RightHand_Bool = false;
            Gun_Bool = false;
        }
        else if(collision.Equals(GameObject.FindGameObjectWithTag("Left_Hand")))
        {
            LefttHand_Bool = false;
            Gun_Bool = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Right_Hand") )
        {
            RightHand_Bool = true;
            Gun_Bool = true;
        }
        else if (other.CompareTag("Left_Hand"))
        {
            LefttHand_Bool = true;
            Gun_Bool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Right_Hand"))
        {
            RightHand_Bool = false;
            Gun_Bool = false;
        }
        else if (other.CompareTag("Left_Hand"))
        {
            LefttHand_Bool = false;
            Gun_Bool = false;
        }
    }

    public IEnumerator WaitSeconds()
    {
        Gun_Bool = false;
        yield return new WaitForSeconds(0.5f);
    }
}
