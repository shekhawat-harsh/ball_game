using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_tile_follower : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 2.07f, 0);
    }
}
