LDplayerHelper

LDplayerHelper là một helper class mạnh mẽ được viết bằng C#, hỗ trợ thao tác toàn diện với LDPlayer Emulator thông qua ADB.
Thư viện này giúp lập trình viên dễ dàng quản lý nhiều phiên bản LDPlayer cùng lúc, tự động hóa thao tác, và tích hợp vào ứng dụng của mình.

✨ Tính năng chính

Khởi chạy LDPlayer theo index

Thay đổi độ phân giải và DPI

Dump UI text hoặc content qua ADB

Tìm kiếm và tương tác bằng nhận diện hình ảnh

Cài đặt hoặc mở ứng dụng theo package name

Hỗ trợ điều khiển đa luồng

Tự động kết nối lại ADB qua IP:Port

🧪 Ví dụ sử dụng (Demo)
int totalLD = 1; 
bool checkDump = false;
int multiThread = Convert.ToInt32(nThread.Value) + 1;

// Tạo danh sách index cho các luồng
for (int i = 1; i < multiThread; i++)
{
    list_index.Add("index " + i);
}

// Khởi tạo LDPlayer
LDplayerHelper.RunCMD(link);

string[] ldcount = File.ReadAllLines("ldcount.txt");
if (multiThread > ldcount.Length)
{
    MessageBox.Show("Vui lòng thiết lập số luồng tương ứng với LDPlayer hiện có");
    return;
}

// Danh sách LD cần xử lý
List<string> ldIndexes = Enumerable.Range(1, totalLD).Select(x => $"index {x}").ToList();

foreach (var ld in ldIndexes)
{
    string ldConsolePath = Path.Combine(txtpathLD.Text, "ldconsole.exe");

    // Gán đường dẫn LDPlayer
    LDplayerHelper.pathLD = ldConsolePath;

    // Khởi động và cấu hình
    LDplayerHelper.RunCMD(ldConsolePath);
    LDplayerHelper.ChangeInfoLD(ld, 540, 960, 240, false);
    LDplayerHelper.OpenLDP(ld);
    LDplayerHelper.SortWnd();
}

// Dump text hoặc content
checkDump = LDplayerHelper.DumpText(ldName, "Now Accepts IP/Domain", 5);
if (!checkDump) return;

// Tìm và tương tác bằng hình ảnh
checkDump = LDplayerHelper.FindImage(ldName, Resources.portproxy, 5);
if (checkDump) return;

// Mở ứng dụng theo package
LDplayerHelper.OpenPackage(ld, namepackage);

// Kết nối lại ADB qua IP:Port (serial có thể giúp bạn reconnect lại adb sau khi change ip trong ld hoặc ngoài pc - như vậy bạn có thể xài bất cứ ld nào mà không sợ dis connect hoặc không tìm thấy thiết bị)
int adbPort = LDplayerHelper.GetAdbPortFromIndex(thisLDIndex);
if (adbPort == 0)
{
   adbPort = 5555 + thisLDIndex * 2;
}
string serial = $"127.0.0.1:{adbPort}";
ADBServer.ConnectByIP_PORT(serial); // adb connect 127.0.0.1:adbPort

☕ Hỗ trợ phát triển

Nếu bạn thấy LDplayerHelper hữu ích, hãy ủng hộ để mình có thêm động lực chia sẻ nhiều tính năng hay hơn:

Paypal: dvshopxyz@gmail.com

Vietinbank: 107872393669

Momo: 0934182398
