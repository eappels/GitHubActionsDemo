using CommunityToolkit.Mvvm.ComponentModel;
using GitHubActionsDemoApp.Data.Models;
using GitHubActionsDemoApp.Interfaces;

namespace GitHubActionsDemoApp.ViewModels;

public partial class DemoViewModel : ObservableObject
{

    private readonly IRepository<DemoContact> contactRepository;

    public DemoViewModel(IRepository<DemoContact> contactRepository)
    {
        this.contactRepository = contactRepository;
        DemoContacts = new List<DemoContact>();
    }

    public async Task LoadDataRequest()
    {
        DemoContacts = await contactRepository.GetAllAsync();        
    }

    [ObservableProperty]
    public List<DemoContact> demoContacts;
}