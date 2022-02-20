using UnityEngine;

namespace SimpleRopes
{
	/// <summary>
	/// Simple controller that allows us to manipulate points/lines.
	/// </summary>
	public class InputController : MonoBehaviour
	{
		#region PUBLIC API
		[SerializeField]
		private Transform m_Container;
		[SerializeField]
		private PointRenderer m_PointPrefab;
		[SerializeField]
		private LineRenderer m_LinePrefab;

		[Space]
		private bool m_ClearOnStart;
		#endregion


		#region UNITY EVENTS
		void Start()
		{
			if (m_ClearOnStart)
			{
				for (int i = m_Container.childCount - 1; i >= 0; i--)
				{
					Destroy(m_Container.GetChild(i));
				}
			}
		}
		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				var pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				var point = new Point(pos.x, pos.y);
				var pointRenderer = Instantiate(m_PointPrefab, m_Container);
				pointRenderer.Set(point);

				// if (not over another object)
				// {
				//	Create point
				// }
				// else
				// {
				//  Create line
				// }


			}
			else
			{

			}
		}
		#endregion
	}
}
