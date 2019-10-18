using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    // Start is called before the first frame update
    void OnEnable()
    {
        //StartCoroutine(ShootingCoroutine());
    }

    public int fireRate = 3;
    //make public for debugging purposes
    public float ellapsed = float.MaxValue;
    //public int x = 0;

    //co-routines
    System.Collections.IEnumerator ShootingCoroutine()
    {
        float toPass = 1.0f / fireRate;
        while (true)
        {
        GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            yield return new WaitForSeconds(toPass);
        }
    }

    Coroutine cr;

    // Update is called once per frame
    void Update()
    {
        float toPass = 1.0f / fireRate;
        ellapsed += Time.deltaTime;
        //x++;
        //if (x > 32)
        //{
        if (Input.GetKey(KeyCode.LeftControl) && ellapsed > toPass)
            {
                GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                ellapsed = 0;
                //x = 0;
            }
        //}
    }
}
