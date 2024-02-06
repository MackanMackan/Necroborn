using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BugReporter : MonoBehaviour
{
    [SerializeField, TextArea] private string m_bugDescription;
    [SerializeField] private string m_branch;
    [SerializeField] private string m_mission;
    [SerializeField] private string m_missionObjective;
    [SerializeField] private Vector3 m_carPosition;
    [SerializeField] private bool m_canReproduce;
    [SerializeField] private List<string> m_reproduceSteps;
    [SerializeField] private Frequency m_frequency = Frequency.IfYouAreUnlucky;
    [SerializeField] private Severity m_severity = Severity.Minor;
    [SerializeField] private Type m_type = Type.Code;

    [Header("Screenshots")]
    [SerializeField] private bool m_takeGameViewScreen;
    [SerializeField] private bool m_takeSceneViewScreen;


    private string m_scene;
    private int m_priority;

    string m_date;
    string m_mainBugfolderPath;
    string m_thisBugfolderPath;

    [ContextMenu("Create Report")]
    public void CreateReport()
    {
        m_date = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        m_mainBugfolderPath = Directory.GetParent(Application.dataPath).FullName + "\\BugReports\\";
        m_thisBugfolderPath = $"{m_mainBugfolderPath}{Application.productName}{m_date}";

        string name = Application.productName + m_date + ".txt";
        string reportPath = Path.Combine(m_mainBugfolderPath, m_thisBugfolderPath, name);

        if (!Directory.Exists(m_mainBugfolderPath))
            Directory.CreateDirectory(m_mainBugfolderPath);

        Directory.CreateDirectory(m_thisBugfolderPath);
        StreamWriter writer = new StreamWriter(reportPath);

        m_scene = SceneManager.GetActiveScene().name;
        m_priority = (int)m_frequency + (int)m_severity;

        writer.WriteLine($"Branch: {m_branch} \n" +
            $"Scene: {m_scene} \n" +
            $"Mission: {m_mission} \n" +
            $"Mission Objective: {m_missionObjective} \n" +
            $"Car Position: {m_carPosition} \n" +
            $"Can Reproduce: {m_canReproduce} \n");

        if (m_canReproduce)
            for(int step = 0; step < m_reproduceSteps.Count; step++)
            {
                writer.WriteLine($"Step {(step + 1)}. {m_reproduceSteps[step]} \n");
            }

        writer.WriteLine($"Frequency: {m_frequency} \n" +
            $"Severity: {m_severity} \n" +
            $"Type: {m_type} \n" +
            $"Priority Score: {m_priority}");
            
        writer.Close();

        if (m_takeGameViewScreen)
            CaptureGameView();

        if (m_takeSceneViewScreen)
            CaptureSceneView();

        Process.Start("explorer.exe", "/select, " + reportPath);
    }

    [ContextMenu("Take Screenshot")]
    public void CaptureGameView()
    {
        string name = Application.productName + m_date + ".png";
        string screenshotPath = Path.Combine(m_mainBugfolderPath, m_thisBugfolderPath, name);

        ScreenCapture.CaptureScreenshot(screenshotPath, 2);
    }

    [MenuItem("Window/Capture SceneView")]
    public void CaptureSceneView()
    {
        string name = Application.productName + m_date + "SceneView.png";
        string screenshotPath = Path.Combine(m_mainBugfolderPath, m_thisBugfolderPath, name);
        CaptureSceneView(screenshotPath);
    }

    public void CaptureSceneView(string pngFilename)
    {
        CaptureSceneView(SceneView.lastActiveSceneView, pngFilename);
    }

    public void CaptureSceneView(SceneView sceneView, string pngFilename)
    {
        EditorApplication.delayCall += () => {
            EditorWindow editorWindow = sceneView;

            Rect pixelPosition = editorWindow.position;
            int width = (int)pixelPosition.width;
            int height = (int)pixelPosition.height;

            Color[] pixels = UnityEditorInternal.InternalEditorUtility.ReadScreenPixel(pixelPosition.position, width, height);
            Texture2D tex2d = new Texture2D(width, height, TextureFormat.RGB24, false);

            tex2d.SetPixels(pixels);
            File.WriteAllBytes(pngFilename, tex2d.EncodeToPNG());
        };
    }

    private enum Severity
    {
        FatalCrashing, GameBreaking, ImmersionBreaking, NoticableAnnoyance, Minor, 
    }

    private enum Frequency
    {
        Unavoidable, EveryTime, Sometimes, IfYouAreUnlucky, 
    }

    private enum Type
    {
        Code, Artist, LevelDesign, SFX, Unsure, Multiple, 
    }
}