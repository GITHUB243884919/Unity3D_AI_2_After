using UnityEngine;
using System.Collections;

public class FireRange2 : MonoBehaviour 
{
	public float fireRange;
	public int penalty;
	public float fieldOfAttack = 30;


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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fireRange);
        Debug.DrawLine(transform.position + new Vector3(0, 2, 0), frontRayPoint + new Vector3(0, 2, 0), Color.black);
        //角度转弧度
		float fieldOfAttackinRadians = fieldOfAttack*3.14f/180.0f;
        float fieldOfAttackinRadians2 = 3.14f / 2 + fieldOfAttackinRadians;
        //根据角的定义，按照顺时针方向旋转而成的角叫做负角。逆时针旋转则是正角，没有旋转叫零角。
        Vector3 rayPoint1 = new Vector3(
            fireRange * Mathf.Cos(fieldOfAttackinRadians2),
            0,
            fireRange * Mathf.Sin(fieldOfAttackinRadians2));
        rayPoint1 = transform.TransformPoint(rayPoint1);
        Debug.DrawLine(transform.position, rayPoint1 + new Vector3(0, 1, 0), Color.blue);
 
        //for (int i = 0; i < 11; i++)
        //for (int i = 0; i<1; i++)
        for (int i = 0; i < 10; i++)
		{
			RaycastHit hit;
            //x = sin 如果从Y的正方向往下看所构成的2维平面(X,Z)，
            //Z在垂直方向，X在水平方向
			float angle = -fieldOfAttackinRadians + fieldOfAttackinRadians * 0.2f * (float)i;
            Vector3 rayPoint = transform.TransformPoint(new Vector3(
                fireRange * Mathf.Sin(angle),
                0,
                fireRange * Mathf.Cos(angle)));

            //Vector3 rayPoint = transform.TransformPoint(new Vector3(
            //    fireRange * Mathf.Cos(angle),
            //    0,
            //    fireRange * Mathf.Sin(angle)));

            //Vector3 rayDirection = (rayPoint - transform.position).normalized;
            //if (Physics.Raycast(transform.position, rayDirection, out hit, fireRange))
            //{
            //    Debug.Log("do not cross");
            //    if (hit.transform.gameObject.layer == 9)
            //    {
            //        Debug.DrawLine(transform.position + new Vector3(0, 1, 0), hit.point, Color.red);
            //        continue;
            //    }
            //}
            if (i == 0)
            {
                Debug.DrawLine(transform.position + new Vector3(0, 1, 0), rayPoint + new Vector3(0, 1, 0), Color.green);
            }
            else
            {
                Debug.DrawLine(transform.position + new Vector3(0, 1, 0), rayPoint + new Vector3(0, 1, 0), Color.red);
            }
            
		}

        Debug.DrawLine(transform.position, frontRayPoint + new Vector3(0, 1, 0), Color.black);

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
