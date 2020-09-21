using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class ActorShooting : MonoBehaviour {

	#region Fields

	[SerializeField] Gun gun;
	private Actor actor;

	#endregion

	#region Unity Callbacks

	private void OnEnable() {
		actor = GetComponent<Actor>();
	}

	private void Start () {
		EnableInputs();
	}

	#endregion

	#region Methods

	private void EnableInputs() {
		actor.GetRewiredPlayer().AddInputEventDelegate(Shoot, UpdateLoopType.Update, InputActionEventType.ButtonPressed, "Shoot");
	}

	private void Shoot(InputActionEventData data) {
		gun.Shoot();
	}
	
	#endregion

}
