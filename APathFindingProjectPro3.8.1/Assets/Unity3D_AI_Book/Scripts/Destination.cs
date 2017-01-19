using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destination : MonoBehaviour {

	public int coherencyWeight = 1;
	public int separatonWeight = 2;

	private List<Destination> destinations;

	private float velocity;
	public float Velocity{
		get {return velocity;}
	}

	private Vector3 coherency;
	private Vector3 separation;

	private Vector3 calculatedForce;
	private Vector3 relativePos;

	void Start () {	
		destinations = DestinationManager.Instance.destinations;
        //Debug.Log("Start destinations " + destinations == null);
	}

	public void CalculateForce(Vector3 center)
	{
		coherency = center - transform.position;
		separation = Vector3.zero;

        //Debug.Log("CalculateForce destinations " + destinations == null);
        if (destinations == null)
        {
            return;
        }

		foreach(Destination d in destinations)
		{
			if (d!=this)
			{
				relativePos = transform.position - d.transform.position;
				separation += relativePos/(relativePos.sqrMagnitude);
			}
		}

		calculatedForce = (coherency * coherencyWeight) + (separation * separatonWeight);
		calculatedForce.y = 0;

		transform.GetComponent<Rigidbody>().velocity = calculatedForce * 20;
		velocity = transform.GetComponent<Rigidbody>().velocity.magnitude;
	}


	void Update () {
	
	}
}
