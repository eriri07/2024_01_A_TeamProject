using System;

public class CalendarManager
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
        currentDate = currentDate.AddMonths(2);
    }
}
