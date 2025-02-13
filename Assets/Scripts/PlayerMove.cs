using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    GameObject ship;
    GameObject destination;

    Vector3 touchWorldPos;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        ship = this.gameObject;
        destination = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveToDestination();
    }

    // ˆÚ“® //
    void PlayerMoveToDestination()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchScreenPos = Input.mousePosition;
            touchScreenPos.z = 10f;
            Camera camera = Camera.main;
            touchWorldPos = camera.ScreenToWorldPoint(touchScreenPos);
            destination.transform.position = touchWorldPos;
        }
        destination.transform.position = touchWorldPos;
        ship.transform.position = Vector3.MoveTowards(ship.transform.position, destination.transform.position, speed * Time.deltaTime);

        Vector3 rotateVec = destination.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, rotateVec);
    }
}
