using System;
using System.Windows;
using Microsoft.Web.WebView2.Core;

namespace TaskPal
{
    public partial class ChatWindow : Window
    {
        public ChatWindow()
        {
            InitializeComponent();
            // تأكد من تحميل محرك WebView2 قبل عرض المحتوى
            //ChatGPTWebView.EnsureCoreWebView2Async(null);
            ChatGPTWebView.Source = new Uri("https://chat.openai.com");
        }

      
    }
}
