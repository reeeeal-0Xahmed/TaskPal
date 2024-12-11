using System;
using System.IO;
using System.Media;
using System.Windows;

namespace TaskPal
{
    public partial class MainWindow : Window
    {
        // تعريف مسارات الملفات الصوتية في مكان مركزي
        private const string StartSoundPath = @"Sounds\interface_start_taskpal.wav";
        private const string ClickSoundPath = @"Sounds\pop_taskpal.wav";

        public MainWindow()
        {
            InitializeComponent();
            PlaySound(StartSoundPath);
        }

        // تشغيل الصوت مع التحقق من وجود الملف
        public void PlaySound(string soundFile)
        {
            try
            {
                if (File.Exists(soundFile))
                {
                    SoundPlayer player = new SoundPlayer(soundFile);
                    player.Play(); // تشغيل الصوت
                }
                else
                {
                    MessageBox.Show($"ملف الصوت غير موجود: {soundFile}", "خطأ", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تشغيل الصوت: " + ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // دالة مشتركة لتشغيل الصوت وفتح النوافذ
        private void OpenWindowWithSound(Window window)
        {
            PlaySound(ClickSoundPath);
            window.Show();
        }

        // عند الضغط على زر مؤقت بومودورو
        private void btnPomodoro_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowWithSound(new PomodoroWindow());
        }

        // عند الضغط على زر المهام
        private void OpenTasksWindow_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowWithSound(new TasksWindow());
        }

        // عند الضغط على زر مساعد AI
        private void btnAI_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowWithSound(new ChatWindow());
        }

        // عند الضغط على زر الملاحظات
        private void OpenNotesButton_Click(object sender, RoutedEventArgs e)
        {
            OpenWindowWithSound(new NotesWindow());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
            string url = "https://www.facebook.com/profile.php?id=61552002253300"; 

            try
            {
             
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true 
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء فتح الرابط: " + ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = "https://www.linkedin.com/in/ahmed-mohamed-abdelrouf-04b6a5295/";

            try
            {

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء فتح الرابط: " + ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
