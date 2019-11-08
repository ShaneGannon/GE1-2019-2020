﻿using System.Collections;
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
        StartCoroutine(Shoot());

    
    }
    int fireRate = 2;

    IEnumerator Shoot()
    {
        while (true)
        {
            if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.LeftControl))
            {
                GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                yield return new WaitForSeconds(1.0f / fireRate);
            }
            yield return null;
        }

    }
    //make public for debugging purposes
    public float ellapsed = float.MaxValue;
    //public int x = 0;

    //co-routines
    System.Collections.IEnumerator ShootingCoroutine { get; }

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
