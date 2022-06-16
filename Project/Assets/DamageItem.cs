using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageItem : MonoBehaviour
{
    float damageTime = 0f;
    bool GetDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetDamageItemTimer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DamageItem")
        {
            UI.score += 5;
            Destroy(other.gameObject);
            GetDamage = true;

            Attack.damage = 2;

            if (damageTime > 0)
            {
                damageTime += 2f;
            }
            else
            {
                damageTime = 2f;
            }
        }
    }

    public void SetDamageItemTimer()
    {
        if (GetDamage)
        {
            if (damageTime > 0)
            {
                //Debug.Log(damageTime);
                damageTime -= Time.deltaTime;
            }
            else
            {
                Attack.damage = 1;
                GetDamage = false;
            }
        }
    }
}
