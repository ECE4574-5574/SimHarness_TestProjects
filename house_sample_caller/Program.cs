using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_sample_caller
{
    class Program
    {

        static void Main(string[] args) {
            //this program will receive these from the command line arguments:
            string exe_name = @"D:\bt2016_D\Desktop\house_sample_exe.exe";
            string configBlob = "";
            string timelineBlob = "'time-factor: { wall: “1997-07-16T19:20:30+01:00”, sim: “ISO 8601”, rate: double }'";
            string username = "user1";
            string password = "password";

            //putting the command together
            string exe_args = string.Concat("-e ", "MODE ", "\"SIM\" ",
                                            "-e ", "CONFIG \"", configBlob, "\" ",
                                            "-e ", "TIMELINE \"", timelineBlob, "\" ",
                                            "-e ", "USER \"", username, "\" ",
                                            "-e ", "PASS \"", password, "\" ");

            //declare variables
            ProcessStartInfo p_info = new ProcessStartInfo();
            StreamWriter child_stdin;
            StreamReader child_stdout;
            StreamReader child_stderr;

            //set process settings
            p_info.FileName = exe_name;
            p_info.Arguments = exe_args;
            p_info.UseShellExecute = false;
            p_info.ErrorDialog = false;
            p_info.RedirectStandardError = true;
            p_info.RedirectStandardInput = true;
            p_info.RedirectStandardOutput = true;

            //start the process
            Process p = new Process();
            p.StartInfo = p_info;
            startProcess(ref p, ref p_info);
            child_stdin = p.StandardInput;
            child_stdout = p.StandardOutput;
            child_stderr = p.StandardError;


            while (true) {
                string child_message = child_stdout.ReadLine();
                Console.WriteLine(child_message);
            }

        }//end main



        public static string startProcess(ref Process p, ref ProcessStartInfo ps) {
            string output = "";
            try {
                p = Process.Start(ps);
                output = string.Concat(output, "Process started successfully\n");
            } catch (Exception) {
                output = string.Concat(output, "Unable to start process from location: ");
                output = string.Concat(output, ps.FileName);
                output = string.Concat(output, "\n");
            }
            return output;
        }

        private string killProcess(ref Process p) {
            string output = "";
            try {
                p.Kill();
                output = string.Concat(output, "Process killed successfully\n");
            } catch (Exception ex) {
                output = string.Concat(output, "Exception thrown while trying to kill the process\n");
                output = string.Concat(output, ex.Message);
                output = string.Concat(output, "\n");
            }
            return output;
        }

    } //end program


} //end namespace
