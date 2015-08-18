using System;
using System.Xml.Linq;
using Tavisca.Templar.Contract;

namespace SampleWidgets
{
    //About this widget
    //This is a sample widget which acts as a very primitive html editor
    //It allows you to add html code from widget settings 
    //and renders the code as is on the page
    //Please ensure you write well formatted html for testing

    //To create a widget all you have to do is impement IWidget from Tavisca.Templar.Contract assembly
    public partial class HtmlWidget : System.Web.UI.UserControl, IWidget
    {
        private IWidgetHost Host { get; set; }

        //When a widget is initialized by Templar than this is the first method which is called
        //All widget interaction with the site and Templar are done through this Host
        public void Init(Tavisca.Templar.Contract.IWidgetHost host)
        {
            this.Host = host;
        }
        
        //This method called when a user clicks on settings icon in Templar designer
        //Here we simply hide the literal and show the settings
        public void ShowSettings()
        {
            this.ltrOutput.Visible = false;
            this.Settings.Visible = true;
            this.Editor.InnerText = this.Host.GetState();
        }

        //This method is called when a user clicks on open settings in Templar designer
        //Here we hide the settings panel and show the literal 
        public void HideSettings()
        {
            this.ltrOutput.Visible = true;
            this.Settings.Visible = false;
        }

        //this is our code when user clicks the save button
        //For this simple widget we just save the entered text in the Host state
        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            this.Host.SaveState(this.Editor.Value);
            this.Host.HideSettings();
        }

        //This shows the last saved text when a widget is displayed
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.ltrOutput.Text = this.Host.GetState();
        }
                
        
    }
}