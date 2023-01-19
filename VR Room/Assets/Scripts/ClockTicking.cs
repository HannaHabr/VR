using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ClockTicking : MonoBehaviour
{
    [SerializeField] private GameObject _secondArrow;
    [SerializeField] private GameObject _minuteArrow;
    [SerializeField] private GameObject _hourArrow;

    private bool _doesSecondArrowExist;
    private bool _doesMinuteArrowExist;
    
    void Start()
    {
        _doesMinuteArrowExist = _minuteArrow != null;
        _doesSecondArrowExist = _secondArrow != null;
        
        SetClockArrows();
    }
    
    void Update()
    {
        SetClockArrows();
    }

    private void SetClockArrows()
    {
        var now = DateTime.Now;
        Debug.Log(now);
        if (_doesMinuteArrowExist)
        {
            RotateArrow(now.Minute, 60, _minuteArrow);
        }

        if (_doesSecondArrowExist)
        {
            RotateArrow(now.Second, 60, _secondArrow);
        }
        
        RotateArrow(now.Hour % 12, 12, _hourArrow);
    }

    private void RotateArrow(int current, int max, GameObject arrow)
    {
        var angle = current / (float) max * 360;
        arrow.transform.localRotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
}
