using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using SimpleProjectStopwatch.Models;

namespace SimpleProjectStopwatch.Helper
{
    internal class EmailSender
    {
        public static string GenerateHtmlTable<T>(IEnumerable<T> items, string tableTitle = "Datenübersicht")
            {
                if (items == null || !items.Any())
                    return "<p>Keine Daten verfügbar.</p>";

                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                var sb = new StringBuilder();
                sb.AppendLine("<style>");
                sb.AppendLine("table { border-collapse: collapse; width: 100%; font-family: Arial; }");
                sb.AppendLine("th, td { border: 1px solid #ccc; padding: 8px; text-align: left; }");
                sb.AppendLine("th { background-color: #f2f2f2; }");
                sb.AppendLine("tr:nth-child(even) { background-color: #f9f9f9; }");
                sb.AppendLine("</style>");

                sb.AppendLine($"<h2>{tableTitle}</h2>");
                sb.AppendLine("<table>");
                sb.AppendLine("<thead><tr>");

                foreach (var prop in properties)
                {
                    sb.AppendLine($"<th>{prop.Name}</th>");
                }

                sb.AppendLine("</tr></thead>");
                sb.AppendLine("<tbody>");

                foreach (var item in items)
                {
                    sb.AppendLine("<tr>");
                    foreach (var prop in properties)
                    {
                        var value = prop.GetValue(item, null)?.ToString() ?? "";
                        sb.AppendLine($"<td>{System.Net.WebUtility.HtmlEncode(value)}</td>");
                    }
                    sb.AppendLine("</tr>");
                }

                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");

                return sb.ToString();
            }
        public static void Send(IEnumerable<Project> daten)
        {
            string htmlBody = GenerateHtmlTable(daten, "Teamübersicht");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("JLionSoft SimpleProjectStopwatch", "noreply@l-en.de.de"));
            message.To.Add(new MailboxAddress("JLionSoft DataCollector", "development@l-en.de"));
            message.Subject = "HTML-Tabelle in E-Mail";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlBody
            };
            message.Body = bodyBuilder.ToMessageBody();
        }
        public static void SendEmail(MimeMessage email)
        {
            using var client = new SmtpClient();
            client.Connect("smtp.goneo.de", 587, false);
            client.Authenticate("development@l-en.de", "1Kor6,12");
            client.Send(email);
            client.Disconnect(true);
        }
    }
}
