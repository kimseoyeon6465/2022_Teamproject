using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    // 순간이동 하는 발판
    // 1. 닿았는지 확인
    // 2. 현재 위치를 파악, 닿은 오브젝트의 이름 파악
    // 3. 다른 오브젝트로 이동 시킴

    public GameObject[] teleportObjects;

    public AudioClip audioTeleport;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "teleport1")
        {
            if (UI.score >= 3)
            {
                audioSource.clip = audioTeleport;
                audioSource.Play();

                UI.score -= 3;

                gameObject.transform.position = teleportObjects[1].transform.position;

                teleportObjects[1].GetComponent<CapsuleCollider>().enabled = false;
                Invoke("SetTeleport2Collider", 3.0f);
            }
            else return;
        }

        if (other.name == "teleport2")
        {
            if (UI.score >= 3)
            {
                audioSource.clip = audioTeleport;
                audioSource.Play();
             
                UI.score -= 3;
                gameObject.transform.position = teleportObjects[0].transform.position;


                teleportObjects[0].GetComponent<CapsuleCollider>().enabled = false;
                Invoke("SetTeleport1Collider", 3.0f);
            }
            else return;
        }
    }

    void SetTeleport1Collider()
    {
        teleportObjects[0].GetComponent<CapsuleCollider>().enabled = true;
    }
    void SetTeleport2Collider()
    {
        teleportObjects[1].GetComponent<CapsuleCollider>().enabled = true;
    }
}
