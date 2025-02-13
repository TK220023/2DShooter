using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class bulletMove : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    private void Start()
    {
        Invoke("DestroyMyself", 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + transform.up, speed * Time.deltaTime);
    }

    private void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
