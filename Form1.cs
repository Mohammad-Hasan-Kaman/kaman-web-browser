using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // لیست پویا برای مدیریت تب‌ها
        private List<WebView2> browsers = new List<WebView2>();

        public Form1()
        {
            InitializeComponent();
            // فعال کردن رندر دو مرحله‌ای فرم برای جلوگیری از سیاهی و تداخل گرافیکی
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ساخت اولین تب به محض باز شدن برنامه
            AddNewTab();

            this.UseWaitCursor = false;
            this.Cursor = Cursors.Arrow;
            this.BackColor = Color.White;
        }

        private WebView2 GetCurrentBrowser()
        {
            if (tabControl1.SelectedIndex >= 0 && tabControl1.SelectedIndex < browsers.Count)
            {
                return browsers[tabControl1.SelectedIndex];
            }
            return null;
        }

        private async void AddNewTab()
        {
            TabPage newTabPage = new TabPage("برگه جدید");
            WebView2 newBrowser = new WebView2();
            newBrowser.Dock = DockStyle.Fill;

            // تغییر مهم: تنظیم رنگ به شفاف برای هماهنگی با پوسته TabControl و حل مشکل رنگ مشکی
            newBrowser.DefaultBackgroundColor = Color.Transparent;

            browsers.Add(newBrowser);
            newTabPage.Controls.Add(newBrowser);
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectTab(newTabPage);

            try
            {
                await newBrowser.EnsureCoreWebView2Async(null);
                newBrowser.NavigationCompleted += Browser_NavigationCompleted;
                newBrowser.CoreWebView2.Navigate("about:blank");
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در راه‌اندازی مرورگر: " + ex.Message);
            }
        }

        private void CloseTab()
        {
            // مطمئن می‌شویم که حداقل یک تب باقی بماند و کاربر نتواند همه تب‌ها را ببندد
            if (tabControl1.TabPages.Count > 1)
            {
                // ۱. گرفتن ایندکس تبی که در حال حاضر انتخاب شده و کاربر روی آن است
                int selectedTabIndex = tabControl1.SelectedIndex;

                if (selectedTabIndex >= 0 && selectedTabIndex < browsers.Count)
                {
                    // ۲. گرفتن مرورگر مربوط به این تب و حذف کامل آن از حافظه (برای جلوگیری از سنگین شدن برنامه)
                    WebView2 browserToDispose = browsers[selectedTabIndex];

                    // ۳. حذف مرورگر از لیست پویا
                    browsers.RemoveAt(selectedTabIndex);

                    // ۴. آزاد کردن منابع مرورگر حذف شده
                    browserToDispose.Dispose();
                }

                // ۵. حذف فیزیکی تب از روی ظاهر گرافیکی فرم
                tabControl1.TabPages.RemoveAt(selectedTabIndex);

                // ۶. انتقال فوکوس و انتخاب تب به تب قبلی یا بعدی تا برنامه خالی نماند
                int newTabIndex = Math.Min(selectedTabIndex, tabControl1.TabPages.Count - 1);
                tabControl1.SelectedIndex = newTabIndex;
            }
        }

        // رویداد تغییر عنوان تب پس از پایان لود سایت
        private void Browser_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            WebView2 activeBrowser = sender as WebView2;
            if (activeBrowser != null && activeBrowser.CoreWebView2 != null)
            {
                int index = browsers.IndexOf(activeBrowser);
                if (index >= 0 && index < tabControl1.TabPages.Count)
                {
                    string pageTitle = activeBrowser.CoreWebView2.DocumentTitle;

                    // اگر صفحه خالی بود یا عنوانی نداشت، نام آن را "برگه جدید" بگذار
                    if (string.IsNullOrEmpty(pageTitle) || pageTitle == "about:blank")
                    {
                        tabControl1.TabPages[index].Text = "برگه جدید";
                    }
                    else
                    {
                        tabControl1.TabPages[index].Text = pageTitle;
                    }
                }
            }
            progressBar1.Value = 100;
        }

        /* نکته مهم: متد Browser_SourceChanged که آدرس را در TextBox می‌انداخت 
           به طور کامل حذف شد تا متن داخل کادر سرچ شما تغییر نکند.
        */

        private void NavigateToPage()
        {
            WebView2 currentBrowser = GetCurrentBrowser();
            if (currentBrowser == null || currentBrowser.CoreWebView2 == null) return;

            string input = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            progressBar1.Value = 30; // شروع لودینگ

            if (input.StartsWith("http://") || input.StartsWith("https://") || input.Contains("."))
            {
                if (!input.StartsWith("http://") && !input.StartsWith("https://"))
                {
                    input = "https://" + input;
                }
                currentBrowser.CoreWebView2.Navigate(input);
            }
            else
            {
                currentBrowser.CoreWebView2.Navigate("https://www.google.com/search?q=" + Uri.EscapeDataString(input));
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            WebView2 browser = GetCurrentBrowser();
            if (browser != null && browser.CanGoBack) browser.GoBack();
        }

        private void forward_Click(object sender, EventArgs e)
        {
            WebView2 browser = GetCurrentBrowser();
            if (browser != null && browser.CanGoForward) browser.GoForward();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            WebView2 browser = GetCurrentBrowser();
            if (browser != null) browser.Reload();
        }

        private void Stop_search_Click(object sender, EventArgs e)
        {
            WebView2 browser = GetCurrentBrowser();
            if (browser != null) browser.Stop();
        }

        private void Add_New_Tab_Click(object sender, EventArgs e)
        {
            AddNewTab();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NavigateToPage();
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebView2 browser = GetCurrentBrowser();
            TabPage newTabPage = new TabPage("برگه جدید");
            WebView2 newBrowser = new WebView2();
            newBrowser.Dock = DockStyle.Fill;

            // تغییر مهم: تنظیم رنگ به شفاف برای هماهنگی با پوسته TabControl و حل مشکل رنگ مشکی
            newBrowser.DefaultBackgroundColor = Color.Transparent; if (browser != null && browser.CoreWebView2 != null)
            {
                browser.CoreWebView2.Navigate("about:blank");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CloseTab();
        }
    }
}