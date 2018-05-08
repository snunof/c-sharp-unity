using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public bool jumpP;
    public int jumpNum;
    public bool vA = false;
    public bool vW = false;
    public bool vS = false;
    public bool vD = false;
    public float speed = 0f;
    private bool got = false;
    // Use this for initialization
    void Start()
    {
        jumpNum = 0;
        jumpP = false;
    }
    void OnCollisionStay(Collision collision)
    {
        jumpNum = 0;
        jumpP = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        jumpNum = 0;
        jumpP = true;
    }
    void OnCollisionExit(Collision collision)
    {
        jumpP = false;
        jumpNum++;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject child = GameObject.Find("Sphere") as GameObject;
        if(Input.GetKeyDown(KeyCode.R))
        {
            speed += 0.5f;
        }
        if (jumpP)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(Time.deltaTime*speed, 0, 0);
                vD = true;
            }
            else
                vD = false;
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(Time.deltaTime*speed, 0, 0);
                vA = true;
            }
            else
                vA = false;
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, 0, Time.deltaTime*speed);
                vW = true;
            }
            else
                vW = false;
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, 0, Time.deltaTime*speed);
                vS = true;
            }
            else
                vS = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position += new Vector3(0, 0.2f, 0);
                //this.transform.Translate(Vector3.up * 5.0f * Time.deltaTime);
            }
        }
        else
        {
            if (vD)
            {
                transform.position += new Vector3(Time.deltaTime * speed*0.7f, 0, 0);
                if(Input.GetKey(KeyCode.D))
                    transform.position += new Vector3(Time.deltaTime * speed*0.3f, 0, 0);
            }
            else
            {
                if (Input.GetKey(KeyCode.D))
                    transform.position += new Vector3(Time.deltaTime * speed*0.3f, 0, 0);
            }
            if (vA)
            {
                transform.position -= new Vector3(Time.deltaTime * speed*0.7f, 0, 0);
                if(Input.GetKey(KeyCode.A))
                    transform.position -= new Vector3(Time.deltaTime * speed*0.3f, 0, 0);
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                    transform.position -= new Vector3(Time.deltaTime * speed*0.3f, 0, 0);
            }
            if (vW)
            {
                transform.position += new Vector3(0, 0, Time.deltaTime * speed*0.7f);
                if (Input.GetKey(KeyCode.W))
                    transform.position += new Vector3(0, 0, Time.deltaTime * speed*0.3f);
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                    transform.position += new Vector3(0, 0, Time.deltaTime * speed*0.3f);
            }
            if (vS)
            {
                transform.position -= new Vector3(0, 0, Time.deltaTime * speed*0.7f);
                if (Input.GetKey(KeyCode.S))
                    transform.position -= new Vector3(0, 0, Time.deltaTime * speed*0.3f);
            }
            else
            {
                if (Input.GetKey(KeyCode.S))
                    transform.position -= new Vector3(0, 0, Time.deltaTime * speed*0.3f);
            }
            if (jumpNum < 40)
            {
                float jumpAcceration = 5 - jumpNum * 0.1f;
                transform.position += new Vector3(0, Time.deltaTime * jumpAcceration, 0);
                jumpNum++;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            
            if(!got)
            {
                child.transform.parent = this.transform;
                got = true;
            }
            else
            {
                child.transform.parent = null;
                got = false;
            }
        }


    }

}
