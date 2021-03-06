﻿using ResSched.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResSched.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditResourceDetailsPage : ContentPage
    {
        private EditResourceDetailsViewModel viewModel;

        public EditResourceDetailsPage(EditResourceDetailsViewModel _viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = _viewModel;
        }

        private void Cancel_OnClicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void Save_OnClicked(object sender, System.EventArgs e)
        {
            if (viewModel != null)
            {
                var result = await viewModel.SaveAsync();
                if (result)
                {
                    await DisplayAlert("Success", "Resource was updated", "OK");
                }
                else
                {
                    await DisplayAlert("Failure", "Resource was not updated! Please check the logs for error info.", "OK");
                }

                Navigation.PopModalAsync();
            }
        }
    }
}