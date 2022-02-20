using UnityEngine;

namespace SimpleRopes
{
	/// <summary>
	/// Defines a single point in 2D space.
	/// </summary>
	public class Point
	{
		#region VARIABLES
		public Vector2 position { get; set; }
		public bool locked { get; set; }
		#endregion


		#region CONSTRUCTORS
		public Point(float x, float y, bool locked = false)
		{
			this.position = new Vector2(x, y);
			this.locked = locked;
		}
		#endregion
	}
}
