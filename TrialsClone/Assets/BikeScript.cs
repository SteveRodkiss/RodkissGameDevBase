using UnityEngine;
using System.Collections;

public class BikeScript : MonoBehaviour
{

	public float MotorPower = 500f;
	public WheelCollider RearWheel;
	public WheelCollider FrontWheel;
	public Transform FrontWheelMesh;
	public Transform RearWheelMesh;

	// Use this for initialization
	void Start ()
	{

	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float torque = Input.GetAxis("Horizontal") * MotorPower;
		RearWheel.motorTorque = torque;

		ApplyVisualTransform(RearWheel,RearWheelMesh);
		ApplyVisualTransform(FrontWheel,FrontWheelMesh);
	}

	void ApplyVisualTransform(WheelCollider wc, Transform mesh)
	{
		Vector3 pos;
		Quaternion rot;
		wc.GetWorldPose(out pos,out rot);
		mesh.position = pos;
		mesh.rotation = rot;
	}


}
