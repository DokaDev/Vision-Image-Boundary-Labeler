using System.Windows;
using Vision_Image_Boundary_Labeler.Json;

namespace Vision_Image_Boundary_Labeler {
    public partial class LabelMain : Window {
        private LabelClassManager labelClassManager = new();

        public LabelMain() {
            InitializeComponent();
            labelClassManager.JsonFilePath = "C:/Users/Awesome/Desktop/TestPath";
        }

        private void FolderBrowse(object sender, RoutedEventArgs e) {

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            // Desc: Key 0 : Value: "Zero"
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            // Desc: Key 1 : Value: "One"
        }
    }
}
