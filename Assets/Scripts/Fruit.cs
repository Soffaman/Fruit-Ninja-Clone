using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;

    public void CreateSlicedFruit()
    {
        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rbsOnSliced = inst.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500f, 1000f), transform.position, 5f);
        }

        Destroy(inst, 5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (!b)
        {
            return;
        }

        FindObjectOfType<GameManager>().IncreaseScore(3);
        CreateSlicedFruit();
    }
}
