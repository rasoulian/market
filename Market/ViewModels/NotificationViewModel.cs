using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Market.ViewModels;


public partial class NotificationViewModel : BaseViewModel
{
    public ObservableCollection<Notification> Messages { get; private set; } = new();
    public ICommand RefreshCommand => new Command(async () => await RefreshDataAsync());


    public NotificationViewModel()
    {
        PrepareData();
    }

    private void PrepareData()
    {
        var messages = new List<Notification>
        {
            new() {MessageBody= "مشتری گرامی نسخه شما با کدپیگیری 141313 ثبت شد.", At=DateTime.Now.AddMinutes(-1)},
            new() {MessageBody= "مشتری گرامی اطلاعات شما با موفقیت دریافت نمودیم." , At=DateTime.Now.AddMinutes(-2)},
            new() {MessageBody= "بیمار گرامی خوش آمدید.", At = DateTime.Now.AddMinutes(-3)},
        }.OrderByDescending(i => i.At).ToList();
        messages.ForEach(Messages.Add);
    }

    private async Task RefreshDataAsync()
    {
        IsRefreshing = true;
        await Task.Delay(TimeSpan.FromSeconds(3));
        var messages = new List<Notification>
        {
            new() {MessageBody= "پیام جدیدی ندارید."},
        }.OrderByDescending(i => i.At).ToList();
        messages.ForEach(Messages.Add);
        IsRefreshing = false;
    }

}


public class Notification
{
    public string MessageBody { get; set; }
    public DateTime At { get; set; } = DateTime.Now;
}
