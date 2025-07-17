# LDplayerHelper

A powerful C# helper class that provides full control over **LDPlayer emulators** via ADB.  
This includes launching instances, resizing windows, executing commands, dumping UI text, interacting by image detection, and more.

---

## 🧩 Key Features

- ✅ Launch LDPlayer instance by index
- ✅ Change resolution and DPI
- ✅ Dump UI text or content using ADB
- ✅ Image recognition via resource-matching
- ✅ Open APK packages via command
- ✅ Multi-threaded LDPlayer control support

---

## 🧪 Sample Usage (Demo)

```csharp
int totalLD = 1; 
bool checkdump = false;
int multiThread = Convert.ToInt32(nThread.Value) + 1;

// Tạo danh sách index tương ứng với số luồng
for (int i = 1; i < multiThread; i++)
{
    list_index.Add("index " + i);
}

// Chạy lệnh khởi tạo LDPlayer
LDplayerHelper.RunCMD(link);

string[] ldcount = File.ReadAllLines("ldcount.txt");
if (multiThread > ldcount.Length)
{
    MessageBox.Show("Vui lòng setup số luồng tương ứng với LD hiện có");
    return;
}

// Tạo danh sách LD cần xử lý
List<string> ldIndexes = Enumerable.Range(1, totalLD).Select(x => $"index {x}").ToList();

foreach (var ld in ldIndexes)
{
    string ldConsolePath = Path.Combine(txtpathLD.Text, "ldconsole.exe");

    // Gán đường dẫn LDPlayer
    LDplayerHelper.pathLD = ldConsolePath;

    // Khởi động LD và cấu hình cửa sổ
    LDplayerHelper.RunCMD(ldConsolePath);
    LDplayerHelper.ChangeInfoLD(ld, 540, 960, 240, false);
    LDplayerHelper.OpenLDP(ld);
    LDplayerHelper.SortWnd();
}

// Dump text hoặc content để kiểm tra
checkdump = LDplayerHelper.DumpText(ldName, "Now Accepts IP/Domain", 5);
if (!checkdump) return;

// Tìm và tương tác bằng hình ảnh trong Resources
checkdump = LDplayerHelper.FindImage(ldName, Resources.portproxy, 5);
if (checkdump)
{
    return;
}

// Mở ứng dụng theo tên gói
LDplayerHelper.OpenPackage(ld, namepackage);
