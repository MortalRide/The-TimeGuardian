using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectHitPlayer : MonoBehaviour
{

    public Slider healthbarPlayer;
    Animator anim;
    public string opponent;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != opponent)
        {
            return;
        }
        healthbarPlayer.value -= 10;

        if (healthbarPlayer.value <= 0)
        {
            anim.SetBool("isPlayerDead", true);
            Object.Destroy(gameObject, 2.0f);
        }


    }

    void Update()
    {
       
    }

}
