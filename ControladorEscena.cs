using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEscena : MonoBehaviour
{
    public delegate void delegateMethod();

    public event delegateMethod collision_event_;

    public static ControladorEscena controller_;

    public Player player_;

    private void Awake()
    {
        if(controller_ == null)
        {
            controller_ = this;
            DontDestroyOnLoad(this);
        } else if (controller_ != this)
        {
            Destroy(gameObject);
        }
    }

    public void changeCObjects()
    {
        collision_event_();
    }
}
