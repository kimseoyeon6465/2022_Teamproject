using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindItem : MonoBehaviour
{
    float blindTime = 0f;
    bool GetBlind = false;

    public GameObject BlindImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetBlindItemTimer();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlindItem")
        {
            UI.score += 5;
            Destroy(other.gameObject);
            GetBlind = true;

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

    public void SetBlindItemTimer()
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
            }
        }
    }
}
