using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;
using System.IO;

public class UIGazePoint : MonoBehaviour
{
    private Image image;
	private string gazeJsonPath;
	private string gazeInfo;

    void Awake()
    {
        image = this.GetComponent<Image>();
		gazeJsonPath = Application.streamingAssetsPath+"\\Json\\GazeJson.txt";
		if (File.Exists(gazeJsonPath))
		{
			File.Delete(gazeJsonPath);
		}
    }
    void Update()
    {
        GazePoint gazePoint=TobiiAPI.GetGazePoint();
        image.transform.position = gazePoint.Screen;
        GameObject go = TobiiAPI.GetFocusedObject();
		WriteGazeInfo(gazePoint);
    }
	private void WriteGazeInfo(GazePoint gazePoint)
	{
		gazeInfo = "Gaze," + gazePoint.Viewport.x + "," + gazePoint.Viewport.y + "," + gazePoint.Timestamp + "," + gazePoint.PreciseTimestamp + "\n";
		FileStream fs = new FileStream(gazeJsonPath, FileMode.Append);
		StreamWriter sw = new StreamWriter(fs);
		sw.Write(gazeInfo);
		sw.Flush();
		sw.Close();
		fs.Close();
	}
}
