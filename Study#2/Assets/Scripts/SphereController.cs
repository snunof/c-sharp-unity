using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

	// Use this for initialization
	public bool jumpP;
    public int jumpNum;
	void Start () {
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
	void Update () {
		if(this.transform.parent != null)
        {
            if(jumpP)
            {
                transform.Translate(Vector3.up*Time.deltaTime); 
            }
            else
            {
                if (jumpNum < 20)
                {
                    float jumpAcceration = 3 - jumpNum * 0.1f;
                    transform.Translate(Vector3.up*Time.deltaTime * jumpAcceration);
                    jumpNum++;
                }
            }
        }
	}
}
