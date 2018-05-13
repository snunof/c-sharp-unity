using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float h = 0.0f;
	private float v = 0.0f;

	public float Speed = 3;
	public float Ro = 50;
	public float CurrRo;
	private Vector3 ForwardVector;
	private Rigidbody Myrigidbody;
	// Use this for initialization
	void Start () {
		Myrigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis("Horizontal"); // a and d -1 0 1
		v = Input.GetAxis("Vertical"); // w and s -1 0 1

		ForwardVector = (this.transform.forward*v*Speed);

		Myrigidbody.velocity = new Vector3(ForwardVector.x, Myrigidbody.velocity.y, ForwardVector.z);

		CurrRo += Ro*h;
		this.transform.rotation = Quaternion.AngleAxis(CurrRo, Vector3.up);
	}
}
