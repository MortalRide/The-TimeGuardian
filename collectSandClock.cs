using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collectSandClock : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collectSound.Play();
            sandClock.scNumber += 1;
            Destroy(gameObject);
            
            if (sandClock.scNumber == 10)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
