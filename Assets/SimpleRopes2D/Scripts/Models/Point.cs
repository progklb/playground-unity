using UnityEngine;

namespace SimpleRopes
{
	/// <summary>
	/// Defines a single point in 3D space.
	/// </summary>
	public class Point : MonoBehaviour
	{
		#region VARIABLES
		public Vector3 position
		{ 
			get => transform.position;
			set => transform.position = value;
		}

		public Vector3 prevPosition { get; set; }
		public bool isLocked { get; set; }
		#endregion
	}
}
