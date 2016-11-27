using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProcessJson
{
    public class JsonDecoded
    {
        public JsonDecoded()
        {
            Children = new List<JsonDecoded>();
        }

        public string Key { get; set; }
        public List<JsonDecoded> Children { get; }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void FormatJsonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(MiniBox.Text))
                {
                    FormBox.Text = JsonConvert.SerializeObject(
                        JsonConvert.DeserializeObject(MiniBox.Text), Formatting.Indented);
                }
            }
            catch (JsonReaderException ex)
            {
                await new MessageDialog($"Error parsing JSON: {ex.Message}").ShowAsync();
            }
        }

        private async void MinifyJsonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(FormBox.Text))
                {
                    MiniBox.Text = JsonConvert.SerializeObject(
                        JsonConvert.DeserializeObject(FormBox.Text), Formatting.None);
                }
            }
            catch (JsonReaderException ex)
            {
                await new MessageDialog($"Error parsing JSON: {ex.Message}").ShowAsync();
            }
        }
    }
}
