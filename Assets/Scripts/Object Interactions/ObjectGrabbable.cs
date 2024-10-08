using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
	private Rigidbody rb;
	private Transform objectGrabPoint;
	
	private float speed = 10f;
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void Grab(Transform objectGrabPoint)
	{
		this.objectGrabPoint = objectGrabPoint;
		rb.useGravity = false;
		rb.isKinematic = true;
	}

	public void Drop()
	{
		this.objectGrabPoint = null;
		rb.useGravity = true;
		rb.isKinematic = false;
	}

	private void FixedUpdate()
	{
		if (objectGrabPoint != null)
		{
			Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPoint.position, Time.deltaTime * speed);
			rb.MovePosition(newPosition);
		}
	}
}
