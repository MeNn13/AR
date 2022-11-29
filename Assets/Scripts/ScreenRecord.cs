using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRecord : MonoBehaviour
{
    bool flag = false;
    [SerializeField]private AndroidUtils _androidUtils;
    [SerializeField] private Animation _animation;
    public void Record()
    {
        if (!flag)
        {
            OnClickStartRecord();
            flag = true;
        }
        else
        {
            OnClickStopRecord();
            flag = false;
        }
    }

    private void OnClickStartRecord()
    {
        _androidUtils.StartRecording();
        _animation["Record"].speed = 1f;
        _animation.Play();
    }

    private void OnClickStopRecord()
    {
        _androidUtils.StopRecording();
        float desired_play_time = 0.0f;
        _animation["Record"].time = desired_play_time;
        _animation["Record"].speed = 0.0f;
        _animation.Play("Record");
    }
}
