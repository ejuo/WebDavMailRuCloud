using System;
using System.Windows.Forms;
using NWebDav.Server.Logging;

namespace WDMRC.Form
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
		    LoggerFactory.Factory = new Log4NetAdapter();
		    Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
		    Application.Run(new Authentication());
		}
	}
}
