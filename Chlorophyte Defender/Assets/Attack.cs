using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ATTACKED: " + other.name);
        other.gameObject.GetComponent<Character>().DecreaseHealth(10);
    }
}
