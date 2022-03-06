using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehavior : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float distancePoints = 10f;
    Vector3 pointA;
    Vector3 pointB;
    Vector3 currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        pointA = transform.position;
        pointB = transform.position + (Vector3.forward * distancePoints);
        currentPoint = pointB;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pointA) {
            currentPoint = pointB;
            gameObject.transform.Rotate(0, 0, 180);
        }

        if (transform.position == pointB) {
            gameObject.transform.Rotate(0, 0, 180);
            currentPoint = pointA;
        }

        Debug.Log("PointA" + pointA);
        Debug.Log("PointB" + pointB);
        Debug.Log(currentPoint);

        transform.position = Vector3.MoveTowards(transform.position, currentPoint, moveSpeed * Time.deltaTime);
        
    }
}
