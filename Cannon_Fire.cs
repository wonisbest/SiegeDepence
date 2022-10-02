using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Fire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("I");
            gameObject.transform.position = new Vector3((float)123.365, (float)-1.52471, (float)-21.704);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cannon") {
            other.GetComponent<Cannon_Controller>().Cannon_Reload_Fire();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cannon")
        {
            other.GetComponent<Cannon_Controller>().Load_Fire = true;
            //GameObject.Find("Game_Manager").GetComponent<Game_Manager>().Load_Fire = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cannon")
        {
            //collision.gameObject.GetComponent<Cannon_Controller>().Load_Fire = true;
            GameObject.Find("Game_Manager").GetComponent<Game_Manager>().Load_Fire = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Cannon")
        { 
            //collision.gameObject.GetComponent<Cannon_Controller>().Load_Fire = true;
            GameObject.Find("Game_Manager").GetComponent<Game_Manager>().Load_Fire = true;
        }
    }
}
