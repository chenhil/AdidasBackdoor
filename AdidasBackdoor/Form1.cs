using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AdidasBackdoor
{
    public partial class Form1 : Form
    {
        List<string> gResponses = new List<string>();
        private delegate void RichTextBoxUpdateEventHandler(string message);
        private delegate void LabelTextUpdateEventHandler(string count);
        int i = 0;
        private SemaphoreSlim _concurrencySemaphore = new SemaphoreSlim(3);



        
        CancellationTokenSource wtoken;

        private WriteHtml writer = null;
        private HttpHelper helper = null;

        public Form1()
        {
            writer = new WriteHtml();
            helper = new HttpHelper();
            InitializeComponent();
        }

        private void button_atc_Click(object sender, EventArgs e)
        {
            string captcha = gResponses[0];
            gResponses.RemoveAt(0);
            UpdateLabel(gResponses.Count.ToString());
            _concurrencySemaphore.Release();

            string url = helper.Get_URL(textBox_Sku.Text, Find_Size().ToString(), captcha);

            writer.CreateHtml(url, "1");
            
            using (var process = new Process())
            {
                string username = Environment.UserName;
                string filepath = "C:/Users/" + username + "/desktop/debug/";
                string profile = "user" + i.ToString();

                process.StartInfo.FileName = @"chrome.exe";
                process.StartInfo.Arguments = filepath + "/test1.html" + " --new-window --user-data-dir=" + filepath + profile;
                //process.AddArguments();

                process.Start();
            }
            ++i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_Sitekey.Enabled = false;

            UpdateRichTextBox("Starting");
            Task.Factory.StartNew(() => Start_Work());
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            Stop_Work();
        }

        private void Start_Work()
        {
            int count = 1;
            while (true)
            {
                while(gResponses.Count >= 6)
                {
                    UpdateRichTextBox("Stopped, waiting to free up some response tokens.");
                    _concurrencySemaphore.Wait();
                }

                _concurrencySemaphore.Wait();
                Task.Run(async () =>
                 {
                     Thread.CurrentThread.Name = "Thread " + count.ToString();
                     await Do_Work(count);                 
                 })
                    .ContinueWith(_ => _concurrencySemaphore.Release());
                ++count;
            }
        }

        private async Task Do_Work(int name)
        {
            UpdateRichTextBox("Getting Request for:" + Thread.CurrentThread.Name);
            string response = await helper.Start_Factory("198.55.109.170", "8800", textBox_Sitekey.Text);
            if (response.Length < 20)
            {
                UpdateRichTextBox(response);
            }
            else
            {
                gResponses.Add(response);
                UpdateRichTextBox("Done getting request for: " + Thread.CurrentThread.Name);
                UpdateLabel(gResponses.Count.ToString());
            }
        }

        private void Stop_Work()
        {
            UpdateRichTextBox("Waiting for Task to end.");
            using (wtoken)
            {
                // Cancel.  This will cancel the task.
                wtoken.Cancel();
            }

            // Set everything to null, since the references
            // are on the class level and keeping them around
            // is holding onto invalid state.
            wtoken = null;
        }

        private int Find_Size()
        {
            int size = Int32.Parse(textBox_Size.Text);
            int result = (size - 4) * 20;
            return result + 530;
        }

        public void UpdateRichTextBox(string message)
        {
            string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";
            if (richTextBox1.InvokeRequired)
            {
                // this means we’re on the wrong thread!  
                // use BeginInvoke or Invoke to call back on the 
                // correct thread.
                richTextBox1.Invoke(
                    new RichTextBoxUpdateEventHandler(UpdateRichTextBox), // the method to call back on
                    new object[] { message });                              // the list of arguments to pass
            }
            else
            {
                richTextBox1.AppendText(nDateTime + message + System.Environment.NewLine);
                richTextBox1.ScrollToCaret();
            }
        }

        public void UpdateLabel(string count)
        {
            if(label_CaptchaCount.InvokeRequired)
            {
                label_CaptchaCount.Invoke(new LabelTextUpdateEventHandler(UpdateLabel), new object[] { count });
            }
            else
            {
                label_CaptchaCount.Text = count;
            }
        }

    }
}
