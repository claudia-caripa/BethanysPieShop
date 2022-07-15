using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels;

//This is a model for the view that will contain the IEnumerable<Pie> and the CurrentCategory
public class PieListViewModel
{

    public IEnumerable<Pie> Pies { get; }

    public string? CurrentCategory { get; }

    public PieListViewModel(IEnumerable<Pie> pies, string? currentCategory)
    {
        Pies = pies;
        CurrentCategory = currentCategory;
    }
}
