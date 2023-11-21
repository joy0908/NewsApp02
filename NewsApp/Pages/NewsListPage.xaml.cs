using NewsAPP.Models;
using NewsAPP.Services;

namespace NewsAPP.Pages;

public partial class NewsListPage : ContentPage
{
	public List<Article> ArticlesList;
	public NewsListPage(string categoryName)
	{
		InitializeComponent();
		Title = categoryName;
		GetNews(categoryName);
		ArticlesList = new List<Article>();
	}

	private async void GetNews(string categoryName)
	{
		var apiService = new ApiService();
		var newsReult = await apiService.GetNews(categoryName);
		foreach (var item in newsReult.Articles) 
		{
			ArticlesList.Add(item);
		}
		CvNews.ItemsSource = ArticlesList;
	}

    private void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
        if (selectedItem == null) return;
        Navigation.PushAsync(new NewsDetailPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
        
    }
}