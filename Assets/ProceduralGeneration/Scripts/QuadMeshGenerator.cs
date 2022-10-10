using UnityEngine;

namespace Playground.ProcGen
{
    public class QuadMeshGenerator : MeshGenerator
    {
        protected override void GenerateMesh()
		{
            var origin = transform.position;

            vertices = new Vector3[4]{
				origin + new Vector3(0f, 0f, 0f),
				origin + new Vector3(0f, 0f, 1f),
				origin + new Vector3(1f, 0f, 0f),
				origin + new Vector3(1f, 0f, 1f)
			};

            triangles = new int[6] {
				0, 1, 2,
                1, 3, 2
            };

			UpdateMesh();
		}
	}
}