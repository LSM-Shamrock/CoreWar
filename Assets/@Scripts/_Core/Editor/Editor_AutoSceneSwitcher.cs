#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public static class Editor_AutoSceneSwitcher
{
    static readonly string SceneRoot = "Assets/@Scenes";
    static readonly Scenes startScene = Scenes.LobbyScene;

    static Editor_AutoSceneSwitcher()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }
    
    static void OnPlayModeChanged(PlayModeStateChange state)
    {
        string startScenePath = $"{SceneRoot}/{startScene.ToString()}.unity";
        string saveScenePathKey = "SAVED_SCENE_PATH";

        if (state == PlayModeStateChange.ExitingEditMode)
        {
            string activeScenePath = EditorSceneManager.GetActiveScene().path;

            EditorPrefs.SetString(saveScenePathKey, activeScenePath);

            if (activeScenePath != startScenePath)
            {
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                    EditorSceneManager.OpenScene(startScenePath);
                else
                    EditorApplication.isPlaying = false;
            }
        }
        if (state == PlayModeStateChange.EnteredEditMode)
        {
            string savedScenePath = EditorPrefs.GetString(saveScenePathKey);
            EditorSceneManager.OpenScene(savedScenePath);
        }
    }
}
#endif