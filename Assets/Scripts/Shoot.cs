using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    bool shooting = false;
    private void Update()
    {
        if(shooting == false)
        {
            StartCoroutine(Shot());
        }
    }

    void bulletShoot()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);
            Vector3[] rotate = { transform.up, transform.right, -transform.up, -transform.right };
            bullet.transform.rotation = Quaternion.FromToRotation(Vector3.up, rotate[i]);
        }

        shooting = true;
    }

    IEnumerator Shot()
    {
        bulletShoot();

        yield return new WaitForSeconds(0.5f);

        shooting = false;
    }
}
