using System.Text;
using System.Text.Json;

namespace AutosplitGenerator
{
    public partial class Form1 : Form
    {
        private readonly string firstPart = "state(\"ADACA-Win64-Shipping\", \"1.0.6\")\r\n{\r\n\tstring255 stage: \"ADACA-Win64-Shipping.exe\", 0x4A54520, 0x520, 0x4A8, 0x0;\r\n\tfloat IGT: \"ADACA-Win64-Shipping.exe\", 0x4509078;\t\r\n\tint loading: \"ADACA-Win64-Shipping.exe\", 0x44BD181;\r\n}\r\n\r\nstate(\"ADACA-Win64-Shipping\", \"1.1.5\")\r\n{\r\n\tstring255 stage: \"ADACA-Win64-Shipping.exe\", 0x499D120, 0x520, 0x4A8, 0x0;\r\n\tfloat IGT: \"ADACA-Win64-Shipping.exe\", 0x4454308;\r\n\tint loading: \"ADACA-Win64-Shipping.exe\", 0x4408401;\r\n}\r\n\r\ninit\r\n{\t\r\n\t// This is to know what version you are playing on\r\n    \tswitch (modules.First().ModuleMemorySize) \r\n    \t{ \r\n\tcase  82018304: version = \"1.1.5\";\r\n\t    break;\r\n\tcase  82821120: version = \"1.0.6\"; \r\n\t    break;\r\n\tdefault:        version = \"\"; \r\n\t    break;\r\n    \t}\r\n    \tvars.prevStage = \"\";\r\n\tvars.IGT = 0;\r\n\tvars.SplitIndex = 0;\r\n}";
        private readonly string lastPart = "\r\nisLoading \r\n{\r\n\tif (current.loading == 0)\r\n\t{\r\n\t\tvars.IGT = current.IGT;\r\n\t}\r\n\treturn current.loading == 0 || current.IGT == vars.IGT;\r\n}\r\n";
        private bool useFilters;
        private AllMaps MapList;

        private class AllMaps
        {
            public Map[]? Maps { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            string content;
            using (HttpClient hc = new HttpClient())
            {
                content = hc.GetStringAsync("https://raw.githubusercontent.com/BurndiL/ADACA-Autosplitter/main/Maps.json").Result;
            }

            MapList = DeserializeMaps(content);
            UpdateMaps();

            //Filters
            FilterCheckListBox.BeginUpdate();
            foreach (LevelType type in Enum.GetValues(typeof(LevelType)))
            {
                FilterCheckListBox.Items.Add(type);
            }
            FilterCheckListBox.EndUpdate();

            
        }

        private static AllMaps DeserializeMaps(string json)
        {
            return JsonSerializer.Deserialize<AllMaps>(json) ?? new AllMaps();
        }

        private void UpdateMaps()
        {
            if (MapList != null && MapList.Maps != null)
            {
                MapSelection.BeginUpdate();
                MapSelection.Items.Clear();
                foreach (Map map in MapList.Maps)
                {
                    if (!useFilters || FilterCheckListBox.CheckedItems.Contains(map.LevelType))
                    {
                        MapSelection.Items.Add(map);
                    }
                }
                MapSelection.EndUpdate();
            }
        }

        private void AddToSplits(Map map)
        {
            if (map != null)
            {
                Splits.Items.Add(map);
            }
        }

        private void RemoveFromSplits()
        {
            if (Splits.SelectedItems != null && Splits.SelectedItems.Count == 1)
            {
                Splits.BeginUpdate();
                Splits.Items.RemoveAt(Splits.SelectedIndex);
                Splits.EndUpdate();
            }
        }

        private void AddToSplitsButton_Click(object sender, EventArgs e)
        {
            if (MapSelection.SelectedItems != null && MapSelection.SelectedItems.Count == 1)
            {
                Map selectedMap = (Map)MapSelection.SelectedItem;
                AddToSplits(selectedMap);
            }
        }

        private void MapSelection_DoubleClick(object sender, EventArgs e)
        {
            if (MapSelection.SelectedItems != null && MapSelection.SelectedItems.Count == 1)
            {
                Map selectedMap = (Map)MapSelection.SelectedItem;
                AddToSplits(selectedMap);
            }
        }

        //remove button
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveFromSplits();
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            if (Splits.SelectedItems != null && Splits.SelectedItems.Count == 1)
            {
                int newIndex = Splits.SelectedIndex - 1;
                Map? selectedMap = Splits.SelectedItem as Map;
                if (selectedMap != null && newIndex >= 0)
                {
                    Splits.Items.RemoveAt(Splits.SelectedIndex);
                    Splits.Items.Insert(newIndex, selectedMap);
                    Splits.SetSelected(newIndex, true);
                }

            }
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (Splits.SelectedItems != null && Splits.SelectedItems.Count == 1)
            {
                int newIndex = Splits.SelectedIndex + 1;
                Map? selectedMap = Splits.SelectedItem as Map;
                if (selectedMap != null && newIndex < Splits.Items.Count)
                {
                    Splits.Items.RemoveAt(Splits.SelectedIndex);
                    Splits.Items.Insert(newIndex, selectedMap);
                    Splits.SetSelected(newIndex, true);
                }

            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (Splits.Items == null || Splits.Items.Count == 0) return;
            StringBuilder result = new StringBuilder();
            result.Append(firstPart);
            result.Append( //start method
                "\r\nstart\r\n{\r\n    " +
                "if(current.stage == \"" +
                ((Map)Splits.Items[0]).Path +
                "\")" +
                "{\r\n\tvars.IGT = current.IGT;" +
                "\r\n\tvars.SplitIndex = 0;" +
                "\r\n\treturn true;" +
                "\r\n    }" +
                "\r\n}");

            result.Append(//split method
                "\r\nsplit" +
                "\r\n{" +
                "\r\n\tswitch ((int)vars.SplitIndex){");
            for (int i = 1; i < Splits.Items.Count; i++)
            {
                result.Append("\r\n\t\tcase " + (i - 1) + ": if (current.stage == \"" + ((Map)Splits.Items[i]).Path + "\") {vars.SplitIndex++; return true;}; break;");
            }
            result.Append("\r\n\t\tdefault: break;" +
                "\r\n\t}" +
                "\r\n}"
                );
            result.Append(lastPart);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "AutoSplitter File|*.asl";
            saveFileDialog.Title = "Save the generated Autosplitter";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                // Saves the Splitter via a FileStream created by the OpenFile method.
                FileStream fs = (FileStream)saveFileDialog.OpenFile();

                byte[] bytes = Encoding.UTF8.GetBytes(result.ToString());
                fs.Write(bytes, 0, bytes.Length);


                fs.Close();
            }
        }

        private void LoadLocalMapsButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json File|*.json";
            openFileDialog.Title = "Select custom map file";
            FileStream fs;
            string result ="";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fs = (FileStream)openFileDialog.OpenFile();
                long size = fs.Length;
                byte[] bytes = new byte[size];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                result = Encoding.UTF8.GetString(bytes);
            }
            MapList = DeserializeMaps(result);
            UpdateMaps();
        }



        private void FilterCheckListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => UpdateMaps()));
        }

        private void UseFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            useFilters = FilterCheckListBox.Enabled = UseFilterCheckBox.Checked;
            UpdateMaps();
        }

        private void Splits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) RemoveFromSplits();
        }
    }
}