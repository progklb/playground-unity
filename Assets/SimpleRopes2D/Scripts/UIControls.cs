using UnityEngine;
using UnityEngine.UI;

namespace SimpleRopes
{
	/// <summary>
	/// Simple UI interface to provide controls for the simulation.
	/// </summary>
	public class UIControls : MonoBehaviour
	{
		#region PROPERTIES
		private SimulationController simulationController { get => SimulationController.instance; }
		#endregion


		#region VARIABLE
		[SerializeField]
		private Button m_StartButton;
		[SerializeField]
		private Button m_StopButton;
		[SerializeField]
		private Button m_ClearButton;
		#endregion


		#region UNITY EVENTS
		void Start()
		{
			m_StartButton.onClick.AddListener(StartSimulating);
			m_StopButton.onClick.AddListener(StopSimulating);
			m_ClearButton.onClick.AddListener(Clear);


		}
		#endregion


		#region PUBLIC API
		public void StartSimulating()
		{
			simulationController.SetUpdateMode(SimulationController.UpdateMode.Update);
		}

		public void StopSimulating()
		{
			simulationController.SetUpdateMode(SimulationController.UpdateMode.None);
		}

		public void Clear()
		{
			simulationController.Clear();
		}

		public void Load(string prefabPath)
		{
			var asset = Resources.Load<GameObject>(prefabPath);
			SimulationController.instance.Load(asset);
		}
		#endregion


		#region HELPER FUNCTIONS
		void Refresh()
		{
			m_StartButton.interactable = !simulationController.isSimulating;
			m_StopButton.interactable = simulationController.isSimulating;
			m_ClearButton.interactable = !simulationController.isSimulating;
		}
		#endregion
	}
}
