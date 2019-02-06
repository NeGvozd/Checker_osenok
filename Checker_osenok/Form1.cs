using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

namespace Checker_osenok
{
    public partial class Form1 : Form
    {
        public List<string> lessons = new List<string>();
        public List<string> marks = new List<string>();
        public string[] result;
        public Form1()
        {
            InitializeComponent();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                var html = File.ReadAllText(openFileDialog.FileName, Encoding.Default);
                var res = Regex.Matches(html, @"<td class=\Ds2\D>.*</td>");
                if (res.Count == 0)
                    richTextBox1.Text = "net";
                result = res.Cast<Match>().Select(x => x.Value).ToArray();
                Start_Work(result);
            }
            
        }

        void Start_Work(string[] result)
        {
            Regex pattern = new Regex(@"<strong class=\Du\D>\w+");
            Regex pattern_marks = new Regex(@"data-num=\D\d\D>\d?");
            for (int i = 0; i < result.Count(); i++)
            {
                MatchCollection matches = pattern.Matches(result[i]);
                MatchCollection matcher_marks = pattern_marks.Matches(result[i]);
                if (matches.Count > 0)
                    Print(matches);
                else
                    richTextBox1.Text = "Совпадений не найдено";
                if (matcher_marks.Count > 0)
                    Print_marks(matcher_marks);
            }
        }

      void Print(MatchCollection matches)
        {
            foreach (Match match in matches)
            {
                var str = match.Groups[0].ToString();
                richTextBox1.Text += str.Substring(18, str.Length-18);
                lessons.Add(str.Substring(18, str.Length-18));
                richTextBox1.Text += "\r\n";
            }
        }

        void Print_marks(MatchCollection matches)
        {
            marks.Add(null);
            foreach (Match match in matches)
            {
                var str = match.Groups[0].ToString();
                richTextBox1.Text += str.Substring(13, str.Length - 13);
                marks[marks.Count-1] += str.Substring(13, str.Length - 13);
                richTextBox1.Text += " ";
            }
            richTextBox1.Text += Average();
            richTextBox1.Text += "\r\n ";
        }

      public string Average()
        {
            float av = 0;
            string OutPut = "";
                for (int i2=0; i2<marks[marks.Count-1].Length; i2++)
                {
                    av += (int)Char.GetNumericValue(marks[marks.Count-1][i2]);
                }
            av /= marks[marks.Count - 1].Length;
            OutPut += " ср. балл:" + av;
            if (marks[marks.Count - 1].Length < 3)
                OutPut += "; не хватает оценок:" + (3 - marks[marks.Count - 1].Length);
            if (Math.Round(av) < 5)
            {
                float res2 = (4.6f - av) * marks[marks.Count - 1].Length;
                av = res2 + 1;
            }
            else av = 0;
            OutPut += "; до \"Отличного\" нужно еще пятерок: " + Math.Round(av);
            return OutPut;
        }
                      
        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Net.WebRequest reqGET = System.Net.WebRequest.Create(@"https://schools.school.mosreg.ru/marks.aspx?school=49652&index=7&tab=period&homebasededucation=False");
            //System.Net.WebResponse resp = reqGET.GetResponse();
            //System.IO.Stream stream = resp.GetResponseStream();
            //System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            //string s = sr.ReadToEnd();
            //File.WriteAllText("321.txt", s);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode && richTextBox1.Text.Length>10)
            {
                var html = richTextBox1.Text;
                var res = Regex.Matches(html, @"<td class=\Ds2\D>.*</td>");
                richTextBox1.Text = null;
                if (res.Count == 0)
                    richTextBox1.Text = "net";
                result = res.Cast<Match>().Select(x => x.Value).ToArray();
                richTextBox1.ReadOnly = true;
                Start_Work(result);
            }
        }
    }
}
