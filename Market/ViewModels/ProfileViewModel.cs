namespace Market.ViewModels;


public partial class ProfileViewModel : BaseViewModel
{

    public string FirstName => "سارا";
    public int Age => _persianService.TotalYears(new DateTime(1987, 5, 23));
    public string GestationalAge => $"{_persianService.TotalWeeksAndDays(new DateTime(2024, 05, 13)).Weeks}هفته و {_persianService.TotalWeeksAndDays(new DateTime(2024, 05, 13)).Days}روز";
    public string Children => $"{0}دختر و {0}پسر";


    public ProfileViewModel()
    {
    }
}
