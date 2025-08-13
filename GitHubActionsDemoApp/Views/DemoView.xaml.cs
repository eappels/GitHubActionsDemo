using GitHubActionsDemoApp.ViewModels;

namespace GitHubActionsDemoApp.Views;

public partial class DemoView : ContentPage
{
	public DemoView(DemoViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ((DemoViewModel)BindingContext).LoadDataRequest();
    }
}