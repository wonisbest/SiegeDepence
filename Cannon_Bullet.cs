using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Cannon_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cannon") {
            other.GetComponent<Cannon_Controller>().Cannon_Reload_Bulluet();
            Destroy(gameObject);
            GameObject.Find("Bullet_Box").GetComponent<Bullet_Box>().isBullet = false;
        }
    }
    
    
}
