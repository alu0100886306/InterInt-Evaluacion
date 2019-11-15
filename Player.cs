using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public float turn_speed;
    public int player_number;
    public Text Dinero;
    public Text Poder;
    [HideInInspector]
        public int money;
    [HideInInspector]
        public int power;
    private bool Fire1_button_pressed_;
    private bool Fire2_button_pressed_;
    private Renderer rend;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        speed = 10f;
        turn_speed = 80f;
        money = 0;
        power = 1;
        Poder.text = "Power: " + power;
        Dinero.text = "Dinero: " + money;
        if (player_number % 2 == 0)
        {
            rend.material.color = new Color(255, 0, 0);
        }
        else
        {
            rend.material.color = new Color(0, 0, 255);
        }
    }

    private void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Input.GetAxis("Fire1") == 1)
        {
            if (!Fire1_button_pressed_)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {                    
                    if (hit.collider.tag == "B")
                    {
                        Debug.DrawRay(transform.position, transform.forward, Color.white, 5);
                        Renderer rend2 = hit.collider.GetComponent<Renderer>();
                        rend2.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
                        money++;
                        Dinero.text = "Dinero: " + money;
                        ControladorEscena.controller_.changeCObjects();
                    }
                }
                Fire1_button_pressed_ = true;
            }
        }        
        if (Input.GetAxis("Fire1") == 0)
        {
            Fire1_button_pressed_ = false;
        }

        if (Input.GetAxis("Fire2") == 1)
        {
            if (!Fire2_button_pressed_)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    Debug.DrawRay(transform.position,transform.forward,Color.white,5);
                    Collider col = hit.collider;
                    col.transform.localScale /= power;
                }
                Fire2_button_pressed_ = true;
            }
        }
        if (Input.GetAxis("Fire2") == 0)
        {
            Fire2_button_pressed_ = false;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal" + player_number);
        float moveVertical = Input.GetAxis("Vertical" + player_number);
        float turnHorizontal = Input.GetAxis("Turn" + player_number);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 turnDirection = new Vector3(0, turnHorizontal, 0);

        rb.AddRelativeForce(movement * speed);
        //rb.MovePosition(movement * speed);
        Quaternion deltaRotation = Quaternion.Euler(turnDirection * turn_speed * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public void more_power()
    {
        if (money >= 3)
        {
            power++;            
            money -= 3;
            Poder.text = "Power: " + power;
            Dinero.text = "Dinero: " + money;
        }
    }
}
