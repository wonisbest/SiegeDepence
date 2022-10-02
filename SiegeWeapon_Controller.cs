using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiegeWeapon_Controller : MonoBehaviour
{
    public int Working_Enemy_Number = 0;
    public bool Working_Weapon = false;
    public bool SiegeWeapon_Delay = true;
    public bool[] SiegeWeopon_Working_Arr = new bool[5] { false, false, false, false, false };
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (SiegeWeopon_Working_Arr[0] && SiegeWeopon_Working_Arr[1] && 
            SiegeWeopon_Working_Arr[2] && SiegeWeopon_Working_Arr[3] && SiegeWeopon_Working_Arr[4])
        {
            Working_Weapon = true;
        }
        else
        {
            Working_Weapon = false;
        }
        if (Working_Weapon) {            
            Attack_Castle();
        }
    }

    public void Attack_Castle()
    {
        if (SiegeWeapon_Delay)
        {
            StartCoroutine(SiegeAttack_Delay());
        }
    }
    IEnumerator SiegeAttack_Delay()
    {
        animator.SetTrigger("Siege_Attack");
        SiegeWeapon_Delay = false;
        yield return new WaitForSeconds(2f);
        GameObject.Find("Game_Manager").GetComponent<Score_Manger>().HealthPoint -= 8;
        yield return new WaitForSeconds(10f);
        SiegeWeapon_Delay = true;
    }
}
