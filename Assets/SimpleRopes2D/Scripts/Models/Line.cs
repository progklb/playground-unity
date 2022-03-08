using UnityEngine;

namespace SimpleRopes
{
	/// <summary>
	/// Defines a line in 2D space.
	/// </summary>
	public class Line : MonoBehaviour
	{
		#region PROPERTIES
		public Point pointA { get => m_PointA; set => m_PointA = value; }
		public Point pointB { get => m_PointB; set => m_PointB = value; }

		public Vector3 center { get => (pointA.position + pointB.position) / 2; }
		public Vector3 direction { get => (pointA.position - pointB.position).normalized; }

		public float length { get => m_Length; set => m_Length = value; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private LineRenderer m_LineRenderer;

		[Space]

		[SerializeField]
		private Point m_PointA;
		[SerializeField]
		private Point m_PointB;
		[SerializeField]
		private float m_Length;
		#endregion


		#region UNITY EVENTS
		void LateUpdate()
		{
			if (pointA == null || pointB == null)
			{
				return;
			}

			// No, this isn't very efficient. But this is just an experiment after all.
			if (m_LineRenderer != null)
			{
				if (m_LineRenderer.positionCount != 2)
				{
					m_LineRenderer.SetPositions(new Vector3[] { pointA.position, pointB.position });
				}
				else
				{
					m_LineRenderer.SetPosition(0, pointA.position);
					m_LineRenderer.SetPosition(1, pointB.position);
				}
			}
		}

		void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere(pointA.position, 1);
			Gizmos.DrawWireSphere(pointB.position, 1);

			Gizmos.DrawWireSphere(m_LineRenderer.GetPosition(0), 0.75f);
			Gizmos.DrawWireSphere(m_LineRenderer.GetPosition(1), 0.75f);
		}
		#endregion


		#region PUBLIC API
		public override string ToString()
		{
			return $"{name} [{pointA.name}->{pointB.name}], {nameof(length)}={length}";
		}
		#endregion
	}
}
