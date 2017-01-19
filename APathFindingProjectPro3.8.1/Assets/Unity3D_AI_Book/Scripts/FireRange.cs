using UnityEngine;
using System.Collections;

public class FireRange : MonoBehaviour 
{
	public float fireRange;
	public int penalty;
	public float fieldOfAttack = 45;


	void Start () {
	
	}	

	void Update () {
	
	}

	/*
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, fireRange);
	}*/


	void OnDrawGizmos()
	{
		Vector3 frontRayPoint = transform.position + (transform.forward * fireRange);
		float fieldOfAttackinRadians = fieldOfAttack*3.14f/180.0f;

		for (int i = 0; i<11; i++)
		{
			RaycastHit hit;
			float angle = -fieldOfAttackinRadians + fieldOfAttackinRadians * 0.2f * (float)i;
			Vector3 rayPoint = transform.TransformPoint(new Vector3(
                fireRange * Mathf.Sin(angle),
                0,
                fireRange * Mathf.Cos(angle)));
			Vector3 rayDirection = rayPoint - transform.position;
			if (Physics.Raycast(transform.position, rayDirection, out hit,fireRange))
			{
                //原书代码有点小bug，阻挡的层数不一定是9，不过根据名字就可以判断
				//if (hit.transform.gameObject.layer == 9)
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
				{
					Debug.DrawLine(transform.position+new Vector3(0,1,0), hit.point, Color.red);
					continue;
				}
			}

			Debug.DrawLine(transform.position+new Vector3(0,1,0), rayPoint+new Vector3(0,1,0), Color.red);
		}

	}

	/*
	void OnDrawGizmos()
	{
		Vector3 frontRayPoint = transform.position + (transform.forward * fireRange);
		float fieldOfAttackinRadians = fieldOfAttack*3.14f/180.0f;
		Vector3 leftRayPoint = transform.TransformPoint(new Vector3(fireRange * Mathf.Sin(fieldOfAttackinRadians),0,fireRange * Mathf.Cos(fieldOfAttackinRadians)));
		Vector3 rightRayPoint = transform.TransformPoint(new Vector3(-fireRange * Mathf.Sin(fieldOfAttackinRadians),0,fireRange * Mathf.Cos(fieldOfAttackinRadians)));
		Debug.DrawLine(transform.position+new Vector3(0,1,0), frontRayPoint+new Vector3(0,1,0), Color.green);
		Debug.DrawLine(transform.position+new Vector3(0,1,0), leftRayPoint+new Vector3(0,1,0), Color.green);
		Debug.DrawLine(transform.position+new Vector3(0,1,0), rightRayPoint+new Vector3(0,1,0), Color.green);
	}*/
}
