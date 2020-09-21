using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class ActorLocomotion : MonoBehaviour {

	#region Fields

	private Rigidbody rb;
	private Actor actor;

	[SerializeField]private float speed;
	
	#endregion

	#region Unity Callbacks

	private void OnEnable() {
		actor = GetComponent<Actor>();
		rb = GetComponent<Rigidbody>();
	}

	private void Start() {
		EnableInputs();
	}
	
	#endregion

	#region Methods

	private void Move(InputActionEventData data) {
		float x = actor.GetRewiredPlayer().GetAxis("Move Horizontal");
		float z = actor.GetRewiredPlayer().GetAxis("Move Vertical");
		
		Vector3 movement = new Vector3(x, 0f, z).normalized * speed;
		rb.velocity = movement;
	}

	private void Aim(InputActionEventData data) {
		float xRot = actor.GetRewiredPlayer().GetAxis("Aim Horizontal");
		float zRot = actor.GetRewiredPlayer().GetAxis("Aim Vertical");
		
		Vector3 direction = new Vector3(xRot, 0f, zRot).normalized;
		transform.LookAt(transform.position + direction);
	}

	private void EnableInputs() {
		actor.GetRewiredPlayer().AddInputEventDelegate(Move, UpdateLoopType.FixedUpdate, InputActionEventType.Update, "Move Horizontal");
		actor.GetRewiredPlayer().AddInputEventDelegate(Move, UpdateLoopType.FixedUpdate, InputActionEventType.Update, "Move Vertical");
		
		actor.GetRewiredPlayer().AddInputEventDelegate(Aim, UpdateLoopType.FixedUpdate, InputActionEventType.Update, "Aim Horizontal");
		actor.GetRewiredPlayer().AddInputEventDelegate(Aim, UpdateLoopType.FixedUpdate, InputActionEventType.Update, "Aim Vertical");
	}
	
	#endregion

}
