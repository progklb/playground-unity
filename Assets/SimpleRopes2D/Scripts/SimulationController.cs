using UnityEngine;

using System.Collections.Generic;

using Utilities.Frameworks;

namespace SimpleRopes
{
	public class SimulationController : Singleton<SimulationController>
	{
		#region TYPES
		public enum UpdateMode
		{
			None,
			Update,
			FixedUpdate
		}
		#endregion


		#region PROPERTIES
		public List<Point> points { get; private set; } = new List<Point>();
		public List<Line> lines { get; private set; } = new List<Line>();
		#endregion


		#region VARIABLES
		[SerializeField]
		private Transform m_Container;

		[SerializeField]
		private Point m_PointPrefab;
		[SerializeField]
		private Line m_LinePrefab;

		[Space]

		[SerializeField]
		private UpdateMode m_UpdateMode = UpdateMode.Update;
		[SerializeField]
		private Vector3 m_Gravity = new Vector3(0f, -9.8f, 0f);
		[SerializeField]
		private bool m_ClearOnStart;
		#endregion


		#region UNITY EVENTS
		void Start()
		{
			if (m_ClearOnStart)
			{
				Clear();
			}
		}

		void Update()
		{
			if (m_UpdateMode == UpdateMode.Update)
			{
				Simulate(Time.deltaTime);
			}
		}

		void FixedUpdate()
		{
			if (m_UpdateMode == UpdateMode.FixedUpdate)
			{
				Simulate(Time.fixedDeltaTime);
			}
		}
		#endregion


		#region PUBLIC API
		public void Clear()
		{
			points.ForEach(x => Destroy(x.gameObject));
			//lines.ForEach(x => Destroy(x.gameObject));

			points.Clear();
			lines.Clear();
		}

		public Point CreatePoint(Vector3 pos)
		{
			Debug.Log($"Creating point: {pos}");

			var point = Instantiate(m_PointPrefab, m_Container, worldPositionStays: false) as Point;
			point.position = pos;
			point.prevPosition = pos;
			points.Add(point);

			return point;
		}

		public Line CreateLine(Point a, Point b)
		{
			throw new System.NotImplementedException();
		}

		public void Simulate(float deltaTime)
		{
			foreach (var p in points)
			{
				if (!p.isLocked)
				{
					var posBeforeUpdate = p.position;

					p.position += p.position - p.prevPosition;
					p.position += m_Gravity * deltaTime * deltaTime;

					p.prevPosition = posBeforeUpdate;
				}
			}
		}
		#endregion
	}
}
