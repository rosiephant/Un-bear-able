using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement: MonoBehaviour
{
    Transform player;
    [SerializeField] float speed;
    [SerializeField] int Stop;
    [SerializeField] int Close;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < Stop && Vector2.Distance(transform.position, player.position) > Close)
        {
            transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
            );
        }
    }
}