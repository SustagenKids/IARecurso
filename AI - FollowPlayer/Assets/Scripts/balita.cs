using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balita : MonoBehaviour
{
    public float speed;
    public float maxDistance;

    public GameObject Shooter;

    private GameObject playerTrigger;

    private GameObject enemyTrigger;
    public float damage;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        //if (hit.gameObject.tag == "Player" && Shooter.gameObject.tag != "Player")
        //{

        //    Destroy(this.gameObject);
        //    Debug.Log("hitted");
        //    playerTrigger = hit.gameObject;
        //    playerTrigger.GetComponent<ClickMovement>().playerHP -= damage;

        //}

        if (hit.gameObject.tag == "Enemy" && Shooter.gameObject.tag != "Enemy")
        {
            enemyTrigger = hit.gameObject;
            enemyTrigger.GetComponent<EnemyHP>().enemyHealth -= damage;
            Destroy(this.gameObject);
            Debug.Log("hitted");
        }
    }
}

