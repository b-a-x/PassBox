using PassBox.Mobile.ViewModels;

namespace PassBox.Mobile.Views;

public partial class PasswordInfoListPage : ContentPage
{
	public PasswordInfoListPage()
	{
		InitializeComponent();
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
        base.OnNavigatedTo(args);

        //TODO: ������� ���������, �� ���� �� ���� ��� ��������� CollectionView
        var context = BindingContext as PasswordInfoListViewModel;
        context?.Load();
    }
}