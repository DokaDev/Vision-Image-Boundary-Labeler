using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using Vision_Image_Boundary_Labeler.Domain;

namespace Vision_Image_Boundary_Labeler.Json {
    public class LabelClassManager {
        private const string jsonFileName = "BoundaryClass.json";

        private string _jsonFilePath;
        public string JsonFilePath {
            get { return _jsonFilePath; }
            set {
                _jsonFilePath = Path.Combine(value, jsonFileName);
                CheckFileIsExsits();
                getJsonData();
            }
        }

        private List<BoundaryClass> BoundaryClassList = new List<BoundaryClass>();

        public void ShowBoundaryClass(ref ListView view) {
            foreach (var item in BoundaryClassList) {
                view.Items.Add(item);
            }
        }

        private void getJsonData() {
            // DESC: Read Json File
            string jsonContent = File.ReadAllText(JsonFilePath);
            JObject jsonObject = JObject.Parse(jsonContent);

            foreach(var keys in jsonObject.Properties()) {
                BoundaryClassList.Add(new BoundaryClass() {
                    ClassIndex = int.Parse(keys.Name), 
                    ClassName = keys.Value.ToString()
                });
            }
        }

        public void AddValue(string value) {
            BoundaryClass boundaryClass = new();
            boundaryClass.ClassIndex = BoundaryClassList.Count;
            boundaryClass.ClassName = value;

            BoundaryClassList.Add(boundaryClass);
        }

        public void ClearValue() {
            BoundaryClassList.Clear();
        }

        public void Save() {
            Dictionary<string, string> jsonData = new Dictionary<string, string>();
            foreach (var item in BoundaryClassList) {
                jsonData.Add(item.ClassIndex.ToString(), item.ClassName);
            }

            // Save File
            string jsonContent = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
            File.WriteAllText(JsonFilePath, jsonContent);
        }

        private void CheckFileIsExsits() {
            if(!File.Exists(JsonFilePath)) {
                Debug.WriteLine("Create 'BoundaryClass.json' file, because there's no this file.");

                var jsonTemplate = new Dictionary<string, string>();
                string jsonContent = JsonConvert.SerializeObject(jsonTemplate, Formatting.Indented);

                // Save File
                File.WriteAllText(JsonFilePath, jsonContent);
            }
        }
    }
}
