using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            if (Input.GetKeyDown(KeyCode.E));
            {
                HungerBar.Hunger += 50f;
                Destroy(gameObject);
            }
        }
    }
}
