using TMPro;
using UnityEngine;

public class script_time : MonoBehaviour
{
    private TextMeshPro textDisplay;
    
    void Start()
    {
        // Get the TextMeshPro component from this GameObject
        textDisplay = GetComponent<TextMeshPro>();
        
        if (textDisplay == null)
        {
            Debug.LogError("TextMeshPro component not found on this GameObject!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay != null)
        {
            string timeText = System.DateTime.Now.ToString("HH:mm:ss");
            textDisplay.text = timeText;
        }
    }

}
