using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //referencing the text time inside unity
    public Text timeText;
    //the starting time
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        //setting the starting time to time.time (time goes up every second)
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //setting t to time
        float t = Time.time - startTime;
        //some maths for time:
        //1hr
        string timeInHrs = ((int)t / 3600).ToString();
        //60 secs
        string timeInMins = ((int)t / 60).ToString();
        //1 sec
        string timeInSecs = (t % 60).ToString("f2");
        //setting the time text to HH:MM:SS
        timeText.text = timeInHrs + ":" + timeInMins + ":" + timeInSecs;
    }
}
