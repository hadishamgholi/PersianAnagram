using System;
using System.Linq;

namespace ConsoleApplication1
{
    using Gtk;
    public class Window1 : Window
    {
        private Label label;
        private Label result;
        private static DataSetBuilder dataBuilder;
        private Entry entry;
 
        public Window1() : base("Center")
        {
            BorderWidth = 10;
            SetDefaultSize(300, 300);
            SetPosition(WindowPosition.Center);
            DeleteEvent += delegate { Application.Quit(); };
            
            label = new Label("Enter a word:");
            result = new Label("");
            entry = new Entry();
//            entry.Changed += OnChanged;
        
            VBox vbox = new VBox(false, 5);
            HBox hbox = new HBox(true, 3);
            HBox le = new HBox(false, 10);
            
            le.Add(label);
            le.Add(entry);
            
            Alignment leAlignment = new Alignment(0, 0, 0, 0);
            leAlignment.Add(le);
            vbox.PackStart(leAlignment, false, true, 1);
            vbox.Add(result);
            Alignment valign = new Alignment(0, 1, 0, 0);
//            valign.Add(result);
            vbox.PackStart(valign, true, false, 1);
        
            Button anagramBtn = new Button("Anagram");
            anagramBtn.SetSizeRequest(70, 30);
            Button close = new Button("Close");
            close.Clicked += OnCloseClicked;
            anagramBtn.Clicked += OnAnagramClicked;
        
            hbox.Add(anagramBtn);
            hbox.Add(close);
        
            Alignment halign = new Alignment(1, 0, 0, 0);
            halign.Add(hbox);
            
        
            vbox.PackStart(halign, false, false, 3);

            Add(vbox);

            ShowAll();
        }
        
        void OnCloseClicked(object sender, EventArgs args)
        {
//            Entry entry = (Entry) sender;
//            label.Text = entry.Text;
            Application.Quit();
        }

        void OnAnagramClicked(object sender, EventArgs args)
        {
            Button anagram = (Button) sender;
            result.Text = "";
            anagram.Sensitive = false;
            string s = entry.Text;
            if (!string.IsNullOrEmpty(s))
            {
                dataBuilder.GetAnagramOf(s).ForEach(x => result.Text = result.Text + x + "\n");
            }

            anagram.Sensitive = true;
        }


        public static void Main()
        {
            dataBuilder = new DataSetBuilder();
            Application.Init();
            new Window1();
            Application.Run();
        }
    
    }
}