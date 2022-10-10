using UnityEngine;

namespace Playground.ProcGen
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public abstract class MeshGenerator : MonoBehaviour
    {
        public Vector3[] vertices { get; set; }
		public int[] triangles { get; set; }

		void Start()
        {
            GenerateMesh();
        }

		protected abstract void GenerateMesh();

		protected virtual void UpdateMesh()
        {
            var filter = GetComponent<MeshFilter>();

            filter.mesh.Clear();

            filter.mesh.vertices = vertices;
            filter.mesh.triangles = triangles;

            filter.mesh.RecalculateNormals();
        }

		protected virtual void OnDrawGizmos()
		{
            if (vertices == null)
			{
                return;
			}

			for (int i = 0; i < vertices.Length; i++)
			{
                Gizmos.DrawSphere(vertices[i], 0.1f);
			}
		}
	}
}