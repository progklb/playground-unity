using UnityEngine;

namespace Playground.ProcGen
{
    public class TerrainMeshGenerator : MeshGenerator
    {
        [SerializeField]
        private int m_XSize = 20;
		[SerializeField]
        private int m_ZSize = 20;

        protected override void GenerateMesh()
		{
            int i = 0;

			vertices = new Vector3[(m_XSize + 1) * (m_ZSize  + 1)];

			for (int z = 0; z <= m_ZSize; z++)
			{
				for (int x = 0; x <= m_XSize; x++)
				{
					vertices[i] = new Vector3(x, 0f, z);
					i++;
				}
			}


			UpdateMesh();
		}
	}
}