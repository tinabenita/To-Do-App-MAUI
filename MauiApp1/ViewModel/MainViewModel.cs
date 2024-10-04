using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Networking;
namespace MauiApp1.ViewModel;

public partial class MainViewModel : ObservableObject
{
	IConnectivity _connectivity;
	public MainViewModel(IConnectivity connectivity)
	{
		Items = new ObservableCollection<string>();
		_connectivity = connectivity ?? throw new ArgumentNullException(nameof(connectivity));
	}

	[ObservableProperty]
	ObservableCollection<string> items;

	[ObservableProperty]
	string text;

	[RelayCommand]
	async void Add()
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return;
		}

		if (_connectivity.NetworkAccess != NetworkAccess.Internet)
		{
			await Shell.Current.DisplayAlert("Uh oh!", "No internet", "OK");
			return;
			
		}

		Items.Add(Text);
		Text = string.Empty;


	}

	[RelayCommand]
	void Delete(string s)
	{
		if (Items.Contains(s))
		{
			Items.Remove(s);
		}
	}

	[RelayCommand]
	async Task Tap(string s)
	{
		await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
	}
}
