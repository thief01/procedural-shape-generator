using Unity.Burst;
using UnityEngine;
using WRA.Utility;

namespace procedural_shape_generator.Runtime.Scripts.Procedural_Factories.Flat3D
{
    [BurstCompile(CompileSynchronously = true)]
    public static class ArrowFactory
    {
        public static Mesh GenereteLine(float lenght, float height, float offsetX = 0)
        {
            Mesh mesh = new Mesh();
        
            Vector3[] vertices = new Vector3[4];
            Vector2[] uv = new Vector2[4];
            int[] triangles = new int[6];
        
            vertices[0] = new Vector3(-offsetX, -height / 2, 0); // left bottom
            vertices[1] = new Vector3(-offsetX + lenght, -height / 2, 0); // right bottom
            vertices[2] = new Vector3(-offsetX, height / 2, 0); // left top
            vertices[3] = new Vector3(-offsetX + lenght, height / 2, 0); // right top
        
            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(lenght, 0);
            uv[2] = new Vector2(0, height);
            uv[3] = new Vector2(lenght, height);
        
            triangles[0] = 0;
            triangles[1] = 2;
            triangles[2] = 1;
        
            triangles[3] = 2;
            triangles[4] = 3;
            triangles[5] = 1;
        
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.name = "ProceduralLine";
        
            return mesh;
        }
        
        public static Mesh GenerateArrow(float lineLenght, float lineHeight, float arrrowHeadLenght, float arrowHeadHeight, float offsetX= 0.5f)
        {
            offsetX = Mathf.Clamp(offsetX, 0, 1);
            var offsetValue = (lineLenght + arrrowHeadLenght) * offsetX;
            
            var line = GenereteLine(lineLenght, lineHeight, offsetValue);
            var triangleVerticies = MeshMath.GetTriangleVertices(arrowHeadHeight, arrrowHeadLenght, -90);
            for (int i = 0; i < triangleVerticies.Length; i++)
            {
                triangleVerticies[i] += new Vector3(lineLenght - offsetValue + arrowHeadHeight / 2, 0, 0);
            }
            var triangle = SimpleFactory.CreateTriangle(triangleVerticies);
            
            var mesh = new Mesh();
            mesh = MeshUtility.Combine(line, triangle);
            mesh.name = "ProceduralArrow";
            return mesh;
        }
    }
}
