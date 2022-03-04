using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectHit : MonoBehaviour
{

    public Slider healthbar;
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
        healthbar.value -= 10;

        if (healthbar.value <= 0)
        {
            animat.SetBool("isDead", true);
            Object.Destroy(gameObject, 2.0f);
        }
            
    }
    
    void Update()
    {
        
    }

}
