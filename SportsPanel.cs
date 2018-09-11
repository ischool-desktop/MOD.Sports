using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FISCA.Presentation;
using CefSharp.WinForms;


namespace ischool.Sports
{
    public partial class SportsPanel : BlankPanel
    {
        private CefSharp.WinForms.ChromiumWebBrowser _browser;
        public SportsPanel()
        {
            InitializeComponent();
            
            Group = "體育競賽(開發中)";

            //this._browser = new ChromiumWebBrowser("https://sites.google.com/ischool.com.tw/neat-competition/%E9%A6%96%E9%A0%81");
            //this._browser.Dock = DockStyle.Fill;
            //ContentPanePanel.Controls.Add(this._browser);
        }

        private static SportsPanel _SportsPanel;

        public static SportsPanel Instance
        {
            get
            {
                if (_SportsPanel == null)
                {
                    _SportsPanel = new SportsPanel();
                }
                return _SportsPanel;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ContentPanePanel
            // 
            this.ContentPanePanel.Location = new System.Drawing.Point(0, 163);
            this.ContentPanePanel.Size = new System.Drawing.Size(870, 421);
            // 
            // SportsPanel
            // 
            this.Name = "SportsPanel";
            this.ResumeLayout(false);

        }
    }
}
