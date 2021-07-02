using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject DoorStuck;
    public GameObject AbrirPara;
    public GameObject FecharPara;
    public Collider Collider;
    public bool isOpening = false;
    public bool playerIsNear = false;
    public bool isXMovement;
    public bool isClosing = false;
    public bool isClosed = true;

    public bool isLocked = false;

    public float timeAberto = 3.0f;
    public float timeParaFechar;

    public float timeFechado = 3.0f;
    public float timeParaAbrir;

    public float timeTranca = 10.0f;
    public float timeParaDestrancar;

    public float timeStart = 2.0f;

    // Update is called once per frame

    void Update()
    {
        //isLocked = sniper.GetComponent<SniperScript>().isLocked;
        if (timeStart > 0)
        {
            timeStart -= Time.deltaTime;
            playerIsNear = false;
        }
        if (isLocked)
        {
            timeParaDestrancar -= Time.deltaTime;
            isClosing = true;
            if (timeParaDestrancar <= 0)
            {
                isLocked = false;
            }
        }

        if (playerIsNear && !isLocked && Input.GetKeyDown("e") && isClosed)
        {
            isOpening = true;
            timeParaFechar = timeAberto;
            isClosed = false;
        }
        if (playerIsNear && !isLocked && Input.GetKeyDown("e") && !isClosed && !isOpening)
        {
            isClosing = true;
            timeParaAbrir = timeFechado;
        }

        if (isOpening)
        {
            if (DoorStuck.transform.position.x <= AbrirPara.transform.position.x && isXMovement)
            {
                DoorStuck.transform.position += new Vector3(0.1f, 0,0);
            }

            if (DoorStuck.transform.position.y <= AbrirPara.transform.position.y && !isXMovement)
            {
                DoorStuck.transform.position += new Vector3(0.1f, 0, 0);
            }

            timeParaFechar -= Time.deltaTime;
            if (timeParaFechar <= 0)
            {
                isOpening = false;
            }
        }
        if (isClosing)
        {
            if (DoorStuck.transform.position.x >= FecharPara.transform.position.x && isXMovement)
            {
                DoorStuck.transform.position -= new Vector3(0.1f, 0, 0);
            }

            if (DoorStuck.transform.position.y >= FecharPara.transform.position.y && !isXMovement)
            {
                DoorStuck.transform.position -= new Vector3(0.1f, 0, 0);
            }
            timeParaAbrir -= Time.deltaTime;
            if (timeParaAbrir <= 0)
            {
                isClosing = false;
                isClosed = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        playerIsNear = true;
    }
    private void OnTriggerExit(Collider other)
    {
        playerIsNear = false;
    }
}
