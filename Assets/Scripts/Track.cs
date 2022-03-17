using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public LineRenderer characterLineRenderer;
    public LineRenderer shadowLineRenderer;

    public int sampleFrequency = 5;
    
    private Control controller;
    private List<Vector3> characterTrack = null;
    private List<Vector3> shadowTrack = null;
    
    void Start()
    {
        controller = GameObject.Find("GameManager").GetComponent<Control>();
        characterTrack = TransmittedData.lastCharacterTrack;
        shadowTrack = TransmittedData.lastShadowTrack;
        if (characterTrack != null && shadowTrack != null)
        {
            DrawTrack();
        }
        characterTrack = new List<Vector3>();
        shadowTrack = new List<Vector3>();
    }

    void Update()
    {
        if (Time.frameCount % sampleFrequency == 0)
        {
            Vector3 tmp = controller.getCharacterCenter();
            if (characterTrack.Count == 0 || !characterTrack[characterTrack.Count - 1].Equals(tmp))
            {
                characterTrack.Add(tmp);
            }
            tmp = controller.getShadowCenter();
            if (shadowTrack.Count == 0 || !shadowTrack[shadowTrack.Count - 1].Equals(tmp))
            {
                shadowTrack.Add(tmp);
            }
        }
    }

    // 将当前轨迹传入被传输数据中，失败重开时获得该数据
    public void BackupTrack()
    {
        TransmittedData.lastCharacterTrack = new List<Vector3>(characterTrack);
        TransmittedData.lastShadowTrack = new List<Vector3>(shadowTrack);
    }

    // 绘制轨迹并清除引用
    private void DrawTrack()
    {
        characterLineRenderer.positionCount = characterTrack.Count;
        characterLineRenderer.SetPositions(characterTrack.ToArray());
        characterTrack = null;

        shadowLineRenderer.positionCount = shadowTrack.Count;
        shadowLineRenderer.SetPositions(shadowTrack.ToArray());  
        shadowTrack = null;
    }
}
