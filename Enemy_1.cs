using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : MonoBehaviour
{
    NavMeshAgent agent;
    private bool naving = true;
    GameObject NavTar;
    public bool attack = false;
    public bool Enemy_Death_Bool = false;
    public bool Working_SiegeWeapon = false;
    public bool Enemy_Working = false;
    public bool Cannon_Death = false;
    public int ScorePlus = 0;
    public AudioSource audioSource;
    public AudioClip audioClip;


    [SerializeField]
    Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            agent.speed = GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().FootSoldier_Speed;
        }
        if (gameObject.CompareTag("Enemy_Siege")) { 
        agent.speed = GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().SiegeSoldier_Speed;
        }
    }
    void Update()
    {
        if (naving)
        {
            
            agent.SetDestination(target.position);
            
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }


        if (attack)
        { 
            Attack();  
        }
        if (Enemy_Death_Bool)
        {
            StartCoroutine(WaitSecondsDeath());
            if(ScorePlus < 3) ScorePlus += 1;
            if (ScorePlus == 1) {
                audioSource.PlayOneShot(audioClip);
                GameObject.Find("Game_Manager").GetComponent<Score_Manger>().Score += 100;
                GameObject.Find("Game_Manager").GetComponent<Score_Manger>().Enemy_Killed += 1;
                
               
                if (gameObject.CompareTag("Enemy_Siege"))
                {
                    if (gameObject.GetComponent<Enemy_1>().NavTar == GameObject.Find("FirstPosition"))
                    {
                        GameObject.FindGameObjectWithTag("SiegeWeapon").GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[0] = false;
                    }
                    else if (gameObject.GetComponent<Enemy_1>().NavTar == GameObject.Find("SecondPosition"))
                    {
                        GameObject.FindGameObjectWithTag("SiegeWeapon").GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[1] = false;
                    }
                    else if (gameObject.GetComponent<Enemy_1>().NavTar == GameObject.Find("ThirdePosition"))
                    {
                        GameObject.FindGameObjectWithTag("SiegeWeapon").GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[2] = false;
                    }
                    else if (gameObject.GetComponent<Enemy_1>().NavTar == GameObject.Find("FourthPosition"))
                    {
                        GameObject.FindGameObjectWithTag("SiegeWeapon").GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[3] = false;
                    }
                    else if (gameObject.GetComponent<Enemy_1>().NavTar == GameObject.Find("FifthPosition"))
                    {
                        GameObject.FindGameObjectWithTag("SiegeWeapon").GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[4] = false;
                    }
                }
                
            }
        }
        if (gameObject.CompareTag("Enemy_Siege")){
            if (gameObject.GetComponent<Enemy_1>().NavTar == GameObject.Find("FirstPosition") ||
                gameObject.GetComponent<Enemy_1>().NavTar == GameObject.Find("SecondPosition") ||
                gameObject.GetComponent<Enemy_1>().NavTar == GameObject.Find("ThirdPosition") ||
                gameObject.GetComponent<Enemy_1>().NavTar == GameObject.Find("FourthPosition") ||
                gameObject.GetComponent<Enemy_1>().NavTar == GameObject.Find("FifthPosition"))
            { }
            else
            {
                if (GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round == 1)
                { } 
                else if (GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round == 2)
                { 
                    if (GameObject.Find("Siege_Weapon_1(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon)
                    {
                        NavTar = GameObject.FindGameObjectWithTag("NavTarget_1");
                        target = NavTar.transform;
                    }
                }
                else if (GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round == 3 || GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round == 4)
                {
                    if (GameObject.Find("Siege_Weapon_1(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon &&
                        GameObject.Find("Siege_Weapon_2(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon  )
                    {
                        NavTar = GameObject.FindGameObjectWithTag("NavTarget_1");
                        target = NavTar.transform;
                    }
                }
                else if (GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round == 5)
                {
                    if (GameObject.Find("Siege_Weapon_1(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon &&
                        GameObject.Find("Siege_Weapon_2(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon &&
                        GameObject.Find("Siege_Weapon_3(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon)
                    {
                        NavTar = GameObject.FindGameObjectWithTag("NavTarget_1");
                        target = NavTar.transform;
                    }
                }
            }
        }
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Second_Respawn_Place"))
        {
            NavTar = GameObject.FindGameObjectWithTag("Second_NavTarget_1");
            target = NavTar.transform;
            Debug.Log("Second_Respawn");
        }
        if (other.CompareTag("NavTarget_1"))
        {
            NavTar = GameObject.FindGameObjectWithTag("NavTarget_2");
            if (gameObject.CompareTag("Enemy_Siege"))
            {
                if (GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round == 5)
                {
                    NavTar = GameObject.Find("SiegeWeapon_Position_3");
                    if (GameObject.Find("Siege_Weapon_3(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon)
                    {
                        NavTar = GameObject.Find("SiegeWeapon_Position_1");
                        if (GameObject.Find("Siege_Weapon_1(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon)
                        {
                            NavTar = GameObject.Find("SiegeWeapon_Position_2");
                        }
                    }
                }
                else
                {
                    NavTar = GameObject.Find("SiegeWeapon_Position_1");
                    if (GameObject.Find("Siege_Weapon_1(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon)
                    {
                        NavTar = GameObject.Find("SiegeWeapon_Position_2");
                    }
                }
            }
            target = NavTar.transform;
        }
        else if (other.CompareTag("NavTarget_2"))
        {
            NavTar = GameObject.FindGameObjectWithTag("NavTarget_3");
            if (gameObject.CompareTag("Enemy_Siege"))
            {
                if(GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round == 5)
                {
                    NavTar = GameObject.Find("SiegeWeapon_Position_3");
                    if (GameObject.Find("Siege_Weapon_3(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon)
                    {
                        NavTar = GameObject.Find("SiegeWeapon_Position_1");
                        if (GameObject.Find("Siege_Weapon_1(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon)
                        {
                            NavTar = GameObject.Find("SiegeWeapon_Position_2");
                        }
                    }
                }
                else
                {
                    NavTar = GameObject.Find("SiegeWeapon_Position_1");
                    if (GameObject.Find("Siege_Weapon_1(Clone)").GetComponent<SiegeWeapon_Controller>().Working_Weapon)
                    {
                        NavTar = GameObject.Find("SiegeWeapon_Position_2");
                    }
                }
            }
            target = NavTar.transform;
            
        }
        else if (other.CompareTag("NavTarget_3"))
        {
            NavTar = GameObject.FindGameObjectWithTag("NavTarget_4");
            target = NavTar.transform;
            
        }
        else if (other.CompareTag("NavTarget_4"))
        {
            
            Debug.Log("NavTarget_4_Arrive");
            agent.GetComponent<Animator>().SetBool("Arrive", true);
            agent.GetComponent<Animator>().SetBool("Attack", true);
            attack = true;
            naving = false;
            //agent.Stop();
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }

        if (other.CompareTag("Second_NavTarget_1"))
        {
            NavTar = GameObject.FindGameObjectWithTag("Second_NavTarget_2");
            target = NavTar.transform;
            
        }
        else if (other.CompareTag("Second_NavTarget_2"))
        {
            NavTar = GameObject.FindGameObjectWithTag("NavTarget_3");
            if (gameObject.CompareTag("Enemy_Siege"))
            {
                NavTar = GameObject.Find("SiegeWeapon_Position_1");
            }
            target = NavTar.transform;
            Debug.Log("Second_NavTarget_2_Arrive");
            
        }

        if (other.CompareTag("SiegeWeapon") && gameObject.CompareTag("Enemy_Siege"))
        {
            if (other.GetComponent<SiegeWeapon_Controller>().Working_Weapon)
            {
                NavTar = GameObject.Find("SiegeWeapon_Position_2");
                if(GameObject.Find("Game_Manager").GetComponent<Enemy_Creat>().Round == 5)
                {
                    NavTar = GameObject.Find("SiegeWeapon_Position_1");
                }
            }
            Debug.Log("SiegeWeapon_Arrive");
            if (!other.GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[0])
            {
                other.GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[0] = true;
                Working_SiegeWeapon = true;
                NavTar = other.transform.Find("Arr_Tranform").transform.Find("FirstPosition").gameObject;
                target = NavTar.transform;
                GetComponent<Animator>().Play("Crouch Idle");
            }
            else if (!other.GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[1])
            {
                other.GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[1] = true;
                Working_SiegeWeapon = true;
                NavTar = other.transform.Find("Arr_Tranform").transform.Find("SecondPosition").gameObject;
                target = NavTar.transform;
                GetComponent<Animator>().Play("Crouch Idle");
            }
            else if (!other.GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[2])
            {
                other.GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[2] = true;
                Working_SiegeWeapon = true;
                NavTar = other.transform.Find("Arr_Tranform").transform.Find("ThirdPosition").gameObject;
                target = NavTar.transform;
                GetComponent<Animator>().Play("Crouch Idle");
            }
            else if (!other.GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[3])
            {
                other.GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[3] = true;
                Working_SiegeWeapon = true;
                NavTar = other.transform.Find("Arr_Tranform").transform.Find("FourthPosition").gameObject;
                target = NavTar.transform;
                GetComponent<Animator>().Play("Crouch Idle");
            }
            else if (!other.GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[4])
            {
                other.GetComponent<SiegeWeapon_Controller>().SiegeWeopon_Working_Arr[4] = true;
                Working_SiegeWeapon = true;
                NavTar = other.transform.Find("Arr_Tranform").transform.Find("FifthPosition").gameObject;
                target = NavTar.transform;
                GetComponent<Animator>().Play("Crouch Idle");
            }
        }
    }

    public void Attack()
    {
        StartCoroutine(WaitSecondsAttack());
    }
    IEnumerator WaitSecondsAttack()
    {
        agent.GetComponent<Animator>().SetBool("Attack", true);
        attack = false;
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().HealthPoint -= 1;
        Debug.Log("체력 -1");
        yield return new WaitForSeconds(5f);
        agent.GetComponent<Animator>().SetBool("Attack", false);
        attack = true;
    }
    IEnumerator WaitSecondsDeath()
    {
        GetComponent<Animator>().Play("Dying");
        yield return new WaitForSeconds(3.75f);
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Gun_Bullet")
        {
            Debug.Log("총알에 트리거");
            naving = false;
            Enemy_Death_Bool = true;
            Destroy(other);
        }
    }
    
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("파티클 충돌");
        naving = false;
        Enemy_Death_Bool = true;
    }



    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌엔터");
        if (collision.Equals(GameObject.FindGameObjectsWithTag("Gun_Bullet")))
        {
            Debug.Log("충돌");
            naving = false;
            //GetComponent<Animator>().Play("Dying");
            Enemy_Death_Bool = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("충돌엑싵");
        if (collision.Equals(GameObject.FindGameObjectsWithTag("Gun_Bullet")))
        {
            Debug.Log("충돌");
            naving = false;
            //GetComponent<Animator>().Play("Dying");
            Enemy_Death_Bool = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("충돌스테이");
        if (collision.Equals(GameObject.FindGameObjectsWithTag("Gun_Bullet")))
        {
            Debug.Log("충돌");
            naving = false;
            GetComponent<Animator>().Play("Dying");
            Enemy_Death_Bool = true;
        }
    }*/
}
