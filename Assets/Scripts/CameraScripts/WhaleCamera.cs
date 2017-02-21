﻿using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Cameras
{
	public class WhaleCamera
	{
		[SerializeField] private float m_MoveSpeed = 1f;                      // How fast the rig will move to keep up with the target's position.
		[Range(0f, 10f)] [SerializeField] private float m_TurnSpeed = 1.5f;   // How fast the rig will rotate from user input.
		[SerializeField] private float m_TurnSmoothing = 0.0f;                // How much smoothing to apply to the turn input, to reduce mouse-turn jerkiness
		[SerializeField] private float m_TiltMax = 75f;                       // The maximum value of the x axis rotation of the pivot.
		[SerializeField] private float m_TiltMin = 45f;                       // The minimum value of the x axis rotation of the pivot.
		[SerializeField] private bool m_LockCursor = false;                   // Whether the cursor should be hidden and locked.
		[SerializeField] private bool m_VerticalAutoReturn = false;           // set wether or not the vertical axis should auto return

		private float m_LookAngle;                    // The rig's y axis rotation.
		private float m_TiltAngle;                    // The pivot's x axis rotation.
		private const float k_LookDistance = 100f;    // How far in front of the pivot the character's look target is.
		private Vector3 m_PivotEulers;
		private Quaternion m_PivotTargetRot;
		private Quaternion m_TransformTargetRot;



	}
}

