using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using Vision_Image_Boundary_Labeler.Json;

namespace Vision_Image_Boundary_Labeler {
    /// <summary>
    /// Interaction logic for SetClassWindow.xaml
    /// </summary>
    public partial class SetClassWindow : Window {
        private LabelClassManager labelClassManager = new();
        private static int IndexNumber = 0;
        public SetClassWindow() {
            InitializeComponent();
            labelClassManager.JsonFilePath = "C:/Users/Awesome/Desktop/TestPath";
            RefreshListView();
        }

        private void RefreshListView() {
            ClassListView.Items.Clear();
            labelClassManager.ShowBoundaryClass(ref ClassListView);
        }

        private void btnAddClass_Click(object sender, RoutedEventArgs e) {
            // Desc: TextBox 값 유효성 확인
            if (string.IsNullOrEmpty(txtLabelName.Text)) return;
            labelClassManager.AddValue(txtLabelName.Text);
            txtLabelName.Clear();

            RefreshListView();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) {
            labelClassManager.ClearValue();
            RefreshListView();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            labelClassManager.Save();
        }
    }
}
