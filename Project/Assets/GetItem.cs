using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    float speedTime = 0f;
    bool GetSpeed = false;

    float damageTime = 0f;
    bool GetDamage = false;

    float blindTime = 0f;
    bool GetBlind = false;

    public GameObject BlindImage;
    public RawImage[] itemImage;
    public Texture speedImage;
    public Texture damageImage;
    public Texture blindImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeedItemTimer();
        SetDamageItemTimer();
        SetBlindItemTimer();

        Debug.Log(speedTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedItem")
        {
            Destroy(other.transform.parent.parent.gameObject);
            GetSpeed = true;
            //itemImage.texture = speedImage;

            SetUIimage(0,speedImage);
            //UIImage(100);

            CharacterController.speed = 14f;

            if (speedTime > 0)
            {
                speedTime += 3f;
            }
            else
            {
                speedTime = 3f;
            }
        }

        if (other.tag == "DamageItem")
        {
            Destroy(other.transform.parent.parent.gameObject);
            GetDamage = true;
            
            SetUIimage(1, damageImage);

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

        if (other.tag == "BlindItem")
        {
            Destroy(other.transform.parent.parent.gameObject);
            GetBlind = true;

            SetUIimage(2, blindImage);

            BlindImage.SetActive(true);

            if (blindTime > 0)
            {
                blindTime += 5f;
            }
            else
            {
                blindTime = 5f;
            }
        }
    }

    
    private void SetSpeedItemTimer()
    {
        if (GetSpeed)
        {
            if (speedTime > 0)
            {
                //Debug.Log(speedTime);
                speedTime -= Time.deltaTime;
            }
            else
            {
                CharacterController.speed = 7f;
                GetSpeed = false;
                speedTime = 0;
                ClearUIimage(0);
            }
        }
    }
    private void SetDamageItemTimer()
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
                speedTime = 0;
                ClearUIimage(1);
            }
        }
    }
    private void SetBlindItemTimer()
    {
        if (GetBlind)
        {
            if (blindTime > 0)
            {
                blindTime -= Time.deltaTime;
            }
            else
            {
                BlindImage.SetActive(false);
                GetBlind = false;
                speedTime = 0;
                ClearUIimage(2);
            }
        }
    }

    void SetUIimage(int i,Texture Image)
    {
        itemImage[i].texture = Image;
        UIImage(i, 100);
    }

    void ClearUIimage(int i)
    {
        itemImage[i].texture = null;
        UIImage(i, 0);
    }

    void UIImage(int i,int colorA)
    {
        Color color = itemImage[i].color;
        color.a = colorA;
        itemImage[i].color = color;
    }

}
