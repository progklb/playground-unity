using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using System;

namespace SimpleRopes
{
	public class PointRenderer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		#region TYPES
		public enum State
		{
			Normal,
			Hover,
			Click
		}
		#endregion


		#region PROPERTIES
		public Point model { get; set; }

		public State state { get; private set; } = State.Normal;
		#endregion


		#region VARIABLES
		[SerializeField]
		private Image m_Image;

		[SerializeField]
		private ColorBlock m_Colours;
		#endregion


		#region UNITY EVENTS
		void Start()
		{
			OnPointerExit(null);
		}
		#endregion


		#region PUBLIC API
		public void Set(Point model)
		{
			this.model = model;

			var pos = transform.position;
			pos.x = model.position.x;
			pos.y = model.position.y;
			transform.position = pos;
		}
		#endregion


		#region INTERFACE IMPLEMENTATIONS
		public void OnPointerEnter(PointerEventData eventData)
		{
			state = State.Hover;
			m_Image.color = m_Colours.highlightedColor;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			state = State.Normal;
			m_Image.color = m_Colours.normalColor;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			state = State.Click;
			m_Image.color = m_Colours.pressedColor;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			state = State.Hover;
			m_Image.color = m_Colours.highlightedColor;
		}
		#endregion
	}
}
