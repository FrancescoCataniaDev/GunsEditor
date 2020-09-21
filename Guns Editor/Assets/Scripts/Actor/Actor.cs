using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class Actor : MonoBehaviour {

	#region Fields

	private Player rewiredPlayer;

	#endregion

	#region Unity Callbacks

	private void OnEnable() {
		rewiredPlayer = ReInput.players.GetPlayer(0);
	}

	#endregion

	#region Methods

	public Player GetRewiredPlayer() {
		return rewiredPlayer;
	}
	
	#endregion
}
