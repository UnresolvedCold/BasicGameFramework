/*
 * In Weapon holder all types of weapon that is owned by player must bea attached and tagged "OwnedWeapon"
 * rest weapons that are not attached to players must be tagged "Weapon"
 * 
 * The Player is attached with all types of weapon
 * PickUp() - void - if there is a weapon somewhere in reach, player will activate that weapon from its holder 
 * 					and destroy the weapon on ground
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	[SerializeField]private GameObject weaponHolder;
	[SerializeField]private GameObject firePoint;
	[SerializeField]private LayerMask layerMaskToConsider;

	[SerializeField]private GameObject[] ownedWeapons; //must be arranged from high preference to low preference

	[SerializeField]private float playerHandRange = 5f;

	private int[,] weaponAmmos;
	private int selectedWeapon = 0;

	void Start()
	{
		weaponAmmos = new int[ownedWeapons.Length, 2];
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			PickUp ();
		}

		if (Input.GetKeyDown (KeyCode.Insert)) {
			selectedWeapon=(++selectedWeapon) % ownedWeapons.Length;
			ChangeWeapon (selectedWeapon);
		}
	}

	void ChangeWeapon(int n)
	{
		ActivateSelectedWeapon (ownedWeapons[n]);
	}

	void PickUp()
	{
		RaycastHit hit;
		Physics.Raycast (firePoint.transform.position,firePoint.transform.TransformDirection(Vector3.forward),out hit,Mathf.Infinity,layerMaskToConsider);
		Collider targetWeapon;

		Debug.Log (hit.distance);
		Debug.Log (hit.collider.name);

		if ((hit.distance < playerHandRange) && (hit.collider.tag.Equals ("Weapon"))) {
			targetWeapon = hit.collider;

			ActivateSelectedWeapon (targetWeapon);

			Destroy (hit.collider.gameObject);
			Debug.Log (hit.collider.name+" picked up");

		} else
			return;
	}


	void ActivateSelectedWeapon(Collider selectedWeapon)
	{
		for (int i = 0; i < ownedWeapons.Length; i++) {
			if (selectedWeapon.name != ownedWeapons [i].name) {
				ownedWeapons [i].SetActive (false);
			} else if (selectedWeapon.name == ownedWeapons [i].name) {
				ownedWeapons [i].SetActive (true);
			}

			Debug.Log ("OwnedWeapon= "+ownedWeapons[i].name+" selectedWeapon= "+selectedWeapon.name);
		}
	}

	void ActivateSelectedWeapon(GameObject selectedWeapon)
	{
		for (int i = 0; i < ownedWeapons.Length; i++) {
			if (selectedWeapon.name != ownedWeapons [i].name) {
				ownedWeapons [i].SetActive (false);
			} else if (selectedWeapon.name == ownedWeapons [i].name) {
				ownedWeapons [i].SetActive (true);
			}
		}
	}

} 