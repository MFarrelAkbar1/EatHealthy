using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Collections.ObjectModel;

namespace EatHealthyWPF
{
    public partial class ResepMakanan : Window
    {
        public ObservableCollection<Recipe?> Recipes { get; set; }

        public ResepMakanan()
        {
            InitializeComponent();
            Loaded += ResepMakanan_Loaded;

            Recipes = new ObservableCollection<Recipe?>();
        }

        private async void ResepMakanan_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var endpoint = "https://raw.githubusercontent.com/MFarrelAkbar1/EatHealthy/resep.json";
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(endpoint);

                    // Check if the response is successful (status code 2xx)
                    if (!string.IsNullOrEmpty(response))
                    {
                        // Check if the response is an array, if not, wrap it in an array
                        if (!response.Trim().StartsWith("["))
                        {
                            response = "[" + response + "]";
                        }

                        var recipesJson = JArray.Parse(response);
                        // Update Recipes with parsed data
                        UpdateRecipes(recipesJson);
                        // Update UI with fetched recipes on the UI thread
                        Dispatcher.Invoke(() => UpdateUIWithRecipes());
                    }
                    else
                    {
                        MessageBox.Show("Empty response", "API Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateRecipes(JArray recipesJson)
        {
            foreach (var recipeJToken in recipesJson)
            {
                var title = recipeJToken["title"]?.ToString();
                var ingredients = recipeJToken["ingredients"]?.ToObject<List<string>>() ?? new List<string>();
                var directions = recipeJToken["directions"]?.ToObject<List<string>>() ?? new List<string>();

                var recipe = new Recipe()
                {
                    Title = title,
                    Ingredients = ingredients,
                    Directions = directions
                };

                Recipes.Add(recipe);
            }
        }


        private void UpdateUIWithRecipes()
        {
            recipeItemsControl.ItemsSource = Recipes;
        }

        public class Recipe
        {
            public string? Title { get; set; } // Make title nullable
            public List<string>? Ingredients { get; set; } // Make ingredients nullable
            public List<string>? Directions { get; set; } // Make steps nullable
        }
    }
}
