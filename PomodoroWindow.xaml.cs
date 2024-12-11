using System;
using System.Media;
using System.Windows;
using System.Windows.Threading;

namespace TaskPal
{
    public partial class PomodoroWindow : Window
    {
        private DispatcherTimer timer;
        private int timeLeft = 25 * 60; // 25 دقائق
        private int completedSessions = 0;

        public PomodoroWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        public void PlaySound(string soundFile)
        {
            if (System.IO.File.Exists(soundFile))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(soundFile);
                    player.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ أثناء تشغيل الصوت: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ملف الصوت غير موجود: " + soundFile);
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                // إيقاف المؤقت
                timer.Stop();
                startButton.Content = "resume"; // تغيير النص للزر
            }
            else
            {
                if (timeLeft <= 0)
                {
                    // إذا انتهى الوقت، إعادة تعيين العد التنازلي
                    timeLeft = 25 * 60;
                }

                // بدء المؤقت
                timer.Start();
                string soundPath = @"Sounds\pop_taskpal.wav"; // صوت عند بدء الجلسة
                PlaySound(soundPath);
                startButton.Content = "stop"; // تغيير النص للزر
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--; // تقليل الوقت المتبقي
                int minutes = timeLeft / 60;
                int seconds = timeLeft % 60;
                timerText.Text = $"{minutes:D2}:{seconds:D2}"; // تحديث النص في واجهة المستخدم
            }
            else
            {
                timer.Stop(); // إيقاف المؤقت عند انتهاء الوقت
                string soundPath = @"Sounds\endpromodoro_taskpal.wav"; // صوت انتهاء الجلسة
                PlaySound(soundPath);
                completedSessions++; // زيادة عدد الجلسات المكتملة
                PomodoroCounter.Text = $"Pomodoros Completed: {completedSessions}";
                MessageBox.Show("Mission completed! Choose a break."); // رسالة انتهاء الجلسة

                // إعادة تعيين وقت الاستراحة
                timeLeft = GetBreakTime();
                startButton.Content = "START"; // إعادة النص للزر
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop(); // إيقاف المؤقت
            timeLeft = 25 * 60; // إعادة تعيين الوقت إلى 25 دقيقة
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            timerText.Text = $"{minutes:D2}:{seconds:D2}"; // تحديث واجهة المستخدم
            startButton.Content = "ابدأ"; // تغيير النص للزر
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            string soundPath = @"Sounds\pop_taskpal.wav"; // صوت عند العودة
            PlaySound(soundPath);
            this.Close(); // إغلاق النافذة الحالية
        }

        private int GetBreakTime()
        {
            if (BreakTypeComboBox != null && BreakTypeComboBox.SelectedIndex == 1)
                return 15 * 60; // استراحة طويلة
            else
                return 5 * 60; // استراحة قصيرة
        }
    }
}
