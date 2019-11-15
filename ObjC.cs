using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjC : MonoBehaviour
{
    private Rigidbody rb;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ControladorEscena.controller_.collision_event_ += move;
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move()
    {
        int power = player.power + 50;
        rb.AddForce(Random.Range(0f,1f)*power, Random.Range(0f, 1f) * power, Random.Range(0f, 1f) * power);
    }
}
