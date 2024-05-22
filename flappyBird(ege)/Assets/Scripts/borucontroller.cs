using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borucontroller : MonoBehaviour
{
    public GameObject[] borular;

    public float BoruHizi = 4f;

    public Transform SpawnerObjesininYeri;
    void Start()
    {
        StartCoroutine(BoruSpawn());

    }

    IEnumerator BoruSpawn()
    {
        while (true)
        {
            GameObject boru = Instantiate(borular[Random.Range(0, borular.Length)], SpawnerObjesininYeri.position, Quaternion.identity);
            boru.GetComponent<Rigidbody2D>().velocity = Vector2.left * BoruHizi;
            
            yield return new WaitForSeconds(3f);
        }
    }
}
