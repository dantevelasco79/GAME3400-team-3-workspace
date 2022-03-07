using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehavior : MonoBehaviour
{
    public GameObject blood;
    public float moveSpeed = 1f;
    public float distancePoints = 10f;
    Vector3 pointA;
    Vector3 pointB;
    Vector3 currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        pointA = transform.position;
        pointB = transform.position + (transform.up * distancePoints);
        currentPoint = pointB;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pointA)
        {
            currentPoint = pointB;
            gameObject.transform.Rotate(0, 0, 180);
        }

        if (transform.position == pointB)
        {
            gameObject.transform.Rotate(0, 0, 180);
            currentPoint = pointA;
        }
        transform.position = Vector3.MoveTowards(transform.position, currentPoint, moveSpeed * Time.deltaTime);

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Human"))
        {
            Debug.Log("Collided with the human!");
            transform.Rotate(new Vector3(0, 90, 0));
            transform.position = transform.position - transform.right * 0.2f;
            moveSpeed = 0;
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Rigidbody>());
            Instantiate(blood, transform.position + transform.right * 0.1f, Quaternion.Euler(-90, 0, 0));
            Destroy(gameObject, 2);
        }
    }
}
