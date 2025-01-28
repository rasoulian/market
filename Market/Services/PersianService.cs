using System.Globalization;

namespace Market.Services;

public class PersianService
{
    private PersianCalendar _persianCalendar = new();

    public string GetDate() => $"{_persianCalendar.GetYear(DateTime.Now):0000}/{_persianCalendar.GetMonth(DateTime.Now):00}/{_persianCalendar.GetDayOfMonth(DateTime.Now):00}";

    public string GetTime() => $"{_persianCalendar.GetHour(DateTime.Now):00}:{_persianCalendar.GetMinute(DateTime.Now):00}";

    public string GetSimpleCode(string nationalId = "2939960232")
    {
        string code = nationalId.Substring(Random.Shared.Next(0, 6), 4);
        if (code.StartsWith("0")) code = nationalId.Substring(Random.Shared.Next(0, 5), 4);
        if (code.StartsWith("0")) code = nationalId.Substring(Random.Shared.Next(0, 4), 4);
        if (code.StartsWith("0")) code = nationalId.Substring(Random.Shared.Next(0, 3), 4);
        return code;
    }

    public string ToPersian(DateTime at)
    {
        return $"{_persianCalendar.GetYear(DateTime.Now):0000}/{_persianCalendar.GetMonth(DateTime.Now):00}/{_persianCalendar.GetDayOfMonth(DateTime.Now):00} {_persianCalendar.GetHour(DateTime.Now):00}:{_persianCalendar.GetMinute(DateTime.Now):00}";
    }


    public int TotalYears(DateTime date)
    {
        var today = DateTime.Today;
        var a = (today.Year * 100 + today.Month) * 100 + today.Day;
        var b = (date.Year * 100 + date.Month) * 100 + date.Day;
        return (a - b) / 10000;
    }

    public (int Years, int Weeks, int Days) TotalWeeksAndDays(DateTime date)
    {
        var today = DateTime.Today;
        var totalDays = (today - date).Days;
        int remainingDays = totalDays % 365;
        int years = totalDays / 365;

        // Adjust for leap years
        for (int i = date.Year; i <= today.Year; i++)
        {
            if (DateTime.IsLeapYear(i) && date <= new DateTime(i, 2, 28) && today >= new DateTime(i, 2, 28))
            {
                remainingDays--;
            }
        }

        int weeks = remainingDays / 7;
        int days = remainingDays % 7;

        return (years, weeks, days);
    }


}