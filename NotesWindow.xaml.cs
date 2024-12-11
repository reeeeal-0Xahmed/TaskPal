using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace TaskPal
{
    public partial class NotesWindow : Window
    {
        private List<Note> Notes = new List<Note>();  // قائمة الملاحظات
        private string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "notes.json"); // مسار حفظ الملاحظات في ملف JSON
        private string soundPath = @"Sounds\pop_taskpal.wav"; // مسار الصوت

        public NotesWindow()
        {
            InitializeComponent();
            LoadNotes(); // تحميل الملاحظات عند فتح النافذة
            DisplayNotes(); // عرض الملاحظات عند فتح النافذة
        }

        // تحميل الملاحظات من ملف JSON
        private void LoadNotes()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    var json = File.ReadAllText(FilePath);
                    Notes = JsonConvert.DeserializeObject<List<Note>>(json) ?? new List<Note>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء تحميل الملاحظات: " + ex.Message);
                }
            }
        }

        // حفظ الملاحظات في ملف JSON
        private void SaveNotes()
        {
            try
            {
                var json = JsonConvert.SerializeObject(Notes, Formatting.Indented);
                File.WriteAllText(FilePath, json); // حفظ الملاحظات في الملف
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حفظ الملاحظات: " + ex.Message);
            }
        }

        // عرض الملاحظات في الواجهة
        private void DisplayNotes(string searchQuery = "")
        {
            NotesPanel.Children.Clear(); // Clear existing notes

       

            // Filter notes based on search query
            var filteredNotes = Notes
                .Where(note => string.IsNullOrEmpty(searchQuery) ||
                               note.Title.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                               note.Content.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                .ToList();

            int columns = 4;
            int rowIndex = 0;
            int columnIndex = 0;

            // Dynamically adjust Grid columns if needed
            if (NotesPanel.ColumnDefinitions.Count != columns)
            {
                NotesPanel.ColumnDefinitions.Clear();
                for (int i = 0; i < columns; i++)
                {
                    NotesPanel.ColumnDefinitions.Add(new ColumnDefinition());
                }
            }

            // Dynamically adjust Grid rows based on filtered notes count
            int totalRows = (int)Math.Ceiling((double)filteredNotes.Count / columns);
            if (NotesPanel.RowDefinitions.Count != totalRows)
            {
                NotesPanel.RowDefinitions.Clear();
                for (int i = 0; i < totalRows; i++)
                {
                    NotesPanel.RowDefinitions.Add(new RowDefinition());
                }
            }

            foreach (var note in filteredNotes)
            {
                var noteCard = CreateNoteCard(note);
                Grid.SetRow(noteCard, rowIndex);
                Grid.SetColumn(noteCard, columnIndex);
                NotesPanel.Children.Add(noteCard);

                columnIndex++;
                if (columnIndex == columns)
                {
                    columnIndex = 0;
                    rowIndex++;
                }
            }
        }

        // تحسين إعداد الأعمدة والصفوف في Grid
        private void ConfigureGrid(int columns, int noteCount)
        {
            NotesPanel.ColumnDefinitions.Clear();
            for (int i = 0; i < columns; i++)
            {
                NotesPanel.ColumnDefinitions.Add(new ColumnDefinition());
            }

            int totalRows = (int)Math.Ceiling((double)noteCount / columns);
            NotesPanel.RowDefinitions.Clear();
            for (int i = 0; i < totalRows; i++)
            {
                NotesPanel.RowDefinitions.Add(new RowDefinition());
            }
        }

        // تشغيل الصوت
        private void PlaySound()
        {
            try
            {
                if (File.Exists(soundPath))
                {
                    SoundPlayer player = new SoundPlayer(soundPath);
                    player.Play(); // لتشغيل الصوت
                }
                else
                {
                    MessageBox.Show("ملف الصوت غير موجود.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تشغيل الصوت: " + ex.Message);
            }
        }

        // إنشاء بطاقة لكل ملاحظة
        private Border CreateNoteCard(Note note)
        {
            var border = new Border
            {
                Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 217, 217)),
                CornerRadius = new CornerRadius(10),
                Width = 180, // عرض النوت بحيث تتسع 4 نوتس في كل صف
                Height = 150,
                Margin = new Thickness(10)
            };

            var stackPanel = new StackPanel();

            var titleBlock = new TextBlock
            {
                Text = note.Title,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5)
            };

            var contentBlock = new TextBlock
            {
                Text = note.Content.Length > 50 ? note.Content.Substring(0, 50) + "..." : note.Content,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5)
            };

            var deleteButton = new Button
            {
                Content = "Delete",
                Width = 50,
                Height = 20,
                Margin = new Thickness(5)
            };

            // ربط حدث الحذف
            deleteButton.Click += (sender, e) => DeleteNote(note);

            stackPanel.Children.Add(titleBlock);
            stackPanel.Children.Add(contentBlock);
            stackPanel.Children.Add(deleteButton);

            border.Child = stackPanel;

            // عند الضغط على الملاحظة، تفتح نافذة التفاصيل
            border.MouseDown += (sender, e) => OpenNotePage(note);

            return border;
        }

        // إضافة ملاحظة جديدة
        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            PlaySound();
            var newNote = new Note
            {
                Title = "New Note",
                Content = "Write something...",
                CreatedDate = DateTime.Now
            };

            Notes.Add(newNote);  // إضافة الملاحظة
            SaveNotes();         // حفظ الملاحظة في الملف
            DisplayNotes();      // تحديث العرض بعد إضافة الملاحظة
        }

        // حذف ملاحظة
        private void DeleteNote(Note note)
        {
            Notes.Remove(note); // حذف الملاحظة من القائمة
            SaveNotes();        // حفظ التغييرات في الملف
            DisplayNotes();     // تحديث العرض بعد الحذف
        }

        // فتح نافذة تحرير الملاحظة
        private void OpenNotePage(Note note)
        {
            var notePage = new NotePage(note);
            if (notePage.ShowDialog() == true)
            {
                SaveNotes(); // حفظ التغييرات بعد تعديل الملاحظة
                DisplayNotes(); // تحديث العرض بعد التعديل
            }
        }

        // البحث عن الملاحظات
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DisplayNotes(SearchBox.Text); // تحديث الملاحظات بناءً على النص المدخل
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            PlaySound();
            this.Close();
        }
    }
}
