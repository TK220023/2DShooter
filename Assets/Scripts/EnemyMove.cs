using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position == destination)
        {
            destination = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5));
        }

        transform.position = Vector3.MoveTowards(this.transform.position, destination, speed * Time.deltaTime);
        Vector3 rotateVec = destination - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, rotateVec);
    }
}
