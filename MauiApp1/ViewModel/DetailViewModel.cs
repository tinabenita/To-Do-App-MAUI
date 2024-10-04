﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.ViewModel;

[QueryProperty("Text", "Text" )]
public partial class DetailViewModel : ObservableObject
{
	[ObservableProperty]
	string text;

	[RelayCommand]
	async Task GoBack()
	{
		await Shell.Current.GoToAsync("..");
	}
}	
