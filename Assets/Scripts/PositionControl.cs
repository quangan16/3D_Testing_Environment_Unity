using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionControl : MonoBehaviour
{
	[SerializeField] private float durationTime = 3f;
	[SerializeField] private float lerpedValue;
	[SerializeField] private float elapsedTime;
	[SerializeField] private float rotateStrength;
	private bool isRolling;


	private float start = 0;
	private float end = 1;

	// Start is called before the first frame update
	void Start()
	{
		rotateStrength = 500f;
		isRolling = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (elapsedTime < durationTime)
		{
			float time = elapsedTime / durationTime;
			lerpedValue = Mathf.Lerp(start, end, time);
			elapsedTime += Time.deltaTime;
		}
		else
		{
			lerpedValue = end;
		}
		if (isRolling == true)
		{
			transform.eulerAngles += Vector3.forward * rotateStrength * Time.deltaTime;

		}

	}
}
