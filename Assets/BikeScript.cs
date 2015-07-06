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
		DoInput();

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

	void DoInput()
	{
		float xin = Input.GetAxis("Horizontal");
		//reset values
		RearWheel.motorTorque = 0f;
		if(xin > 0f)
			RearWheel.motorTorque = xin * MotorPower;
		if(xin <= 0f)
		{
			RearWheel.brakeTorque = -xin * MotorPower * 2.5f;
			FrontWheel.brakeTorque = -xin * MotorPower * 0.5f;
		}
		//apply rotation of rigidbody for control in air
		if(!RearWheel.isGrounded && !FrontWheel.isGrounded)
		{
			GetComponent<Rigidbody>().AddTorque(-xin * MotorPower * 0.5f,0,0);
		}

	}


}
