using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Diagnostics;

namespace Checker_osenok
{
    public partial class Form1 : Form
    {
        public List<string> lessons = new List<string>();
        public List<string> marks = new List<string>();
        public string[] result;
        string forFive, forFour, forThree;
        string shortage=null;
        public Form1()
        {
            InitializeComponent();

            tipsPanel.SelectedIndex = 0;

            var subject = new DataGridViewColumn();
            subject.HeaderText = "Предметы";
            subject.Name = "subjectBox";
            subject.Width = 350;
            subject.ReadOnly = true;
            subject.Frozen = true;
            subject.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            subject.CellTemplate = new DataGridViewTextBoxCell();

            var mark = new DataGridViewColumn();
            mark.HeaderText = "Оценки";
            mark.Name = "marks";
            mark.ReadOnly = true;
            mark.Frozen = true;
            mark.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            mark.CellTemplate = new DataGridViewTextBoxCell();

            var averageMark = new DataGridViewColumn();
            averageMark.HeaderText = "Средний балл";
            averageMark.Name = "averagemark";
            averageMark.ReadOnly = true;
            averageMark.Frozen = true;
            averageMark.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            averageMark.CellTemplate = new DataGridViewTextBoxCell();

            var correctionBox = new DataGridViewColumn();
            correctionBox.HeaderText = "Повышение балла";
            correctionBox.Name = "correction";
            correctionBox.ReadOnly = true;
            correctionBox.Frozen = true;
            correctionBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            correctionBox.CellTemplate = new DataGridViewTextBoxCell();

            tableBox.Columns.Add(subject);
            tableBox.Columns.Add(mark);
            tableBox.Columns.Add(averageMark);
            tableBox.Columns.Add(correctionBox);
            tableBox.AllowUserToAddRows = false;
            tableBox.Font = new Font("Microsoft Sans Serif", 17);
            tableBox.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //tableBox.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{

            //    var html = File.ReadAllText(openFileDialog.FileName, Encoding.Default);
            //    var res = Regex.Matches(html, @"<td class=\Ds2\D>.*</td>");
            //    if (res.Count == 0)
            //        richTextBox1.Text = "net";
            //    result = res.Cast<Match>().Select(x => x.Value).ToArray();
            //    Start_Work(result);
            //}

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
                var text = str.Substring(18, str.Length - 18);
                richTextBox1.Text += text;
                lessons.Add(text);
                tableBox.Rows.Add();
                tableBox["subjectBox", tableBox.Rows.Count - 1].Value = text;
                richTextBox1.Text += "\r\n";
            }
        }

        void Print_marks(MatchCollection matches)
        {
            marks.Add(null);
            foreach (Match match in matches)
            {
                var str = match.Groups[0].ToString();
                var text = str.Substring(13, str.Length - 13);
                //richTextBox1.Text += text;
                marks[marks.Count - 1] += text;
                //richTextBox1.Text += " ";
                tableBox["marks", tableBox.Rows.Count - 1].Value += text + " ";
            }
            var av = Average();
            tableBox["averagemark", tableBox.Rows.Count - 1].Value = Math.Round(av, 2);
            tableBox["correction", tableBox.Rows.Count - 1].Value = HowToCorrect(av);
            //richTextBox1.Text += Average();
            richTextBox1.Text += "\r\n ";
        }

        public float Average()
        {
            float av = 0;
            for (int i2 = 0; i2 < marks[marks.Count - 1].Length; i2++)
            {
                av += (int)Char.GetNumericValue(marks[marks.Count - 1][i2]);
            }
            av /= marks[marks.Count - 1].Length;
            return av;
        }

        private int correction(float average, int count, float mark)
        {
            var sum = average * count;
            while (Math.Round(average, 2) <=mark)
            {
                sum += 5;
                count++;
                average = sum / count;
            }
            return count;
        }

        public string HowToCorrect(float av)
        {
            string OutPut = "";
            forThree = forFour = forFive = null;
            if (marks[marks.Count - 1].Length < 3)
                shortage = "не хватает оценок: " + (3 - marks[marks.Count - 1].Length) + ";";
            if (Math.Round(av) < 3)
            {
                float res2 = correction(av, marks[marks.Count - 1].Length, 2.6f)
                    - marks[marks.Count - 1].Length;
                //float res2 = (2.6f - av) * marks[marks.Count - 1].Length;
                forThree = $" нужно ещё пятерок: {Math.Round(res2)}";
            }
            if (Math.Round(av) < 4)
            {
                //float res2 = (3.6f - av) * marks[marks.Count - 1].Length;
                float res2 = correction(av, marks[marks.Count - 1].Length, 3.6f)
                    - marks[marks.Count - 1].Length;
                forFour = $" нужно ещё пятерок: {Math.Round(res2)}";
            }
            if (Math.Round(av) < 5)
            {
                //float res2 = (4.6f - av) * marks[marks.Count - 1].Length;
                float res2 = correction(av, marks[marks.Count - 1].Length, 4.6f)
                    - marks[marks.Count - 1].Length;
                forFive = $" нужно ещё пятерок: {Math.Round(res2)}";
            }
            else av = 0;
            switch (Point())
            {
                case 3:
                    OutPut = forThree;
                    break;
                case 4:
                    OutPut = forFour;
                    break;
                case 5:
                    OutPut = forFive;
                    break;
            }
            //OutPut += " до \"Отличного\" нужно еще пятерок: " + Math.Round(av);
            return shortage + OutPut;
        }

        private int Point()
        {//возвращает оценку для советов
            var text = tipsPanel.SelectedItem.ToString();
            return int.Parse(text.Last()+"");
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("https://uslugi.mosreg.ru/obr/school");

            //System.Net.WebRequest reqGET = System.Net.WebRequest.Create(@"");
            //System.Net.WebResponse resp = reqGET.GetResponse();
            //System.IO.Stream stream = resp.GetResponseStream();
            //System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            //string s = sr.ReadToEnd();
            //File.WriteAllText("321.txt", s);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TipsPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i=0; i<tableBox.Rows.Count; i++)
            {
                tableBox["correction", i].Value = HowToCorrect(Convert.ToSingle(tableBox["averagemark", i].Value));
            }
        }

        private void go_Click(object sender, EventArgs e)
        {
            if (go.Text == "Начать")
            {
                //var html = webBrowser1.DocumentText;
                //var html = File.ReadAllText(@"124.txt");
                webBrowser1.Visible = false;
                var html = richTextBox1.Text;
                var res = Regex.Matches(html, @"<td class=\Ds2\D>.*</td>");
                richTextBox1.Text = null;
                if (res.Count == 0)
                    richTextBox1.Text = "net";
                result = res.Cast<Match>().Select(x => x.Value).ToArray();
                richTextBox1.ReadOnly = true;
                Start_Work(result);
                go.Text = "Отменить";

                richTextBox1.Visible = false;
            }
            else
            {
                richTextBox1.Text = null;
                webBrowser1.Visible = true;
                go.Text = "Начать";
            }

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
