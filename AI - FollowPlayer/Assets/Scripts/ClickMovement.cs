using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMovement : MonoBehaviour
{

    public LayerMask whatCanBeClickedOn;

    public UnityEngine.AI.NavMeshAgent myAgent;

    public GameObject tiroSpawn;
    public float rateOfFire;
    public GameObject tirocarioca;

    public float playerHP = 20;

    public GameObject Shooter;
    // private GameObject enemyTrigger;


    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast (myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                myAgent.SetDestination(hitInfo.point);
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }

    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Enemy" && Shooter.gameObject.tag != "Enemy")
        {
            //enemyTrigger = hit.gameObject;
            //enemyTrigger.GetComponent<EnemyDeath>().enemyHealth -= damage;
            Destroy(this.gameObject);
            Debug.Log("hit");
        }
    }

    void Shoot()
    {
        Instantiate(tirocarioca.transform, tiroSpawn.transform.position, tiroSpawn.transform.rotation);
    }
}
