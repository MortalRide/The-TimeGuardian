using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectHit1 : MonoBehaviour
{

    public Slider healthbarEnemy1;
    Animator animat;
    public string opponent;


    void Start()
    {
        animat = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != opponent)
        {
            return;
        }

        animat.Play("damage", 0, 0);
        healthbarEnemy1.value -= 10;

        if (healthbarEnemy1.value <= 0)
        {
            animat.SetBool("isDead", true);
            Object.Destroy(gameObject, 2.0f);
        }

    }

    void Update()
    {

    }

}
