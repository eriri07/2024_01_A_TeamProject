using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarManager : MonoBehaviour
{
    private DateTime currentDate;

    public CalendarManager(DateTime startDate)
    {
        currentDate = startDate;
    }

    public DateTime GetCurrentDate()
    {
        return currentDate;
    }

    public void AdvanceThreeMonths()
    {
        currentDate = currentDate.AddMonths(3);
    }
}
