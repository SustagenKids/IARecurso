using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject Endscreen;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            Endscreen.gameObject.SetActive(true);

        }
    }

}
