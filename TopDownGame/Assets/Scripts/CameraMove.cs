using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public Transform mainMenuPosition = null; // create an empty gameobject and assign in inspector
	public Transform playPosition = null; // create an empty gameobject and assign in inspector
	public Transform settingPosition = null; // create an empty gameobject and assign in inspector
	public GameObject mainMenu;
	public GameObject settings;

	void Update ()
	{
		transform.position = Vector3.Lerp(transform.position, playPosition.position, Time.deltaTime);
		float rotateX = 90;
		transform.eulerAngles = new Vector3(rotateX, 0, 0);
	}
}
