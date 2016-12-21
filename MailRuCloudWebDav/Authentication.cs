using System;
using System.Configuration;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NWebDav.Server;
using NWebDav.Server.Http;
using NWebDav.Server.HttpListener;
using WebDavMailRuCloudStore;
using YaR.WebDavMailRu.CloudStore.Mailru.StoreBase;

namespace MailRuCloudWebDav
{
    public partial class Authentication : System.Windows.Forms.Form
    {
        static HttpListener httpListener;
        static CancellationTokenSource cancellationTokenSource;

        public Authentication()
        {
            InitializeComponent();
            textBoxUserName.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cloud.Init(textBoxUserName.Text, textBoxPassword.Text);
            }
            catch (Exception)
            {

                MessageBox.Show(@"Authorization Error");
                return;
            }

            if (Cloud.Instance.Is2StepAuth)
            {
                SecondAuthPanel.Visible = true;
                textBoxAuthCode.Select();
            }
            else
            {
                SuccessPanel.Visible = true;

                InitServer();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cloud.Instance.SecondStepAuth(textBoxAuthCode.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Authorization Error");
                return;
            }


		    SecondAuthPanel.Visible = false;
		    SuccessPanel.Visible = true;

		    InitServer();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			cancellationTokenSource.Cancel();
		    httpListener.Stop();
			
			userToolStripMenuItem.Visible = false;
			SecondAuthPanel.Visible = false;
		    SuccessPanel.Visible = false;
		}

	    private void InitServer()
	    {
		    userToolStripMenuItem.Text = textBoxUserName.Text;
		    userToolStripMenuItem.Visible = true;
			WindowState = FormWindowState.Minimized;
		    notifyIcon1.BalloonTipText = @"Connecting successful";
			notifyIcon1.ShowBalloonTip(100);

            var webdavProtocol = ConfigurationManager.AppSettings["protocol"] ?? "http";
            var webdavIp = ConfigurationManager.AppSettings["server"] ?? "127.0.0.1";
            var webdavPort = ConfigurationManager.AppSettings["port"] ?? "8080";

            httpListener = new HttpListener();
            httpListener.Prefixes.Add($"{webdavProtocol}://{webdavIp}:{webdavPort}/");

            httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;

            // Start the HTTP listener
            httpListener.Start();
			StartListener();
	    }

	    private void StartListener()
	    {
			var maxThreadCount = ConfigurationManager.AppSettings["ThreadCount"] ?? "5";
	        cancellationTokenSource = new CancellationTokenSource();
	        DispatchHttpRequestsAsync(httpListener, cancellationTokenSource.Token, int.Parse(maxThreadCount));
	    }


		private static async void DispatchHttpRequestsAsync(HttpListener httpListener, CancellationToken cancellationToken, int maxThreadCount = Int32.MaxValue)
		{
			// Create a request handler factory that uses basic authentication
			var requestHandlerFactory = new RequestHandlerFactory();

			// Create WebDAV dispatcher
			var homeFolder = new MailruStore();
			var webDavDispatcher = new WebDavDispatcher(homeFolder, requestHandlerFactory);

			using (var sem = new SemaphoreSlim(maxThreadCount))
			{
				var semclo = sem;
			    while ( !cancellationToken.IsCancellationRequested )
				{
				    HttpListenerContext httpListenerContext;
				    try
				    {
				        httpListenerContext = await httpListener.GetContextAsync().ConfigureAwait(false);
				    }
				    catch (Exception)
				    {
				        return;
				    }

				    IHttpContext httpContext= new HttpContext(httpListenerContext);

					await semclo.WaitAsync(cancellationToken);
					await Task
					    .Run(async () =>
					    {
					        try
					        {
					            await webDavDispatcher.DispatchRequestAsync(httpContext);
					        }
					        catch (Exception ex)
					        {
					            throw new Exception(ex.Message);
					        }

					    }, cancellationToken)
					    .ContinueWith(t => semclo.Release(), cancellationToken);
				}
			}
		}

		private void Authentication_Resize(object sender, EventArgs e)
		{
		    if (WindowState == FormWindowState.Minimized)
			{
				ShowInTaskbar = false;
				notifyIcon1.Visible = true;
			}
		}

		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			ShowInTaskbar = true;
			notifyIcon1.Visible = false;
			WindowState = FormWindowState.Normal;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void showToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowInTaskbar = true;
			notifyIcon1.Visible = false;
			WindowState = FormWindowState.Normal;
		}

		private void textBoxAuthCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter){
				button2.PerformClick();
			}
		}

		private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter){
				button1.PerformClick();
			}
		}

		private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter){
				textBoxPassword.Select();
			}
		}
	}
}
