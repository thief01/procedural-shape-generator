using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

namespace WRA.Utility
{
    [BurstCompile(CompileSynchronously = true)]
    public class MeshUtility
    {
        public static Mesh Combine(params Mesh[] meshes)
        {
            CombineInstance[] combine = new CombineInstance[meshes.Length];
            for (int i = 0; i < meshes.Length; i++)
            {
                combine[i].mesh = meshes[i];
                combine[i].transform = Matrix4x4.identity;
            }

            Mesh mesh = new Mesh();
            mesh.CombineMeshes(combine);
            return mesh;
        }
    }
}