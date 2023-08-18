using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Vision_Image_Boundary_Labeler.Domain;
using Vision_Image_Boundary_Labeler.Json;
using Microsoft.VisualBasic;

namespace Vision_Image_Boundary_Labeler {
    /// <summary>
    /// Interaction logic for SetClassWindow.xaml
    /// </summary>
    public partial class SetClassWindow : Window {
        private LabelClassManager labelClassManager = new();

        public string DirectoryPath { get; set; }
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

        private void ClassListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
            // 선택된 항목을 BoundaryClass 타입으로 가져옴
            var selectedItem = ClassListView.SelectedItem as BoundaryClass;
            if(selectedItem != null) {
                string reply = Interaction.InputBox($"[{selectedItem.ClassIndex}]번 클래스 항목의 이름을 변경합니다. \n변경할 이름을 입력하세요.\n\n현재 설정값 : {selectedItem.ClassName}", "Title", $"{selectedItem.ClassName}");
                selectedItem.ClassName = reply;

                RefreshListView();
            }
        }
    }
}
