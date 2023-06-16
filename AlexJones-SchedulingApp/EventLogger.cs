using System;
using System.IO;
using System.Text;
using AlexJones_SchedulingApp.Models;

namespace AlexJones_SchedulingApp
{
    public static class EventLogger {
        private static string filename = "logs.txt";

        public static void LogSuccessfulLogin(User user) {
            LogUnspecifiedEntry($"User Successfully logged in with username \"{user.Username}\".");
        }
        public static void LogUnsuccessfulLogin(string username) {
            LogUnspecifiedEntry($"ERROR: User could not log in with username \"{username}\".");
        }
        public static void LogConnectionIssue() {
            LogUnspecifiedEntry($"ERROR: Could not access database.");
        }
        public static void LogUnspecifiedEntry(string entry) {
            StringBuilder logBuilder = new StringBuilder();
            logBuilder.Append($"{DateTime.Now}: ");
            logBuilder.Append($"{entry}");

            if(entry[entry.Length - 1] != '.') {
                logBuilder.Append('.');
            }

            logBuilder.Append("\r\n");

            EnterLogItem(logBuilder.ToString());
        }

        private static void EnterLogItem(string entry) {
            using(StreamWriter fileWriter = File.AppendText(filename)) {
                fileWriter.Write(entry);
            }
        }
    }
}
