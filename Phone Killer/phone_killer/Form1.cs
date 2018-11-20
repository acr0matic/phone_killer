using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberKiller
{
    public partial class Form1 : Form
    {
        private String number = "+79653546090";
        private String name = "Светлана";
        private int page_number = 0;
        private String[] URLs = new String[5];

        public Form1()
        {
            InitializeComponent();

            URLs[0] = "http://eco-gribs.ru/";
            URLs[1] = "http://lexopol-low.dostavka2.me/";
            URLs[2] = "http://flk.officialhealth.ru/";
            URLs[3] = "http://c.potencialex.ru/149/v1/";
            URLs[4] = "http://titan-gel.com";
        }

        private void changePage(int page)
        {
            webBrowser1.Navigate(URLs[page]);        
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                switch (page_number)
                {
                    case 0:
                        webBrowser1.Document.GetElementById("lv-formLanding1-phone").InnerText = number;

                        foreach (HtmlElement he in webBrowser1.Document.GetElementsByTagName("button"))
                            if (he.GetAttribute("name").Equals("au1th"))
                                he.InvokeMember("click");
                        //page_number++;
                        //changePage(page_number);
                        break;

                    case 11:
                        foreach (HtmlElement htmlElement in webBrowser1.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("name"))
                                htmlElement.InnerText = name;

                        foreach (HtmlElement htmlElement in webBrowser1.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("phone"))
                                htmlElement.InnerText = number;

                        foreach (HtmlElement htmlElement in webBrowser1.Document.GetElementsByTagName("button"))
                            if (htmlElement.GetAttribute("type").Equals("subm1it"))
                                htmlElement.InvokeMember("click");

                        page_number++;
                        changePage(page_number);
                        break;
                    case 22:
                        foreach (HtmlElement htmlElement in webBrowser1.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("name"))
                                htmlElement.InnerText = name;

                        foreach (HtmlElement htmlElement in webBrowser1.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("phone"))
                                htmlElement.InnerText = number;

                        foreach (HtmlElement htmlElement in webBrowser1.Document.GetElementsByTagName("button"))
                            if (htmlElement.GetAttribute("type").Equals("subm1it"))
                                htmlElement.InvokeMember("click");
                        page_number++;
                        changePage(page_number);
                        break;

                    case 24:
                        foreach (HtmlElement htmlElement in webBrowser1.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("fio"))
                                htmlElement.InnerText = name;

                        foreach (HtmlElement htmlElement in webBrowser1.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("phone"))
                                htmlElement.InnerText = number;

                        foreach (HtmlElement htmlElement in webBrowser1.Document.GetElementsByTagName("button"))
                            if (htmlElement.GetAttribute("type").Equals("subm1it"))
                                htmlElement.InvokeMember("click");
                        break;
                }
                
            }
            catch (NullReferenceException)
            {

            }                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changePage(page_number);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
