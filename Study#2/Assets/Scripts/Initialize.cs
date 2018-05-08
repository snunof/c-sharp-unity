using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    private GameObject target;

    void Awake()
    {
        target = GameObject.FindWithTag("Cube");
    }

    // Use this for initialization
    void Start()
    {
		Awake();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
