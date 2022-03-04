using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class detectHitBoss : MonoBehaviour
{

    public Slider healthbarBoss;
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
        healthbarBoss.value -= 5;

        if (healthbarBoss.value <= 0)
        {
            animat.SetBool("isDead", true);
            Object.Destroy(gameObject, 6f);
            StartCoroutine(coUpdate());
        }

    }
    
    IEnumerator coUpdate()
    {
        if (healthbarBoss.value <= 0)
        {
            Debug.Log("Oyun Bitti." + Time.time);
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void Update()
    {
        
    }

}
