using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CreateLabel : EditorWindow
{
    private GameObject prefabToClone;
    private string prefabFolderPath = "Assets/Resources/Labels";
    private string materialFolderPath = "Assets/Materials"; // Đường dẫn tới thư mục chứa materials

    [MenuItem("Tools/Prefab and Material Cloner")]
    public static void ShowWindow()
    {
        GetWindow<CreateLabel>("Prefab & Material Cloner");
    }

    private void OnGUI()
    {
        GUILayout.Label("Clone Prefab and Save", EditorStyles.boldLabel);
        prefabToClone = (GameObject)EditorGUILayout.ObjectField("Prefab to Clone", prefabToClone, typeof(GameObject), false);

        // Trường nhập đường dẫn thư mục Prefab
        prefabFolderPath = EditorGUILayout.TextField("Save Clone To", prefabFolderPath);

        materialFolderPath = EditorGUILayout.TextField("Material Folder", materialFolderPath);

        if (GUILayout.Button("Clone Materials"))
        {
            if (Directory.Exists(materialFolderPath))
            {
                CloneOriginalPrefab();
            }
            else
            {
                Debug.LogError("Material folder does not exist!");
            }
        }
    }


    private void CloneOriginalPrefab()
    {
        if (!Directory.Exists(prefabFolderPath))
            Directory.CreateDirectory(prefabFolderPath);

        string[] materialFiles = Directory.GetFiles(materialFolderPath, "*.mat");

        foreach (string materialFile in materialFiles)
        {
            string filename = Path.GetFileNameWithoutExtension(materialFile);

            GameObject clonedPrefab = Instantiate(prefabToClone);
            Material material = AssetDatabase.LoadAssetAtPath<Material>(materialFile);

            //clonedPrefab.GetComponent<DecalProjector>().material = material;

            string prefabName = filename + ".prefab";
            string assetPath = prefabFolderPath + "/" + prefabName;

            PrefabUtility.SaveAsPrefabAsset(clonedPrefab, assetPath);
            DestroyImmediate(clonedPrefab);
        }

        AssetDatabase.Refresh();
    }
}