using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator _anim;
    bool isDoorClosed;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.StopPlayback();
    }

    // Update is called once per frame
    void Update()
    {
       if(isDoorClosed)
        {
            Open();
        }
       else if(!isDoorClosed)
        {
            Close();
        }
    }

    public void Open()
    {
        _anim.SetBool("isClosed", true);
    }

    public void Close()
    {
        _anim.SetBool("isClosed", false);
    }
}
