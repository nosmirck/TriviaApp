using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TriviaApp.Views.ContentViews
{
	public partial class QuestionItem : ContentView
	{
		public QuestionItem()
		{
			InitializeComponent();
		}
		public void HandleItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) return;
			((ListView)sender).SelectedItem = null;
		}
	}
}