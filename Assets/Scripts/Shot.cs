using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject destination;
    public GameObject Player;
    [SerializeField] AudioSource audioShot;


    bool isStart = false;
    private void Start()
    {
        audioShot= GetComponent<AudioSource>();
        Invoke(nameof(StartCheck), 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioShot.Play();
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.transform.rotation = Quaternion.FromToRotation(Vector3.up, destination.transform.position - Player.transform.position);
            }
        }
    }

    void StartCheck()
    {
        isStart= true;
    }
}
