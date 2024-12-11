using System.Windows;

namespace TaskPal
{
    public partial class NotePage : Window
    {
        private Note _note; // الخاصية التي ستخزن الملاحظة

        public NotePage(Note note)
        {
            InitializeComponent();
            _note = note;

            // التأكد من أنه لا يوجد تعارض عند الوصول إلى الخصائص
            TitleBox.Text = _note.Title;
            ContentBox.Text = _note.Content;  // التأكد من أن الوصول يتم بشكل صحيح
        }

        private void SaveNote_Click(object sender, RoutedEventArgs e)
        {
            // حفظ التغييرات التي أجراها المستخدم
            _note.Title = TitleBox.Text;
            _note.Content = ContentBox.Text;
            DialogResult = true; // إغلاق النافذة مع حفظ التغييرات
            Close(); // إغلاق نافذة الملاحظة
        }
    }
}
