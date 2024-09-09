using Unity.Burst;
using UnityEngine;
using WRA.Utility;

namespace procedural_shape_generator.Runtime.Scripts.Procedural_Factories.Flat3D
{
    [BurstCompile(CompileSynchronously = true)]
    public static class SimpleFactory
    {
        public static Mesh CreateLineFromCenter(float lenght, float width)
        {
            var mesh = CreateRectangle(lenght, width);
            mesh.name = "ProceduralLine";
            return mesh;
        }
        
        public static Mesh CreateLineFromLeft(float lenght, float width)
        {
            var mesh = CreateRectangle(lenght, width, 0);
            mesh.name = "ProceduralLine";
            return mesh;
        }
        
        public static Mesh CreateSquare(float size, float offsetX = 0.5f, float offsetY = 0.5f)
        {
            var mesh = CreateRectangle(size, size, offsetX, offsetY);
            mesh.name = "ProceduralSquare";
            return mesh;
        }

        public static Mesh CreateRectangle(float width, float height, float offsetX = 0.5f, float offsetY = 0.5f)
        {
            Mesh mesh = new Mesh();
            Vector3[] vertices = new Vector3[4];
            Vector2[] uv = new Vector2[4];
            int[] triangles = new int[6];
            
            float reverseOffsetX = 1 - offsetX;
            float reverseOffsetY = 1 - offsetY;

            vertices[0] = new Vector3(-width * offsetX, -height * offsetY, 0); // left bottom
            vertices[1] = new Vector3(width * reverseOffsetX, -height * offsetY, 0); // right bottom
            vertices[2] = new Vector3(-width * offsetX, height * reverseOffsetY, 0); // left top
            vertices[3] = new Vector3(width * reverseOffsetX, height * reverseOffsetY, 0); // right top

            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(width, 0);
            uv[2] = new Vector2(0, height);
            uv[3] = new Vector2(width, height);

            triangles[0] = 0;
            triangles[1] = 2;
            triangles[2] = 1;

            triangles[3] = 2;
            triangles[4] = 3;
            triangles[5] = 1;

            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.name = "ProceduralSquare";

            return mesh;
        }
        
        public static Mesh CreateTriangle(float width, float height, float rotation = 0, float offsetX = 0.5f, float offsetY= 0.5f)
        {
            return CreateTriangle(MeshMath.GetTriangleVertices(width, height, rotation, offsetX, offsetY));
        }
        
        public static Mesh CreateTriangle(float height, float rotation = 0, float offsetX = 0.5f, float offsetY= 0.5f)
        {
            return CreateTriangle(MeshMath.GetTriangleVertices(height, height, rotation, offsetX, offsetY));
        }
        
        public static Mesh CreateTriangle(Vector3[] veritcies)
        {
            Mesh mesh = new Mesh();
        
            Vector2[] uv = new Vector2[3];
            int[] triangles = new int[3];
            
        
            triangles[0] = 0;
            triangles[1] = 2;
            triangles[2] = 1;
        
            mesh.vertices = veritcies;
            mesh.uv = uv;
            mesh.triangles = triangles;
            mesh.name = "ProceduralTriangle";
        
            return mesh;
        }
        
    }
}