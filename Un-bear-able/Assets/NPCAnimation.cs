using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Animator>().Play("idle");
    }
}
