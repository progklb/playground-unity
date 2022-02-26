using UnityEngine;

namespace SimpleRopes
{
	/// <summary>
	/// Simple controller that allows us to manipulate points/lines.
	/// </summary>
	public class InputController : MonoBehaviour
	{
		#region PROPERTIES
		private Point selectedPoint { get; set; }
		#endregion


		#region VARIABLES
		[SerializeField]
		private Color m_UnselectedColor = Color.white;
		[SerializeField]
		private Color m_SelectedColor = Color.red;
		[SerializeField]
		private Color m_LockedColor = Color.blue;
		#endregion


		#region UNITY EVENTS
		void Update()
		{
			if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
			{
				var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

				if (ClickPoint(worldPos, out Point point))
				{
					if (Input.GetMouseButtonDown(0))
					{
						if (selectedPoint == null)
						{
							SelectPoint(point, true);
						}
						else if (selectedPoint == point)
						{
							SelectPoint(selectedPoint, false);
						}
						else
						{
							CreateLine(selectedPoint, point);
							SelectPoint(selectedPoint, false);
						}
					}

					if (Input.GetMouseButtonDown(1))
					{
						LockPoint(point, !point.isLocked);
					}
				}
				else
				{
					if (selectedPoint != null)
					{
						SelectPoint(selectedPoint, false);
					}
					else
					{
						SelectPoint(selectedPoint, false);
						CreatePoint(worldPos - new Vector3(0f, 0f, -10f));
					}
				}
			}
		}
		#endregion


		#region HELPER FUNCTIONS
		bool ClickPoint(Vector3 clickPos, out Point point)
		{
			if (Physics.Raycast(clickPos, Vector3.forward, out RaycastHit hit))
			{
				point = hit.collider.gameObject.GetComponent<Point>();
				return point != null;
			}

			point = null;
			return false;
		}

		void SelectPoint(Point point, bool selected)
		{
			if (point != null)
			{
				point.GetComponent<MeshRenderer>().material.color = selected ? m_SelectedColor : m_UnselectedColor;
				selectedPoint = selected ? point : null;
			}
		}

		void LockPoint(Point point, bool locked)
		{
			if (point != null)
			{
				point.isLocked = locked;
				point.GetComponent<MeshRenderer>().material.color =
					locked ? m_LockedColor :
					selectedPoint == point ? m_SelectedColor :
					m_UnselectedColor;
			}
		}

		void CreatePoint(Vector3 pos)
		{
			SimulationController.instance.CreatePoint(pos);
		}

		void CreateLine(Point a, Point b)
		{
			SimulationController.instance.CreateLine(a, b);
		}
		#endregion
	}
}
