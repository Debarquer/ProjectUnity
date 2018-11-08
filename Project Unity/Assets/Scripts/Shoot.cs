using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public Transform FirePoint;
    public GameObject cloudPrefab;

    public AudioSource shootSound;

    public float fireRate = 1;
    float nextFire = 0;
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            shootSound.Play();
            Instantiate(cloudPrefab, FirePoint.position, FirePoint.rotation);
            nextFire = Time.time + fireRate;
        }
        //nextFire += Time.deltaTime;
	}
}
