using UnityEngine;

namespace WRA.Procedural.Arrow
{
    [RequireComponent(typeof(MeshFilter) , typeof(MeshRenderer))]
    [ExecuteInEditMode]
    public abstract class ProceduralObject : MonoBehaviour
    {
        protected MeshFilter meshFilter;
        protected MeshRenderer meshRenderer;
        
        protected virtual void Awake()
        {
            meshFilter = GetComponent<MeshFilter>();
            meshRenderer = GetComponent<MeshRenderer>();
            GenerateObject();
        }

        public void Refresh()
        {
            GenerateObject();
        }
        
        protected abstract void GenerateObject();
    }
}
