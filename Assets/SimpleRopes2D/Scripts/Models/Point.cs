using UnityEngine;

namespace SimpleRopes
{
	/// <summary>
	/// Defines a single point in 3D space.
	/// </summary>
	public class Point : MonoBehaviour
	{
		#region PROPERTIES
		public Vector3 position
		{
			get => transform.position;
			set => transform.position = value;
		}

		public Vector3? prevPosition { get; set; }
		public bool isLocked { get => m_IsLocked; set => m_IsLocked = value; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private bool m_IsLocked;
		#endregion


		#region PUBLIC API
		public override string ToString()
		{
			return $"{name}, {position}, {nameof(isLocked)}={isLocked}";
		}
		#endregion
	}
}
