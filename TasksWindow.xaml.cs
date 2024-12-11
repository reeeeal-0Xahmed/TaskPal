using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Media;

namespace TaskPal
{
    public partial class TasksWindow : Window
    {
        public ObservableCollection<Group> Groups { get; set; }

        public TasksWindow()
        {
            InitializeComponent();
            Groups = LoadData() ?? new ObservableCollection<Group>();
            GroupListBox.ItemsSource = Groups;
        }
         public void PlaySound(string soundFile)
        {
            try
            {
                SoundPlayer player = new SoundPlayer(soundFile);
                player.Play(); // لتشغيل الصوت
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تشغيل الصوت: " + ex.Message);
            }
        }
        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            var newGroup = new Group { Name = "New Group", Tasks = new ObservableCollection<Task>() };
            Groups.Add(newGroup);
            SaveData();
        }

        private void EditGroup_Click(object sender, RoutedEventArgs e)
        {
           
            if (GroupListBox.SelectedItem is Group selectedGroup)
            {
                var input = Microsoft.VisualBasic.Interaction.InputBox("Edit Group Name", "Edit Name", selectedGroup.Name);
                if (!string.IsNullOrWhiteSpace(input))
                {
                     string soundPath = @"Sounds\pop_taskpal.wav"; // تأكد من وضع مسار الملف
                      PlaySound(soundPath);
                    selectedGroup.Name = input;
                    SaveData();
                }
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
           
            if (GroupListBox.SelectedItem is Group selectedGroup)
            {
                selectedGroup.Tasks.Add(new Task { Name = "New Task", Priority = "Medium" });
                UpdateTaskList(selectedGroup);
                string soundPath = @"Sounds\pop_taskpal.wav"; // تأكد من وضع مسار الملف
                PlaySound(soundPath);
                SaveData();
            }
            else
            {
                MessageBox.Show("Please select a group first!");
            }
        }

        private void GroupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupListBox.SelectedItem is Group selectedGroup)
            {
                UpdateTaskList(selectedGroup);
            }
        }
        private void BackToMain_Cli(object sender, RoutedEventArgs e)
        {
            
            // إنشاء نافذة MainWindow جديدة
          
            string soundPath = @"Sounds\pop_taskpal.wav"; 
            PlaySound(soundPath);
           

            // إغلاق النافذة الحالية
            this.Close();
        }

        private void UpdateTaskList(Group group)
        {
            TaskListBox.ItemsSource = group.Tasks;
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
           
            if (TaskListBox.SelectedItem is Task selectedTask)
            {
                selectedTask.Name = TaskNameTextBox.Text;
                selectedTask.Priority = (TaskPriorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                TaskListBox.Items.Refresh();
                string soundPath = @"Sounds\pop_taskpal.wav"; // تأكد من وضع مسار الملف
                PlaySound(soundPath);
                SaveData();
            }
        }

        private void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
           
            if (GroupListBox.SelectedItem is Group selectedGroup)
            {
                var result = MessageBox.Show($"Are you sure you want to delete the group '{selectedGroup.Name}'?",
                                             "Delete Group", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Groups.Remove(selectedGroup);
                    string soundPath = @"Sounds\endtask_taskpal.wav"; // تأكد من وضع مسار الملف
                    PlaySound(soundPath);
                    SaveData();
                }
            }
            else
            {
                MessageBox.Show("Please select a group to delete.");
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
          
            if (TaskListBox.SelectedItem is Task selectedTask && GroupListBox.SelectedItem is Group selectedGroup)
            {
                var result = MessageBox.Show($"Are you sure you want to delete the task '{selectedTask.Name}'?",
                                             "Delete Task", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    selectedGroup.Tasks.Remove(selectedTask);
                    string soundPath = @"Sounds\endtask_taskpal.wav"; // تأكد من وضع مسار الملف
                    PlaySound(soundPath);
                    SaveData();
                }
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
            }
        }

        private void SaveData()
        {
            string json = JsonConvert.SerializeObject(Groups);
            File.WriteAllText("tasksData.json", json);
        }

        private ObservableCollection<Group> LoadData()
        {
            if (File.Exists("tasksData.json"))
            {
                string json = File.ReadAllText("tasksData.json");
                return JsonConvert.DeserializeObject<ObservableCollection<Group>>(json);
            }
            return null;
        }

        private void TaskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TaskPriorityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TaskNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    public class Group : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Task> Tasks { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Task : INotifyPropertyChanged
    {
        private string name;
        private string priority;
        private bool isCompleted;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Priority
        {
            get => priority;
            set
            {
                priority = value;
                OnPropertyChanged();
            }
        }

        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                isCompleted = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
