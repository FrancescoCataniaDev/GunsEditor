using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Guns", order = 1)]
public class Gun : SerializedScriptableObject {
	[HorizontalGroup("Header", 100, 5, 5, 0)] [Header("GunCheck")]
	public List<GunCheck> gunCheck;

	[HorizontalGroup("Header")] [Header("GunAction")]
	public List<GunAction> gunActions;

	public void Shoot() {
		CheckGun();
	}

	private void CheckGun() {
		if (gunCheck.Count > 0) {
			for (int i = 0; i < gunCheck.Count; i++) {
				if (!gunCheck[i].Check()) {
					return;
				}
			}
		}
		ActionGun();
	}

	private void ActionGun() {
		for (int i = 0; i < gunActions.Count; i++) {
			gunActions[i].Action();
		}
	}
}