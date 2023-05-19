using Ccd.Bidding.Manager.Reporting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Reporting.Html
{
    public abstract class HtmlReportBuilder<TObject> : IReportBuilder<TObject>
    {
        protected abstract string Title { get; }
        protected abstract string StyleName { get; }
        protected abstract PrintOrientation PrintOrientation { get; }
        protected string Subtitle { get; set; }
        protected string FileName { get; set; }
        protected string FileNameSubtitle { get; set; }

        private string TableData { get; set; }

        protected HtmlReportBuilder()
        {

        }

        public virtual IReportFile BuildReport(TObject @object)
        {
            HtmlReportFile output = new HtmlReportFile();
            output.TimeStamp = DateTime.Now;
            output.FileName = $"{ output.TimeStamp.ToString("yyyy-MM-dd-HH-mm") }--{Title.ToLower().Replace(' ', '-')}--{FileNameSubtitle}.html";
            output.Data = CreateReport(Title, Subtitle, GenerateTableData(@object), StyleName, PrintOrientation);

            return output;
        }

        public abstract string GenerateTableData(TObject @object);


        #region COMPOSITION
        private static void OpenHTML(StringBuilder sb)
        {
            sb.AppendLine($" <html>");
        }
        private static void HTMLHead(StringBuilder sb, string reportTitle, string styleFileName, PrintOrientation printOrientation)
        {
            sb.AppendLine($"     <head>");
            sb.AppendLine($"         <title>{ reportTitle }</title>");
            sb.AppendLine($"          <link href='https://fonts.googleapis.com/css2?family=Roboto+Mono:wght@400&display=swap' rel='stylesheet'> ");
            sb.AppendLine($"         <style>");

            sb.AppendLine(LoadStyle("Common.css"));

            switch (printOrientation)
            {
                case PrintOrientation.Landscape:
                    sb.AppendLine(LoadStyle("Common.Landscape.css"));
                    break;
                case PrintOrientation.Portrait:
                    sb.AppendLine(LoadStyle("Common.Portrait.css"));
                    break;
            }

            sb.AppendLine(LoadStyle(styleFileName));

            sb.AppendLine($"         </style>");
            sb.AppendLine($"     </head>");

        }
        public static string CreateReport(string reportTitle, string reportSubtitle, string tableData, string styleFileName, PrintOrientation printOrientation)
        {
            StringBuilder sb = new StringBuilder();
            DateTime generationDate = DateTime.Now;

            OpenHTML(sb);
            HTMLHead(sb, reportTitle, styleFileName, printOrientation);
            OpenBody(sb);
            PrintButton(sb);
            HeaderDiv(sb, reportTitle, generationDate, reportSubtitle);
            sb.Append(tableData);
            EndOfReportDiv(sb, generationDate);
            CloseBody(sb);
            CloseHTML(sb);

            return sb.ToString();
        }
        private static void OpenBody(StringBuilder sb)
        {
            sb.AppendLine($"     <body>");
        }
        private static void PrintButton(StringBuilder sb)
        {
            sb.AppendLine($"        <input type='button' onclick='window.print();' value='Print Report' class='noprint' />");
        }
        private static void HeaderDiv(StringBuilder sb, string reportTitle, DateTime generationDate, string reportSubtitle)
        {
            sb.AppendLine($"        <div class='header'>");
            sb.AppendLine($"            <b>HOLLIDAYSBURG AREA SCHOOL DISTRICT</b><br/>");
            sb.AppendLine($"            <b>{ reportSubtitle.ToUpper() }</b><br/>");
            sb.AppendLine($"            <b>{ reportTitle.ToUpper() }</b><br/>");
            sb.AppendLine($"            { generationDate.ToString("MMM dd, yyyy").ToUpper()}<br/>");
            sb.AppendLine($"        </div>");
        }
        private static void EndOfReportDiv(StringBuilder sb, DateTime generationDate)
        {
            sb.AppendLine($"        <div class='eor'>End of Report { generationDate.ToString("yyyy-MM-dd-HH-mm") }</div>");
        }
        private static void CloseBody(StringBuilder sb)
        {
            sb.AppendLine($"     </body>");
        }
        private static void CloseHTML(StringBuilder sb)
        {
            sb.AppendLine($" </html>");
        }
        private static string LoadStyle(string styleFileName)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            using (StreamReader streamReader = new StreamReader(a.GetManifestResourceStream($"Ccd.Bidding.Manager.Reporting.Resources.Styles.{ styleFileName}")))
            {
                return streamReader.ReadToEnd().Replace(Environment.NewLine, " ").Replace("  ", "").Replace("  ", "").Replace("  ", "");
            }
        }
        #endregion

        #region helper functions
        public static string[] SplitStringToLines(string desc)
        {
            List<string> output = new List<string>();

            List<string> descriptionLines = desc.Split(new string[] { "<br />" }, StringSplitOptions.None).ToList();

            foreach (string line in descriptionLines)
            {
                output.AddRange(SplitToLines(line, 82));
            }

            return output.ToArray();
        }

        private static IEnumerable<string> SplitToLines(string stringToSplit, int maximumLineLength)
        {
            var words = stringToSplit.Split(' ').Concat(new[] { "" });
            return
                words
                    .Skip(1)
                    .Aggregate(
                        words.Take(1).ToList(),
                        (a, w) =>
                        {
                            var last = a.Last();
                            while (last.Length > maximumLineLength)
                            {
                                a[a.Count() - 1] = last.Substring(0, maximumLineLength);
                                last = last.Substring(maximumLineLength);
                                a.Add(last);
                            }
                            var test = last + " " + w;
                            if (test.Length > maximumLineLength)
                            {
                                a.Add(w);
                            }
                            else
                            {
                                a[a.Count() - 1] = test;
                            }
                            return a;
                        });
        }
        #endregion
    }
}
