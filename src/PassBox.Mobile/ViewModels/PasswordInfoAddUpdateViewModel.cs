using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PassBox.Mobile.DataBase;
using PassBox.Mobile.Models;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;

namespace PassBox.Mobile.ViewModels;

[QueryProperty(nameof(PasswordInfo), nameof(PasswordInfo))]
public partial class PasswordInfoAddUpdateViewModel : BaseViewModel
{
    private ApplicationContext _context;
    public PasswordInfoAddUpdateViewModel(ApplicationContext context)
    {
        _context = context;
    }

    [ObservableProperty]
    private PasswordInfo _passwordInfo = new PasswordInfo();

    [RelayCommand]
    public async void AddUpdatePasswordInfo()
    {
        var result = false;
        if(PasswordInfo?.Id != Guid.Empty)
        {
            _context.PasswordInfos.Add(PasswordInfo);
            _context.SaveChanges();
            result = true;
        }
        else
        {
            //костыль
            if(PasswordInfo != null)
            {
                _context.PasswordInfos.Add(PasswordInfo.Create<PasswordInfo>(x => {
                    x.Data = PasswordInfo.Data;
                    x.Name = PasswordInfo.Name;
                }));
                _context.SaveChanges();
                result = true;
            }
        }

        if(result)
        {
            await Shell.Current.DisplayAlert("Password add", "Password added to PasswordInfo table", "OK");
        }
        else
        {
            await Shell.Current.DisplayAlert("Not added", "Something went wrong while adding password", "OK");
        }
    }

    [RelayCommand]
    public async void Back()
    {
        await Shell.Current.GoToAsync($"//{nameof(PasswordInfoListPage)}");
    }
}
