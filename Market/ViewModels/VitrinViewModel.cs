using System.Collections.ObjectModel;

namespace Market.ViewModels;

public partial class VitrinViewModel : BaseViewModel
{
    public ObservableCollection<CollectionItem> Products1 { get; private set; } = new();
    public ObservableCollection<Product> Products2 { get; private set; } = new();

    public VitrinViewModel()
    {
        PrepareData();
    }

    private void PrepareData()
    {
        new List<CollectionItem>
        {
            new() { Image = "dotnet_bot.png", Title = "محصول یک", Description = "شرکت اول" },
            new() { Image = "dotnet_bot.png", Title = "محصول دو", Description = "شرکت دوم" },
            new() { Image = "dotnet_bot.png", Title = "محصول سه", Description = "شرکت سوم" },
            new() { Image = "dotnet_bot.png", Title = "محصول چهار", Description = "شرکت چهارم" },
            new() { Image = "dotnet_bot.png", Title = "محصول پنج", Description = "شرکت پنجم" }
        }.OrderByDescending(i => Guid.NewGuid()).ToList().ForEach(Products1.Add);

        new ObservableCollection<Product>
        {
            new() { Id=1, Name ="گارداسیل 9", Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=2, Name ="گارداسیل 4",Image="prd_gardasil4.png", Icon ="\uea78"},
            new() { Id=3, Name ="گارداسیل 2",Image="prd_gardasil2.png", Icon ="\uf21d"},
            new() { Id=4, Name ="ژل بهداشتی",Image="prd_gardasil9.png", Icon ="\ue138"},
            new() { Id=5, Name ="نوار بهداشتی", Image="prd_gardasil9.png",Icon ="\uef55"},
            new() { Id=6, Name ="پد ضد درد", Image="prd_gardasil9.png",Icon ="\uef55"},
            new() { Id=7, Name ="حوله حرارتی",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=8, Name ="تست قندخون",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=9, Name ="تب سنج",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=10, Name ="پد بهداشتی",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=11, Name ="کاپ قاعدگی",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=12, Name ="شورت ضدبو قاعدگی",Image="prd_gardasil9.png",Icon ="\uef55"},
            new() { Id=13, Name ="تامپون", Image="prd_gardasil9.png",Icon ="\uef55"},
            new() { Id=14, Name ="کرم روشن کننده بیکینی",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=15, Name ="فلاسک گرمکن شیر",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=16, Name ="شیشه شیر ضد نفخ", Image="prd_gardasil9.png",Icon ="\uef55"},
            new() { Id=17, Name ="سرنگ داروخوری با سرپستانکی",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=18, Name ="برچسب دفع کننده حشرات",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=19, Name ="ناخنگیر برقی کودک",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=20, Name ="کاندوم",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=21, Name ="کرم تاخیری",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=22, Name ="ژل لوبریکانت",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=23, Name ="کیت آمنیوشور",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=24, Name ="آیودی مسی",Image="prd_gardasil9.png", Icon ="\uef55"},
            new() { Id=25, Name ="قطره بیبی کر",Image="prd_gardasil9.png", Icon ="\uef55"},
        }.OrderByDescending(i => i.Id).ToList().ForEach(Products2.Add); ;

    }
}

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Image { get; set; }
    public string Icon { get; set; }
}

public class CollectionItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}