using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
    public GameObject player;
    public float walkSpeed = 0.75f;
    public float runSpeed = 1f;
    public float escapeRange = 20;
    public float chaseRange = 20;
    GameObject[] sheeps;
    public Vector3 wayPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        sheeps = GameObject.FindGameObjectsWithTag("Sheep");
        wayPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < escapeRange)
        {
            EscapeFromObject(player);
        }
        else
        {
            GameObject closestSheep = GetClosestObject(sheeps);
            var distanceToClosestSheep = Vector3.Distance(transform.position, closestSheep.transform.position);
            if (distanceToClosestSheep < chaseRange && distanceToPlayer > 1.5f * escapeRange)
            {
                ChaseObject(closestSheep);
            }
            else
            {
                Wander(chaseRange);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("Collided with the player!");
            transform.localScale = new Vector3(1, 0.05f, 1);
            walkSpeed = 0;
            runSpeed = 0;
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Rigidbody>());
            Destroy(gameObject, 3);
        }
    }

    GameObject GetClosestObject(GameObject[] objects)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in objects)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    void ChaseObject(GameObject go)
    {
        Debug.Log("Trying to chase");
        wayPoint = transform.position;
        var goPosition = new Vector3(go.transform.position.x, transform.position.y, go.transform.position.z);
        transform.LookAt(goPosition);
        transform.position = Vector3.MoveTowards(transform.position, goPosition, runSpeed * Time.deltaTime);
    }

    void EscapeFromObject(GameObject go)
    {
        Debug.Log("Trying to escape");
        wayPoint = transform.position;
        var goPosition = new Vector3(go.transform.position.x, transform.position.y, go.transform.position.z);
        transform.rotation = Quaternion.LookRotation(transform.position - goPosition);
        transform.position = Vector3.MoveTowards(transform.position, goPosition, -1 * runSpeed * Time.deltaTime);
    }

    void Wander(float distance)
    {
        Debug.Log("Trying to wander");
        if (Vector3.Distance(transform.position, wayPoint) <= 0.1)
        {
            Debug.Log("Assigning new waypoint");
            wayPoint = transform.position + Random.insideUnitSphere * distance;
            wayPoint.y = transform.position.y;
        }
        transform.LookAt(wayPoint);
        transform.position = Vector3.MoveTowards(transform.position, wayPoint, walkSpeed * Time.deltaTime);
    }
}
