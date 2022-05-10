using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace DragDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            panel1.AllowDrop = true; // Возможность использовать Drop на StackPanel
        }

        /// <summary>
        /// Вызывается после дропа файла в область StackPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Drop(object sender, DragEventArgs e)
        {
            string[] imgPath = (string[])e.Data.GetData(DataFormats.FileDrop); // Пусть к файлу
            Uri uri = new Uri(imgPath[0], UriKind.RelativeOrAbsolute);

            ImageBrush imageBrush = new ImageBrush(); // Для запоолнения области изображением

            try
            {
                imageBrush.Stretch = Stretch.Uniform; // Способ заливки изображения (в данном случае без нарушения пропорций изображения)
                imageBrush.ImageSource = new BitmapImage(uri);
                panel1.Background = imageBrush;
            }
            catch (Exception)
            {
                MessageBox.Show("Можно загружать только картинки!!!", "НЕВЕРНЫЙ ТИП ФАЙЛА!!!");
                throw;
            }
        }
    }
}
