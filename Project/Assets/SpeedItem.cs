using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedItem : MonoBehaviour
{
    float speedTime = 0f;
    bool GetSpeed = false;
    public RawImage itemImage;
    public Texture speedImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeedItemTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedItem")
        {
            UI.score += 5;
            Destroy(other.gameObject);
            GetSpeed = true;
            itemImage.texture = speedImage;

            UIImage(100);

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
    }

    public void SetSpeedItemTimer()
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

                itemImage.texture = null;
                UIImage(0);
            }
        }
    }

    void UIImage(int colorA)
    {
        Color color = itemImage.color;
        color.a = colorA;
        itemImage.color = color;
    }
}
