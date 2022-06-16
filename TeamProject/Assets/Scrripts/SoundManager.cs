using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource myAudio;

    public AudioClip Blue_dying;
    public AudioClip Corn_dying;
    public AudioClip Root_dying;
    public AudioClip Yellow_dying;
    public AudioClip Bee_dying;

    private Enemy_Manager e_man;
    private Enemy_destroying e_des;

    public GameObject enemy_manager;

    private GameObject[] e_temp;
    private int e_ch;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
    }

    private void Set_OtherScripts()
    {

        e_temp = enemy_manager.GetComponent<Enemy_Manager>().
            GetEnemyArray();
        //e_man = GameObject.Find("Enemy_Manager").GetComponent<Enemy_Manager>();
        //GameObject[] e_temp = e_man.GetEnemyArray();

        e_des = GameObject.Find("cur_health").GetComponent<Enemy_destroying>();
        int e_ch = e_des.GetCurHealth();
    }

    // Update is called once per frame
    void Update()
    {
        Set_OtherScripts();
        Debug.Log(e_temp[0].e_ch);
    }

    public void Blue_Dying()
    {
        myAudio.PlayOneShot(Blue_Dying);
    }

    public void Corn_Dying()
    { 
        myAudio.PlayOneShot(Corn_dying);
    }

    public void Root_Dying()
    {
        myAudio.PlayOneShot(Root_dying);
    }

    public void Yellow_Dying()
    {
        myAudio.PlayOneShot(Yellow_dying);
    }

    public void Bee_Dying()
    {
        myAudio.PlayOneShot(Bee_dying);
    }
}
