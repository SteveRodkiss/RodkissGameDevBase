using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour
{

	public GameObject Target;
	public Vector3 Offset = new Vector3(20f,10f,0f);

	// Use this for initialization
	void Start ()
	{
		Target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Target.transform.position + Offset;
		transform.LookAt(Target.transform.position);
	}
}
