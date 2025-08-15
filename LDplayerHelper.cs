using KAutoHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OtpNet;
using REGFACEBOOKBYLDPLAYER;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ZXing;

namespace RegAccoutFacebookV1
{
    class LDplayerHelper
    {
        public static string pathLD = "";
        static Dictionary<string, object> ldLocks = new Dictionary<string, object>();
        public static bool FindImage(string index, Bitmap LinkIMG, int exitwhile, bool tap = true, bool capx = true, int x = 0, int y = 0)
        {
            int count = 0;
            while (true)
            {
                if (fMain.isStop)
                    return false;
                try
                {
                    var screm = ScreenShoot_Index(index, capx);
                    var ImageCapture = ImageScanOpenCV.FindOutPoint(screm, LinkIMG, 0.9);
                    if (ImageCapture != null)
                    {
                        if (tap == true)
                        {
                            Tap(index, ImageCapture.Value.X + x, ImageCapture.Value.Y + y);
                        }
                        return true;
                    }
                    else
                    {
                        count++;
                        Thread.Sleep(1000);
                        if (count == exitwhile)
                        {
                            return false;
                        }
                    }
                }
                catch (Exception)
                {
                    count++;
                    Thread.Sleep(1000);
                    if (count == exitwhile)
                    {
                        return false;
                    }
                }
            }


        }
        public static bool DumpText(string index, string button, int exitwhile, bool dumx = false, bool tap = true, int x = 0, int y = 0)
        {
            string index_copy = index.Replace(" ", "_");
            int num = 0;
            string linksdcard = "/sdcard/" + index_copy + ".xml";
            string filename = Directory.GetCurrentDirectory() + @"\dump";
            string linkdump = "pull \"" + linksdcard + "\" " + "\"" + filename + "\"";
            while (true)
            {
                if (fMain.isStop)
                    return false;
                if (dumx == false)
                {
                    try
                    {
                        File.Delete("dump/" + index_copy + ".xml");
                    }
                    catch (Exception E)
                    {
                    }
                    string text1 = ExcuteCMD(index, "shell uiautomator dump /sdcard/" + index_copy + ".xml");
                    string text2 = ExcuteCMD(index, linkdump);
                }
                XmlDocument doc = new XmlDocument();
                try
                {
                    string linkxml = "dump/" + index_copy + ".xml";
                    doc.Load(linkxml);
                    XmlNode book;
                    XmlNode root = doc.DocumentElement;

                    book = root.SelectSingleNode("//node[@text=\'" + button + "\']");
                    if (book != null)
                    {
                        string toadonext = book.Attributes["bounds"].Value;
                        toadonext = toadonext.Replace("][", ",").Replace("]", "").Replace("[", "");
                        int toado1 = Int32.Parse(toadonext.Split(',')[0]);
                        int toado2 = Int32.Parse(toadonext.Split(',')[1]);
                        if (tap == true)
                        {
                            Tap(index, toado1 + x, toado2 + y);

                        }
                        return true;
                    }
                    else
                    {
                        Thread.Sleep(1500);
                        num++;
                        if (num == exitwhile)
                        {
                            return false;
                        }
                    }
                }
                catch (Exception E)
                {
                }
            }
        }
        public static bool DumpClass(string index, string button, int exitwhile, bool dumx = false, bool tap = true, int x = 0, int y = 0)
        {
            string index_copy = index.Replace(" ", "_");
            int num = 0;
            string linksdcard = "/sdcard/" + index_copy + ".xml";
            string filename = Directory.GetCurrentDirectory() + @"\dump";
            string linkdump = "pull \"" + linksdcard + "\" " + "\"" + filename + "\"";
            while (true)
            {
                if (fMain.isStop)
                    return false;
                if (dumx == false)
                {
                    try
                    {
                        File.Delete("dump/" + index_copy + ".xml");
                    }
                    catch (Exception E)
                    {
                    }
                    string text1 = ExcuteCMD(index, "shell uiautomator dump /sdcard/" + index_copy + ".xml");
                    string text2 = ExcuteCMD(index, linkdump);
                }
                XmlDocument doc = new XmlDocument();
                try
                {
                    string linkxml = "dump/" + index_copy + ".xml";
                    doc.Load(linkxml);
                    XmlNode book;
                    XmlNode root = doc.DocumentElement;

                    book = root.SelectSingleNode("//node[@class=\'" + button + "\']");
                    if (book != null)
                    {
                        string toadonext = book.Attributes["bounds"].Value;
                        toadonext = toadonext.Replace("][", ",").Replace("]", "").Replace("[", "");
                        int toado1 = Int32.Parse(toadonext.Split(',')[0]);
                        int toado2 = Int32.Parse(toadonext.Split(',')[1]);
                        if (tap == true)
                        {
                            Tap(index, toado1 + x, toado2 + y);

                        }
                        return true;
                    }
                    else
                    {
                        Thread.Sleep(1500);
                        num++;
                        if (num == exitwhile)
                        {
                            return false;
                        }
                    }
                }
                catch (Exception E)
                {
                }
            }
        }
        public static bool DumpContent(string index, string button, int exitwhile, bool dumx = false, bool tap = true, int x = 0, int y = 0)
        {
            string index_copy = index.Replace(" ", "_");
            int num = 0;
            string linksdcard = "/sdcard/" + index_copy + ".xml";
            string filename = Directory.GetCurrentDirectory() + @"\dump";
            string linkdump = "pull \"" + linksdcard + "\" " + "\"" + filename + "\"";
            while (true)
            {
                if (fMain.isStop)
                    return false;
                if (dumx == false)
                {
                    try
                    {
                        File.Delete("dump/" + index_copy + ".xml");
                    }
                    catch (Exception E)
                    {
                    }
                    string text1 = ExcuteCMD(index, "shell uiautomator dump /sdcard/" + index_copy + ".xml");
                    string text2 = ExcuteCMD(index, linkdump);
                }
                XmlDocument doc = new XmlDocument();
                try
                {
                    string linkxml = "dump/" + index_copy + ".xml";
                    doc.Load(linkxml);
                    XmlNode book;
                    XmlNode root = doc.DocumentElement;

                    book = root.SelectSingleNode("//node[@content-desc=\'" + button + "\']");
                    if (book != null)
                    {
                        string toadonext = book.Attributes["bounds"].Value;
                        toadonext = toadonext.Replace("][", ",").Replace("]", "").Replace("[", "");
                        int toado1 = Int32.Parse(toadonext.Split(',')[0]);
                        int toado2 = Int32.Parse(toadonext.Split(',')[1]);
                        if (tap == true)
                        {
                            Tap(index, toado1 + x, toado2 + y);

                        }
                        return true;
                    }
                    else
                    {
                        Thread.Sleep(1500);
                        num++;
                        if (num == exitwhile)
                        {
                            return false;
                        }
                    }
                }
                catch (Exception E)
                {
                }
            }
        }
        public static void KeyEvent(string index, string keyEvent)
        {
            ExcuteCMD(index, "shell input keyevent " + keyEvent);
        }
        public static void Tap(string index, int x, int y)
        {
            string a = "shell input tap " + x + " " + y;
            ExcuteCMD(index, a);
        }
        public static void LongPress(string index, int x, int y, int duration = 100)
        {
            string flag = string.Format("shell input swipe {0} {1} {2} {3}", x, y, x, y, duration);
            ExcuteCMD(index, flag);
        }
        public static void Swipe(string index, int x1, int y1, int x2, int y2, int duration = 100)
        {
            string flag = string.Format("shell input swipe {0} {1} {2} {3} {4}", x1, y1, x2, y2, duration);
            ExcuteCMD(index, flag);
        }
        public static void Input(string index, string text)
        {
            text = text.Replace(" ", "%s").Replace("&", "\\&").Replace("<", "\\<").Replace(">", "\\>").Replace("?", "\\?").Replace(":", "\\:").Replace("{", "\\{").Replace("}", "\\}").Replace("[", "\\[").Replace("]", "\\]").Replace("|", "\\|");
            string a = "shell input text " + "\"" + text + "\"";
            ExcuteCMD(index, a);
        }
        public static void InputUnicode(string index, string textpull)
        {
            string text = Convert.ToBase64String(Encoding.UTF8.GetBytes(textpull));
            ExcuteCMD(index, " shell ime set com.android.adbkeyboard/.AdbIME");
            ExcuteCMD(index, " shell am broadcast -a ADB_INPUT_B64 --es msg " + text);
        }
        public static void ImportContact(string index)
        {
            var phones = File.ReadAllLines("contacts\\phone.txt");
            var namecontacts = File.ReadAllLines("contacts\\namecontacts.txt");
            string index_copy = index.Replace(" ", "_");
            string filename = Directory.GetCurrentDirectory() + "\\" + @"contacts\contact_" + index_copy + ".vcf";
            Random ran = new Random();
            try
            {
                File.Delete(filename);
            }
            catch { }
            string _vcf = "";
            int ranso = new Random().Next(40, 60);
            for (int i = 0; i < ranso; i++)
            {
                string phone = phones[ran.Next(0, phones.Length - 1)];
                string name = namecontacts[ran.Next(0, namecontacts.Length - 1)] + " " + ran.Next();
                _vcf += "BEGIN:VCARD\n";
                _vcf += "VERSION:2.1\n";
                _vcf += "N:;" + name + ";;;\n";
                _vcf += "FN:" + name + "\n";
                _vcf += "TEL;CELL:" + phone + "\n";
                _vcf += "END:VCARD\n";
            }
            File.AppendAllText(filename, _vcf);
            string text;
            string excute = "push \"" + filename + "\" \"/sdcard/Contacts.vcf\"";
            ClearPackage(index, "com.android.providers.contacts");
            text = ExcuteCMD(index, excute);
            text = ExcuteCMD(index, "shell am start -t text/vcard -d file:///sdcard/Contacts.vcf -a android.intent.action.VIEW com.android.contacts");
        }
        public static void PullImg(string index, string path)
        {
            string index_copy = index;
            index_copy = index_copy.Replace(" ", "");
            string img = "screenShoot" + index_copy + ".png";
            ExcuteCMD(index, "shell mount -o rw,remount /");
            Thread.Sleep(200);
            ExcuteCMD(index, "shell rm -rR /sdcard/launcher/ad");
            ExcuteCMD(index, "shell rm -rR /sdcard/DCIM/Foleravt");

            ExcuteCMD(index, "shell am broadcast -a android.intent.action.MEDIA_MOUNTED -d file://sdcard");
            Thread.Sleep(200);

            Thread.Sleep(200);
            ExcuteCMD(index, "shell mkdir /sdcard/DCIM/Foleravt");
            var filters = new String[] { "jpg", "png" };
            String searchFolder = path;
            string[] Img_List = GetFilesFrom(searchFolder, filters, false);
            int rdanh = new Random().Next(1, Img_List.Length);

            //adb--{ 0}
            //--command \"{1}\"", index, cmd
            string fileimg = Directory.GetCurrentDirectory() + "\\" + Img_List[rdanh];
            string cmdCommand = "adb --" + index + " --command \"push \"" + fileimg + "\" \"/sdcard/DCIM/Foleravt\"\"";
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = pathLD,
                Arguments = cmdCommand,
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            process.Start();
            string text = process.StandardOutput.ReadToEnd();
            process.Close();


            Thread.Sleep(200);
            ExcuteCMD(index, "shell am broadcast -a android.intent.action.MEDIA_MOUNTED -d file://sdcard/DCIM");
            Thread.Sleep(200);
        }
        static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }
        public static Bitmap ScreenShoot_Index(string index, bool isDeleteImageAfterCapture = true)
        {
            string index_copy = index;
            index_copy = index_copy.Replace(" ", "");
            string fileName = "screenShoot.png";
            string text = Path.GetFileNameWithoutExtension(fileName) + index_copy + Path.GetExtension(fileName);

            string filename = Directory.GetCurrentDirectory() + "\\" + "dump\\" + text;
            if (isDeleteImageAfterCapture)
            {
                string text3, text4;
                string text2 = Directory.GetCurrentDirectory() + "\\dump";
                string linksdcard = "/sdcard/" + text;
                string cmdCommand = "shell screencap -p /sdcard/" + text;
                string linkdump = "pull \"" + linksdcard + "\" " + "\"" + filename + "\"";
                try
                { File.Delete(text); }
                catch { }
                text3 = ExcuteCMD(index, cmdCommand);
                text4 = ExcuteCMD(index, linkdump);
            }
            Bitmap result = null;
            try
            {
                using (Bitmap bitmap = new Bitmap(filename))
                {
                    result = new Bitmap(bitmap);
                }
            }
            catch
            {
            }

            return result;
        }
        public static void ClearPackage(string index, string package)
        {
            string a = "shell pm clear " + package;
            ExcuteCMD(index, a);
        }
        public static void OpenPackage(string index, string package)
        {
            string a = "shell monkey -p " + package + " -c android.intent.category.LAUNCHER 1";
            ExcuteCMD(index, a);
        }
        public static void ForcePackage(string index, string package)
        {
            string a = "shell am force-stop " + package;
            ExcuteCMD(index, a);
        }
        public static void UninstallPackage(string index, string package)
        {
            string a = "uninstall " + package;
            ExcuteCMD(index, a);
        }
        public static string InstallAPK(string index, string pathAPK)
        {
            return ExecuteLD_Result("installapp --" + index + " --filename " + pathAPK);
        }
        public static bool WaitUntilUninstalled(string index, string packageName, int timeoutSeconds = 30)
        {
            int waited = 0;
            while (waited < timeoutSeconds)
            {
                string result = ExcuteCMD(index, $"shell pm list packages {packageName}");
                if (!result.Contains(packageName))
                    return true;

                Thread.Sleep(1000);
                waited++;
            }
            return false;
        }
        public static bool WaitUntilInstalled(string index, string packageName)
        {
            for (int i = 0; i < 10; i++)
            {
                string result = ExcuteCMD(index, $"shell monkey -p {packageName} -c android.intent.category.LAUNCHER 1");
                if (!result.ToLower().Contains("error"))
                    return true;

                Thread.Sleep(1000); 
            }
            return false;
        }
        public static void GrantAllPermissions(string ldName, string packageName)
        {
            lock (GetLDLock(ldName))
            {
                string[] permissions = {
            "android.permission.READ_CONTACTS",
            "android.permission.WRITE_CONTACTS",
            "android.permission.CAMERA",
            "android.permission.RECORD_AUDIO",
            "android.permission.ACCESS_FINE_LOCATION",
            "android.permission.ACCESS_COARSE_LOCATION",
            "android.permission.READ_PHONE_STATE",
            "android.permission.READ_EXTERNAL_STORAGE",
            "android.permission.WRITE_EXTERNAL_STORAGE"
        };

                foreach (string permission in permissions)
                {
                    try
                    {
                        string cmd = $"shell pm grant {packageName} {permission}";
                        LDplayerHelper.ExcuteCMD(ldName, cmd);
                        Thread.Sleep(300);
                    }
                    catch { }
                }
            }
        }
        private static object GetLDLock(string ldName)
        {
            lock (ldLocks)
            {
                if (!ldLocks.ContainsKey(ldName))
                    ldLocks[ldName] = new object();
                return ldLocks[ldName];
            }
        }
        public static JToken GetInfodevice(string path)
        {
            Random ran = new Random();
            string str_json = File.ReadAllText(path);
            JToken res = JToken.Parse(str_json);
            JToken rs = res[ran.Next(0, res.Count() - 1)];
            JToken rs1 = rs["manufacturer"];
            JToken rs2 = rs["models"];
            JToken rs3 = rs2[ran.Next(0, rs2.Count() - 1)];
            return rs1 + "|" + rs3;
        }
        public static void ChangeInfoLD(string index, int width, int height, int dpi, bool addphone, string adbport)
        {
            Random ran = new Random();
            string[] phone_list = {
        "086", "096", "097", "098", "032", "033", "034", "035", "036", "037", "038", "039"
             };
            string phonenumber = phone_list[ran.Next(phone_list.Length)] + ran.Next(1000000, 9999999).ToString("D7");
            string path = AppDomain.CurrentDomain.BaseDirectory +@"DATA\deviceinfo.json";
            string str_json = File.ReadAllText(path);
            JToken res = JToken.Parse(str_json);
            JToken rs = res[ran.Next(0, res.Count())];
            JToken rs1 = rs["manufacturer"];
            JToken rs2 = rs["models"];
            JToken rs3 = rs2[ran.Next(0, rs2.Count())];
            string cmd = $"modify --{index} --imei auto --imsi auto --simserial auto --androidid auto --cpu 2 --memory 2048 --resolution {width},{height},{dpi} --manufacturer {rs1} --model \"{rs3}\"";
            if (adbport != "")
            {
                cmd += $" --adbport {adbport}";
            }
            if (addphone)
            {
                cmd += $" --pnumber {phonenumber}";
            }
            ExecuteLDP(cmd);
        }
        public static void OpenLDP(string index)
        {
            ExecuteLDP(string.Format("launch --{0}", index));
        }
        public static void CloseLDP(string index)
        {
            ExecuteLDP(string.Format("quit  --{0}", index));
        }       
        public static void CloseAllLDP()
        {
            ExecuteLDP("quitall");
        }
        public static string CheckLDRunning(string index)
        {
            Thread.Sleep(3000);
            string cmdCommand = string.Format("adb --{0} --command \"{1}\"", index, "shell input tap 0 0");
            string result;
            int num = 0;
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = pathLD,
                Arguments = cmdCommand,
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            while (true)
            {
                process.Start();
                process.WaitForExit(3000);
                string text = process.StandardOutput.ReadToEnd();
                result = text;
                if (result == "")
                {
                    return "0";
                }
                else
                {
                    Thread.Sleep(3000);
                    num++;
                    if (num == 20)
                    {
                        return null;
                    }
                }
            }
        }
        public static void SortWnd()
        {
            ExecuteLD("sortWnd");
        }
        public static void ExecuteLD(string cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = pathLD;
            p.StartInfo.Arguments = cmd;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.EnableRaisingEvents = true;
            p.Start();
            p.WaitForExit();
            p.Close();
        }
        public static string Run(string cmdCommand, string pathLDNotRun, int timeout = 0, bool resultreturn = true)
        {
            string result;
            try
            {
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = pathLDNotRun,
                    FileName = "cmd.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    Verb = "runas"
                };
                process.Start();
                process.StandardInput.WriteLine(cmdCommand);
                process.StandardInput.Flush();
                process.WaitForExit(timeout);
                if(resultreturn)
                {
                    string text = process.StandardOutput.ReadToEnd();
                    result = text;
                }
                else
                {
                    result = "";
                }
                   
            }
            catch
            {
                result = null;
            }
            return result;
        }
        public static string Pull(string index, string path1, string path2)
        {
            return ExcuteCMD(index, "pull \"" + path1 + "\" " + "\"" + path2 + "\"");
        }
        public static string PullSU(string index, string androidPath, string pcSavePath)
        {
            string adbExe = "D:\\LD\\LDPlayer\\LDPlayer9\\adb.exe";
            // Lấy tên file từ path
            string fileNameOnly = androidPath.Split('/').Last();
            string tempPath = "/sdcard/" + fileNameOnly;

            // Bước 1: su -c để copy file từ /data/data ra sdcard
            string copyCmd = $"shell su -c \"cp {androidPath} {tempPath}\"";
            RunProcess(adbExe, copyCmd);

            // Bước 2: adb pull file từ sdcard về PC
            string pullCmd = $"pull {tempPath} \"{pcSavePath}\"";
            RunProcess(adbExe, pullCmd);

            // Bước 3: (Tuỳ chọn) xóa file tạm trên sdcard
            string cleanupCmd = $"shell su -c \"rm {tempPath}\"";
            RunProcess(adbExe, cleanupCmd);

            return $"Pulled to {pcSavePath}";
        }

        static string GetCookie_Token(string data)
        {
            string cookie = "", token = "";

            try
            {
                int startIdx = data.IndexOf("EAA");
                if (startIdx != -1)
                {
                    int endIdx = data.IndexOf("ZD", startIdx);
                    if (endIdx != -1)
                    {
                        token = data.Substring(startIdx, endIdx - startIdx + 2);
                    }
                }

                startIdx = data.IndexOf("[{");
                if (startIdx != -1)
                {
                    int endIdx = data.IndexOf("}]", startIdx);
                    if (endIdx != -1)
                    {
                        string jsonText = data.Substring(startIdx, endIdx - startIdx + 2); 

                        try
                        {
                            dynamic items = JsonConvert.DeserializeObject(jsonText);
                            foreach (var item in items)
                            {
                                if (cookie != "") cookie += ";";
                                cookie += item.name + "=" + item.value;
                            }
                        }
                        catch {  }
                    }
                }

                if (cookie == "")
                {
                    string c_user = Regex.Match(data, @"c_user=\d+").Value;
                    string xs = Regex.Match(data, @"xs=.+?(?=;)").Value;
                    if (c_user != "" && xs != "") cookie = c_user + ";" + xs;
                }
            }
            catch { }

            return cookie + "|" + token;
        }

        public static string Get2FA(string Key_2FA)
        {
            Key_2FA = Key_2FA.Replace(" ", "");
            var base32Bytes = OtpNet.Base32Encoding.ToBytes(Key_2FA);
            var totp = new Totp(base32Bytes);
            var twoFactorCode = totp.ComputeTotp();
            return twoFactorCode;
        }
        public static string GetTextRan(int looop = 25)
        {
            Random ran = new Random();
            string result = "";
            string textrandom = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            for (int loop = 0; loop < looop; loop++)
            {
                result += textrandom[ran.Next(textrandom.Length - 1)];
            }
            return result;
        }
        public static string GetCookieLite(string index_copy)
        {
            string index = index_copy.Replace(" ", "");
            string linkcookie = @"\dump\" + "cookie_" + index + ".txt";
            try
            {
                File.Delete(linkcookie);
            }
            catch { };
            string flag = Directory.GetCurrentDirectory() + linkcookie;
            //string excute1 = "pull \"/data/data/com.facebook.katana/app_light_prefs/com.facebook.katana/authentication\" \"" + flag + "\"";
            string text = Pull(index_copy, "/data/data/com.facebook.lite/files/PropertiesStore_v02", flag);
            string data = File.ReadAllText(flag);
            string token, cookie;
            string token_cookie;
            token_cookie = GetCookie_Token(data);
            cookie = token_cookie.Split('|')[0];
            token = token_cookie.Split('|')[1];
            string cat = Regex.Match(cookie, "(c_user=)[0-9]{0,}").ToString();
            string UID = Regex.Match(cat, "[0-9]{0,}$").ToString();
            return cookie + "|" + token + "|" + UID;
        }
        public static string GetCookieKatana(string index_copy)
        {
            string index = index_copy.Replace(" ", "");
            string linkcookie = @"\dump\" + "cookie_" + index + ".txt";
            try
            {

                File.Delete(linkcookie);
            }
            catch { }
            string flag = Directory.GetCurrentDirectory() + linkcookie;
            string text = Pull(index_copy, "/data/data/com.facebook.katana/app_light_prefs/com.facebook.katana/authentication", flag);
            string data = File.ReadAllText(flag);
            string token, cookie;
            string token_cookie;
            token_cookie = GetCookie_Token(data);
            cookie = token_cookie.Split('|')[0];
            token = token_cookie.Split('|')[1];
            string cat = Regex.Match(cookie, "(c_user=)[0-9]{0,}").ToString();
            string UID = Regex.Match(cat, "[0-9]{0,}$").ToString();
            return cookie + "|" + token + "|" + UID;
        }

        public static string GetTokenMess(string index_copy)
        {
            string token = ExcuteCMD(index_copy, "shell su -c 'grep -i token /data/data/com.facebook.orca/shared_prefs/*.xml'");
            token = Regex.Match(token, "<string name=\"auth_token\">([^<]+)</string>").Groups[1].Value;
            Console.WriteLine("Token: " + token);
            return token;
        }

        public static string GetUIDFromToken(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://graph.facebook.com/me?access_token={token}";
                var res = client.GetStringAsync(url).Result;
                dynamic json = JsonConvert.DeserializeObject(res);
                return json.id.ToString();
            }
        }
        public static string DelelteLDPlayer(string index)
        {
            return ExecuteLD_Result("remove --" + index);
        }
        public static void CreateLDPlayer()
        {
            ExecuteLDP("add --name VMDungV_1");
            Thread.Sleep(2000);
            //ExecuteLDP("dnconsole.exe modify --index 0 --resolution 540,960,240 --cpu 2 --memory 2048 --imei auto --mac auto");

        }
        public static void CopyLDPlayer(string nameLD)
        {
            ExecuteLDP("copy --name " + nameLD + " --from VMDungV_1");
        }
        public static string ExcuteCMD(string index, string cmd)
        {
            return ExecuteLD_Result(string.Format("adb --{0} --command \"{1}\"", index, cmd));
        }
        public static string ExecuteLD_Result1(string index, string command, int timeout = 0)
        {
            string result;
            try
            {
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = pathLD,
                    Arguments = string.Format("adb --{0} --command \"{1}\"", index, command),
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };
                process.Start();
                if(timeout > 0)
                {
                    process.WaitForExit(timeout);
                }
                else
                    process.WaitForExit();

                string text = process.StandardOutput.ReadToEnd();
                result = text;
                process.Close();

            }
            catch
            {
                result = null;
            }
            return result;
        }
        public static string GetData()
        {
            Random random = new Random();
            string[] ho_file = File.ReadAllLines(@"DATA\name\Ho.txt");
            string ho = ho_file[random.Next(ho_file.Length)];
            string[] name_file = File.ReadAllLines(@"DATA\name\Ten.txt");
            string ten = name_file[random.Next(name_file.Length)];
            string[] randompass = { "F2", "6X4", "B", "D", "706", " 2J5", "37@", "956", "72", "431", "674", "36", "207", "F", "144", "544", "91", "15", "10", "00", "49" };

            string pass = "";
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@-_";

            for (int i = 0; i < random.Next(10, 20); i++)
            {
                pass += chars[random.Next(chars.Length)];
            }
            return ho + "|" + ten + "|" + pass;
        }
        public static string ExecuteLD_Result(string cmdCommand)
        {
            string result;
            try
            {
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = pathLD,
                    Arguments = cmdCommand,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };
                process.Start();
                process.WaitForExit(10000);
                string text = process.StandardOutput.ReadToEnd();
                result = text;
                process.Close();
            }
            catch
            {
                result = null;
            }
            return result;
        }
        public static void ExecuteLDP(string cmd)
        {
            Process p = new Process();
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = pathLD,
                Arguments = cmd,
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
            };
            process.Start();
            process.WaitForExit();
            process.Close();
        }

        private static string RunProcess(string fileName, string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit(10000);

                return output + error;
            }
        }
        public static void BackupApp(string index, string namebackup, string package)
        {
            ForcePackage(index, package);
            string filename = Directory.GetCurrentDirectory() + @"\DATA\Backup";
            string uidtg = namebackup + ".tar.gz";
            string text;
            text = ExcuteCMD(index, "shell mount -o rw,remount /");
            text = ExecuteLD_Result1(index, "shell tar -C /data/data/com.facebook.katana/ -cvzf /data/" + uidtg + " shared_prefs app_bookmarks_cache app_light_prefs databases cache", 5000);
            Thread.Sleep(1000);
            try { File.Delete("DATA/ConfigDevice/" + namebackup + ".config"); } catch { }
            try { File.Delete("DATA/Backup/" + namebackup + ".tar.gz"); } catch { }
            text = ExcuteCMD(index, "pull /data/" + uidtg + " " + filename);
            JObject jObject = new JObject();
            string ledian = "leidian" + Regex.Match(index, @"\d{1}").ToString() + ".config";
            JObject jObject1 = JObject.Parse(File.ReadAllText(REGFACEBOOKBYLDPLAYER.Properties.Settings.Default.txtpathLD + "/vms/config/" + ledian));
            jObject["IMEI"] = jObject1["propertySettings.phoneIMEI"];
            jObject["IMSI"] = jObject1["propertySettings.phoneIMSI"];
            jObject["SimSerial"] = jObject1["propertySettings.phoneSimSerial"];
            jObject["AndroidId"] = jObject1["propertySettings.phoneAndroidId"];
            jObject["Model"] = jObject1["propertySettings.phoneModel"];
            jObject["Manufacturer"] = jObject1["propertySettings.phoneManufacturer"];
            jObject["MacAddress"] = jObject1["propertySettings.macAddress"];
            jObject["PhoneNumber"] = jObject1["propertySettings.phoneNumber"];
            File.WriteAllText(@"DATA\ConfigDevice\" + filename + ".config", jObject.ToString());
        }
        public static void RestoreApp(string index, string namebackup, string package)
        {
            string backupFile = Path.Combine(Directory.GetCurrentDirectory(), @"DATA\Backup\" + namebackup + ".tar.gz");
            string ldID = Regex.Match(index, @"\d+").Value;
            if (!File.Exists(backupFile))
            {
                MessageBox.Show("Không tìm thấy file backup: " + namebackup + ".tar.gz", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ExcuteCMD(index, "shell su -c 'mount -o rw,remount /'");
            ExcuteCMD(index, "shell su -c 'mount -o rw,remount /data'");
            ExcuteCMD(index, $"push \"{backupFile}\" /data/{namebackup}.tar.gz");
            ExcuteCMD(index, "shell su -c 'rm -rf /data/data/com.facebook.katana'");
            ExcuteCMD(index, "shell su -c 'mkdir -p /data/data/com.facebook.katana'");
            ExcuteCMD(index, "shell su -c 'chmod 777 /data/data/com.facebook.katana'");
            ExcuteCMD(index, $"shell su -c 'tar -C /data/data/com.facebook.katana/ -xvzf /data/{namebackup}.tar.gz'");
            ExcuteCMD(index, "shell su -c 'chmod -R 777 /data/data/com.facebook.katana'");
            ExcuteCMD(index, $"shell su -c 'rm /data/{namebackup}.tar.gz'");
            string configPath = $"DATA\\ConfigDevice\\{namebackup}.config";
            if (File.Exists(configPath))
            {
                JObject jObject = JObject.Parse(File.ReadAllText(configPath));
                string ledian = $"leidian{ldID}.config";
                string vmConfigPath = Path.Combine(REGFACEBOOKBYLDPLAYER.Properties.Settings.Default.txtpathLD, "vms/config", ledian);

                JObject vmJson = JObject.Parse(File.ReadAllText(vmConfigPath));
                vmJson["propertySettings.phoneIMEI"] = jObject["IMEI"];
                vmJson["propertySettings.phoneIMSI"] = jObject["IMSI"];
                vmJson["propertySettings.phoneSimSerial"] = jObject["SimSerial"];
                vmJson["propertySettings.phoneAndroidId"] = jObject["AndroidId"];
                vmJson["propertySettings.phoneModel"] = jObject["Model"];
                vmJson["propertySettings.phoneManufacturer"] = jObject["Manufacturer"];
                vmJson["propertySettings.macAddress"] = jObject["MacAddress"];
                vmJson["propertySettings.phoneNumber"] = jObject["PhoneNumber"];

                File.WriteAllText(vmConfigPath, vmJson.ToString());
            }
            ExcuteCMD(index, $"shell am force-stop {package}");
            ExcuteCMD(index, $"shell monkey -p {package} -c android.intent.category.LAUNCHER 1");
        }
        public static int GetAdbPortFromIndex(int index)
        {
            try
            {
                string adbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "adb.exe");
                var startInfo = new ProcessStartInfo
                {
                    FileName = adbPath,
                    Arguments = "devices",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    var emulatorPorts = new List<int>();
                    var ipPorts = new HashSet<int>();

                    var lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("127.0.0.1:"))
                        {
                            var match = Regex.Match(line, @"127\.0\.0\.1:(\d+)");
                            if (match.Success)
                            {
                                int port = int.Parse(match.Groups[1].Value);
                                ipPorts.Add(port);
                            }
                        }
                        else if (line.StartsWith("emulator-"))
                        {
                            var match = Regex.Match(line, @"emulator-(\d+)");
                            if (match.Success)
                            {
                                int port = int.Parse(match.Groups[1].Value);
                                if (!ipPorts.Contains(port))
                                {
                                    emulatorPorts.Add(port);
                                }
                            }
                        }
                    }

                    if (ipPorts.Count == 0 && emulatorPorts.Count == 0)
                    {
                        foreach (var line in lines)
                        {
                            var match = Regex.Match(line, @"emulator-(\d+)");
                            if (match.Success)
                            {
                                int port = int.Parse(match.Groups[1].Value);
                                emulatorPorts.Add(port);
                            }
                        }
                    }

                    emulatorPorts.Sort();

                    if (index < 1 || index > emulatorPorts.Count)
                    {
                        return 0;
                    }

                    int selectedPort = emulatorPorts[index - 1];
                    return selectedPort + 1;
                }
            }
            catch
            {
                return 0;
            }
        }
        public static string RunCMD(string link)
        {
            Process cmdProcess;
            cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = link;
            cmdProcess.StartInfo.Arguments = "list2";
            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            try
            {
                cmdProcess.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Đường dẫn LDPlayer sai");
                return "";
            }
            string output = cmdProcess.StandardOutput.ReadToEnd();
            cmdProcess.WaitForExit();
            if (string.IsNullOrEmpty(output))
            {
                return "";
            }
            File.WriteAllText("ldcount.txt", output);
            return output;
        }
        public static string Get2FaCodeFromDump(string index, int exitWhile = 5)
        {
            string index_copy = index.Replace(" ", "_");
            string fileName = $"dump/{index_copy}.xml";
            string remotePath = $"/sdcard/{index_copy}.xml";
            string pullCommand = $"pull \"{remotePath}\" \"dump\"";
            int retryCount = 0;

            while (retryCount < exitWhile)
            {
                if (fMain.isStop) return null;

                try
                {
                    if (File.Exists(fileName))
                        File.Delete(fileName);

                    ExcuteCMD(index, $"shell uiautomator dump {remotePath}");
                    ExcuteCMD(index, pullCommand);

                    XmlDocument doc = new XmlDocument();
                    doc.Load(fileName);
                    XmlNodeList nodes = doc.SelectNodes("//node[@text]");
                    foreach (XmlNode node in nodes)
                    {
                        string text = node.Attributes["text"]?.Value ?? "";
                        if (!string.IsNullOrWhiteSpace(text))
                        {
                            var match = Regex.Match(text, @"([A-Z0-9]{4,}\s){6,}[A-Z0-9]{4,}");
                            if (match.Success)
                            {
                                return match.Value.Trim();
                            }
                        }
                    }
                }
                catch
                {
                }
                retryCount++;
                Thread.Sleep(1000);
            }
            return null;
        }
        public static string AIQRCode(string index)
        {
            string result = "";
            for (int i = 0;i <10 ;i++ )
            {
                var Sceen = ScreenShoot_Index(index, true);
                try
                {
                    var QRCreader = new BarcodeReader();
                    var QRresult = QRCreader.Decode(new Bitmap(Sceen));
                    if (QRresult != null)
                    {
                        result = QRresult.Text.Split('=')[1].Split('&')[0];/*QRresult.Text;*/
                        if (result != "" || result != null)
                            break;
                    }
                    else
                        Thread.Sleep(2000);
                }
                catch { }
            }
            return result;
        }
        public static bool IsFacebookAccountLive(string accessToken)
        {
            using (var client = new HttpClient())
            {
                var url = $"https://graph.facebook.com/me?access_token={accessToken}";
                var response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync().Result;

                return !content.Contains("\"error\"");
            }
        }

        public static void CreateAdbInstances(int numberOfLD)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string sourceAdbFolder = Path.Combine(basePath, "platform_tools");
            string[] filesToCopy = new[] { "adb.exe", "AdbWinApi.dll", "AdbWinUsbApi.dll" };

            for (int i = 1; i <= numberOfLD; i++)
            {
                string destFolder = Path.Combine(basePath, $"AdbFile/adb{i}");

                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);

                foreach (string fileName in filesToCopy)
                {
                    string srcFile = Path.Combine(sourceAdbFolder, fileName);
                    string destFile = Path.Combine(destFolder, fileName);

                    try
                    {
                        File.Copy(srcFile, destFile, true);
                        Console.WriteLine($"✅ Đã tạo {destFile}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Lỗi khi copy {fileName} vào adb{i}: {ex.Message}");
                    }
                }
            }
        }

    }
}
