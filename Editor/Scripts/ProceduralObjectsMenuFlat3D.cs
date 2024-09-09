#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace WRA.Procedural.Arrow.Editor
{
    public static class ProceduralObjectsMenuFlat3D
    {
        private const string FLAT_3D_PATH = "GameObject/Procedural/Flat 3D";
        // private const string FLAT_2D_PATH = "GameObject/Procedural/Sprites 2D";
        // private const string MESH_3D_PATH = "GameObject/Procedural/Mesh 3D";

        #region FLAT_3D
        
        [MenuItem(FLAT_3D_PATH + "/Procedural Line")]
        public static void CreateProceduralLine()
        {
            CreateProceduralObject<ProceduralLine>("Procedural Line");
        }
    
        [MenuItem(FLAT_3D_PATH + "/Simple Procedural Arrow")]
        public static void CreateSimpleProceduralArrow()
        {
            CreateProceduralObject<SimpleProceduralArrow>("Simple Procedural Arrow");
        }
        
        #endregion

        #region FLAT_2D
        
        public static void CreateProceduralTriangle()
        {
            // CreateProceduralObject<ProceduralTriangle>("Procedural Triangle");
        }

        #endregion
        
        private static void CreateProceduralObject<T>(string name) where T : MonoBehaviour
        {
            GameObject g = new GameObject(name);
            g.AddComponent<T>();

            Selection.activeGameObject = g;
            Undo.RegisterCreatedObjectUndo(g, $"Create {name}");
            EditorSceneManager.MarkAllScenesDirty();
        }
    }
}
#endif